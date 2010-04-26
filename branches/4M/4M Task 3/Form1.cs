using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _4M_Task_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            GridMethod gm = new GridMethod
            {
                p = new Parser { Formula = textBox1.Text },
                q = new Parser { Formula = textBox2.Text },
                f = new Parser { Formula = textBox3.Text },
                a0 = double.Parse(textBox4.Text),
                a1 = double.Parse(textBox6.Text),
                b0 = double.Parse(textBox5.Text),
                b1 = double.Parse(textBox7.Text),
                A = double.Parse(textBox8.Text),
                B = double.Parse(textBox9.Text),
                a = double.Parse(textBox10.Text),
                b = double.Parse(textBox11.Text),
                n = (int)numericUpDown1.Value,
                DataView = dataGridView1
            };
            gm.Calculate();
        }



    }
}
