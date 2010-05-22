using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cryptograph
{
    public partial class DiffieHellman : Form
    {
        public DiffieHellman()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            LongInt q = LongInt.Parse(textBox2.Text);
            LongInt p = LongInt.Parse(textBox1.Text); 
            LongInt a = LongInt.Parse(textBox3.Text);
            textBox5.Text = q.PowWithMod(a, p).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LongInt q = LongInt.Parse(textBox2.Text);
            LongInt p = LongInt.Parse(textBox1.Text);
            LongInt b = LongInt.Parse(textBox4.Text);
            textBox10.Text = q.PowWithMod(b, p).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox9.Text = textBox5.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox6.Text = textBox10.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LongInt p = LongInt.Parse(textBox1.Text);
            LongInt a = LongInt.Parse(textBox3.Text);
            LongInt fromBob = LongInt.Parse(textBox6.Text);
            textBox7.Text = fromBob.PowWithMod(a, p).ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LongInt p = LongInt.Parse(textBox1.Text);
            LongInt b = LongInt.Parse(textBox4.Text);
            LongInt fromAlice = LongInt.Parse(textBox5.Text);
            textBox8.Text = fromAlice.PowWithMod(b, p).ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            LongInt p = LongInt.Parse(textBox1.Text);

            textBox3.Text = LongInt.GenerateRandom(p).ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            LongInt p = LongInt.Parse(textBox1.Text);

            textBox4.Text = LongInt.GenerateRandom(p).ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LongInt a = LongInt.Parse(textBox1.Text);
            LongInt b = LongInt.Parse(textBox2.Text);
            textBox3.Text = (a / b).ToString();
        }
    }
}
