<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChartGridControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.GB_Info = New System.Windows.Forms.GroupBox()
        Me.TB_Log = New System.Windows.Forms.TextBox()
        Me.DGV1 = New System.Windows.Forms.DataGridView()
        Me.DateCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVContMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.UndoMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowCellMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.CellToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZG1 = New ZedGraph.ZedGraphControl()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.B_Save = New System.Windows.Forms.Button()
        Me.B_Add = New System.Windows.Forms.Button()
        Me.CurDate = New System.Windows.Forms.DateTimePicker()
        Me.B_Settings = New System.Windows.Forms.Button()
        Me.UndoMI_copy = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.GB_Info.SuspendLayout()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DGVContMenu.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(984, 400)
        Me.SplitContainer1.SplitterDistance = 359
        Me.SplitContainer1.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.SplitContainer3)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.ZG1)
        Me.SplitContainer2.Size = New System.Drawing.Size(984, 359)
        Me.SplitContainer2.SplitterDistance = 230
        Me.SplitContainer2.TabIndex = 1
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.GB_Info)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.DGV1)
        Me.SplitContainer3.Size = New System.Drawing.Size(230, 359)
        Me.SplitContainer3.SplitterDistance = 93
        Me.SplitContainer3.TabIndex = 0
        '
        'GB_Info
        '
        Me.GB_Info.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GB_Info.Controls.Add(Me.TB_Log)
        Me.GB_Info.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GB_Info.Location = New System.Drawing.Point(0, 0)
        Me.GB_Info.MaximumSize = New System.Drawing.Size(9999, 9050)
        Me.GB_Info.MinimumSize = New System.Drawing.Size(1, 1)
        Me.GB_Info.Name = "GB_Info"
        Me.GB_Info.Size = New System.Drawing.Size(230, 93)
        Me.GB_Info.TabIndex = 6
        Me.GB_Info.TabStop = False
        Me.GB_Info.Text = "Info"
        '
        'TB_Log
        '
        Me.TB_Log.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_Log.BackColor = System.Drawing.SystemColors.Control
        Me.TB_Log.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TB_Log.Location = New System.Drawing.Point(6, 19)
        Me.TB_Log.Multiline = True
        Me.TB_Log.Name = "TB_Log"
        Me.TB_Log.ReadOnly = True
        Me.TB_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TB_Log.Size = New System.Drawing.Size(218, 68)
        Me.TB_Log.TabIndex = 0
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DateCol})
        Me.DGV1.ContextMenuStrip = Me.DGVContMenu
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGV1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV1.Enabled = False
        Me.DGV1.Location = New System.Drawing.Point(0, 0)
        Me.DGV1.Name = "DGV1"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV1.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DGV1.RowHeadersVisible = False
        Me.DGV1.Size = New System.Drawing.Size(230, 262)
        Me.DGV1.TabIndex = 2
        '
        'DateCol
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DateCol.DefaultCellStyle = DataGridViewCellStyle2
        Me.DateCol.Frozen = True
        Me.DateCol.HeaderText = "Time"
        Me.DateCol.Name = "DateCol"
        Me.DateCol.ReadOnly = True
        Me.DateCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DateCol.Width = 80
        '
        'DGVContMenu
        '
        Me.DGVContMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyMI, Me.PasteMI, Me.UndoMI, Me.ShowCellMI})
        Me.DGVContMenu.Name = "TabContMenu"
        Me.DGVContMenu.Size = New System.Drawing.Size(145, 92)
        '
        'CopyMI
        '
        Me.CopyMI.Name = "CopyMI"
        Me.CopyMI.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CopyMI.Size = New System.Drawing.Size(144, 22)
        Me.CopyMI.Text = "Copy"
        '
        'PasteMI
        '
        Me.PasteMI.Name = "PasteMI"
        Me.PasteMI.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.PasteMI.Size = New System.Drawing.Size(144, 22)
        Me.PasteMI.Text = "Paste"
        '
        'UndoMI
        '
        Me.UndoMI.Name = "UndoMI"
        Me.UndoMI.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.UndoMI.Size = New System.Drawing.Size(144, 22)
        Me.UndoMI.Text = "Undo"
        '
        'ShowCellMI
        '
        Me.ShowCellMI.CheckOnClick = True
        Me.ShowCellMI.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CellToolStripMenuItem})
        Me.ShowCellMI.Name = "ShowCellMI"
        Me.ShowCellMI.Size = New System.Drawing.Size(144, 22)
        Me.ShowCellMI.Text = "Highlight"
        '
        'CellToolStripMenuItem
        '
        Me.CellToolStripMenuItem.Name = "CellToolStripMenuItem"
        Me.CellToolStripMenuItem.Size = New System.Drawing.Size(94, 22)
        Me.CellToolStripMenuItem.Text = "Cell"
        '
        'ZG1
        '
        Me.ZG1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.ZG1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ZG1.Enabled = False
        Me.ZG1.Location = New System.Drawing.Point(0, 0)
        Me.ZG1.Name = "ZG1"
        Me.ZG1.ScrollGrace = 0.0R
        Me.ZG1.ScrollMaxX = 0.0R
        Me.ZG1.ScrollMaxY = 0.0R
        Me.ZG1.ScrollMaxY2 = 0.0R
        Me.ZG1.ScrollMinX = 0.0R
        Me.ZG1.ScrollMinY = 0.0R
        Me.ZG1.ScrollMinY2 = 0.0R
        Me.ZG1.Size = New System.Drawing.Size(750, 359)
        Me.ZG1.TabIndex = 7
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.87805!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.04065!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.04065!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.93902!))
        Me.TableLayoutPanel1.Controls.Add(Me.B_Save, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.B_Add, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CurDate, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.B_Settings, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(984, 37)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'B_Save
        '
        Me.B_Save.Dock = System.Windows.Forms.DockStyle.Fill
        Me.B_Save.Location = New System.Drawing.Point(839, 3)
        Me.B_Save.Name = "B_Save"
        Me.B_Save.Size = New System.Drawing.Size(142, 31)
        Me.B_Save.TabIndex = 51
        Me.B_Save.Text = "Save"
        Me.B_Save.UseVisualStyleBackColor = True
        '
        'B_Add
        '
        Me.B_Add.Dock = System.Windows.Forms.DockStyle.Fill
        Me.B_Add.Location = New System.Drawing.Point(691, 3)
        Me.B_Add.Name = "B_Add"
        Me.B_Add.Size = New System.Drawing.Size(142, 31)
        Me.B_Add.TabIndex = 49
        Me.B_Add.Text = "Add"
        Me.B_Add.UseVisualStyleBackColor = True
        '
        'CurDate
        '
        Me.CurDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CurDate.CustomFormat = "dd/MM/yyyy; HH' hs'"
        Me.CurDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.CurDate.Location = New System.Drawing.Point(3, 8)
        Me.CurDate.Name = "CurDate"
        Me.CurDate.Size = New System.Drawing.Size(130, 20)
        Me.CurDate.TabIndex = 47
        '
        'B_Settings
        '
        Me.B_Settings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.B_Settings.Location = New System.Drawing.Point(543, 3)
        Me.B_Settings.Name = "B_Settings"
        Me.B_Settings.Size = New System.Drawing.Size(142, 31)
        Me.B_Settings.TabIndex = 48
        Me.B_Settings.Text = "Settings"
        Me.B_Settings.UseVisualStyleBackColor = True
        '
        'UndoMI_copy
        '
        Me.UndoMI_copy.Name = "UndoMI_copy"
        Me.UndoMI_copy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.UndoMI_copy.Size = New System.Drawing.Size(282, 22)
        Me.UndoMI_copy.Text = "Undo"
        '
        'ChartGridControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "ChartGridControl"
        Me.Size = New System.Drawing.Size(984, 400)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.GB_Info.ResumeLayout(False)
        Me.GB_Info.PerformLayout()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DGVContMenu.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents GB_Info As System.Windows.Forms.GroupBox
    Friend WithEvents TB_Log As System.Windows.Forms.TextBox
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents ZG1 As ZedGraph.ZedGraphControl
    Friend WithEvents DGVContMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopyMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UndoMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UndoMI_copy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowCellMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CellToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CurDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents B_Settings As System.Windows.Forms.Button
    Friend WithEvents B_Add As System.Windows.Forms.Button
    Friend WithEvents DateCol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents B_Save As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog

End Class
