using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Macroprocessor
{
    public partial class Form1 : Form
    {
        public Form2 Properties = new Form2();
        Processor MacroProcessor = new Processor();

        public Form1()
        {
            InitializeComponent();
        }
        private void compileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = MacroProcessor.Compile(textBox1.Text);
            }
            catch (Exception ex)
            {
                textBox3.Text += ex.Message;
            }
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.ShowDialog() == DialogResult.OK)
            {
                MacroProcessor.BeginMacro = Properties.BeginMacro;
                MacroProcessor.EndMacro = Properties.EndMacro;
                MacroProcessor.Include = Properties.Include;
                MacroProcessor.IncludePath = Properties.IncludePath;
                MacroProcessor.MaxIncludeDepth = Properties.IncludeDepth;
            }
            else
            {
                Properties.BeginMacro = MacroProcessor.BeginMacro;
                Properties.EndMacro = MacroProcessor.EndMacro;
                Properties.Include = MacroProcessor.Include;
                Properties.IncludePath = MacroProcessor.IncludePath;
                Properties.IncludeDepth = MacroProcessor.MaxIncludeDepth;
            }
        }
    }
}
