using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _4M_Task_3
{
    class GridMethod
    {
        public DataGridView DataView { get; set; }

        public Parser p { get; set; }
        public Parser q { get; set; }
        public Parser f { get; set; }

        public double a { get; set; }
        public double b { get; set; }

        public double a0 { get; set; }
        public double a1 { get; set; }

        public double b0 { get; set; }
        public double b1 { get; set; }

        public double A { get; set; }
        public double B { get; set; }

        public int n { get; set; }

        private List<double> Ak = new List<double>();
        private List<double> Bk = new List<double>();
        private List<double> Ck = new List<double>();
        private List<double> Fk = new List<double>();

        private List<double> xk = new List<double>();

        private List<double> lk = new List<double>();
        private List<double> dk = new List<double>();

        private List<double> yk = new List<double>();

        private double h;

        public void Calculate()
        {
            h = (b - a) / n;
            xk.Clear();
            for (int i = 0; i <= n; i++)
            {
                xk.Add(a + h * i);
            }

            Ak.Clear();
            Bk.Clear();
            Ck.Clear();
            Fk.Clear();
            lk.Clear();
            dk.Clear();
            yk.Clear();

            CalcCoefsABC();

            calcCoefsLD();
            yk.Add((h * B - b1 * dk[n - 1]) / (b1 - b1 * lk[n - 1] + b0 * h));
            //yk.Add((h * B + dk[n - 1]) / (h * b0 + b1 * lk[n - 1]));
            for (int i = n - 1; i >= 0; i--)
            {
                yk.Add(lk[i] * yk[yk.Count - 1] + dk[i]);
            }
            yk.Reverse();
            printResults();
        }

        private void CalcCoefsABC()
        {
            for (int i = 0; i <= n; i++)
            {
                Ak.Add(1 + p.Calculate(xk[i]) * h / 2);
                Bk.Add(h * h * q.Calculate(xk[i]) - 2);
                Ck.Add(1 - p.Calculate(xk[i]) * h / 2);
                Fk.Add(h * h * f.Calculate(xk[i]));
            }
        }

        private void calcCoefsLD()
        {

            lk.Add(a1 / (a1 - h * a0));
            dk.Add(h * A / (h * a0 - a1));

            for (int i = 1; i <= n; i++)
            {
                lk.Add( - Ak[i] / (Bk[i] + Ck[i] * lk[i - 1]));
                dk.Add((Fk[i] -  Ck[i] * dk[i - 1] ) / (Bk[i] + Ck[i] * lk[i - 1]));
            }

        }
        private void printResults()
        {
            for (int i = 0; i <= n; i++)
            {
                DataView.Rows.Add(i, xk[i], Ak[i], Bk[i], Ck[i], Fk[i], lk[i], dk[i], yk[i]);
            }
        }
    }
}
