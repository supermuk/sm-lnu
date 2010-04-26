using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _4M_Task_1
{
    public partial class Form1 : Form
    {
        private List<NumericalIntegration> methods = new List<NumericalIntegration>();

        public Form1()
        {
            InitializeComponent();

            methods.Add(new RectangleRule());
            methods.Add(new TrapezoidalRule());
            methods.Add(new SimpsonsRule());
            methods.Add(new GaussMethod());
            methods.Add(new ChebyshevMethod());

            dataGridView1.Columns.Add("1", "Метод");
            dataGridView1.Columns.Add("2", "Значення");
            dataGridView1.Columns.Add("3", "Проміжки");
            dataGridView1.Columns.Add("4", "Похибка");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            double a = double.Parse(tbA.Text);
            double b = double.Parse(tbB.Text);
            double eps = double.Parse(tbEps.Text);

            Parser parser = new Parser();
            parser.Formula = tbF.Text;
            double exactValue = parser.Calculate(b) - parser.Calculate(a);

            foreach (NumericalIntegration method in methods)
            {
                KeyValuePair<double, int> res = method.CalculateIntegral(a, b, eps, tbI.Text);
                dataGridView1.Rows.Add(method.ToString(), res.Key, res.Value, Math.Abs(exactValue - res.Key));
            }
            dataGridView1.Rows.Add("Точне значення", exactValue.ToString(), "", "");
            
           


        }
    }
}
