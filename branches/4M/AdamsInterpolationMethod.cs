using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace _4M_Task_2
{
    class AdamsInterpolationMethod:BaseMathod
    {
        public double Yn;
        public double Xn; 
        public List<Point> Points { get; set; }

        public Point Calculate()
        {
            double Yn1 = Yn;

            int count = Points.Count - 1;
            double F = Points[count].Y + H * (8 * Func.Calculate(Points[count].X, Points[count].Y)
                    - Func.Calculate(Points[count - 1].X, Points[count - 1].Y)) / 12;

            double Yn1new;

            int n = 0;
            do
            {
                n++;
                Yn1new = Iteration(F, Xn, Yn1, n);
                double tmp = Yn1;
                Yn1 = Yn1new;
                Yn1new = tmp; 
            } while (Math.Abs(Yn1 - Yn1new) > Eps);
            return new Point { X = Xn, Y = Yn1 };
        }

        private double Iteration(double F, double Xn1, double Yn1, int n)
        {
            int count = Points.Count - 1;
            double res = F + 5 * H * Func.Calculate(Xn1, Yn1) / 12;
            Print(Xn1, res, n, Color.Azure);
            return res;
        }

        public override string ToString()
        {
            return "Інтерполяцій метод Адамса 3 порядку";
        }
    }
}
