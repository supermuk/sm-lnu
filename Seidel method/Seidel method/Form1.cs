using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Seidel_method
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView2.ColumnHeadersVisible = false;
            dataGridView2.RowHeadersVisible = false;
            dataGridView3.ColumnHeadersVisible = false;
            dataGridView3.RowHeadersVisible = false;
           
        }
        private const int MAX = 100000;
        private double Dist(double[] x1, double[] x2)
        {
            double max = 0;
            for (int i = 0; i < x1.Length; i++)
            {
                if (Math.Abs(x1[i] - x2[i]) > max)
                    max = Math.Abs(x1[i] - x2[i]);
            }
            return max;
        }
        private double Norm(double[][] arr)
        {
            double[] rows = new double[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                for(int j = 0; j < arr.Length; j++)
                {
                    rows[i] += Math.Abs(arr[i][j]);
                }
            }
            return Dist(rows, new double[arr.Length]);
        }
        private KeyValuePair<double[], int> IterativeMethod(double[][] a, double[] b, double[] x0, double eps)
        {
            double[] x;
            double d;
            int n = 0;
            do
            {
                x = new double[b.Length];
                n++;
                for (int i = 0; i < b.Length; i++)
                {
                    for (int j = 0; j < b.Length; j++)
                    {
                        if (i != j)
                        {
                            x[i] -= a[i][j] * x0[j] ;
                        }
                        else
                        {
                            x[i] += b[i] ;
                        }
                    }
                    x[i] /= a[i][i];
                }
                d = Dist(x0, x);
                x0 = x;
                if (n > MAX)
                    throw (new Exception("1"));
            } while (d  > eps);
            return new KeyValuePair<double[], int> (x, n);
        }

        private KeyValuePair<double[], int> SeidelMethod(double[][] a, double[] b, double[] x0, double eps)
        {
            double[] x;
            int n = 0;
            double d;
            do
            {
                x = new double[b.Length];
                n++;
                for (int i = 0; i < b.Length; i++)
                {
                    for (int j = 0; j < b.Length; j++)
                    {
                        if (j < i)
                        {
                            x[i] -= a[i][j] * x[j] ;
                        }
                        else
                        {
                            if (j > i)
                            {
                                x[i] -= a[i][j] * x0[j];
                            }
                            else
                            {
                                x[i] += b[i];
                            }
                        }
                    }
                    x[i] /= a[i][i];
                }
                d = Dist(x0, x);
                x0 = x;
                if (n > MAX)
                    throw (new Exception("1"));
            } while ( d > eps);
            return new KeyValuePair<double[], int>(x, n);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = (int)numericUpDown1.Value;
            double[][] a = new double[n][];
            for (int i = 0; i < n; i++)
            {
                a[i] = new double[n];
            }
            double[] b = new double[n];
            double[] x0 = new double[n];
            double eps = 1;


            try
            {
                eps = double.Parse(textBox1.Text);
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        a[i][j] = double.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString());
                    }
                    b[i] = double.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString());
                    x0[i] = double.Parse(dataGridView3.Rows[i].Cells[0].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Дані задані у невірному форматі!");
            }


            double[][] c = new double[n][];

            for (int i = 0; i < n; i++)
            {
                c[i] = new double[n];
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        try
                        {
                            c[i][j] = -a[i][j] / a[i][i];
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Діагональний елемент не може бути 0!");
                        }
                    }
                    else
                    {
                        c[i][j] = 0;
                    }

                }
            }

            try
            {
                
           
                KeyValuePair<double[], int> Iterative = IterativeMethod(a, b, x0, eps);
                KeyValuePair<double[], int> Seidel = SeidelMethod(a, b, x0, eps);


              

                int m = 1;
                double tmp = 0.1;
                while( tmp > eps)
                {
                    tmp *= 0.1;
                    m++;
                }

                textBox2.Text = "x = (";
                foreach (double x in Iterative.Key)
                    if(x != Iterative.Key[Iterative.Key.Length-1])
                        textBox2.Text += Math.Round(x, m).ToString() + ", ";
                textBox2.Text +=  Math.Round(Iterative.Key[Iterative.Key.Length-1], m).ToString() + ") \r\n";
                textBox2.Text += "n = " + Iterative.Value.ToString() + " \r\n";
                textBox2.Text += "||C|| = " + Math.Round(Norm(c), 3).ToString();

                textBox3.Text = "x = (";
                foreach (double x in Seidel.Key)
                    if( x != Seidel.Key[Seidel.Key.Length -1])
                        textBox3.Text += Math.Round(x, m).ToString() + ", ";
                textBox3.Text += Math.Round(Seidel.Key[Seidel.Key.Length -1], m).ToString() + ") \r\n";
                textBox3.Text += "n = " + Seidel.Value.ToString() + "\r\n";
                textBox3.Text += "||CL + CU|| = " + Math.Round(Norm(c), 3).ToString();
            }
            catch (Exception ex)
            {
                if (ex.Message == "1")
                {
                    MessageBox.Show("Не виконується достатня умова збіжності ітераційного методу! \r\n ||C|| = " + Norm(c).ToString() + " > 1");
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView2.Columns.Clear();
            dataGridView3.Columns.Clear();
            dataGridView2.Columns.Add("1", "");
            dataGridView2.Columns[0].Width = 50;
            dataGridView3.Columns.Add("1", "");
            dataGridView3.Columns[0].Width = 50;

            for(int i =0; i < numericUpDown1.Value; i++)
            {
                dataGridView1.Columns.Add(i.ToString(), i.ToString());
                dataGridView1.Columns[i].Width = 50;
                dataGridView1.Rows.Add(1);

                dataGridView2.Rows.Add(1);
                dataGridView3.Rows.Add(1);

            }
        }
    }
}

