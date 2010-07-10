using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Curus_Beck_Algorithm
{
    class Point3d
    {
        private double x;
        private double y;
        private double z;
        private double h;

        public double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        public double Z
        {
            get
            {
                return z;
            }
            set
            {
                z = value;
            }
        }
        public double H
        {
            get
            {
                return h;
            }
            set
            {
                h = value;
            }
        }

        public Point3d()
        {
            x = 0;
            y = 0;
            z = 0;
            h = 1;
        }
        public Point3d(double x, double y)
        {
            this.x = x;
            this.y = y;
            this.z = 0;
            this.h = 1;
        }
        public Point3d(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.h = 1;
        }
        public Point3d(double x, double y, double z, double h)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.h = h;
        }

        static public Point3d operator -(Point3d p1, Point3d p2)
        {
            return new Point3d(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);
        }

        static public Point3d operator +(Point3d p1, Point3d p2)
        {
            return new Point3d(p1.X + p2.X, p1.Y + p2.Y, p1.Z + p2.Z);
        }

        static public Point3d operator *(Point3d p, double k)
        {
            return new Point3d(p.X * k, p.Y * k, p.Z * k);
        }
        public Point3d ToDo(Matrix m)
        {
            double _x, _y, _z, _h;
		    _x = x * m.arr[0][0] + y * m.arr[1][0] + z * m.arr[2][0] + h * m.arr[3][0];
		    _y = x * m.arr[0][1] + y * m.arr[1][1] + z * m.arr[2][1] + h * m.arr[3][1];
		    _z = x * m.arr[0][2] + y * m.arr[1][2] + z * m.arr[2][2] + h * m.arr[3][2];
		    _h = x * m.arr[0][3] + y * m.arr[1][3] + z * m.arr[2][3] + h * m.arr[3][3];
		    _x = _x / _h;
		    _y = _y / _h;
		    _z = _z / _h;
		    _h = 1;
            return new Point3d(_x, _y, _z);

        }

        public Point3d MiddlePoint(Point3d p)
        {
            return new Point3d((x + p.X) / 2, (y + p.Y) / 2, (z + p.Z) / 2);
        }
        
        public double Scalar(Point3d a, Point3d b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }
        public override string ToString()
        {
            return x.ToString() + " " + y.ToString() + " " + z.ToString();
        }
    }
     
    
}
