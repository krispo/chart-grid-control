Public Class MainF
    Private ChartGridControl1 As ChartGridControl.ChartGridControl

    Private Sub MainF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        addTab()
    End Sub

    Private Sub addTab(Optional ByVal name As String = "New Tab")
        ChartGridControl1 = New ChartGridControl.ChartGridControl
        ChartGridControl1.Dock = DockStyle.Fill

        Dim G_ObjectTab As System.Windows.Forms.TabPage
        G_ObjectTab = New System.Windows.Forms.TabPage(name)

        G_ObjectTab.Controls.Add(ChartGridControl1)
        G_ObjectTab.Tag = ChartGridControl1

        TabControl1.TabPages.Add(G_ObjectTab)
    End Sub

    Private Sub removeTab(ByVal idx As Integer)
        If TabControl1.TabCount > 0 Then
            TabControl1.TabPages.RemoveAt(idx)
        End If
        GC.Collect()
    End Sub

    'Tool Strip Menu
    Private Sub NewOpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewOpenToolStripMenuItem.Click
        addTab(InputBox("Please, enter a name for this Tab:", "Input dialog", "New Tab"))
        TabControl1.SelectedIndex = TabControl1.TabCount - 1
    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        If TabControl1.TabCount > 0 Then
            ChartGridControl1 = TabControl1.SelectedTab.Tag
            ChartGridControl1.B_Add_Click(sender, e)
        End If
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        removeTab(TabControl1.SelectedIndex)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseAllToolStripMenuItem.Click
        TabControl1.TabPages.Clear()
        GC.Collect()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        If TabControl1.TabCount > 0 Then
            ChartGridControl1 = TabControl1.SelectedTab.Tag
            ChartGridControl1.B_Save_Click(sender, e)
        End If
    End Sub

    Private Sub QuitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        AboutF.ShowDialog()
    End Sub

    'Tab Context Menu
    Private Sub TabContMenu_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TabContMenu.Opening
        Dim p As Point = Control.MousePosition
        Dim rTab As Rectangle
        For i = 0 To TabControl1.TabCount - 1
            rTab = TabControl1.RectangleToScreen(TabControl1.GetTabRect(i))
            If rTab.Contains(p) Then
                TabControl1.SelectedIndex = i
                Exit For
            End If
        Next
    End Sub

    Private Sub CloseObjMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseObjMenuItem.Click
        Dim idx As Integer = TabControl1.SelectedIndex
        removeTab(idx)
        If idx > TabControl1.TabCount - 1 And TabControl1.TabCount > 0 Then
            TabControl1.SelectedIndex = TabControl1.TabCount - 1
        ElseIf TabControl1.TabCount > 0 Then
            TabControl1.SelectedIndex = idx
        End If
    End Sub

    Private Sub RenObjMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RenObjMenuItem.Click
        TabControl1.SelectedTab.Text = InputBox("Please, enter a new name for this Tab:", "Input dialog", TabControl1.SelectedTab.Text)
    End Sub
End Class
