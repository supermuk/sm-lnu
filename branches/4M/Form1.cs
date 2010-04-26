using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _4M_Task_2
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

            Parser func = new Parser();
            func.Formula = textBox1.Text;
            Point m0 = new Point
            {
                X = double.Parse(textBox2.Text),
                Y = double.Parse(textBox3.Text)
            };
            double eps = double.Parse(textBox4.Text);
            double h = double.Parse(textBox5.Text);
            double a = double.Parse(textBox6.Text);
            double b = double.Parse(textBox7.Text);
            Parser correctFunc = new Parser();
            correctFunc.Formula = textBox8.Text;

            RungeKuttaMethod rkm = new RungeKuttaMethod
            {
                A = a,
                B = a + 3 * h,
                Eps = eps,
                H = h,
                Func = func,
                CorrectFunc = correctFunc,
                DataView = dataGridView1,
                M0 = m0,
                PointsCount = 4
            };
            AdamsExtrapolationMethod adex = new AdamsExtrapolationMethod
            {
                A = a,
                B = b,
                Eps = eps,
                H = h,
                Func = func,
                CorrectFunc = correctFunc,
                DataView = dataGridView1,
                Points = rkm.Calculate()
            };
            adex.Calculate();
        }
    }
}
