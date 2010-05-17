using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Cryptograph
{
    public partial class MainForm : Form
    {
        protected BaseCipher cipher;
        protected Alphabets alphabet;


        public MainForm()
        {
            InitializeComponent();
            alphabet = Alphabets.Latin;
            cipher = new CeaserCipher
            {
                KeyBox = groupBox2,
                Alphabet = alphabet
            };
        }


        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            alphabet = Alphabets.Latin;
            cipher.Alphabet = alphabet;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            alphabet = Alphabets.Ukrainian;
            cipher.Alphabet = alphabet;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            cipher = new CeaserCipher
            {
                KeyBox = groupBox2,
                Alphabet = alphabet
            };
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            cipher = new PicketFenceCipher
            {
                KeyBox = groupBox2,
                Alphabet = alphabet
            };
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            cipher = new SimpleReplacementCipher
            {
                KeyBox = groupBox2,
                Alphabet = alphabet
            };
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            cipher = new VigenereCipher
            {
                KeyBox = groupBox2,
                Alphabet = alphabet
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = cipher.Encode(textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox3.Text = cipher.Decode(textBox2.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                textBox3.Text = cipher.Hack(textBox2.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            AnalizerForm af = new AnalizerForm();
            af.Show();
        }

        private void textBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                StreamReader sr = new StreamReader(file);
                (sender as TextBox).Text += sr.ReadToEnd();
            }
        }

        private void textBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

    }
}
