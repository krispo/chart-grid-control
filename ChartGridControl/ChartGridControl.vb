Public Class ChartGridControl

    Public IsEmptyControl As Boolean = True
    Public Date_detail As EDateInterval
    Private CalendStop As Boolean

    Public Enum EDateInterval
        Hour = 0
        Day = 1
        WeekOfYear = 2
        Month = 3
        Year = 4
    End Enum

    ' ---
    Public SeriesList As New List(Of CSeries)               ' A set of series objects

    Public Date_first As Date
    Public Date_last As Date

    ' --- Operation buffer
    Public OpBuffer As New COperationBuffer()

    Private FormatStr As String() = {"dd.MM.yyyy; HH", "dd.MM.yyyy", "dd.MM.yyyy", "MM.yyyy", "yyyy"}
    Private old_val As Double?

    Private MouseX, MouseY As Integer
    Private forceToolTipNotDisplay As Boolean = False

    Public WithEvents myPane As GraphPane

    Private ShowCellCheckState As CheckState = CheckState.Unchecked

    Dim dimention As Integer = 0
    Dim Dates_str() As String

    Public Structure ZedgraphCurve
        Public List As PointPairList
        Public Curve As LineItem
    End Structure

    Private Structure CurvePar
        Public L_CanMove As Boolean
        Public Series As CSeries
        Public ColumnID As Integer
        Public InternalID As Byte

        Public ReadOnly Property RowID As Integer
            Get
                Return Series.ShiftFromObjectTopCases()
            End Get
        End Property
    End Structure

    Private RangeForDateInterval() As Integer = {1200, 500, 400, 400, 400} ' hour, day, week, month, year

    Public Curves As New List(Of ZedgraphCurve)

    Private wf As New WaitF

    ' --- Delegates
    Public Delegate Sub AddColumnDelegate(ByVal s1 As String, ByVal s2 As String)
    Public Delegate Sub InsertRowDelegate(ByVal rowIndex As Integer, ByVal count As Integer)
    Public Delegate Sub AddTextDelegate(ByVal s As String)
    Public Delegate Sub WaitFDelegate()

    ' --- Constructor
    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        'InitializeGraph()
        'ZG1.Invalidate()
    End Sub

    ' ==== DATAGRID
    ' --- Expand limits(how many to up, how many to down)
    Public Sub ExpandRows(ByVal top As Integer, ByVal bottom As Integer)

        Dim cnt As Integer

        If top > 0 Then
            Dim InsertRow As New InsertRowDelegate(AddressOf Me.DGV1.Rows.Insert)
            Me.DGV1.Invoke(InsertRow, New Object() {0, top})

            For cnt = 1 To top
                DGV1.Item(0, cnt - 1).Value = Dates(cnt - 1).ToString(FormatStr(Date_detail)) ' CurDate
            Next
        End If

        If bottom > 0 Then
            Dim old_numberOfRows As Integer = DGV1.RowCount
            Dim new_numberOfRows As Integer = NumberOfCases
            Me.DGV1.Invoke(Sub() Me.DGV1.RowCount = new_numberOfRows)
            For cnt = 1 To bottom
                Me.DGV1.Item(0, old_numberOfRows + cnt - 1).Value = Dates(old_numberOfRows + cnt - 1).ToString(FormatStr(Date_detail))
            Next
        End If
    End Sub

    ' ---- manual correction of series, syncronization
    Private Sub DGV1_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DGV1.CellBeginEdit
        If ((e.RowIndex) < Curves(e.ColumnIndex - 1).Curve.Tag.RowID) Or ((e.RowIndex) > Curves(e.ColumnIndex - 1).Curve.Tag.RowID + Curves(e.ColumnIndex - 1).Curve.Tag.Series.NumberOfCases - 1) Or (Not Curves(e.ColumnIndex - 1).Curve.Tag.L_CanMove) Then
            e.Cancel = True
            Exit Sub
        End If
        'DGV1.Item(e.ColumnIndex, e.RowIndex).Style.Format = "F2"
        If IsNothing(DGV1.Item(e.ColumnIndex, e.RowIndex).Value) Then
            old_val = Nothing
        Else
            old_val = CDbl(DGV1.Item(e.ColumnIndex, e.RowIndex).Value)
        End If
    End Sub

    ' --- cell editing (manual)
    Private Sub DGV1_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellEndEdit
        Dim new_val As Double?
        Dim ok As Boolean = True
        If IsNothing(DGV1.Item(e.ColumnIndex, e.RowIndex).Value) Then
            new_val = Nothing
        Else
            Try
                new_val = CDbl(DGV1.Item(e.ColumnIndex, e.RowIndex).Value)
            Catch ex As Exception
                MessageBox.Show(ParentForm, "Input error!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                DGV1.Item(e.ColumnIndex, e.RowIndex).Value = old_val
                ok = False
                Exit Sub
            End Try
        End If
        

        'DGV1.Item(e.ColumnIndex, e.RowIndex).Style.Format = "F2"

        For i = 0 To Curves.Count - 1
            If Curves(i).Curve.Tag.ColumnID = e.ColumnIndex Then
                Curves(i).List.Item(e.RowIndex - Curves(i).Curve.Tag.RowID).Y = new_val.GetValueOrDefault(PointPairBase.Missing)

                ' -- add to opBuffer
                Dim op As New COperationBuffer.StrOperation
                op.Series = Curves(i).Curve.Tag.Series
                op.SeriesInternalId = Curves(i).Curve.Tag.InternalID
                op.CaseId = e.RowIndex - Curves(i).Curve.Tag.RowID
                op.savedValue = Curves(i).Curve.Tag.Series.S_RowObject.Value(e.RowIndex - Curves(i).Curve.Tag.RowID, Curves(i).Curve.Tag.InternalID)

                Dim opList As New List(Of COperationBuffer.StrOperation)
                opList.Add(op)
                OpBuffer.Push(opList)

                'change value in the common structure
                Curves(i).Curve.Tag.Series.S_RowObject.Value(e.RowIndex - Curves(i).Curve.Tag.RowID, Curves(i).Curve.Tag.InternalID) = new_val
                Curves(i).Curve.Tag.Series.S_Update = True

                Exit For
            End If
        Next

        ZG1.Invalidate()
    End Sub

    ' --- Set CurDate
    Private Sub DGV1_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellDoubleClick
        If e.ColumnIndex > 0 Then
            Exit Sub
        End If
        CurDate.Value = Dates(e.RowIndex)
    End Sub

    ' --- Paste
    Private Sub Paste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteMI.Click
        Dim SelectedCell As Windows.Forms.DataGridViewCell = DGV1.SelectedCells.Item(0)
        If ((SelectedCell.RowIndex) < Curves(SelectedCell.ColumnIndex - 1).Curve.Tag.RowID) Or ((SelectedCell.RowIndex) > Curves(SelectedCell.ColumnIndex - 1).Curve.Tag.RowID + Curves(SelectedCell.ColumnIndex - 1).Curve.Tag.Series.NumberOfCases - 1) Or (Not Curves(SelectedCell.ColumnIndex - 1).Curve.Tag.L_CanMove) Then
            Exit Sub ' can not edit
        End If

        Dim fromClipBoard As IDataObject
        fromClipBoard = Clipboard.GetDataObject
        Dim str As String
        str = Clipboard.GetText()

        If fromClipBoard IsNot Nothing Then
            Dim s As String
            s = Clipboard.GetText()

            Dim sReader As System.IO.StringReader
            sReader = New System.IO.StringReader(s)

            Dim tempDbl As Double?, tempStr As String, a() As String
            Dim fin As Boolean = False

            Dim CurRow = SelectedCell.RowIndex

            Try
                Dim opList As New List(Of COperationBuffer.StrOperation)
                Do While (Not fin) And (CurRow <= Curves(SelectedCell.ColumnIndex - 1).Curve.Tag.RowID + Curves(SelectedCell.ColumnIndex - 1).Curve.Tag.Series.NumberOfCases - 1)

                    tempStr = sReader.ReadLine()
                    If tempStr IsNot Nothing Then
                        If tempStr <> "" Then
                            a = tempStr.Split(vbTab)
                            tempDbl = CDbl(a(0))
                        Else
                            tempDbl = Nothing
                        End If

                        DGV1.Item(SelectedCell.ColumnIndex, CurRow).Value = tempDbl

                        ' update
                        For i = 0 To Curves.Count - 1
                            If Curves(i).Curve.Tag.ColumnID = SelectedCell.ColumnIndex Then
                                Curves(i).List.Item(CurRow - Curves(i).Curve.Tag.RowID).Y = tempDbl.GetValueOrDefault(PointPair.Missing)

                                ' -- add to opBuffer
                                Dim op As New COperationBuffer.StrOperation
                                op.Series = Curves(i).Curve.Tag.Series
                                op.SeriesInternalId = Curves(i).Curve.Tag.InternalID
                                op.CaseId = CurRow - Curves(i).Curve.Tag.RowID
                                op.savedValue = Curves(i).Curve.Tag.Series.S_RowObject.Value(CurRow - Curves(i).Curve.Tag.RowID, Curves(i).Curve.Tag.InternalID)

                                opList.Add(op)

                                'change value in the common structure
                                Curves(i).Curve.Tag.Series.S_RowObject.Value(CurRow - Curves(i).Curve.Tag.RowID, Curves(i).Curve.Tag.InternalID) = tempDbl
                                Curves(i).Curve.Tag.Series.S_Update = True
                                Exit For
                            End If
                        Next

                        CurRow += 1
                    Else
                        fin = True
                    End If
                Loop

                ' -- add to opBuffer
                OpBuffer.Push(opList)

                ZG1.Invalidate()

            Catch ex As InvalidCastException
                MessageBox.Show(ParentForm, "Data format is not valid in the buffer...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' --- Copy
    Private Sub Copy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyMI.Click
        If DGV1.GetCellCount(DataGridViewElementStates.Selected) > 0 Then
            Try
                Clipboard.SetDataObject(DGV1.GetClipboardContent)
            Catch ex As Exception
                MessageBox.Show(Me, "The data can not be copied. Try again.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
    End Sub

    ' --- Undo 
    Private Sub UndoOp()
        Dim opList As List(Of COperationBuffer.StrOperation) = OpBuffer.Pop

        If opList Is Nothing Then
            Exit Sub
        End If

        Dim op As COperationBuffer.StrOperation
        Dim opEnum As List(Of COperationBuffer.StrOperation).Enumerator = opList.GetEnumerator

        While opEnum.MoveNext
            op = opEnum.Current
            If op.Series IsNot Nothing Then
                For i = 0 To Curves.Count - 1
                    If Curves(i).Curve.Tag.Series.Equals(op.Series) AndAlso Curves(i).Curve.Tag.InternalID = op.SeriesInternalId Then

                        Curves(i).List.Item(op.CaseId).Y = op.savedValue

                        DGV1(Curves(i).Curve.Tag.ColumnID, op.CaseId + Curves(i).Curve.Tag.RowID).Value = op.savedValue

                        'change value in the common structure
                        Curves(i).Curve.Tag.Series.S_RowObject.Value(op.CaseId, op.SeriesInternalId) = op.savedValue
                        Curves(i).Curve.Tag.Series.S_Update = True

                        Exit For
                    End If
                Next
            End If
        End While

        opEnum.Dispose()
        ZG1.Invalidate()
    End Sub

    ' --- run Undo
    Private Sub UndoMI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoMI.Click, UndoMI_copy.Click
        Me.UndoOp()
    End Sub

    ' --- Undo menu is active?
    Private Sub DGVContMenu_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DGVContMenu.Opening
        UndoMI.Enabled = OpBuffer.HasOperations
    End Sub

    Private Sub ShowCellMI_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowCellMI.CheckStateChanged
        ShowCellCheckState = ShowCellMI.CheckState
    End Sub


    ' ======== CHART
    ' --- Graphics Initialization
    Public Sub InitializeGraph()
        ' Get Graph Pane
        myPane = ZG1.GraphPane
        myPane.CurveList.Clear()

        ' !!! Move points via the Left mouse button + Shift
        ZG1.EditButtons = MouseButtons.Left
        ZG1.EditModifierKeys = Keys.Shift

        ' !!! Horizontal moving...
        'ZG1.IsEnableHEdit = True
        ' !!! Vertical moving...
        'ZG1.IsEnableVEdit = True

        'ZG1.Cursor = Cursors.Default

        ' !!! Move chart via the Left mouse button
        ZG1.PanButtons = MouseButtons.Left
        ZG1.PanModifierKeys = Keys.None

        ' !!! Zoom chart via the Left mouse button + Ctrl
        ZG1.ZoomButtons = MouseButtons.Left
        ZG1.ZoomModifierKeys = Keys.Control


        ' !!! Select curve via the Left mouse button + Alt
        ZG1.SelectButtons = MouseButtons.Left
        ZG1.SelectModifierKeys = Keys.Alt

        ZG1.LinkButtons = MouseButtons.Left
        ZG1.LinkModifierKeys = Keys.L

        ZG1.ZoomButtons2 = MouseButtons.Left
        ZG1.ZoomModifierKeys2 = Keys.Z

        '!!! Turn off context menu
        'ZG1.IsShowContextMenu = False

        ' !!! Turn on Tooltips
        ZG1.IsShowPointValues = True

        ' !!! Allow curve selection
        ZG1.IsEnableSelection = True

        ' !!! Turn off zooming
        ' ZG1.IsEnableZoom = false

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' !!! Set font size for various elements
        Dim labelsXfontSize As Integer = 6
        Dim labelsYfontSize As Integer = 6
        Dim titleXFontSize As Integer = 25
        Dim titleYFontSize As Integer = 20
        Dim legendFontSize As Integer = 8
        Dim mainTitleFontSize As Integer = 30

        ' !!! Axis visibility
        myPane.XAxis.IsVisible = True
        myPane.X2Axis.IsVisible = True
        myPane.YAxis.IsVisible = True

        ' !!! Set font size for axis labels 
        myPane.XAxis.Scale.FontSpec.Size = labelsXfontSize
        myPane.X2Axis.Scale.FontSpec.Size = labelsXfontSize
        myPane.YAxis.Scale.FontSpec.Size = labelsYfontSize

        ' !!! Title visibility
        myPane.XAxis.Title.IsVisible = False
        myPane.X2Axis.Title.IsVisible = False
        myPane.YAxis.Title.IsVisible = False

        ' !!! Set font size for axis titles
        myPane.XAxis.Title.FontSpec.Size = titleXFontSize
        myPane.X2Axis.Title.FontSpec.Size = titleXFontSize
        myPane.YAxis.Title.FontSpec.Size = titleYFontSize

        ' !!! Title text
        'myPane.XAxis.Title.Text = "X Value"
        'myPane.X2Axis.Title.Text = "X2 Value"
        'myPane.YAxis.Title.Text = "Y Value"

        ' !!! Set font size for legend
        myPane.Legend.FontSpec.Size = legendFontSize
        'myPane.Legend.IsHStack = True
        myPane.Legend.IsVisible = True

        ' !!! Settings for main title
        myPane.Title.FontSpec.Size = mainTitleFontSize
        myPane.Title.FontSpec.IsUnderline = True
        myPane.Title.IsVisible = False
        'myPane.Title.Text = "My Test Graph"

        ' !!! Scaling fonts while changing size of chart
        'myPane.IsFontsScaled = False

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' !!! Change axis font slope. The angle is given in degree for X axis. 
        myPane.XAxis.Scale.FontSpec.Angle = 90

        ' For the Y axis: 0 degree means title be parallel to axis Y
        'myPane.YAxis.Scale.FontSpec.Angle = 120

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' !!! Set Date type for the X axes
        myPane.XAxis.Type = AxisType.Date
        myPane.X2Axis.Type = AxisType.Date

        ' !!! Set X axes format
        ' http://msdn.microsoft.com/ru-ru/library/system.globalization.datetimeformatinfo.aspx
        myPane.XAxis.Scale.Format = FormatStr(Date_detail)
        myPane.XAxis.Scale.FormatAuto = False

        myPane.X2Axis.Scale.Format = "dd.MM.yyyy"
        myPane.X2Axis.Scale.FormatAuto = False

        ' !!! Set Y axis numerical format
        ' http://msdn.microsoft.com/ru-ru/library/system.globalization.numberformatinfo.aspx
        myPane.YAxis.Scale.Format = "F2"

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        ' !!! Anothe settings: tics, units, steps,...
        ' !!! Major X axis
        'myPane.XAxis.Scale.MajorUnit = DateUnit.Hour
        'myPane.XAxis.Scale.MajorStep = 3
        'myPane.XAxis.MajorTic.Size = 2
        'myPane.XAxis.MajorTic.IsOutside = False

        ' !!! Minor X axis
        'myPane.XAxis.Scale.MinorUnit = DateUnit.Hour
        'myPane.XAxis.Scale.MinorStep = 1
        'myPane.XAxis.MinorTic.Size = 1
        'myPane.XAxis.MinorTic.IsOutside = False
        ' ''myPane.XAxis.Scale = True
        ''myPane.XAxis.MinorTic.IsInside = False
        ''myPane.XAxis.MinorTic.IsOpposite = False
        ''myPane.XAxis.MinorTic.IsOutside = False

        ' !!! Major X2 axis
        'myPane.X2Axis.Scale.MajorUnit = DateUnit.Day
        'myPane.X2Axis.Scale.MajorStep = 1
        'myPane.X2Axis.MajorTic.Size = 2
        'myPane.X2Axis.MajorTic.IsOutside = False

        ' !!! Minor X2 axis
        ''myPane.X2Axis.Scale.MinorUnit = DateUnit.Hour
        ''myPane.X2Axis.Scale.MinorStep = 1
        ''myPane.X2Axis.MinorTic.Size = 1
        'myPane.X2Axis.MinorTic.IsInside = False
        'myPane.X2Axis.MinorTic.IsOpposite = False
        'myPane.X2Axis.MinorTic.IsOutside = False

        ' !!! Major Y axis
        'myPane.YAxis.Scale.MajorUnit = 1
        'myPane.YAxis.Scale.MajorStep = 200
        'myPane.YAxis.MajorTic.Size = 2
        'myPane.YAxis.MajorTic.IsOutside = False

        ' !!! Minor Y axis
        'myPane.YAxis.Scale.MinorUnit = 1
        'myPane.YAxis.Scale.MinorStep = 100
        'myPane.YAxis.MinorTic.Size = 1
        'myPane.YAxis.MinorTic.IsOutside = False

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' !!! Turn on Grid 
        ' !!! Major X,X2 axis
        myPane.XAxis.MajorGrid.IsVisible = True
        myPane.X2Axis.MajorGrid.IsVisible = True

        ' Set intervals for dash line: - - - - - - -
        myPane.XAxis.MajorGrid.DashOn = 10
        myPane.X2Axis.MajorGrid.DashOn = 10

        myPane.XAxis.MajorGrid.DashOff = 0
        myPane.X2Axis.MajorGrid.DashOff = 0

        ' !!! Major Y axis
        myPane.YAxis.MajorGrid.IsVisible = True
        myPane.YAxis.MajorGrid.IsZeroLine = False

        ' Set intervals for dash line: - - - - - - -
        myPane.YAxis.MajorGrid.DashOn = 10
        myPane.YAxis.MajorGrid.DashOff = 0

        ' !!! Minor X,X2 axis
        myPane.XAxis.MinorGrid.IsVisible = False
        myPane.X2Axis.MinorGrid.IsVisible = False

        myPane.XAxis.MinorGrid.DashOn = 10
        myPane.XAxis.MinorGrid.DashOff = 0

        ' !!! Minor Y axis
        myPane.YAxis.MinorGrid.IsVisible = False

        myPane.YAxis.MinorGrid.DashOn = 10
        myPane.YAxis.MinorGrid.DashOff = 0

        ' !!! Set Grid color
        myPane.XAxis.MajorGrid.Color = Color.LightGray
        myPane.X2Axis.MajorGrid.Color = Color.FromArgb(0, 255, 255) 'Color.Aquamarine
        myPane.YAxis.MajorGrid.Color = Color.LightGray
        myPane.XAxis.MinorGrid.Color = Color.LightGray
        myPane.YAxis.MinorGrid.Color = Color.LightGray

        ' !!! Set Grid width
        myPane.X2Axis.MajorGrid.PenWidth = 2

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Scaling
        myPane.YAxis.Scale.MaxAuto = True
        myPane.YAxis.Scale.MinAuto = True
    End Sub

    ' --- chart editing (manual)
    Private Function ZG1_PointEditEvent(ByVal sender As ZedGraph.ZedGraphControl, ByVal pane As ZedGraph.GraphPane, ByVal curve As ZedGraph.CurveItem, ByVal iPt As System.Int32) As System.String Handles ZG1.PointEditEvent
        DGV1(curve.Tag.ColumnID, iPt + curve.Tag.RowID).Value = curve(iPt).Y
        DGV1(curve.Tag.ColumnID, iPt + curve.Tag.RowID).Selected = True
        DGV1.FirstDisplayedScrollingRowIndex = iPt + curve.Tag.RowID
        DGV1.FirstDisplayedScrollingColumnIndex = curve.Tag.ColumnID

        ' -- add to opBuffer
        Dim op As New COperationBuffer.StrOperation
        op.Series = curve.Tag.Series
        op.SeriesInternalId = curve.Tag.InternalID
        op.CaseId = iPt
        op.savedValue = curve.Tag.Series.S_RowObject.Value(iPt, curve.Tag.InternalID)

        Dim opList As New List(Of COperationBuffer.StrOperation)
        opList.Add(op)
        OpBuffer.Push(opList)

        'change value in the common structure
        curve.Tag.Series.S_RowObject.Value(iPt, curve.Tag.InternalID) = curve(iPt).Y
        curve.Tag.Series.S_Update = True

        Return ""
    End Function

    ' --- Set limits for Date axes
    Public Sub SetGrDateLimits(ByVal minD As Date, ByVal maxD As Date)
        Dim xmin_limit As Double = New XDate(minD)
        Dim xmax_limit As Double = New XDate(maxD) '(Dates(Dates.Length - 1))

        ' !!! Set limits for X, X2 axes
        myPane.XAxis.Scale.Min = xmin_limit
        myPane.XAxis.Scale.Max = xmax_limit
        myPane.X2Axis.Scale.Min = xmin_limit
        myPane.X2Axis.Scale.Max = xmax_limit

        myPane.AxisChange()
        ' Me.CustomAxisChangeHandler(myPane)

        ZG1.Invalidate()
    End Sub

    ' --- Set limits for Y axis
    Public Sub SetGrValueLimits(ByVal minV As Double, ByVal maxV As Double)
        ' !!! Set limits for Y axis
        myPane.YAxis.Scale.Min = minV
        myPane.YAxis.Scale.Max = maxV

        myPane.AxisChange()
        ' Me.CustomAxisChangeHandler(myPane)

        ZG1.Invalidate()
    End Sub

    ' <summary>
    ' PointValueEvent handler.
    ' Return string for tooltip.
    ' </summary>
    ' <param name="sender">Message Sender</param>
    ' <param name="pane">Chart panel</param>
    ' <param name="curve">The Curve near cursor placed</param>
    ' <param name="iPt">Point number in the curve</param>
    ' <returns>String to be displayed</returns>
    Private Function ZG1_PointValueEvent(ByVal sender As ZedGraph.ZedGraphControl, ByVal pane As ZedGraph.GraphPane, ByVal curve As ZedGraph.CurveItem, ByVal iPt As System.Int32) As System.String Handles ZG1.PointValueEvent
        ' Get the nearest point
        Dim point As PointPair = curve(iPt)

        Dim d As Date = Date.FromOADate(point.X)
        Dim result As String = curve.Label.Text + ": " + point.Y.ToString("F2") + vbCrLf + vbCrLf + CreateDateString(d)

        If ShowCellCheckState = CheckState.Checked Then
            DGV1.ClearSelection()
            DGV1(curve.Tag.ColumnID, iPt + curve.Tag.RowID).Selected = True
            Dim case_ As Integer = iPt + curve.Tag.RowID
            If (Not DGV1.Item(Math.Min(curve.Tag.ColumnID + 1, DGV1.ColumnCount - 1), Math.Min(case_ + 1, DGV1.RowCount - 1)).Displayed) Then
                DGV1.FirstDisplayedCell = DGV1.Item(Math.Min(curve.Tag.ColumnID + 1, DGV1.ColumnCount - 1), Math.Min(case_ + 1, DGV1.RowCount - 1))
            ElseIf (Not DGV1.Item(Math.Max(curve.Tag.ColumnID - 1, 1), Math.Max(case_ - 1, 0)).Displayed) Then
                DGV1.FirstDisplayedCell = DGV1.Item(Math.Max(curve.Tag.ColumnID - 1, 1), Math.Max(case_ - 1, 0))
            End If
        End If

        If curve.Tag.L_CanMove Then
            ZG1.IsEnableVEdit = True
        Else
            ZG1.IsEnableVEdit = False
        End If

        Return result
    End Function

    ' --- fix tooltip blinking
    Private Sub ZG1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ZG1.MouseMove
        If MouseX <> e.X Or MouseY <> e.Y Then
            EnableToolTip(False)
            MouseX = e.X
            MouseY = e.Y
        Else
            DisableToolTip(False)
        End If
    End Sub

    ' --- remove the last element from contextmenu - By default
    Private Sub ZG1_ContextMenuBuilder(ByVal sender As ZedGraph.ZedGraphControl, ByVal menuStrip As System.Windows.Forms.ContextMenuStrip, ByVal mousePt As System.Drawing.Point, ByVal objState As ZedGraph.ZedGraphControl.ContextMenuObjectState) Handles ZG1.ContextMenuBuilder
        menuStrip.Items.RemoveAt(7)

        menuStrip.Items.Add(ShowCellMI)
        ShowCellMI.CheckState = ShowCellCheckState

        menuStrip.Items.Add(UndoMI_copy)
        UndoMI_copy.Enabled = OpBuffer.HasOperations
    End Sub

    Public Sub DisableToolTip(ByVal force As Boolean)
        If force Then
            forceToolTipNotDisplay = True
        Else
            If forceToolTipNotDisplay Then Exit Sub
        End If
        ZG1.IsShowPointValues = False
    End Sub

    Public Sub EnableToolTip(ByVal force As Boolean)
        If force Then
            forceToolTipNotDisplay = False
        Else
            If forceToolTipNotDisplay Then Exit Sub
        End If
        ZG1.IsShowPointValues = True
    End Sub

    ' --- Handle scaling
    Private Sub CustomAxisChangeHandler(ByVal pane As ZedGraph.GraphPane) Handles myPane.AxisChangeEvent
        Dim i As Short = 0
        While (Range(Date_interval(Date_detail + i)) > RangeForDateInterval(Date_detail + i)) _
            And (Date_detail + i <= 2)
            i += 1
        End While
        If Range(Date_interval(Date_detail + i)) <= RangeForDateInterval(Date_detail + i) Then
            ' Major Units for X axis
            myPane.XAxis.Scale.MajorUnit = convertDateInterval(Date_detail + i)
            myPane.XAxis.Scale.MinorUnit = myPane.XAxis.Scale.MajorUnit

            ' Major Units for X2 axis
            myPane.X2Axis.Scale.MajorUnit = myPane.XAxis.Scale.MajorUnit - 1
            myPane.X2Axis.Scale.MajorStep = 1
        Else
            myPane.XAxis.Scale.MajorUnit = DateUnit.Year
            myPane.XAxis.Scale.MinorUnit = DateUnit.Year

            myPane.X2Axis.Scale.MajorUnit = DateUnit.Year
            myPane.X2Axis.Scale.MajorStepAuto = True
            If Range(DateInterval.Year) <= RangeForDateInterval(4) Then
                myPane.XAxis.Scale.MajorStep = 1
                myPane.XAxis.Scale.MinorStep = 1
            Else
                myPane.XAxis.Scale.MajorStepAuto = True
                myPane.XAxis.Scale.MinorStepAuto = True
            End If

        End If

        ' !!! X
        myPane.XAxis.MajorTic.Size = 2
        myPane.XAxis.MajorTic.IsOutside = False

        'myPane.XAxis.Scale.MinorStep = 1 '0.25
        myPane.XAxis.MinorTic.Size = 1
        myPane.XAxis.MinorTic.IsOutside = False
        ''myPane.XAxis.Scale = True
        'myPane.XAxis.MinorTic.IsInside = False
        'myPane.XAxis.MinorTic.IsOpposite = False
        'myPane.XAxis.MinorTic.IsOutside = False

        ' !!! X2
        myPane.X2Axis.MajorTic.Size = 2
        myPane.X2Axis.MajorTic.IsOutside = False

        'myPane.X2Axis.Scale.MinorUnit = DateUnit.Hour
        'myPane.X2Axis.Scale.MinorStep = 1
        'myPane.X2Axis.MinorTic.Size = 1
        myPane.X2Axis.MinorTic.IsInside = False
        myPane.X2Axis.MinorTic.IsOpposite = False
        myPane.X2Axis.MinorTic.IsOutside = False

        ' !!! Y
        myPane.YAxis.Scale.MajorUnit = 1
        'myPane.YAxis.Scale.MajorStep = 200
        myPane.YAxis.Scale.MajorStepAuto = True
        myPane.YAxis.MajorTic.Size = 2
        myPane.YAxis.MajorTic.IsOutside = False

        myPane.YAxis.Scale.MinorUnit = 1
        'myPane.YAxis.Scale.MinorStep = 100
        myPane.YAxis.Scale.MinorStepAuto = True
        myPane.YAxis.MinorTic.Size = 1
        myPane.YAxis.MinorTic.IsOutside = False

        Me.UpdateCalendar()

    End Sub

    ' --- update Calendar on graph scroll
    Private Function ZG1_MouseUpEvent(ByVal sender As ZedGraph.ZedGraphControl, ByVal e As System.Windows.Forms.MouseEventArgs) As System.Boolean Handles ZG1.MouseUpEvent
        If e.Button = Windows.Forms.MouseButtons.Left And (Control.ModifierKeys <> Keys.Shift) And (Control.ModifierKeys <> Keys.Control) Then
            Me.UpdateCalendar()
        End If
        Return False
    End Function

    Private Sub UpdateCalendar()
        ' --- update Calendar
        RemoveHandler CurDate.ValueChanged, AddressOf CurDate_ValueChanged
        CurDate.Value = CurrentDate 'DGV1_SelectionChanged(Me, New System.EventArgs)
        AddHandler CurDate.ValueChanged, AddressOf CurDate_ValueChanged
    End Sub

    Private Sub ZG1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ZG1.KeyDown
        If e.KeyCode = Keys.H Then
            ZG1.IsEnableVZoom = False
        End If
        If e.KeyCode = Keys.V Then
            ZG1.IsEnableHZoom = False
        End If
    End Sub

    Private Sub ZG1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ZG1.KeyUp
        ZG1.IsEnableVZoom = True
        ZG1.IsEnableHZoom = True
    End Sub

    ' --- Convert DateInterval into ZedGraph.DateUnit
    Private Function convertDateInterval(ByVal Date_detail As EDateInterval) As ZedGraph.DateUnit
        Dim unit As DateUnit
        Select Case Date_detail
            Case EDateInterval.Hour
                unit = DateUnit.Hour
                myPane.XAxis.Scale.MajorStep = 3
                myPane.XAxis.Scale.MinorStep = 1
            Case EDateInterval.Day
                unit = DateUnit.Day
                myPane.XAxis.Scale.MajorStep = 1
                myPane.XAxis.Scale.MinorStep = 1
            Case EDateInterval.WeekOfYear
                unit = DateUnit.Day
                myPane.XAxis.Scale.MajorStep = 7
                myPane.XAxis.Scale.MinorStep = 1
            Case EDateInterval.Month
                unit = DateUnit.Month
                myPane.XAxis.Scale.MajorStep = 1
                myPane.XAxis.Scale.MinorStep = 0.25
        End Select
        Return unit
    End Function

    ' --- Zoom limitation
    Private Sub ZG1_ZoomEvent(ByVal sender As ZedGraph.ZedGraphControl, ByVal oldState As ZedGraph.ZoomState, ByVal newState As ZedGraph.ZoomState) Handles ZG1.ZoomEvent
        Dim extr As Integer = 200000
        If (myPane.XAxis.Scale.Min < -extr) Then
            myPane.XAxis.Scale.Min = -extr
        End If

        If (myPane.XAxis.Scale.Max > extr) Then
            myPane.XAxis.Scale.Max = extr
        End If

        If (myPane.X2Axis.Scale.Min < -extr) Then
            myPane.X2Axis.Scale.Min = -extr
        End If

        If (myPane.X2Axis.Scale.Max > extr) Then
            myPane.X2Axis.Scale.Max = extr
        End If

        If (myPane.YAxis.Scale.Min < -extr) Then
            myPane.YAxis.Scale.Min = -extr
        End If

        If (myPane.YAxis.Scale.Max > extr) Then
            myPane.YAxis.Scale.Max = extr
        End If
    End Sub

    ' ===== SERIES
    ' --- add series to control
    Public Sub AddSeriesToControl(ByRef Series As CSeries) 'ByVal Series As CSeries, 

        Dim Tag As New CurvePar
        Tag.Series = Series

        Dim NumberOfCurves As Integer = Curves.Count
        Dim cnt As Integer

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim SeriesObj As CData = Series.S_RowObject
        Dim CurvesItem(SeriesObj.NumberOfRows - 1) As ZedgraphCurve

        For i = 0 To SeriesObj.NumberOfRows - 1
            CurvesItem(i).List = New PointPairList

            Dim ColumnAdd As New AddColumnDelegate(AddressOf DGV1.Columns.Add)
            DGV1.Invoke(ColumnAdd, New Object() {SeriesObj.L_Description(i).L_Label, SeriesObj.L_Description(i).L_Label})

            DGV1.Columns(DGV1.Columns.Count - 1).DefaultCellStyle.Format = "F2"
            DGV1.Columns(DGV1.Columns.Count - 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGV1.Columns(DGV1.Columns.Count - 1).Width = 60
            DGV1.Columns(DGV1.Columns.Count - 1).SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        Dim Shift As Integer = Series.ShiftFromObjectTopCases

        For cnt = 0 To SeriesObj.ParentSeries.NumberOfCases - 1
            For i = 0 To SeriesObj.NumberOfRows - 1
                'If Not SeriesObj.Value(cnt, i) = vbNull Then
                If Not IsNothing(SeriesObj.Value(cnt, i)) Then
                    DGV1.Item(NumberOfCurves + 1 + i, cnt + Shift).Value = SeriesObj.Value(cnt, i)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    CurvesItem(i).List.Add(New XDate(Dates(cnt + Shift)), DGV1.Item(NumberOfCurves + 1 + i, cnt + Shift).Value)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Else
                    CurvesItem(i).List.Add(New XDate(Dates(cnt + Shift)), PointPairBase.Missing)
                End If
            Next
        Next
        For i = 0 To SeriesObj.NumberOfRows - 1
            CurvesItem(i).Curve = myPane.AddCurve("", CurvesItem(i).List, Color.Black)

            Tag.ColumnID = NumberOfCurves + 1 + i
            CurvesItem(i).Curve.Tag = Tag

            Curves.Add(CurvesItem(i))
        Next
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        SetCurveParameters_FromStructureToCurve(Series)
    End Sub

    ' --- remove series from control
    Public Sub RemoveSeriesFromControl(ByVal SeriesID As Integer)

        For i = Curves.Count - 1 To 0 Step -1
            If Curves(i).Curve.Tag.Series.SeriesID = SeriesID Then

                myPane.CurveList.Remove(Curves(i).Curve)
                Curves.RemoveAt(i)

                DGV1.Columns.RemoveAt(i + 1)
            End If
        Next

        'Curves.Count has already another value
        For i = 0 To Curves.Count - 1
            Curves(i).Curve.Tag.ColumnID = i + 1
        Next

        ZG1.Invalidate()
    End Sub

    ' ---  add settings
    Public Sub SetCurveParameters_FromStructureToCurve(ByRef Series As CSeries)
        Dim L As CSeries.StrLDescription

        For i = 0 To Curves.Count - 1
            If Curves(i).Curve.Tag.Series.SeriesID = Series.SeriesID Then
                L = Series.S_RowObject.L_Description(Curves(i).Curve.Tag.InternalID)
                Curves(i).Curve.IsVisible = L.L_IsVisible
                Curves(i).Curve.Label.Text = L.L_Label
                Curves(i).Curve.Line.Color = L.L_Color
                Curves(i).Curve.Line.Width = L.L_Width
                Curves(i).Curve.Line.Style = L.L_Style
                Curves(i).Curve.Symbol.Type = L.L_Symbol
                Curves(i).Curve.Symbol.Size = L.L_SymbolSize
                Curves(i).Curve.Symbol.IsVisible = L.L_IsVisibleSymbol

                Curves(i).Curve.Tag.L_CanMove = L.L_CanMove

                Curves(i).Curve.Symbol.Border.Color = Curves(i).Curve.Line.Color
                Curves(i).Curve.Label.IsVisible = Curves(i).Curve.IsVisible

                'to fill symbol
                'Curves(i).Curve.Symbol.Fill.Type = FillType.Solid
                'Curves(i).Curve.Symbol.Fill.Color = Curves(i).Curve.Color
            End If
        Next

        ZG1.Invalidate()
    End Sub

    '======= GENERAL ====================================================================================================================
    ' --- Add series
    Private Sub AddSeries(ByRef NewSeries As CSeries)

        Me.DisableToolTip(True) 'Turn off tooltip handler - otherwise exception "For each" arise

        SeriesList.Add(NewSeries)

        If IsEmptyControl Then
            Me.Date_first = NewSeries.Date_first
            Me.Date_last = NewSeries.Date_last
            Me.Date_detail = NewSeries.Date_detail

            Dim ToEnd As Integer = NewSeries.NumberOfCases

            Me.ExpandRows(0, ToEnd)
            IsEmptyControl = False
        Else
            ' Need to expand DGV1

            Dim ToEnd As Integer = DateDiff(Date_interval, ClearDate(Me.Date_last), ClearDate(NewSeries.Date_last), FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)
            Dim ToStart As Integer = -1 * DateDiff(Date_interval, ClearDate(Me.Date_first), ClearDate(NewSeries.Date_first), FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)

            If ToEnd > 0 Then
                Me.Date_last = NewSeries.Date_last
            End If
            If ToStart > 0 Then
                Me.Date_first = NewSeries.Date_first
            End If

            Me.ExpandRows(ToStart, ToEnd)
        End If

        Me.AddSeriesToControl(NewSeries)

        Me.EnableToolTip(True) ' Turn on tooltip handler

        Me.AddOperationDescr("--- """ + NewSeries.S_RowObject.Name + """ is added.")

        GC.Collect()
    End Sub

    ' --- Remove series
    Public Sub RemoveSeries(ByVal SeriesID As Integer)
        Me.RemoveSeriesFromControl(SeriesID)

        Dim name As String = SeriesList(SeriesID).S_RowObject.Name
        SeriesList.RemoveAt(SeriesID)
        Me.AddOperationDescr("--- """ + name + """ is removed.")

        If SeriesList.Count = 0 Then
            Me.DGV1.Invoke(Sub() Me.DGV1.RowCount = 0)
            IsEmptyControl = True
            DGV1.Enabled = False
            Me.AddOperationDescr("--- Control is cleared.")
        End If
        GC.Collect()
    End Sub

    ' -- Add operation description
    Public Sub AddOperationDescr(ByVal oper As String)
        Dim t_S As String
        Dim t As Date = Now

        t_S = t.Hour.ToString("D2") + ":" + t.Minute.ToString("D2") + ":" + t.Second.ToString("D2") + " "

        Dim add_T As New ChartGridControl.AddTextDelegate(AddressOf Me.TB_Log.AppendText)
        Me.TB_Log.Invoke(add_T, New Object() {t_S + oper + vbCrLf})
    End Sub

    '===========================================================================================================================
    Public Sub B_Settings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Settings.Click
        Dim csd As New ChartSettingsDialog(Me)
        csd.ShowDialog()
    End Sub

    Private Sub CurDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CurDate.ValueChanged
        If SeriesList.Count <> 0 Then
            If CalendStop Then Exit Sub
            CalendStop = True

            Select Case Date_interval

                Case EDateInterval.Day
                    If CurDate.Value.Hour <> 0 Then
                        CurDate.Value = DateAdd(DateInterval.Hour, (-1) * CurDate.Value.Hour, CurDate.Value)
                    End If

                Case EDateInterval.WeekOfYear
                    If CurDate.Value.Hour <> 0 Then
                        CurDate.Value = DateAdd(DateInterval.Hour, (-1) * CurDate.Value.Hour, CurDate.Value)
                    End If
                    If CurDate.Value.DayOfWeek <> DayOfWeek.Monday Then
                        If CurDate.Value.DayOfWeek <> DayOfWeek.Sunday Then
                            CurDate.Value = DateAdd(DateInterval.Day, -1 * (CurDate.Value.DayOfWeek - 1), CurDate.Value)
                        Else
                            CurDate.Value = DateAdd(DateInterval.Day, -6, CurDate.Value)
                        End If
                    End If

                Case EDateInterval.Month
                    If CurDate.Value.Hour <> 0 Then
                        CurDate.Value = DateAdd(DateInterval.Hour, (-1) * CurDate.Value.Hour, CurDate.Value)
                    End If
                    If CurDate.Value.Day <> 1 Then
                        CurDate.Value = DateAdd(DateInterval.Day, -1 * (CurDate.Value.Day - 1), CurDate.Value)
                    End If
            End Select

            If CurDate.Value > Date_last Then
                CurDate.Value = Date_last
            End If

            If CurDate.Value < Date_first Then
                CurDate.Value = Date_first
            End If

            ''''''''''''''''''''''''''''''''''''''''
            Dim ind As Integer = DateDiff(Date_interval, Date_first, CurDate.Value)
            If Not DGV1.Item(0, ind).Displayed Then
                DGV1.FirstDisplayedScrollingRowIndex = ind
            End If
            'obj.me.ResultsV.Item(0, ind).Selected = True

            Dim delta As Integer = Int(Range(Date_interval) / 2)

            SetGrDateLimits(DateAdd(Date_interval, -delta, Dates(ind)), _
                            DateAdd(Date_interval, delta, Dates(ind)))
            '''''''''''''''''''''''''''''''''''''''''''

            CalendStop = False
        End If
    End Sub

    Public Sub B_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Add.Click
        'Me.CreateSeries()
        Dim ad As New AddDialog(Me)
        Dim series As CSeries

        If ad.ShowDialog() = DialogResult.OK Then
            'add extra thread for "Loading..." form
            Dim tr As New Threading.Thread(AddressOf wf.ShowDialog)
            tr.IsBackground = True
            tr.Start()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'main thread
            If IsEmptyControl Then
                DGV1.Enabled = True
                ZG1.Enabled = True
                InitializeGraph()
            End If

            If ad.RB_New.Checked Then
                Threading.Thread.Sleep(1000)

                series = New CSeries(Me)

                If IsEmptyControl Then
                    series.Date_detail = ad.CB_DateInterval.SelectedIndex
                End If

                series.Date_first = ClearDate(ad.DTP_From.Value, series.Date_detail)
                series.Date_last = ClearDate(ad.DTP_To.Value, series.Date_detail)

                series.S_RowObject = New CData(series)
                Dim value(series.NumberOfCases - 1, 0) As Nullable(Of Double)
                series.S_RowObject.Value = value
                series.S_RowObject.Name = "New Series"
                series.S_RowObject.LoadDefL_Description()
                Me.AddSeries(series)
            ElseIf ad.RB_FromFile.Checked Then
                Dim format As String = ""
                If ad.ChB_Format.Checked Then
                    'manually set up time format string
                    format = ad.TB_Format.Text
                End If

                Dim data = ad.ExcelConn.ReadData(ad.CB_TimeVariable.SelectedIndex, ad.LB_SeriesVariables.SelectedIndices, format)
                For i = 1 To data.GetLength(1) - 1
                    If ad.ChB_TimeIntervalFromFile.Checked Then
                        'manually set up time interval
                        series = New CSeries(Me, ad.CB_TimeIntervalFromFile.SelectedIndex)
                    Else
                        'automatically determine time interval
                        series = New CSeries(Me)
                    End If
                    series.S_RowObject = New CData(series)
                    series.S_RowObject.LoadData(data, i)
                    series.S_RowObject.LoadDefL_Description()
                    AddSeries(series)
                Next
                ad.ExcelConn.Close()
                Me.AddOperationDescr("--- All data are loaded from file.")
            End If
            ' --- set auto YAxis Scale
            Me.myPane.YAxis.Scale.MaxAuto = True
            Me.myPane.YAxis.Scale.MinAuto = True
            Me.myPane.AxisChange()
            Me.myPane.YAxis.Scale.MaxAuto = False
            Me.myPane.YAxis.Scale.MinAuto = False

            Dim delta As Integer = Int(Me.Range(Date_interval) / 2)
            Me.SetGrDateLimits(DateAdd(Date_interval, -delta, Me.Date_last), _
                            DateAdd(Date_interval, delta, Me.Date_last))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'close "Loading..." thread
            If wf.InvokeRequired Then
                Dim wfc As New WaitFDelegate(AddressOf wf.Close)
                wf.Invoke(wfc)
            Else
                wf.Close()
            End If
        End If
    End Sub

    Public Sub B_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Save.Click
        'set formats
        SaveFileDialog1.Filter = "Excel Workbook (*.xlsx)|*.xlsx|Excel Document 97-2003 (*.xls)|*.xls"

        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            'add extra thread for "Loading..." form
            Dim tr As New Threading.Thread(AddressOf wf.ShowDialog)
            tr.IsBackground = True
            tr.Start()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'main thread
            Dim excelConn = New ExcelConnection(SaveFileDialog1.FileName, False)
            excelConn.WriteData(SeriesList, SaveFileDialog1.FilterIndex)
            excelConn.Close()
            Me.AddOperationDescr("--- All data are saved to file.")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'close "Loading..." thread
            If wf.InvokeRequired Then
                Dim wfc As New WaitFDelegate(AddressOf wf.Close)
                wf.Invoke(wfc)
            Else
                wf.Close()
            End If
        End If
    End Sub

    '====== UTILS =========================================================================================================
    Public Function ClearDate(ByVal _dt As Date, Optional ByVal detail As EDateInterval = -1) As Date
        Dim dt As Date

        If detail = -1 Then
            detail = Date_detail
        End If

        Select Case detail
            Case 0 'hour
                dt = New Date(_dt.Year, _dt.Month, _dt.Day, _dt.Hour, 0, 0)
            Case 1 'day
                dt = New Date(_dt.Year, _dt.Month, _dt.Day)
            Case 2 'week
                dt = New Date(_dt.Year, _dt.Month, _dt.Day)
            Case 3 'month
                dt = _dt.Date
            Case 4 'year
                dt = _dt.Date
        End Select
        Return dt
    End Function

    Public Function CreateDateString(ByVal date_ As Date) As String
        Dim dStr As String

        dStr = "Date: " + date_.ToString(FormatStr(Date_detail))
        dStr += vbCrLf

        Select Case Date_detail
            Case EDateInterval.Hour, EDateInterval.Day
                dStr += "Day: "
                Dim weekday As Integer = DatePart(DateInterval.Weekday, date_, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)
                Select Case weekday
                    Case 1
                        dStr += "Monday"
                    Case 2
                        dStr += "Tuesday"
                    Case 3
                        dStr += "Wednesday"
                    Case 4
                        dStr += "Thursday"
                    Case 5
                        dStr += "Friday"
                    Case 6
                        dStr += "Saturday"
                    Case 7
                        dStr += "Sunday"
                End Select
            Case EDateInterval.WeekOfYear
                Dim week As Integer = DatePart(DateInterval.WeekOfYear, date_, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)
                If week = 53 Then week = 1
                dStr += "Week: " + week.ToString
        End Select
        Return dStr
    End Function

    '====== PROPERTIES ====================================================================================================
    Public ReadOnly Property Date_interval(Optional ByVal Date_detail_ As EDateInterval = -1) As DateInterval
        Get
            If Date_detail_ = -1 Then
                Date_detail_ = Date_detail
            End If

            Select Case Date_detail_
                Case EDateInterval.Hour
                    Return DateInterval.Hour
                Case EDateInterval.Day
                    Return DateInterval.Day
                Case EDateInterval.WeekOfYear
                    Return DateInterval.WeekOfYear
                Case EDateInterval.Month
                    Return DateInterval.Month
                Case EDateInterval.Year
                    Return DateInterval.Year
                Case Else
                    ' if EDateInterval.None
                    Return DateInterval.Hour
            End Select
        End Get
    End Property

    ' --- calculate the number of visible points with specified interval
    Public ReadOnly Property Range(ByVal Date_Interval As DateInterval) As Integer
        Get
            Return DateDiff(Date_Interval, Date.FromOADate(myPane.XAxis.Scale.Min), Date.FromOADate(myPane.XAxis.Scale.Max)) + 1 ',  FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) + 1
        End Get
    End Property

    ' --- Return Date by case - from the first date of Object (in table)
    Public ReadOnly Property Dates(ByVal ind As Integer) As Date
        Get
            Return DateAdd(Date_interval, ind, Date_first)
        End Get
    End Property

    ' --- Property - the number of cases in Object
    Public ReadOnly Property NumberOfCases As Integer
        Get
            Return DateDiff(Date_interval, Date_first, Date_last, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) + 1
        End Get
    End Property

    ' --- Property - currently displayed Date
    Public ReadOnly Property CurrentDate() As Date
        Get
            If IsEmptyControl Then
                Return Now
            Else
                Dim d As Date = Date.FromOADate((myPane.XAxis.Scale.Max + myPane.XAxis.Scale.Min) / 2)
                Return d.Date.AddHours(d.Hour)
            End If
        End Get
    End Property

End Class
