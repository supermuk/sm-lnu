using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Serialization;

namespace ShapeEditor2
{
    public class Picture
    {
        private List<Shape> shapes;
        public List<Shape> Shapes
        {
            set
            {
                shapes = value;
            }
            get
            {
                return shapes;
            }
        }

        public Picture()
        {
        }
        public void Add(Shape shape)
        {
            shapes.Add(shape);
        }
    }
}
