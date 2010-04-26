using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4M_Task_1
{
    class TrapezoidalRule:NumericalIntegration
    {
        protected override double Calculate(double a, double b, int n, string integral)
        {
            double res = 0;
            double h = (b - a) / n;
            Parser parser = new Parser();
            parser.Formula = integral;
            res = parser.Calculate(a);
            for (double x = a + h; x < b; x += h)
            {
                res += 2*parser.Calculate(x);
            }
            res += parser.Calculate(b);
            res *= h / 2;
            return res;
        }
        public override string ToString()
        {
            return "Трапецій";
        }
    }
}
