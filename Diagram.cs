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
        public Diagram(double[] x, double[] y, string name, string nameX, string nameY)
        {
            InitializeComponent();
            zedGraphControl1.GraphPane.Title.Text = name;
            zedGraphControl1.GraphPane.XAxis.Title = new ZedGraph.AxisLabel(nameX, "Arial", 16, Color.Black, false, false, false);
            zedGraphControl1.GraphPane.YAxis.Title = new ZedGraph.AxisLabel(nameY, "Arial", 16, Color.Black, false, false, false); 
            zedGraphControl1.GraphPane.AddCurve("Diagram", x, y, Color.Blue);
            zedGraphControl1.GraphPane.AxisChange();
            zedGraphControl1.Invalidate();
        }
    }
}
