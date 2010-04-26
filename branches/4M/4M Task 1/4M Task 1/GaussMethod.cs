using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4M_Task_1
{
    class GaussMethod:NumericalIntegration
    {
        protected override double Calculate(double a, double b, int n, string integral)
        {
            double res = 0;
            double A = (b - a) / 2;
            double B = (b + a) / 2;
            Parser parser = new Parser();
            parser.Formula = integral;
            double[] x = GaussLegendre.arr[9].x;
            double[] w = GaussLegendre.arr[9].w;
            for(int i = 0; i < GaussLegendre.arr.Length; i++)
            {
                if(GaussLegendre.arr[i].n == n)
                {
                    x = GaussLegendre.arr[i].x;
                    w = GaussLegendre.arr[i].w;
                }
            }
            for(int i = 0; i < x.Length; i++)
            {
                res += w[i] * (parser.Calculate(A * x[i] + B) + parser.Calculate(B - A * x[i]));
            }
            return A*res;
        }

        public override string ToString()
        {
            return "Гауса";
        }
    }
}
