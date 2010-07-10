using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace Curus_Beck_Algorithm
{
    public partial class Form1 : Form
    {
        protected Graphics gr;

        protected object box = new Box(50, 100, 200);
        protected object coord;
        protected object segments = new Polygon();
        protected object show = new Polygon();

        protected bool sh = true;

        protected int x = -1;
        protected int y = -1;

    


        protected ArrayList n = new ArrayList();
        protected ArrayList f = new ArrayList();

        protected object zoom = new Matrix();

        protected object all_we_done = new Matrix();
        protected object old_mat = new Matrix();

        public Form1()
        {

           

            Polygon _coord = new Polygon();
            _coord.CreateCoords(250);
            coord = _coord;

   

            InitializeComponent();

            mainPanel.Click += new EventHandler(mainPanel_Click);
            gr = mainPanel.CreateGraphics();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void mainPanel_Click(object sender, EventArgs e)
        {
            
        }

        public void render(Graphics gr)
        {
            mainPanel.Refresh();
           
            Matrix norm = new Matrix();
            norm.Transport(mainPanel.Width/2 , mainPanel.Height/2 , 0);
            norm.arr[1][1] = -1;
           

            Box test =  (Box)box;
           
            Matrix rotx = new Matrix();
            rotx.Rotate( ((Box)box).ox, trackBar1.Value );

            test = test.ToDo(rotx);

            Matrix roty = new Matrix();
            roty.Rotate( ((Box)box).oy, trackBar2.Value );

            test = test.ToDo(roty);

            Matrix rotz = new Matrix();
            rotz.Rotate(((Box)box).oz, trackBar3.Value);
            
            test = test.ToDo(rotz);


            test = test.ToDo((Matrix)all_we_done).ToDo((Matrix)zoom).ToDo(norm);
            test.Draw(gr);

            if(sh)
                ((Polygon)segments).ToDo((Matrix)all_we_done).ToDo((Matrix)zoom).ToDo(norm).Draw(gr, new Pen(Brushes.Gray, 1));
            else
                ((Polygon)show).ToDo((Matrix)all_we_done).ToDo((Matrix)zoom).ToDo(norm).Draw(gr, new Pen(Brushes.Red, 2));

            

            ((Polygon)coord).ToDo((Matrix)all_we_done).ToDo(norm).Draw(gr, new Pen(Brushes.Green, 1));
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            render(gr);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            render(gr);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            render(gr);
        }

        private void mainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }

        private void mainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (x > -1 && y > -1)
            {
                Matrix rox = new Matrix();
                Matrix roy = new Matrix();

                rox.RotateOX( (e.Y - y) / 3);
                roy.RotateOY( (e.X - x) / 3);

                all_we_done = (Matrix) old_mat * rox * roy;
                render(gr);
            }
        }

        private void mainPanel_MouseUp(object sender, MouseEventArgs e)
        {
            x = -1;
            y = -1;
            old_mat = all_we_done;
            
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            double ax, ay, az, bx, by, bz;
            double.TryParse(Ax.Text, out ax);
            double.TryParse(Ay.Text, out ay);
            double.TryParse(Az.Text, out az);
            double.TryParse(Bx.Text, out bx);
            double.TryParse(By.Text, out by);
            double.TryParse(Bz.Text, out bz);
            ((Polygon)segments).add(new Segment(new Point3d(ax * 50, ay * 50, az * 50), new Point3d(bx * 50, by * 50, bz * 50)));
            sh = true;
            render(gr);
        }

        private void trackBarZoom_Scroll(object sender, EventArgs e)
        {
            ((Matrix)zoom ).arr[0][0] = (double)trackBarZoom.Value / 50;
            ((Matrix)zoom).arr[1][1] = (double)trackBarZoom.Value / 50;
            ((Matrix)zoom).arr[2][2] = (double)trackBarZoom.Value / 50;
            render(gr);
        }

        private void buttonAlgo_Click(object sender, EventArgs e)
        {

            ((Polygon)show).Clear();
            updateNF();
            for (int j = 0; j < ((Polygon)segments).arr.Count; j++)
            {

                Point3d P1 = ((Segment)((Polygon)segments).arr[j]).a;
                Point3d P2 = ((Segment)((Polygon)segments).arr[j]).b;
                Point3d D = P2 - P1;
                double tl = 0, th = 1;
                bool check = true;
                for (int i = 0; i < 6; i++)
                {
                    Point3d wi = P1 - (Point3d)f[i];
                    double Dsc = (new Point3d()).Scalar(D, (Point3d)n[i]);
                    double Wsc = (new Point3d()).Scalar(wi, (Point3d)n[i]);


                    if (Dsc == 0)
                    {
                        if( Wsc < 0)
                        {
                            check = false;
                            break;
                        }
                    }
                    else if (Dsc > 0)
                    { 
                        double t = -Wsc / Dsc;
                        if (t > th)
                        {
                            check = false;
                            break;
                        }
                        if (t > tl)
                        {
                            tl = t;
                        }

                    }
                    else if (Dsc < 0)
                    {
                        double t = -Wsc / Dsc;
                        if (t < tl)
                        {
                            check = false;
                            break;
                        }
                        if (t < th)
                        {
                            th = t;
                        }
                    }
                }

                if (tl <= th && check)
                {
                    Point3d newP1 = P1 + (P2 - P1) * tl;
                    Point3d newP2 = P1 + (P2 - P1) * th;

                    if (radioButtonIn.Checked)
                    {
                        ((Polygon)show).add(new Segment(newP1, newP2));
                    }
                    else
                    {
                        ((Polygon)show).add(new Segment(P1, newP1));
                        ((Polygon)show).add(new Segment(newP2, P2));

                    }
                }
                else
                {
                    if (radioButtonOut.Checked)
                    {
                        ((Polygon)show).add(new Segment(P1, P2));
                    }

                }

                
                

            }
            sh = false;
            render(gr);
        }

        public void updateNF()
        {
            Box test = (Box)box;

            Matrix rotx = new Matrix();
            rotx.Rotate(((Box)box).ox, trackBar1.Value);

            test = test.ToDo(rotx);

            Matrix roty = new Matrix();
            roty.Rotate(((Box)box).oy, trackBar2.Value);

            test = test.ToDo(roty);

            Matrix rotz = new Matrix();
            rotz.Rotate(((Box)box).oz, trackBar3.Value);

            //test = test.ToDo(rotz);

            Matrix all = rotx * roty * rotz;

            n.Clear();
            n.Add(new Point3d(0, -1, 0));
            n.Add(new Point3d(0, 1, 0));
            n.Add(new Point3d(-1, 0, 0));
            n.Add(new Point3d(1, 0, 0));
            n.Add(new Point3d(0, 0, -1));
            n.Add(new Point3d(0, 0, 1));
            

            f.Clear();
            f.Add(new Point3d(50, 100, 200));
            f.Add(new Point3d(-50, -100, -200));
            f.Add(new Point3d(50, 100, 200));
            f.Add(new Point3d(-50, -100, -200));
            f.Add(new Point3d(50, 100, 200));
            f.Add(new Point3d(-50, -100, -200));

            for (int i = 0; i < 6; i++)
            {
                n[i] = ((Point3d)n[i]).ToDo(all);
                f[i] = ((Point3d)f[i]).ToDo(all);
            }


        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                string path = saveFileDialog1.FileName;
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                
                FileStream fs = File.Create(path);
                foreach( object tmp in ((Polygon)segments).arr)
                    AddText(fs, tmp.ToString() );

                AddText(fs, "Orest Mykhaylovych © 2009");
                fs.Close();
            }
            catch (Exception) 
            {
                MessageBox.Show("nono");
            }
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }

        private void відкритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                string path = openFileDialog1.FileName;

                ((Polygon)segments).Clear();
                ((Polygon)show).Clear();
                StreamReader sr = new StreamReader(path);
                string line;
                while ((line = sr.ReadLine()) != "Orest Mykhaylovych © 2009")
                {
                    string[] ar = line.Split(' ');
                    ((Polygon)segments).add( new Segment( 
                            new Point3d( double.Parse(ar[0]), double.Parse(ar[1]), double.Parse(ar[2])),
                            new Point3d( double.Parse(ar[3]), double.Parse(ar[4]), double.Parse(ar[5]))));
                    
                }
                sh = true;
                render(gr);

            }
            catch (Exception)
            {
                MessageBox.Show("nono");
            }
        }

        private void новийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((Polygon)segments).Clear();
            ((Polygon)show).Clear();
            ((Matrix)all_we_done).Clear();
            ((Matrix)old_mat).Clear();
            render(gr);
        }

        private void проПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Тривимірний алгоритм Кируса-Бека \n Версія програми 1.0.3 \n Автор: \n Михайлович Орест \n sm.lpml@gmail.com \n \n \n Усі права захищено  © 2009");
        }


    }
}
