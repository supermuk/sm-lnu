using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace _4M_Task_2
{
    class BaseMathod
    {
        public DataGridView DataView { get; set; }
        public Parser Func { get; set; }
        public Parser CorrectFunc { get; set; }
        public double A { get; set; }
        public double B { get; set; }
        public double H { get; set; }
        public double Eps { get; set; }


        protected void Print(double x, double y, int iter, Color color)
        {
            double diff = Math.Abs( CorrectFunc.Calculate(x,0) - y);
            DataView.Rows.Add(DataView.Rows.Count, x, y, iter, diff, this.ToString());
            DataView.Rows[DataView.Rows.Count - 1].DefaultCellStyle.BackColor = color;
        }


        public override string ToString()
        {
            return "Base Method";
        }
    }
}
