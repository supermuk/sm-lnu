using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ZedGraph;
namespace Spreadsheetq
{
    public partial class Form1 : Form
    {
        private bool selectX = false;
        private bool selectY = false;
        private double[] x;
        private double[] y;

        public Form1()
        {
            InitializeComponent();
            spreadsheet1.Changed += new EventHandler(newSheet_Changed);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AddTab()
        {
            int pos = tabControl1.TabPages.Count;
            TabPage page = new TabPage("Untiteled sheet");
            Spreadsheet newSheet = new Spreadsheet();
            newSheet.Dock = DockStyle.Fill;
            newSheet.Changed += new EventHandler(newSheet_Changed);
            page.Controls.Add(newSheet);
            tabControl1.TabPages.Add(page);
            tabControl1.SelectTab(pos);
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage.Name == "NewSheet")
            {
            //    AddTab();
            }
            Spreadsheet s = ((Spreadsheet)tabControl1.SelectedTab.Controls[0]);
            toolStripButton2.Enabled = s.CanUndo();
            toolStripButton3.Enabled = s.CanRedo();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Spreadsheet s = ((Spreadsheet)tabControl1.SelectedTab.Controls[0]);
            s.Undo();
            toolStripButton2.Enabled = s.CanUndo();
            toolStripButton3.Enabled = s.CanRedo();

        }   

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Spreadsheet s = ((Spreadsheet)tabControl1.SelectedTab.Controls[0]);
            s.Redo();
            toolStripButton2.Enabled = s.CanUndo();
            toolStripButton3.Enabled = s.CanRedo();
        }

        private void newSheet_Changed(object sender, EventArgs e)
        {
            Spreadsheet s = ((Spreadsheet)tabControl1.SelectedTab.Controls[0]);
            toolStripButton2.Enabled = s.CanUndo();
            toolStripButton3.Enabled = s.CanRedo();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Spreadsheet s = ((Spreadsheet)tabControl1.SelectedTab.Controls[0]);
            if (s.CanUndo())
            {
                s.Undo();
                toolStripButton2.Enabled = s.CanUndo();
                toolStripButton3.Enabled = s.CanRedo();
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Spreadsheet s = ((Spreadsheet)tabControl1.SelectedTab.Controls[0]);
            if (s.CanRedo())
            {
                s.Redo();
                toolStripButton2.Enabled = s.CanUndo();
                toolStripButton3.Enabled = s.CanRedo();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AddTab();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Spreadsheet s = ((Spreadsheet)tabControl1.SelectedTab.Controls[0]);
            SaveToFile(s.SaveFile());
        }

        private void SaveToFile(string text)
        {
            saveFileDialog1.DefaultExt = "csv";
            saveFileDialog1.Filter = "Spreadsheet File|*.csv";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string name = saveFileDialog1.FileName;
                StreamWriter sw = new StreamWriter(name);
                sw.Write(text);
                sw.Close();
                tabControl1.SelectedTab.Text = name.Substring(name.LastIndexOf('\\') + 1);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Spreadsheet s = ((Spreadsheet)tabControl1.SelectedTab.Controls[0]);
            openFileDialog1.Filter = "Spreadsheet File|*.csv";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                s.OpenFile(sr.ReadToEnd());
                tabControl1.SelectedTab.Text = openFileDialog1.SafeFileName;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Spreadsheet s = ((Spreadsheet)tabControl1.SelectedTab.Controls[0]);
            SaveToFile(s.SaveFile());
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTab();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("All data will be lost! You really whant to continue?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Spreadsheet s = ((Spreadsheet)tabControl1.SelectedTab.Controls[0]);
                TableSize dialog = new TableSize();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (dialog.RowCount > 0 && dialog.ColumCount > 0)
                    {
                        s.CreateTable(dialog.RowCount, dialog.ColumCount);
                    }
                    else
                    {
                        MessageBox.Show("но-но");
                    }
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Spreadsheet s = ((Spreadsheet)tabControl1.SelectedTab.Controls[0]);
            openFileDialog1.Filter = "Spreadsheet File|*.csv";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                s.OpenFile(sr.ReadToEnd());
                tabControl1.SelectedTab.Text = openFileDialog1.SafeFileName;
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Spreadsheet s = ((Spreadsheet)tabControl1.SelectedTab.Controls[0]);
            if (selectX && selectY)
            {
                y = s.GetSelectedArray();
                Diagram d = new Diagram(x, y);
                d.Show();
                selectX = false;
                selectY = false;
            }
            else
            {
                if (!selectX)
                {
                    selectX = true;
                    MessageBox.Show("Виберіть значення х");
                }
                else
                {
                    x = s.GetSelectedArray();
                    selectY = true;
                    MessageBox.Show("Виберіть значення у");
                }
            }
        }
    }
}
