<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChartSettingsDialog
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Col_ChooseCurve = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Col_ShowCurve = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Col_CurveName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_CurveColor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_CurveType = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Col_CurveWidth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_SymbolType = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Col_SymbolSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_ShowSymbol = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Col_MovePoints = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.RemoveB = New System.Windows.Forms.Button()
        Me.ChB_Legend = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.CancelB = New System.Windows.Forms.Button()
        Me.OkB = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.SplitContainer1)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(648, 380)
        Me.Panel1.TabIndex = 1
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.DataGridView1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(648, 380)
        Me.SplitContainer1.SplitterDistance = 339
        Me.SplitContainer1.TabIndex = 1
        '
        'DataGridView1
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Col_ChooseCurve, Me.Col_ShowCurve, Me.Col_CurveName, Me.Col_CurveColor, Me.Col_CurveType, Me.Col_CurveWidth, Me.Col_SymbolType, Me.Col_SymbolSize, Me.Col_ShowSymbol, Me.Col_MovePoints})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridView1.Size = New System.Drawing.Size(648, 339)
        Me.DataGridView1.TabIndex = 6
        '
        'Col_ChooseCurve
        '
        Me.Col_ChooseCurve.HeaderText = "Select"
        Me.Col_ChooseCurve.Name = "Col_ChooseCurve"
        Me.Col_ChooseCurve.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Col_ChooseCurve.Width = 40
        '
        'Col_ShowCurve
        '
        Me.Col_ShowCurve.FillWeight = 99.46524!
        Me.Col_ShowCurve.HeaderText = "Visible"
        Me.Col_ShowCurve.Name = "Col_ShowCurve"
        Me.Col_ShowCurve.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Col_ShowCurve.Width = 70
        '
        'Col_CurveName
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Col_CurveName.DefaultCellStyle = DataGridViewCellStyle2
        Me.Col_CurveName.FillWeight = 57.30772!
        Me.Col_CurveName.HeaderText = "Name"
        Me.Col_CurveName.Name = "Col_CurveName"
        Me.Col_CurveName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Col_CurveColor
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Col_CurveColor.DefaultCellStyle = DataGridViewCellStyle3
        Me.Col_CurveColor.FillWeight = 62.93076!
        Me.Col_CurveColor.HeaderText = "Color"
        Me.Col_CurveColor.Name = "Col_CurveColor"
        Me.Col_CurveColor.ReadOnly = True
        Me.Col_CurveColor.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Col_CurveColor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Col_CurveColor.Width = 50
        '
        'Col_CurveType
        '
        Me.Col_CurveType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.Col_CurveType.FillWeight = 65.37469!
        Me.Col_CurveType.HeaderText = "Type"
        Me.Col_CurveType.Items.AddRange(New Object() {"0", "1", "2", "3", "4"})
        Me.Col_CurveType.Name = "Col_CurveType"
        Me.Col_CurveType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Col_CurveType.Width = 50
        '
        'Col_CurveWidth
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Col_CurveWidth.DefaultCellStyle = DataGridViewCellStyle4
        Me.Col_CurveWidth.FillWeight = 100.1421!
        Me.Col_CurveWidth.HeaderText = "Width"
        Me.Col_CurveWidth.Name = "Col_CurveWidth"
        Me.Col_CurveWidth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Col_CurveWidth.Width = 55
        '
        'Col_SymbolType
        '
        Me.Col_SymbolType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.Col_SymbolType.FillWeight = 77.85468!
        Me.Col_SymbolType.HeaderText = "Symbol"
        Me.Col_SymbolType.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"})
        Me.Col_SymbolType.Name = "Col_SymbolType"
        Me.Col_SymbolType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Col_SymbolType.Width = 50
        '
        'Col_SymbolSize
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Col_SymbolSize.DefaultCellStyle = DataGridViewCellStyle5
        Me.Col_SymbolSize.FillWeight = 137.0092!
        Me.Col_SymbolSize.HeaderText = "Symbol size"
        Me.Col_SymbolSize.Name = "Col_SymbolSize"
        Me.Col_SymbolSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Col_SymbolSize.Width = 50
        '
        'Col_ShowSymbol
        '
        Me.Col_ShowSymbol.FillWeight = 155.0824!
        Me.Col_ShowSymbol.HeaderText = "Symbol visible"
        Me.Col_ShowSymbol.Name = "Col_ShowSymbol"
        Me.Col_ShowSymbol.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Col_ShowSymbol.Width = 70
        '
        'Col_MovePoints
        '
        Me.Col_MovePoints.FillWeight = 144.8333!
        Me.Col_MovePoints.HeaderText = "Can move"
        Me.Col_MovePoints.Name = "Col_MovePoints"
        Me.Col_MovePoints.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Col_MovePoints.Width = 70
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33555!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33223!))
        Me.TableLayoutPanel2.Controls.Add(Me.RemoveB, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ChB_Legend, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(143, 37)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'RemoveB
        '
        Me.RemoveB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RemoveB.Location = New System.Drawing.Point(74, 3)
        Me.RemoveB.Name = "RemoveB"
        Me.RemoveB.Size = New System.Drawing.Size(66, 31)
        Me.RemoveB.TabIndex = 12
        Me.RemoveB.Text = "Remove"
        Me.RemoveB.UseVisualStyleBackColor = True
        '
        'ChB_Legend
        '
        Me.ChB_Legend.AutoSize = True
        Me.ChB_Legend.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChB_Legend.Location = New System.Drawing.Point(3, 3)
        Me.ChB_Legend.Name = "ChB_Legend"
        Me.ChB_Legend.Size = New System.Drawing.Size(65, 31)
        Me.ChB_Legend.TabIndex = 10
        Me.ChB_Legend.Text = "Legend"
        Me.ChB_Legend.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.CancelB, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.OkB, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(448, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(200, 37)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'CancelB
        '
        Me.CancelB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CancelB.Location = New System.Drawing.Point(103, 3)
        Me.CancelB.Name = "CancelB"
        Me.CancelB.Size = New System.Drawing.Size(94, 31)
        Me.CancelB.TabIndex = 3
        Me.CancelB.Text = "Cancel"
        Me.CancelB.UseVisualStyleBackColor = True
        '
        'OkB
        '
        Me.OkB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OkB.Location = New System.Drawing.Point(3, 3)
        Me.OkB.Name = "OkB"
        Me.OkB.Size = New System.Drawing.Size(94, 31)
        Me.OkB.TabIndex = 2
        Me.OkB.Text = "OK"
        Me.OkB.UseVisualStyleBackColor = True
        '
        'ChartSettingsDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(672, 395)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ChartSettingsDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings"
        Me.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents RemoveB As System.Windows.Forms.Button
    Friend WithEvents ChB_Legend As System.Windows.Forms.CheckBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CancelB As System.Windows.Forms.Button
    Friend WithEvents OkB As System.Windows.Forms.Button
    Friend WithEvents Col_ChooseCurve As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Col_ShowCurve As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Col_CurveName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_CurveColor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_CurveType As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Col_CurveWidth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_SymbolType As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Col_SymbolSize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_ShowSymbol As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Col_MovePoints As System.Windows.Forms.DataGridViewCheckBoxColumn

End Class
