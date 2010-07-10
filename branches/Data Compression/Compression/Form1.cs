using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Collections;

namespace Compression
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        StringBuilder lastOutput = new StringBuilder();
        StringBuilder lastInput = new StringBuilder();


        private void button1_Click(object sender, EventArgs e)
        {
          //  MessageBox.Show(((int)'ф').ToString());
            StringBuilder input = new StringBuilder(tbInput.Text);
            StringBuilder outputDemo = new StringBuilder();
            StringBuilder outputReal = new StringBuilder();
            try
            {
                if (rbRLE.Checked)
                {
                    if (rbEncode.Checked)
                    {
                        outputDemo = RLE.EncodeDemo(input);
                        outputReal = RLE.EncodeReal(input);
                    }
                    if (rbDecode.Checked)
                    {
                        outputDemo = RLE.Decode(input);
                        outputReal = outputDemo;
                    }
                }
                if (rbSF.Checked)
                {
                    if (rbEncode.Checked)
                    {
                        outputDemo = ShennonFano.EncodeDemo(input);
                        outputReal = ShennonFano.EncodeReal(input);
                    }
                    if (rbDecode.Checked)
                    {
                        outputDemo = ShennonFano.Decode(lastInput);
                        outputReal = outputDemo;
                    }

                }
                if (rbLZW.Checked)
                {
                    if (rbEncode.Checked)
                    {
                        outputDemo = LZW.EncodeDemo(input, (int)numericUpDown1.Value);
                        outputReal = LZW.EncodeReal(input,(int) numericUpDown1.Value);
                    }
                    if (rbDecode.Checked)
                    {
                        outputDemo = LZW.Decode(lastInput, (int)numericUpDown1.Value);
                        outputReal = outputDemo;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            tbOutputDemo.Text = outputDemo.ToString();
            tbOutputReal.Text = Replace(outputReal).ToString();
            lastOutput = outputReal;
            tbCompression.Text = "Вхідний текст: " + lastInput.Length + " символів\r\n";
            tbCompression.Text += "Вихідний текст: \r\n" + lastOutput.Length + " символів\r\n";
            tbCompression.Text += "Процент стисненя: " + Math.Round((((double)lastOutput.Length / (double)lastInput.Length) * 100.0), 2) + "%";
        }
        private StringBuilder Replace(StringBuilder s)
        {
            StringBuilder tmp = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != '\0')
                {
                    tmp.Append(s[i]);
                }
            }
            return tmp;
        }
        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                for(int i = 0; i < lastOutput.Length; i++)
                {
                    sw.Write(lastOutput[i]);
                }
                sw.Close();
            }
        }

        private void відкритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                lastInput = new StringBuilder();
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                lastInput.Append(sr.ReadToEnd());
                StringBuilder copy = lastInput;
                tbInput.Text = copy.ToString();
                lastInput = copy;
              

                sr.Close();
            }
        }

        private void tbInput_TextChanged(object sender, EventArgs e)
        {
            lastInput = new StringBuilder(tbInput.Text);
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lastInput = lastOutput;
            StringBuilder copy = lastInput;
            tbInput.Text = Replace(copy).ToString();
            lastInput = copy;
        }

  
    }
}
