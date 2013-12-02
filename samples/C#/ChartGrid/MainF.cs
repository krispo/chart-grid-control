using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using ChartGridControl;

namespace ChartGrid
{
    public partial class MainF : Form
    {
        private ChartGridControl.ChartGridControl ChartGridControl1;

        public MainF()
        {
            InitializeComponent();
        }

        private void MainF_Load(object sender, EventArgs e)
        {
            addTab();
        }

        private void addTab(string name = "New Tab")
        {
            ChartGridControl1 = new ChartGridControl.ChartGridControl();
            ChartGridControl1.Dock = DockStyle.Fill;

            System.Windows.Forms.TabPage G_ObjectTab;
            G_ObjectTab = new System.Windows.Forms.TabPage(name);

            G_ObjectTab.Controls.Add(ChartGridControl1);
            G_ObjectTab.Tag = ChartGridControl1;

            TabControl1.TabPages.Add(G_ObjectTab);
        }

        private void removeTab(int idx)
        {
            if (TabControl1.TabCount > 0)
            {
                TabControl1.TabPages.RemoveAt(idx);
            }
            GC.Collect();
        }

        // Too Strop Menu
        private void NewOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addTab(Interaction.InputBox("Please, enter a name for this Tab:", "Input dialog", "New Tab"));
            TabControl1.SelectedIndex = TabControl1.TabCount - 1;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TabControl1.TabCount > 0)
            {
                ChartGridControl1 = (ChartGridControl.ChartGridControl)TabControl1.SelectedTab.Tag;
                ChartGridControl1.B_Add_Click(sender, e);
            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removeTab(TabControl1.SelectedIndex);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabControl1.TabPages.Clear();
            GC.Collect();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TabControl1.TabCount > 0)
            {
                ChartGridControl1 = (ChartGridControl.ChartGridControl)TabControl1.SelectedTab.Tag;
                ChartGridControl1.B_Save_Click(sender, e);
            }
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutF about = new AboutF();
            about.ShowDialog();
        }

        // Tab Context Menu
        private void TabContMenu_Opening(object sender, CancelEventArgs e)
        {
            Point p = Control.MousePosition;
            Rectangle rTab;
            for (int i = 0; i <= TabControl1.TabCount - 1; i++)
            {
                rTab = TabControl1.RectangleToScreen(TabControl1.GetTabRect(i));
                if (rTab.Contains(p))
                {
                    TabControl1.SelectedIndex = i;
                    break;
                }
            }
        }

        private void CloseObjMenuItem_Click(object sender, EventArgs e)
        {
            int idx = TabControl1.SelectedIndex;
            removeTab(idx);
            if (idx > TabControl1.TabCount - 1 & TabControl1.TabCount > 0)
            {
                TabControl1.SelectedIndex = TabControl1.TabCount - 1;
            }
            else
            {
                if (TabControl1.TabCount > 0) TabControl1.SelectedIndex = idx;
            }
        }

        private void RenObjMenuItem_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab.Text = Interaction.InputBox("Please, enter a new name for this Tab:", "Input dialog", TabControl1.SelectedTab.Text);
        }
    }
}