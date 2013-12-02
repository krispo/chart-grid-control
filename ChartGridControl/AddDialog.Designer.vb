<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddDialog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.B_Browse = New System.Windows.Forms.Button()
        Me.TB_FilePath = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.LB_SeriesVariables = New System.Windows.Forms.ListBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CB_TimeIntervalFromFile = New System.Windows.Forms.ComboBox()
        Me.ChB_TimeIntervalFromFile = New System.Windows.Forms.CheckBox()
        Me.ChB_Format = New System.Windows.Forms.CheckBox()
        Me.TB_Format = New System.Windows.Forms.TextBox()
        Me.CB_TimeVariable = New System.Windows.Forms.ComboBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RB_FromFile = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.RB_New = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DTP_From = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CB_DateInterval = New System.Windows.Forms.ComboBox()
        Me.DTP_To = New System.Windows.Forms.DateTimePicker()
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(154, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(156, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(72, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Cancel_Button.Location = New System.Drawing.Point(81, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(72, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'B_Browse
        '
        Me.B_Browse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.B_Browse.Enabled = False
        Me.B_Browse.Location = New System.Drawing.Point(233, 139)
        Me.B_Browse.Name = "B_Browse"
        Me.B_Browse.Size = New System.Drawing.Size(72, 20)
        Me.B_Browse.TabIndex = 1
        Me.B_Browse.Text = "Browse"
        Me.B_Browse.UseVisualStyleBackColor = True
        '
        'TB_FilePath
        '
        Me.TB_FilePath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_FilePath.Enabled = False
        Me.TB_FilePath.Location = New System.Drawing.Point(93, 116)
        Me.TB_FilePath.Name = "TB_FilePath"
        Me.TB_FilePath.Size = New System.Drawing.Size(212, 20)
        Me.TB_FilePath.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 168)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Time variable:"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(155, 168)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Series variables:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(91, 139)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Path to filename"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.LB_SeriesVariables, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 183)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(304, 76)
        Me.TableLayoutPanel2.TabIndex = 8
        '
        'LB_SeriesVariables
        '
        Me.LB_SeriesVariables.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LB_SeriesVariables.Enabled = False
        Me.LB_SeriesVariables.FormattingEnabled = True
        Me.LB_SeriesVariables.Location = New System.Drawing.Point(155, 3)
        Me.LB_SeriesVariables.Name = "LB_SeriesVariables"
        Me.LB_SeriesVariables.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.LB_SeriesVariables.Size = New System.Drawing.Size(146, 70)
        Me.LB_SeriesVariables.TabIndex = 9
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CB_TimeIntervalFromFile)
        Me.Panel1.Controls.Add(Me.ChB_TimeIntervalFromFile)
        Me.Panel1.Controls.Add(Me.ChB_Format)
        Me.Panel1.Controls.Add(Me.TB_Format)
        Me.Panel1.Controls.Add(Me.CB_TimeVariable)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(146, 70)
        Me.Panel1.TabIndex = 10
        '
        'CB_TimeIntervalFromFile
        '
        Me.CB_TimeIntervalFromFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CB_TimeIntervalFromFile.Enabled = False
        Me.CB_TimeIntervalFromFile.FormattingEnabled = True
        Me.CB_TimeIntervalFromFile.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CB_TimeIntervalFromFile.Items.AddRange(New Object() {"Hour", "Day", "Week", "Month", "Year"})
        Me.CB_TimeIntervalFromFile.Location = New System.Drawing.Point(60, 25)
        Me.CB_TimeIntervalFromFile.Name = "CB_TimeIntervalFromFile"
        Me.CB_TimeIntervalFromFile.Size = New System.Drawing.Size(86, 21)
        Me.CB_TimeIntervalFromFile.TabIndex = 57
        Me.CB_TimeIntervalFromFile.Text = "Hour"
        '
        'ChB_TimeIntervalFromFile
        '
        Me.ChB_TimeIntervalFromFile.AutoSize = True
        Me.ChB_TimeIntervalFromFile.Enabled = False
        Me.ChB_TimeIntervalFromFile.Location = New System.Drawing.Point(2, 27)
        Me.ChB_TimeIntervalFromFile.Name = "ChB_TimeIntervalFromFile"
        Me.ChB_TimeIntervalFromFile.Size = New System.Drawing.Size(61, 17)
        Me.ChB_TimeIntervalFromFile.TabIndex = 6
        Me.ChB_TimeIntervalFromFile.Text = "Interval"
        Me.ChB_TimeIntervalFromFile.UseVisualStyleBackColor = True
        '
        'ChB_Format
        '
        Me.ChB_Format.AutoSize = True
        Me.ChB_Format.Enabled = False
        Me.ChB_Format.Location = New System.Drawing.Point(2, 52)
        Me.ChB_Format.Name = "ChB_Format"
        Me.ChB_Format.Size = New System.Drawing.Size(58, 17)
        Me.ChB_Format.TabIndex = 4
        Me.ChB_Format.Text = "Format"
        Me.ChB_Format.UseVisualStyleBackColor = True
        '
        'TB_Format
        '
        Me.TB_Format.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_Format.Enabled = False
        Me.TB_Format.Location = New System.Drawing.Point(60, 50)
        Me.TB_Format.Name = "TB_Format"
        Me.TB_Format.Size = New System.Drawing.Size(86, 20)
        Me.TB_Format.TabIndex = 5
        Me.TB_Format.Text = "dd-MMM-yyyy HH:mm tt zzz"
        '
        'CB_TimeVariable
        '
        Me.CB_TimeVariable.Dock = System.Windows.Forms.DockStyle.Top
        Me.CB_TimeVariable.Enabled = False
        Me.CB_TimeVariable.FormattingEnabled = True
        Me.CB_TimeVariable.Location = New System.Drawing.Point(0, 0)
        Me.CB_TimeVariable.Name = "CB_TimeVariable"
        Me.CB_TimeVariable.Size = New System.Drawing.Size(146, 21)
        Me.CB_TimeVariable.TabIndex = 3
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Location = New System.Drawing.Point(12, 12)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(310, 295)
        Me.SplitContainer1.SplitterDistance = 262
        Me.SplitContainer1.TabIndex = 9
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RB_FromFile)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.RB_New)
        Me.GroupBox1.Controls.Add(Me.B_Browse)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TB_FilePath)
        Me.GroupBox1.Controls.Add(Me.DTP_From)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.CB_DateInterval)
        Me.GroupBox1.Controls.Add(Me.DTP_To)
        Me.GroupBox1.Controls.Add(Me.ShapeContainer2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(310, 262)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Choose method"
        '
        'RB_FromFile
        '
        Me.RB_FromFile.AutoSize = True
        Me.RB_FromFile.Location = New System.Drawing.Point(6, 116)
        Me.RB_FromFile.Name = "RB_FromFile"
        Me.RB_FromFile.Size = New System.Drawing.Size(73, 17)
        Me.RB_FromFile.TabIndex = 9
        Me.RB_FromFile.Text = "From file..."
        Me.RB_FromFile.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(101, 75)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "Time Interval:"
        '
        'RB_New
        '
        Me.RB_New.AutoSize = True
        Me.RB_New.Checked = True
        Me.RB_New.Location = New System.Drawing.Point(6, 19)
        Me.RB_New.Name = "RB_New"
        Me.RB_New.Size = New System.Drawing.Size(88, 17)
        Me.RB_New.TabIndex = 0
        Me.RB_New.TabStop = True
        Me.RB_New.Text = "Create new..."
        Me.RB_New.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(149, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 13)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "To:"
        '
        'DTP_From
        '
        Me.DTP_From.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DTP_From.CustomFormat = "dd/MM/yyyy; HH' hs'"
        Me.DTP_From.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_From.Location = New System.Drawing.Point(175, 19)
        Me.DTP_From.Name = "DTP_From"
        Me.DTP_From.Size = New System.Drawing.Size(129, 20)
        Me.DTP_From.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(139, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "From:"
        '
        'CB_DateInterval
        '
        Me.CB_DateInterval.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CB_DateInterval.FormattingEnabled = True
        Me.CB_DateInterval.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CB_DateInterval.Items.AddRange(New Object() {"Hour", "Day", "Week", "Month", "Year"})
        Me.CB_DateInterval.Location = New System.Drawing.Point(175, 71)
        Me.CB_DateInterval.Name = "CB_DateInterval"
        Me.CB_DateInterval.Size = New System.Drawing.Size(91, 21)
        Me.CB_DateInterval.TabIndex = 51
        Me.CB_DateInterval.Text = "Hour"
        '
        'DTP_To
        '
        Me.DTP_To.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DTP_To.CustomFormat = "dd/MM/yyyy; HH' hs'"
        Me.DTP_To.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_To.Location = New System.Drawing.Point(175, 45)
        Me.DTP_To.Name = "DTP_To"
        Me.DTP_To.Size = New System.Drawing.Size(129, 20)
        Me.DTP_To.TabIndex = 52
        '
        'ShapeContainer2
        '
        Me.ShapeContainer2.Location = New System.Drawing.Point(3, 16)
        Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer2.Name = "ShapeContainer2"
        Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer2.Size = New System.Drawing.Size(304, 243)
        Me.ShapeContainer2.TabIndex = 56
        Me.ShapeContainer2.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.LineShape1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot
        Me.LineShape1.Enabled = False
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = -2
        Me.LineShape1.X2 = 307
        Me.LineShape1.Y1 = 87
        Me.LineShape1.Y2 = 88
        '
        'AddDialog
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(334, 312)
        Me.Controls.Add(Me.SplitContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add Series"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents B_Browse As System.Windows.Forms.Button
    Friend WithEvents TB_FilePath As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LB_SeriesVariables As System.Windows.Forms.ListBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents RB_New As System.Windows.Forms.RadioButton
    Friend WithEvents RB_FromFile As System.Windows.Forms.RadioButton
    Friend WithEvents DTP_From As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTP_To As System.Windows.Forms.DateTimePicker
    Friend WithEvents CB_DateInterval As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents CB_TimeVariable As System.Windows.Forms.ComboBox
    Friend WithEvents ChB_Format As System.Windows.Forms.CheckBox
    Friend WithEvents TB_Format As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CB_TimeIntervalFromFile As System.Windows.Forms.ComboBox
    Friend WithEvents ChB_TimeIntervalFromFile As System.Windows.Forms.CheckBox

End Class
