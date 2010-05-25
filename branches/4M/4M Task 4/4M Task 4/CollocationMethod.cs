using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _4M_Task_4
{
    class CollocationMethod
    {
        public Parser p { get; set; }
        public Parser q { get; set; }
        public Parser f { get; set; }

        public double a1 { get; set; }
        public double a0 { get; set; }
        public double b1 { get; set; }
        public double b0 { get; set; }

        public int n { get; set; }

        public double a { get; set; }
        public double b { get; set; }

        public double A { get; set; }
        public double B { get; set; }


        public Parser yCorrect { get; set; }

        public Parser Un;

        private List<double> Xn = new List<double>();

        public DataGridView DataView { get; set; }

        public void Calculate()
        {
            //Un = new Parser { Formula = "x^(2*y - 2)*(1 - x^2 ) " };//* (x" + (a < 0 ? "+" + Math.Abs(a) : "-" + Math.Abs(a)) + ")*(x" + (b < 0 ? "+" + Math.Abs(b) : "-" + Math.Abs(b)) + ")" };
            Matrix lMatrix = new Matrix(n, n);
            Matrix fMatrix = new Matrix(n, 1);

            Xn.Clear();
            double h = (b - a) / (n + 1);
            Random rand = new Random();
            for (int i = n; i > 0; i--)
            {
                //Xn.Add(Math.Cos(((2.0 * i - 1) / (2.0 * n)) * Math.PI));
                Xn.Add(b - h * i  + h * (0.5 - rand.Next(100)/100.0));
            }
            for (int i = 0; i < n; i++)
            {
                double _p = p.Calculate(Xn[i]);
                double _q = q.Calculate(Xn[i]);

                double _f = f.Calculate(Xn[i]);
                fMatrix.arr[i][0] = _f;
                for (int j = 0; j < n; j++)
                {
                    double dif = Un.CalculateDiff(Xn[i], j+1);
                    double dif2 = Un.CalculateDoubleDiff(Xn[i], j+1);

                    double _l = dif2 + _p * dif + _q * Un.Calculate(Xn[i], j+1);

                    lMatrix.arr[i][j] = _l;
                    
                }
            }

            /*
            for (int i = 0; i < n; i++)
            {
                double _p = p.Calculate(Xn[i]);
                double _q = q.Calculate(Xn[i]);
                double _f = f.Calculate(Xn[i]);
                double dif = Un.CalculateDiff(Xn[i], 0);
                double dif2 = Un.CalculateDoubleDiff(Xn[i], 0);
                double _l = dif2 + _p * dif + _q * Un.Calculate(Xn[i], 0);

                fMatrix.arr[i][0] -= _l;
            }*/
            //MessageBox.Show(lMatrix.ToString());

            lMatrix = lMatrix.Inverse();
            //MessageBox.Show(lMatrix.ToString());

            Matrix An = lMatrix * fMatrix;

            //MessageBox.Show(An.ToString());
            List<double> Yn = new List<double>();

            for (int i = 0; i < n; i++)
            {
                double _y = 0;// Un.Calculate(Xn[0], 0);
                for (int j = 0; j < n; j++)
                {
                    _y += An.arr[j][0] * Un.Calculate(Xn[i], j + 1);
                }
                Yn.Add(_y);
            }

            DataView.Rows.Clear();
            for(int i = 0; i < n; i++)
            {
                DataView.Rows.Add(i, Xn[i], Yn[i], yCorrect.Calculate(Xn[i]));
            }
        }
    }
}
