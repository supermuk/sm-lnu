using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace _4M_Task_2
{
    class RungeKuttaMethod:BaseMathod
    {
        public Point M0 { get; set; }
        public int PointsCount { get; set; }
        
        public int IterationCount 
        {
            get
            {
                return iterationCount;
            }
        }
        private int iterationCount = 1;
        private List<Point> correctPoints = new List<Point>();

        public List<Point> Calculate()
        {
            double h = (B - A) / (PointsCount - 1);
            List<Point> r1 = Iteration(h);
            List<Point> r2;
            PrintAll(r1);
            do
            {
                h = h / 2;
                iterationCount++;
                r2 = Iteration(h);
                List<Point> tmp = r2;
                r2 = r1;
                r1 = tmp;
                PrintAll(r1);
            }
            while (Distance(r1, r2) > Eps);

            int scale = (int)Math.Pow(2, IterationCount - 1);
            List<Point> result = new List<Point>();
            for (int i = 0; i < PointsCount; i++)
            {
                result.Add(r1[i * scale]);
            }
            return result;
        }

        private List<Point> Iteration(double h)
        {
            List<Point> arr = new List<Point>();
            arr.Add(M0);
            int scale = (int)Math.Pow(2, IterationCount - 1);
            for (int i = 1; i < scale * PointsCount; i++)
            {
                double Xn = arr.Last().X;
                double Yn = arr.Last().Y;
                double k1 = h * Func.Calculate(Xn, Yn);
                double k2 = h * Func.Calculate(Xn + h / 4, Yn + k1 / 4);
                double k3 = h * Func.Calculate(Xn + h / 2, Yn + k2 / 2);
                double k4 = h * Func.Calculate(Xn + h, Yn + k1 - 2 * k2 + 2 * k3);
                double Yn1 = Yn + (k1 + 4 * k3 + k4) / 6;
                double Xn1 = Xn + h;
                arr.Add(new Point { X = Xn1, Y = Yn1 });
            }
            return arr;
        }

        private double Distance(List<Point> r1, List<Point> r2)
        {

            double max = 0;
            for (int i = 0; i < PointsCount; i++)
            {
                int scale1 = (int) Math.Pow(2, IterationCount - 1);
                int scale2 = scale1 / 2;
                double cur = Math.Abs(r1[scale1 * i].Y - r2[scale2 * i].Y);
                if ( cur > max)
                {
                    max = cur;
                }
            }
            return max;
        }


        private void PrintAll(List<Point> points)
        {
            int scale = (int)Math.Pow(2, IterationCount - 1);
            for (int i = 0; i < PointsCount; i++)
            {
                Print(points[i * scale].X, points[i * scale].Y, iterationCount - 1, Color.Cornsilk);
            }
        }
        public override string ToString()
        {
            return "Метод Рунге-Кутта 4 порядку";
        }
    }
}
