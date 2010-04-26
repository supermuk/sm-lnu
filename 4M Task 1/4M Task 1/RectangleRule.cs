using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4M_Task_1
{
    class RectangleRule:NumericalIntegration
    {
        protected override double Calculate(double a, double b, int n, string integral)
        {
            double res = 0;
            double h = (b - a) / n;
            Parser parser = new Parser();
            parser.Formula = integral;
            for (double x = a; x < b; x += h)
            {
                res += parser.Calculate(x);
            }
            res *= h;
            return res;
        }
        public override string ToString()
        {
            return "Прямокутників";
        }
    }
}
