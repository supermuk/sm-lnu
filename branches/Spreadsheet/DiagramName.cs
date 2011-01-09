using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Spreadsheetq
{
    public partial class DiagramName : Form
    {
        public string Name;
        public string NameX;
        public string NameY;
        public DiagramName()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Name = textBox1.Text;
            NameX = textBox2.Text;
            NameY = textBox3.Text;
        }
    }
}
