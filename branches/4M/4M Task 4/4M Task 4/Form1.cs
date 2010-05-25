using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _4M_Task_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CollocationMethod method = new CollocationMethod
            {
                p = new Parser { Formula = textBox1.Text },
                q = new Parser { Formula = textBox2.Text },
                f = new Parser { Formula = textBox3.Text },
                a1 = double.Parse(textBox4.Text),
                a0 = double.Parse(textBox5.Text),
                b1 = double.Parse(textBox7.Text),
                b0 = double.Parse(textBox6.Text),
                A = double.Parse(textBox9.Text),
                B = double.Parse(textBox8.Text),
                a = double.Parse(textBox12.Text),
                b = double.Parse(textBox11.Text),
                n = int.Parse(textBox10.Text),
                yCorrect = new Parser { Formula = textBox13.Text },
                DataView = dataGridView1,
                Un = new Parser { Formula = textBox14.Text }
            };
            method.Calculate();
        }
    }
}
