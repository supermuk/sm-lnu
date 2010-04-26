using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace _4M_Task_2
{
    class AdamsExtrapolationMethod: BaseMathod
    {
        public List<Point> Points { get; set; }
        private List<Point> correctPoints = new List<Point>();

        public void Calculate()
        {
            int n =  Points.Count;
            int N = (int)((B - A) / H - n);
            n--;
            for (int i = 0; i <= N; i++)
            {
                double Xn = Points[n].X + H;
                double Yn = Points[n].Y + H * (55 * Func.Calculate(Points[n].X, Points[n].Y) 
                    - 59 * Func.Calculate(Points[n - 1].X, Points[n - 1].Y) 
                    + 37 * Func.Calculate(Points[n - 2].X, Points[n - 2].Y) 
                    - 9 * Func.Calculate(Points[n - 3].X, Points[n - 3].Y)) / 24;
                n++;

                Print(Xn, Yn, 0, Color.AntiqueWhite);

                AdamsInterpolationMethod aim = new AdamsInterpolationMethod
                {
                    A = A,
                    B = B,
                    H = H,
                    Eps =Eps,
                    Func = Func,
                    CorrectFunc = CorrectFunc,
                    DataView = DataView,
                    Points = Points,
                    Yn = Yn,
                    Xn = Xn
                };
                Points.Add(aim.Calculate());
            }
        }
        public override string ToString()
        {
            return "Екстраполяційний метод Адамса 4 порядку";
        }
    }
}
