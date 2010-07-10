using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Collections;
using System.Text;

namespace Curus_Beck_Algorithm
{
    class Polygon
    {
        
        public ArrayList arr;

        public Polygon()
        {
            arr = new ArrayList();
        }
        public void CreateRect(int l)
        {
            arr.Add(new Segment(new Point3d(0, 0), new Point3d(l, 0)));
            arr.Add(new Segment(new Point3d(l, 0), new Point3d(l, l)));
            arr.Add(new Segment(new Point3d(l, l), new Point3d(0, l)));
            arr.Add(new Segment(new Point3d(0, l), new Point3d(0, 0)));
        }
        public void CreateBox(int a, int b, int c)
        {
            /*
            //back face
            arr.Add(new Segment(new Point3d(0, 0, 0), new Point3d(a, 0, 0)));
            arr.Add(new Segment(new Point3d(a, 0, 0), new Point3d(a, b, 0)));
            arr.Add(new Segment(new Point3d(a, b, 0), new Point3d(0, b, 0)));
            arr.Add(new Segment(new Point3d(0, b, 0), new Point3d(0, 0, 0)));
            //front face
            arr.Add(new Segment(new Point3d(0, 0, c), new Point3d(a, 0, c)));
            arr.Add(new Segment(new Point3d(a, 0, c), new Point3d(a, b, c)));
            arr.Add(new Segment(new Point3d(a, b, c), new Point3d(0, b, c)));
            arr.Add(new Segment(new Point3d(0, b, c), new Point3d(0, 0, c)));
            //top face
            arr.Add(new Segment(new Point3d(0, b, 0), new Point3d(a, b, 0)));
            arr.Add(new Segment(new Point3d(a, b, 0), new Point3d(a, b, c)));
            arr.Add(new Segment(new Point3d(a, b, c), new Point3d(0, b, c)));
            arr.Add(new Segment(new Point3d(0, b, c), new Point3d(0, b, 0)));
            //bottom face
            arr.Add(new Segment(new Point3d(0, 0, 0), new Point3d(a, 0, 0)));
            arr.Add(new Segment(new Point3d(a, 0, 0), new Point3d(a, 0, c)));
            arr.Add(new Segment(new Point3d(a, 0, c), new Point3d(0, 0, c)));
            arr.Add(new Segment(new Point3d(0, 0, c), new Point3d(0, 0, 0)));
            //right face
            arr.Add(new Segment(new Point3d(a, 0, 0), new Point3d(a, b, 0)));
            arr.Add(new Segment(new Point3d(a, b, 0), new Point3d(a, b, c)));
            arr.Add(new Segment(new Point3d(a, b, c), new Point3d(a, 0, c)));
            arr.Add(new Segment(new Point3d(a, 0, c), new Point3d(a, 0, 0)));
            //left face
            arr.Add(new Segment(new Point3d(0, 0, 0), new Point3d(0, b, 0)));
            arr.Add(new Segment(new Point3d(0, b, 0), new Point3d(0, b, c)));
            arr.Add(new Segment(new Point3d(0, b, c), new Point3d(0, 0, c)));
            arr.Add(new Segment(new Point3d(0, 0, c), new Point3d(0, 0, 0)));
            */


            //back face
            arr.Add(new Segment(new Point3d(-a, -b, -c), new Point3d(a, -b, -c)));
            arr.Add(new Segment(new Point3d(a, -b, -c), new Point3d(a, b, -c)));
            arr.Add(new Segment(new Point3d(a, b, -c), new Point3d(-a, b, -c)));
            arr.Add(new Segment(new Point3d(-a, b, -c), new Point3d(-a, -b, -c)));
            //front face
            arr.Add(new Segment(new Point3d(-a, -b, c), new Point3d(a, -b, c)));
            arr.Add(new Segment(new Point3d(a, -b, c), new Point3d(a, b, c)));
            arr.Add(new Segment(new Point3d(a, b, c), new Point3d(-a, b, c)));
            arr.Add(new Segment(new Point3d(-a, b, c), new Point3d(-a, -b, c)));
            //top face
            arr.Add(new Segment(new Point3d(-a, b, -c), new Point3d(a, b, -c)));
            arr.Add(new Segment(new Point3d(a, b, -c), new Point3d(a, b, c)));
            arr.Add(new Segment(new Point3d(a, b, c), new Point3d(-a, b, c)));
            arr.Add(new Segment(new Point3d(-a, b, c), new Point3d(-a, b, -c)));
            //bottom face
            arr.Add(new Segment(new Point3d(-a, -b, -c), new Point3d(a, -b, -c)));
            arr.Add(new Segment(new Point3d(a, -b, -c), new Point3d(a, -b, c)));
            arr.Add(new Segment(new Point3d(a, -b, c), new Point3d(-a, -b, c)));
            arr.Add(new Segment(new Point3d(-a, -b, c), new Point3d(-a, -b, -c)));
            //right face
            arr.Add(new Segment(new Point3d(a, -b, -c), new Point3d(a, b, -c)));
            arr.Add(new Segment(new Point3d(a, b, -c), new Point3d(a, b, c)));
            arr.Add(new Segment(new Point3d(a, b, c), new Point3d(a, -b, c)));
            arr.Add(new Segment(new Point3d(a, -b, c), new Point3d(a, -b, -c)));
            //left face
            arr.Add(new Segment(new Point3d(-a, -b, -c), new Point3d(-a, b, -c)));
            arr.Add(new Segment(new Point3d(-a, b, -c), new Point3d(-a, b, c)));
            arr.Add(new Segment(new Point3d(-a, b, c), new Point3d(-a, -b, c)));
            arr.Add(new Segment(new Point3d(-a, -b, c), new Point3d(-a, -b, -c)));



        }
        public void CreateCoords(int l)
        {
            arr.Add(new Segment(new Point3d(0, 0, 0), new Point3d(l, 0, 0)));
            arr.Add(new Segment(new Point3d(0, 0, 0), new Point3d(0, l, 0)));
            arr.Add(new Segment(new Point3d(0, 0, 0), new Point3d(0, 0, l)));
            arr.Add(new Segment(new Point3d(l, 0, 0), new Point3d(l-4, 4, 0)));
            arr.Add(new Segment(new Point3d(l, 0, 0), new Point3d(l-4, -4, 0)));
            arr.Add(new Segment(new Point3d(0, l, 0), new Point3d(4, l-4, 0)));
            arr.Add(new Segment(new Point3d(0, l, 0), new Point3d(-4, l-4, 0)));
            arr.Add(new Segment(new Point3d(0, 0, l), new Point3d(0, 4, l-4)));
            arr.Add(new Segment(new Point3d(0, 0, l), new Point3d(0, 4, l-4)));
        }


