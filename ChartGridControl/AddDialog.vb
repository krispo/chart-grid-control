Public Class AddDialog
    Public ParentControl As ChartGridControl

    Public ExcelConn As ExcelConnection

    Private wf As New WaitF

    Sub New(ByVal _ParentControl As ChartGridControl)
        ParentControl = _ParentControl

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        If Not ParentControl.IsEmptyControl Then
            DTP_From.Value = ParentControl.Date_first
            DTP_To.Value = ParentControl.Date_last
            CB_DateInterval.SelectedIndex = ParentControl.Date_detail
            CB_DateInterval.Enabled = False
        End If
    End Sub
    Private Sub B_Browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Browse.Click
        'System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim filename As String = OpenFileDialog1.FileName
            Dim headers As List(Of String)

            'add extra thread for "Loading..." form
            Dim tr As New Threading.Thread(AddressOf wf.ShowDialog)
            tr.IsBackground = True
            tr.Start()

            Me.TB_FilePath.Text = filename

            ExcelConn = New ExcelConnection(filename, 1) ' to read
            headers = ExcelConn.ReadHeaders()

            CB_TimeVariable.Items.Clear()
            CB_TimeVariable.Items.AddRange(headers.ToArray)
            CB_TimeVariable.SelectedIndex = 0

            LB_SeriesVariables.Items.Clear()
            LB_SeriesVariables.Items.AddRange(headers.ToArray)
            LB_SeriesVariables.SelectedIndex = 1

            If wf.InvokeRequired Then
                Dim wfc As New ChartGridControl.WaitFDelegate(AddressOf wf.Close)
                wf.Invoke(wfc)
            Else
                wf.Close()
            End If
        End If
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub RB_New_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_New.CheckedChanged
        DTP_From.Enabled = RB_New.Checked
        DTP_To.Enabled = RB_New.Checked
        If Not ParentControl.IsEmptyControl Then
            CB_DateInterval.Enabled = False
        Else
            CB_DateInterval.Enabled = RB_New.Checked
        End If
    End Sub

    Private Sub RB_FromFile_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_FromFile.CheckedChanged
        TB_FilePath.Enabled = RB_FromFile.Checked
        B_Browse.Enabled = RB_FromFile.Checked
        CB_TimeVariable.Enabled = RB_FromFile.Checked
        LB_SeriesVariables.Enabled = RB_FromFile.Checked
        ChB_TimeIntervalFromFile.Enabled = RB_FromFile.Checked
        CB_TimeIntervalFromFile.Enabled = ChB_TimeIntervalFromFile.Checked And RB_FromFile.Checked
        ChB_Format.Enabled = RB_FromFile.Checked
        TB_Format.Enabled = ChB_Format.Checked And RB_FromFile.Checked
    End Sub

    Private Sub ChB_Format_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChB_Format.CheckedChanged
        TB_Format.Enabled = ChB_Format.Checked And RB_FromFile.Checked
    End Sub

    Private Sub ChB_TimeIntervalFromFile_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChB_TimeIntervalFromFile.CheckedChanged
        CB_TimeIntervalFromFile.Enabled = ChB_TimeIntervalFromFile.Checked And RB_FromFile.Checked
    End Sub
End Class
