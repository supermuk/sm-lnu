using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SlavkoSuperPrint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = int.Parse(textBox1.Text);
            if (n % 4 != 0)
            {
                MessageBox.Show("N не ділиться на 4");
                return;
            }
            textBox2.Text = "";
            for (int i = 0; i < n/4; i++)
            {
                textBox2.Text += n - 2 * i;
                textBox2.Text += ",";
                textBox2.Text += 1 + 2 * i;
                if (i != n / 4 - 1)
                {
                    textBox2.Text += ",";
                }
            }

            textBox3.Text = "";
            for (int i = 0; i < n / 4; i++)
            {
                textBox3.Text += n / 2 - 2 * i;
                textBox3.Text += ",";
                textBox3.Text += n / 2 + 1 + 2 * i;
                if (i != n / 4 - 1)
                {
                    textBox3.Text += ",";
                }

            }
        }
    }
}