        public void add(Segment seg)
        {
            arr.Add(seg);
        }
        public void Draw(Graphics g)
        {
            foreach (Segment seg in arr)
                seg.Draw(g);
        }
        public void Draw(Graphics g, Pen pen)
        {
            foreach (Segment seg in arr)
                seg.Draw(g, pen);
        }
        public Polygon ToDo(Matrix m)
        {
            Polygon res = new Polygon();
            foreach (Segment seg in arr)
                res.add(seg.ToDo(m));
            return res;
        }
        public void Clear()
        {
            arr.Clear();
        }
        
        
    }
    class Box : Polygon
    {
        public Segment ox;
        public Segment oy;
        public Segment oz;
        public Box()
        {

        }
        public Box(int a, int b, int c)
        {
            base.CreateBox(a, b, c);
            ox = ((Segment)arr[0]).MiddleSegment((Segment)arr[6]);
            oy = ((Segment)arr[1]).MiddleSegment((Segment)arr[7]);
            oz = ((Segment)arr[9]).MiddleSegment((Segment)arr[15]);
        }
        public Box ToDo(Matrix m)
        {
            Box res = new Box();
            res.ox = ox;
            res.oy = oy;
            res.oz = oz;
            foreach (Segment seg in arr)
                res.add(seg.ToDo(m));
            return res;
        }
        
    }
}
