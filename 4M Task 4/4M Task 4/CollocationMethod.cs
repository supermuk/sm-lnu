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

        public double A { get; set; }
        public double B { get; set; }

        public Parser Un = new Parser { Formula = "x^y" };

        public DataGridView DataView { get; set; }

        public void Calculate()
        {
            Matrix matrix = new Matrix(n, n);

            //// CALCULATE MATRIX
            for (int j = 0; j < n; j++)
            {
                Parser L = new Parser();
                for (int i = 0; i < n; i++)
                {
                    matrix.arr[i][j] = Un.x[i]
                }
            }


        }
    }
}
