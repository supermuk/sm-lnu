using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace ShapeEditor2
{
    public class Polygon: Shape
    {

        public Polygon()
        {
        }
        public List<Point> points = new List<Point>();

        public Point FirstPoint
        {
            get
            {
                if (points.Count > 0)
                    return points[0];
                return new Point();
            }
        }

        public void Add(Point p)
        {
            points.Add(p);
        }

        public override void Draw(Graphics gr, Pen pen)
        {
            for (int i = 0; i < points.Count - 1; i++)
            {
                Point p1 = new Point(points[i].X, points[i].Y);
                Point p2 = new Point(points[(i + 1) % points.Count].X, points[(i + 1) % points.Count].Y);
                gr.DrawLine(pen, p1, p2);
            }
        }
        public override bool Contain(Point p)
        {
            foreach (Point i in points)
            {
                if (Math.Abs(i.X - p.X) < 6 && Math.Abs(i.Y - p.Y) < 6)
                    return true;
            }
            return false;
        }
        public override string Name()
        {
            return "Polygon";
        }
    }
}
