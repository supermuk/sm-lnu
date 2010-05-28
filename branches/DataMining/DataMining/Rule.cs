using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataMining
{
    class Rule
    {
        public string Category { get; set; }
        public string Value { get; set; }
        public string Result { get; set; }

        public override string ToString()
        {
            return "Якщо (" + Category + " = " + Value + ") то (гра = " + Result + ")";
        }
    }
}
