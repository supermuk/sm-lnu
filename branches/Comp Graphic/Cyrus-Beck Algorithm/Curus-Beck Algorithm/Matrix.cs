using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Curus_Beck_Algorithm
{
    class Matrix
    {
        private const double pi = 3.1415926;
        public double[][] arr;
        public Matrix()
        {
            arr = new double[4][];
            arr[0] = new double[4];
            arr[1] = new double[4];
            arr[2] = new double[4];
            arr[3] = new double[4];
            arr[0][0] = 1;
            arr[1][1] = 1;
            arr[2][2] = 1;
            arr[3][3] = 1;
        }
        public Matrix(double a, double b, double c, double p, double d, double e, double f, double q, double i, double j, double k, double r, double l, double m, double n, double s)
	    {
            arr = new double[4][];
            arr[0] = new double[4];
            arr[1] = new double[4];
            arr[2] = new double[4];
            arr[3] = new double[4];
		    arr[0][0]=a; arr[0][1]=b; arr[0][2]=c; arr[0][3]=p; 
		    arr[1][0]=d; arr[1][1]=e; arr[1][2]=f; arr[1][3]=q; 
		    arr[2][0]=i; arr[2][1]=j; arr[2][2]=k; arr[2][3]=r; 
		    arr[3][0]=l; arr[3][1]=m; arr[3][2]=n; arr[3][3]=s; 
	    }
        public void RotateOX(double alpha)
        {
            double s = Math.Sin(alpha * pi / 180);
            double c = Math.Cos(alpha * pi / 180);

            arr[1][1] = c;
            arr[1][2] = s;
            arr[2][1] = -s;
            arr[2][2] = c;
        }
        public void RotateOY(double alpha)
        {
            double s = Math.Sin(alpha * pi / 180);
            double c = Math.Cos(alpha * pi / 180);

            arr[0][0] = c;
            arr[0][2] = -s;
            arr[2][0] = s;
            arr[2][2] = c;
        }
        public void RotateOZ(double alpha)
        {

            double s = Math.Sin(alpha * pi / 180);
            double c = Math.Cos(alpha * pi / 180);

            arr[0][0] = c;
            arr[0][1] = s;
            arr[1][0] = -s;
            arr[1][1] = c;
        }
        public void Rotate(Segment seg, double alpha)
        {

            Matrix trans = new Matrix();
            trans.Transport(-seg.a.X, -seg.a.Y, -seg.a.Z);
            Matrix trans_rev = new Matrix();
            trans_rev.Transport(seg.a.X, seg.a.Y, seg.a.Z);

            Segment new_s = seg.ToDo(trans);
            double dis = new_s.Distance();
            double n1 = new_s.b.X / dis;
            double n2 = new_s.b.Y / dis;
            double n3 = new_s.b.Z / dis;

            double c = Math.Cos(alpha * pi / 180);
            double s = Math.Sin(alpha * pi / 180);

            Matrix rotate = new Matrix();

            rotate.arr[0][0] = n1 * n1 + (1 - n1 * n1) * c;
            rotate.arr[0][1] = n1 * n2 * (1 - c) + n3 * s;
            rotate.arr[0][2] = n1 * n3 * (1 - c) - n2 * s;
            rotate.arr[1][0] = n1 * n2 * (1 - c) - n3 * s;
            rotate.arr[1][1] = n2 * n2 + (1 - n2 * n2) * c;
            rotate.arr[1][2] = n2 * n3 * (1 - c) + n1 * s;
            rotate.arr[2][0] = n1 * n3 * (1 - c) + n2 * s;
            rotate.arr[2][1] = n2 * n3 * (1 - c) - n1 * s;
            rotate.arr[2][2] = n3 * n3 + (1 - n3 * n3) * c;

            Matrix result = new Matrix();
            result = trans * rotate;
            result = result * trans_rev;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    arr[i][j] = result.arr[i][j];
                }
            }

            
        }

        public void Transport(double xx, double yy, double zz)
        {
            arr[3][0] = xx;
            arr[3][1] = yy;
            arr[3][2] = zz;
        }
        public static Matrix operator * (Matrix m1, Matrix m2)
        {
            Matrix result = new Matrix();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    double tmp = 0;
                    for (int k = 0; k < 4; k++)
                        tmp += m1.arr[i][k] * m2.arr[k][j];
                    result.arr[i][j] = tmp;
                }
            return result;
        }

        public void Clear()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == j)
                        arr[i][j] = 1;
                    else
                        arr[i][j] = 0;
                }
            }
        }

    }
}
