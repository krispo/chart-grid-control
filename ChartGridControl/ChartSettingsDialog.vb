Public Class ChartSettingsDialog
    Public ParentControl As ChartGridControl

    Private remObj As New List(Of Integer)

    Private Curves As List(Of ChartGridControl.ZedgraphCurve)

    Private Cur_Row_Ind, Cur_Col_Ind As Integer
    Private old_val As Single

    Private Combo As DataGridViewComboBoxEditingControl
    Private ComboCell As DataGridViewComboBoxCell

    Private zedPane As New ZedGraph.GraphPane
    Private line As LineItem = zedPane.AddCurve("", {0}, {0}, Color.Black)

    Sub New(ByVal _ParentControl As ChartGridControl)
        ParentControl = _ParentControl

        Curves = ParentControl.Curves

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        DataGridView1.Columns(Col_ChooseCurve.Name).Visible = True
        'RemoveB.Enabled = False

        'check the legend
        If ParentControl.myPane.Legend.IsVisible Then
            ChB_Legend.Checked = True
        Else
            ChB_Legend.Checked = False
        End If

        SetValuesInDataGridView()

        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Cur_Col_Ind = e.ColumnIndex
        Cur_Row_Ind = e.RowIndex

        If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
            If e.ColumnIndex = Col_CurveColor.Index Then
                Dim СDialog As New ColorDialog()
                ' Keeps the user from selecting a custom color.
                СDialog.AllowFullOpen = True
                ' Allows the user to get help. (The default is false.)
                СDialog.ShowHelp = True
                ' Update the text box color if the user clicks OK 
                If (СDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = СDialog.Color
                End If
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellPainting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles DataGridView1.CellPainting
        If (e.ColumnIndex >= 0) And (e.RowIndex >= 0) Then

            If e.ColumnIndex = Col_CurveColor.Index Then
                Dim newRect As New Rectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, e.CellBounds.Width - 4, e.CellBounds.Height - 4)
                Dim backColorBrush As New SolidBrush(e.CellStyle.BackColor)
                Dim gridBrush As New SolidBrush(Me.DataGridView1.GridColor)
                Dim gridLinePen As New Pen(gridBrush)
                Dim LPen As New Pen(Brushes.White)

                Try
                    ' Erase the cell.
                    e.Graphics.FillRectangle(backColorBrush, e.CellBounds)

                    ' Draw the grid lines (only the right and bottom lines;
                    ' DataGridView takes care of the others).
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)

                    ' Draw the inset highlight box.
                    e.Graphics.DrawRectangle(LPen, newRect)
                    e.Handled = True
                Finally
                    gridLinePen.Dispose()
                    gridBrush.Dispose()
                    backColorBrush.Dispose()
                    LPen.Dispose()
                End Try
            End If

            If e.ColumnIndex = Col_CurveType.Index Then
                Dim backColorBrush As New SolidBrush(e.CellStyle.BackColor)
                Dim gridBrush As New SolidBrush(Me.DataGridView1.GridColor)
                Dim gridLinePen As New Pen(gridBrush)
                Dim LPen As New System.Drawing.Pen(DataGridView1.Rows(e.RowIndex).Cells(Col_CurveColor.Name).Style.BackColor, DataGridView1.Rows(e.RowIndex).Cells(Col_CurveWidth.Name).Value)
                LPen.DashStyle = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value

                Try
                    ' Erase the cell.
                    e.Graphics.FillRectangle(backColorBrush, e.CellBounds)

                    ' Draw the grid lines (only the right and bottom lines;
                    ' DataGridView takes care of the others).
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)

                    e.Graphics.DrawLine(LPen, CInt(e.CellBounds.X + 4), CInt(e.CellBounds.Y + e.CellBounds.Height / 2 - 1), CInt(e.CellBounds.X + e.CellBounds.Width - 6), CInt(e.CellBounds.Y + e.CellBounds.Height / 2 - 1)) '
                    e.Handled = True
                Finally
                    gridLinePen.Dispose()
                    gridBrush.Dispose()
                    backColorBrush.Dispose()
                    LPen.Dispose()
                End Try
                'DataGridView1.InvalidateCell(e.ColumnIndex, e.RowIndex)
            End If

            If e.ColumnIndex = Col_SymbolType.Index Then
                Dim backColorBrush As New SolidBrush(e.CellStyle.BackColor)
                Dim gridBrush As New SolidBrush(Me.DataGridView1.GridColor)
                Dim gridLinePen As New Pen(gridBrush)

                Try
                    ' Erase the cell.
                    e.Graphics.FillRectangle(backColorBrush, e.CellBounds)

                    ' Draw the grid lines (only the right and bottom lines;
                    ' DataGridView takes care of the others).
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)

                    line.Symbol.Border.Color = DataGridView1.Rows(e.RowIndex).Cells(Col_CurveColor.Index).Style.BackColor
                    line.Symbol.Size = DataGridView1.Rows(e.RowIndex).Cells(Col_SymbolSize.Index).Value
                    line.Symbol.Type = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value

                    line.Symbol.DrawSymbol(e.Graphics, zedPane, _
                    CInt(e.CellBounds.X + e.CellBounds.Width / 2), CInt(e.CellBounds.Y + e.CellBounds.Height / 2), _
                    1, True, line.Item(0))

                    e.Handled = True
                Finally
                    gridLinePen.Dispose()
                    gridBrush.Dispose()
                    backColorBrush.Dispose()
                    'LPen.Dispose()
                End Try
            End If

            If DataGridView1.Columns(e.ColumnIndex).GetType().ToString = "System.Windows.Forms.DataGridViewCheckBoxColumn" Then
                If DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly Then
                    Dim backColorBrush As New SolidBrush(e.CellStyle.BackColor)
                    Dim gridBrush As New SolidBrush(Me.DataGridView1.GridColor)
                    Dim gridLinePen As New Pen(gridBrush)

                    Dim checkboxPoint As Point = New Point(Int(e.CellBounds.X + e.CellBounds.Width / 2 - 7), Int(e.CellBounds.Y + e.CellBounds.Height / 2 - 7))
                    Dim VStyleChB As VisualStyles.CheckBoxState

                    If DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value Then
                        VStyleChB = VisualStyles.CheckBoxState.CheckedDisabled
                    Else
                        VStyleChB = VisualStyles.CheckBoxState.UncheckedDisabled
                    End If

                    Try
                        ' Erase the cell.
                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds)

                        ' Draw the grid lines (only the right and bottom lines;
                        ' DataGridView takes care of the others).
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)

                        CheckBoxRenderer.DrawCheckBox(e.Graphics, checkboxPoint, VStyleChB)
                        e.Handled = True
                    Finally
                        gridLinePen.Dispose()
                        gridBrush.Dispose()
                        backColorBrush.Dispose()
                    End Try
                End If
            End If

        End If
        DataGridView1.ClearSelection()
    End Sub

    Private Sub OkB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OkB.Click

        GetValuesFromDataGridView()

        remObj.Sort()
        For i = remObj.Count - 1 To 0 Step -1
            ParentControl.RemoveSeries(remObj(i))
        Next
        
        'check the legend
        If ChB_Legend.Checked Then
            ParentControl.myPane.Legend.IsVisible = True
        Else
            ParentControl.myPane.Legend.IsVisible = False
        End If

        Me.Close()

        ParentControl.ZG1.Invalidate()
    End Sub

    Private Sub CancelB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelB.Click
        Me.Close()
    End Sub

    ''Draw lines to divide series into separate groups
    'Private Sub DataGridView1_RowPostPaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
    '    Dim LPen As New System.Drawing.Pen(Brushes.Black, 1)

    '    If (e.RowIndex > 0) And (e.RowIndex < Curves.Count - 1) Then ' And (Not e.IsFirstDisplayedRow) Then
    '        If Curves(e.RowIndex).Curve.Tag.Series.SeriesID <> Curves(e.RowIndex + 1).Curve.Tag.Series.SeriesID Then
    '            e.Graphics.DrawLine(LPen, e.RowBounds.X, e.RowBounds.Y + e.RowBounds.Height - 2, e.RowBounds.X + e.RowBounds.Size.Width, e.RowBounds.Y + e.RowBounds.Height - 2)
    '        End If
    '        If Curves(e.RowIndex).Curve.Tag.Series.SeriesID <> Curves(e.RowIndex - 1).Curve.Tag.Series.SeriesID Then
    '            e.Graphics.DrawLine(LPen, e.RowBounds.X, e.RowBounds.Y, e.RowBounds.X + e.RowBounds.Width, e.RowBounds.Y)
    '        End If

    '    Else
    '        If e.RowIndex = Curves.Count - 1 Then
    '            e.Graphics.DrawLine(LPen, e.RowBounds.X, e.RowBounds.Y + e.RowBounds.Height - 2, e.RowBounds.X + e.RowBounds.Size.Width, e.RowBounds.Y + e.RowBounds.Height - 2)
    '        End If
    '        If e.RowIndex = 0 Then
    '            e.Graphics.DrawLine(LPen, e.RowBounds.X, e.RowBounds.Y, e.RowBounds.X + e.RowBounds.Width, e.RowBounds.Y)
    '        End If
    '    End If
    'End Sub

    Private Sub RemoveB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveB.Click
        remObj = SelectedRows()
        If Not ParentControl.IsEmptyControl Then
            If MessageBox.Show(Me, "Yoe really want to remove the selected series?", "Attention!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                For i = 0 To remObj.Count - 1
                    DataGridView1.Rows(remObj(i)).Visible = False
                Next
                DataGridView1.Invalidate()
            End If
        End If
    End Sub

    Private Sub SetValuesInDataGridView()

        AddHandler DataGridView1.EditingControlShowing, AddressOf DataGridView1_EditingControlShowing

        For i = 0 To Curves.Count - 1
            DataGridView1.Rows.Add()

            DataGridView1.Rows(i).Cells(Col_ChooseCurve.Name).Value = False

            DataGridView1.Rows(i).Cells(Col_ShowCurve.Name).Value = Curves(i).Curve.IsVisible
            DataGridView1.Rows(i).Cells(Col_CurveName.Name).Value = Curves(i).Curve.Label.Text
            DataGridView1.Rows(i).Cells(Col_CurveColor.Name).Style.BackColor = Curves(i).Curve.Line.Color

            ComboCell = DataGridView1.Rows(i).Cells(Col_CurveType.Name)
            DataGridView1.Rows(i).Cells(Col_CurveType.Name).Value = ComboCell.Items(CInt(Curves(i).Curve.Line.Style)) 'Curves(i).Curve.Line.Style 'ComboCell.Value

            DataGridView1.Rows(i).Cells(Col_CurveWidth.Name).Value = Curves(i).Curve.Line.Width

            ComboCell = DataGridView1.Rows(i).Cells(Col_SymbolType.Name)
            DataGridView1.Rows(i).Cells(Col_SymbolType.Name).Value = ComboCell.Items(CInt(Curves(i).Curve.Symbol.Type))

            DataGridView1.Rows(i).Cells(Col_SymbolSize.Name).Value = Curves(i).Curve.Symbol.Size
            DataGridView1.Rows(i).Cells(Col_ShowSymbol.Name).Value = Curves(i).Curve.Symbol.IsVisible
            DataGridView1.Rows(i).Cells(Col_MovePoints.Name).Value = Curves(i).Curve.Tag.L_CanMove
        Next

        DataGridView1.Invalidate()
    End Sub

    Private Sub GetValuesFromDataGridView()
        Dim L As CSeries.StrLDescription

        For i = 0 To DataGridView1.RowCount - 1
            Curves(i).Curve.IsVisible = DataGridView1.Rows(i).Cells(Col_ShowCurve.Name).Value
            Curves(i).Curve.Label.Text = DataGridView1.Rows(i).Cells(Col_CurveName.Name).Value
            Curves(i).Curve.Line.Color = DataGridView1.Rows(i).Cells(Col_CurveColor.Name).Style.BackColor

            Curves(i).Curve.Line.Style = DataGridView1.Rows(i).Cells(Col_CurveType.Name).Value

            Curves(i).Curve.Line.Width = DataGridView1.Rows(i).Cells(Col_CurveWidth.Name).Value

            Curves(i).Curve.Symbol.Type = DataGridView1.Rows(i).Cells(Col_SymbolType.Name).Value

            Curves(i).Curve.Symbol.Size = DataGridView1.Rows(i).Cells(Col_SymbolSize.Name).Value
            Curves(i).Curve.Symbol.IsVisible = DataGridView1.Rows(i).Cells(Col_ShowSymbol.Name).Value
            Curves(i).Curve.Tag.L_CanMove = DataGridView1.Rows(i).Cells(Col_MovePoints.Name).Value

            Curves(i).Curve.Symbol.Border.Color = Curves(i).Curve.Line.Color
            Curves(i).Curve.Label.IsVisible = Curves(i).Curve.IsVisible

            'to fill symbol
            'Curves(i).Curve.Symbol.Fill.Type = FillType.Solid
            'Curves(i).Curve.Symbol.Fill.Color = Curves(i).Curve.Color

            ParentControl.DGV1.Columns(i + 1).HeaderText = Curves(i).Curve.Label.Text

            L = ParentControl.SeriesList(Curves(i).Curve.Tag.Series.SeriesID).S_RowObject.L_Description(Curves(i).Curve.Tag.InternalID)
            L.L_IsVisible = Curves(i).Curve.IsVisible
            L.L_Label = Curves(i).Curve.Label.Text
            L.L_Color = Curves(i).Curve.Line.Color
            L.L_Width = Curves(i).Curve.Line.Width
            L.L_Style = Curves(i).Curve.Line.Style
            L.L_Symbol = Curves(i).Curve.Symbol.Type
            L.L_SymbolSize = Curves(i).Curve.Symbol.Size
            L.L_IsVisibleSymbol = Curves(i).Curve.Symbol.IsVisible

            L.L_CanMove = Curves(i).Curve.Tag.L_CanMove
            ParentControl.SeriesList(Curves(i).Curve.Tag.Series.SeriesID).S_RowObject.L_Description(Curves(i).Curve.Tag.InternalID) = L
        Next
    End Sub

    Private Sub DataGridView1_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If (e.ColumnIndex = Col_CurveColor.Index) Or (e.ColumnIndex = Col_CurveWidth.Index) Or (e.ColumnIndex = Col_SymbolSize.Index) Then
            DataGridView1.Invalidate()
        End If
    End Sub

    Private Sub DataGridView1_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DataGridView1.CellBeginEdit
        If (e.ColumnIndex = Col_CurveWidth.Index) Or (e.ColumnIndex = Col_SymbolSize.Index) Then
            old_val = DataGridView1.Item(e.ColumnIndex, e.RowIndex).Value
        End If
    End Sub

    Private Sub DataGridView1_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        If (e.ColumnIndex = Col_CurveWidth.Index) Or (e.ColumnIndex = Col_SymbolSize.Index) Then
            Dim new_val As Single
            Try
                new_val = CSng(DataGridView1.Item(e.ColumnIndex, e.RowIndex).Value)
                If DataGridView1.Item(e.ColumnIndex, e.RowIndex).Value = Nothing Then
                    DataGridView1.Item(e.ColumnIndex, e.RowIndex).Value = 0
                End If
            Catch ex As Exception
                DataGridView1.Item(e.ColumnIndex, e.RowIndex).Value = old_val
                MessageBox.Show(Me, "Input error!", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Sub DataGridView1_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) ' Handles DataGridView1.EditingControlShowing
        If (DataGridView1.CurrentCellAddress.X = Col_CurveType.Index) _
            Or (DataGridView1.CurrentCellAddress.X = Col_SymbolType.Index) Then

            Combo = e.Control
            Combo.DrawMode = DrawMode.OwnerDrawFixed

            Combo.DropDownStyle = ComboBoxStyle.DropDownList

            AddHandler Combo.DrawItem, AddressOf combo_DrawItem
        End If
    End Sub

    Private Sub combo_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) ' Handles combo.DrawItem

        Dim CurRowInd As Integer = DataGridView1.CurrentCell.RowIndex
        Dim CurColInd As Integer = DataGridView1.CurrentCell.ColumnIndex
        If (CurRowInd >= 0) Then
            If CurColInd = Col_CurveType.Index Then
                Dim LPen As New System.Drawing.Pen(DataGridView1.Rows(CurRowInd).Cells(Col_CurveColor.Index).Style.BackColor, DataGridView1.Rows(CurRowInd).Cells(Col_CurveWidth.Index).Value)

                If e.Index <> -1 Then
                    LPen.DashStyle = e.Index
                Else
                    LPen.DashStyle = DataGridView1.CurrentCell.Value
                End If

                e.Graphics.DrawLine(LPen, CInt(e.Bounds.X + 2), CInt(e.Bounds.Y + e.Bounds.Height / 2), CInt(e.Bounds.X + e.Bounds.Width - 2), CInt(e.Bounds.Y + e.Bounds.Height / 2)) '
                e.Graphics.DrawRectangle(New Pen(Color.LightGray, 1), New Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.X + e.Bounds.Width, e.Bounds.Y + e.Bounds.Height))
            End If
            If CurColInd = Col_SymbolType.Index Then

                If e.Index <> -1 Then
                    line.Symbol.Type = e.Index
                Else
                    line.Symbol.Type = DataGridView1.CurrentCell.Value
                End If

                line.Symbol.Border.Color = DataGridView1.Rows(CurRowInd).Cells(Col_CurveColor.Index).Style.BackColor
                line.Symbol.Size = DataGridView1.Rows(CurRowInd).Cells(Col_SymbolSize.Index).Value

                line.Symbol.DrawSymbol(e.Graphics, zedPane, _
                CInt(e.Bounds.X + e.Bounds.Width / 2), CInt(e.Bounds.Y + e.Bounds.Height / 2), _
                1, True, line.Item(0))

                e.Graphics.DrawRectangle(New Pen(Color.LightGray, 1), New Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.X + e.Bounds.Width, e.Bounds.Y + e.Bounds.Height))
            End If
        End If
    End Sub

    Private Function SelectedRows() As List(Of Integer)
        Dim l As New List(Of Integer)
        For i = 0 To DataGridView1.RowCount - 1
            If DataGridView1.Rows(i).Cells(Col_ChooseCurve.Name).Value Then
                l.Add(i)
            End If
        Next
        Return l
    End Function
End Class
