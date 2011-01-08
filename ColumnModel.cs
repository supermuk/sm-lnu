using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBMS
{
    public class ColumnModel
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public bool AllowNull { get; set; }
    }
}
