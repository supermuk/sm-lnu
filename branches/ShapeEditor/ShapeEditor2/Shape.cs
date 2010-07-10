using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Serialization;

namespace ShapeEditor2
{
    [Serializable()]
    public class Shape
    {
        public virtual string Name()
        {
            return "";
        }
        public virtual void Draw(System.Drawing.Graphics gr, System.Drawing.Pen pen)
        {
        }
        public virtual bool Contain(System.Drawing.Point p)
        {
            return false;
        }
    }
}
