using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataMining
{
    class Hypothesis:Rule
    {
        public int Probability1 { get; set; }
        public int Probability2 { get; set; }
        public double Probabylity
        {
            get
            {
                return (double)Probability1 / (double)Probability2;
            }
        }

        public override string ToString()
        {
            return "P(" + Category + " = " + Value + " | гра = " + Result + ") = " + Probability1 + "/" + Probability2;

        }
        
    }
}
