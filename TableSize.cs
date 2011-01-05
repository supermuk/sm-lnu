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
    public partial class TableSize : Form
    {
        public int RowCount = 20;
        public int ColumCount = 20;

        public TableSize()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            RowCount = int.Parse(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ColumCount = int.Parse(textBox2.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

    }
}
