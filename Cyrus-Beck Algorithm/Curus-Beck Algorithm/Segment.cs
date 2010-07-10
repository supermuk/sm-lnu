using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;

namespace Curus_Beck_Algorithm
{
    class Segment
    {
        public Point3d a;
        public Point3d b;

        public Segment(Point3d a, Point3d b)
        {
            this.a = a;
            this.b = b;
        }
        public void Draw(Graphics g)
        {
            g.DrawLine(new Pen(Brushes.Blue), new Point((int)a.X, (int)a.Y), new Point((int)b.X, (int)b.Y));
            
        }
        public void Draw(Graphics g, Pen pen)
        {
            g.DrawLine(pen, new Point((int)a.X, (int)a.Y), new Point((int)b.X, (int)b.Y));

        }
        public Segment ToDo(Matrix m)
        {
            return new Segment(a.ToDo(m), b.ToDo(m));
        }
        public double Distance()
        {
            return Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y) + (a.Z - b.Z) * (a.Z - b.Z)); 
        }
        public Segment MiddleSegment(Segment s)
        {
            Segment s1 = new Segment(a.MiddlePoint(s.a), b.MiddlePoint(s.b));
            Segment s2 = new Segment(b.MiddlePoint(s.a), a.MiddlePoint(s.b));
            if (s1.Distance() > s2.Distance())
                return s1;
            else
                return s2;
        }
        public override string ToString()
        {
            return a.ToString() + " " + b.ToString() + "\r\n";
        }
        
    }
}
