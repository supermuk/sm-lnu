using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Xml.Serialization;
using System.Data.Linq.Mapping;
using System.Data.Linq;


namespace ShapeEditor2
{
    public partial class Form1 : Form
    {
        private List<Shape> picture = new List<Shape>();
        private Point oldPoint = new Point();
        private Polygon currentPol = new Polygon();
        private int deletePos;
        private bool mouseDown = false;
        Graphics gr;

        public Form1()
        {
            InitializeComponent();
            gr = pictureBox1.CreateGraphics();
        }
        private void Redraw()
        {


            pictureBox1.Refresh();
            foreach (Shape shape in picture)
            {
                shape.Draw(gr, new Pen(Color.Blue, 2));
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                XmlSerializer SerializerObj = new XmlSerializer(typeof(List<Shape>), new Type[] { typeof(Ellipse), typeof(Rectangle), typeof(Polygon) });
                FileStream ReadFileStream = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                picture = (List<Shape>)SerializerObj.Deserialize(ReadFileStream);
                ReadFileStream.Close();
            }
            Redraw();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                XmlSerializer SerializerObj = new XmlSerializer(typeof(List<Shape>),new Type[] {typeof(Ellipse), typeof(Rectangle), typeof(Polygon)});
                FileStream WriteFileStream = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                SerializerObj.Serialize(WriteFileStream, picture);
                WriteFileStream.Close();
            }
            Redraw();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            tsslMode.Text = "Rectangle";
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            tsslMode.Text = "Polygon";
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            tsslMode.Text = "Ellipse";
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            tsslPosition.Text = "X:" + e.X.ToString() + "Y:" + e.Y;
            if (mouseDown)
            {
                Redraw();
                Pen pen = new Pen(Color.HotPink, 1);
                switch (tsslMode.Text)
                {
                    case "Rectangle": gr.DrawRectangle(pen, 
                        Math.Min(oldPoint.X,e.X),
                        Math.Min(oldPoint.Y, e.Y), 
                        Math.Abs(e.X - oldPoint.X), 
                        Math.Abs(e.Y - oldPoint.Y)); 
                        break;
                    case "Polygon": currentPol.Draw(gr, pen); gr.DrawLine(pen, oldPoint, new Point(e.X, e.Y)); break;
                    case "Ellipse": gr.DrawEllipse(pen, oldPoint.X, oldPoint.Y, e.X - oldPoint.X, e.Y - oldPoint.Y); break;
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int i = 0;
                foreach (Shape s in picture)
                {
                    if (s.Contain(new Point(e.X, e.Y)))
                    {
                        contextMenuStrip1.Show(new Point(e.X + this.Location.X + 10, e.Y + 2 + this.Location.Y + pictureBox1.Location.Y + contextMenuStrip1.Size.Height));
                        deletePos = i;
                     //   break;
                    }
                    i++;

                }
            }
            if(e.Button == MouseButtons.Left)
            {
                oldPoint.X = e.X;
                oldPoint.Y = e.Y;
                mouseDown = true;
                if (tsslMode.Text == "Polygon")
                    currentPol.Add(new Point(e.X, e.Y));
            }
            Redraw();
            
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = false;
                switch (tsslMode.Text)
                {
                    case "Rectangle":
                        picture.Add(new ShapeEditor2.Rectangle(
                        Math.Min(oldPoint.X, e.X),
                        Math.Min(oldPoint.Y, e.Y),
                        Math.Abs(e.X - oldPoint.X),
                        Math.Abs(e.Y - oldPoint.Y)));
                        Redraw();

                        break;
                    case "Polygon":
                        oldPoint.X = e.X;
                        oldPoint.Y = e.Y;
                        if (Math.Abs(currentPol.FirstPoint.X - e.X) < 6 && Math.Abs(currentPol.FirstPoint.Y - e.Y) < 6)
                        {
                            currentPol.Add(currentPol.FirstPoint);
                            picture.Add(currentPol);
                            currentPol = new Polygon();
                            Redraw();
                        }
                        else
                        {
                            currentPol.Add(new Point(e.X, e.Y));
                            mouseDown = true;
                        }

                        break;
                    case "Ellipse":
                        picture.Add(new Ellipse(
                        Math.Min(oldPoint.X, e.X),
                        Math.Min(oldPoint.Y, e.Y),
                        Math.Abs(e.X - oldPoint.X),
                        Math.Abs(e.Y - oldPoint.Y)));
                        Redraw();

                        break;
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            picture.RemoveAt(deletePos);
            Redraw();
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Form2(ref picture, "View")).ShowDialog();
            Redraw();
        }

        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Form2(ref picture, "Edit")).ShowDialog();
            Redraw();
        }

        private void delToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Form2(ref picture, "Delete")).ShowDialog();
            Redraw();
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            (new Form2(ref picture, "Edit")).ShowDialog();
            Redraw();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new AboutBox1()).ShowDialog();
            Redraw();
        }

        private void storeInDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext("Data Source=.\\SQLEXPRESS;AttachDbFilename=D:\\SMile\\Projects\\ShapeEditor3\\ShapeEditor2\\Database1.mdf;Integrated Security=True;User Instance=True");
            tblPicture pic = db.tblPictures.Single();
            pic.Name = "bob";
            //pic.ID = 2;
            List<tblPicture> l = new List<tblPicture>();
            l.Add(pic);
            //db.tblPictures.InsertAllOnSubmit(l);
            //var ex = (from p in  db.tblPictures select p).ToArray() ;
            //foreach (var group in ex)
            //{
             //  MessageBox.Show(group.ID.ToString());
            //}
            db.SubmitChanges();
        }
    }
}
