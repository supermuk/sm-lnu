using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace ShapeEditor2
{
    public class Ellipse : Shape
    {
        public static string name = "Ellipse";
        private int x;
        public int X
        {
            set
            {
                x = value;
            }
            get
            {
                return x;
            }
        }
        private int y;
        public int Y
        {
            set
            {
                y = value;
            }
            get
            {
                return y;
            }
        }
        private int width;
        public int Width
        {
            set
            {
                width = value;
            }
            get
            {
                return width;
            }
        }
        private int height;
        public int Height
        {
            set
            {
                height = value;
            }
            get
            {
                return height;
            }
        }

        public Ellipse()
        {
        }
        public Ellipse(int _x, int _y, int _w, int _h)
        {
            x = _x;
            y = _y;
            width = _w;
            height = _h;
        }


        public override void Draw(Graphics gr, Pen pen)
        {
            gr.DrawEllipse(pen, new System.Drawing.Rectangle(x, y, width, height));
        }
        public override bool Contain(Point p)
        {
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(x, y, width, height);
            return rect.Contains(p);
        }
        public override string Name()
        {
            return "Ellipse";
        }

    }
}
