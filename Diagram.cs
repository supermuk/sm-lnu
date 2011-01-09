using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Spreadsheetq
{
    public partial class Diagram : Form
    {
        public Diagram(double[] x, double[] y)
        {
            InitializeComponent();

            zedGraphControl1.GraphPane.AddCurve("Diagram", x, y, Color.Blue);
            zedGraphControl1.GraphPane.AxisChange();
            zedGraphControl1.Invalidate();
        }
    }
}
