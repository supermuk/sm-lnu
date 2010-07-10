using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShapeEditor2
{
    public partial class Form2 : Form
    {
        private List<Shape> picture;
        private string mode;
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(ref List<Shape> pictureRef, string _mode)
        {
            InitializeComponent();
            picture = pictureRef;
            mode = _mode;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach(Shape s in picture)
            {
                listBox1.Items.Add(s.Name());
            }
            button1.Text = mode;
            if (mode == "Edit" || mode == "Delete")
                button1.Visible = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem.ToString() == "Polygon")
            {
                panel1.Visible = true;
                panel2.Visible = false;
                listBox2.Items.Clear();
                foreach (Point p in ((Polygon)picture[listBox1.SelectedIndex]).points)
                {
                    listBox2.Items.Add("X=" + p.X + " Y=" + p.Y);
                }
            }
            else
            {
                panel1.Visible = false;
                panel2.Visible = true;
                if (listBox1.SelectedItem.ToString() == "Ellipse")
                {
                    textBox3.Text = ((Ellipse)picture[listBox1.SelectedIndex]).X.ToString();
                    textBox4.Text = ((Ellipse)picture[listBox1.SelectedIndex]).Y.ToString();
                    textBox5.Text = ((Ellipse)picture[listBox1.SelectedIndex]).Width.ToString();
                    textBox6.Text = ((Ellipse)picture[listBox1.SelectedIndex]).Height.ToString();
                }
                else
                {
                    textBox3.Text = ((Rectangle)picture[listBox1.SelectedIndex]).X.ToString();
                    textBox4.Text = ((Rectangle)picture[listBox1.SelectedIndex]).Y.ToString();
                    textBox5.Text = ((Rectangle)picture[listBox1.SelectedIndex]).Width.ToString();
                    textBox6.Text = ((Rectangle)picture[listBox1.SelectedIndex]).Height.ToString();
                }
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = ((Polygon)picture[listBox1.SelectedIndex]).points[listBox2.SelectedIndex].X.ToString();
            textBox2.Text = ((Polygon)picture[listBox1.SelectedIndex]).points[listBox2.SelectedIndex].Y.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mode == "Edit")
            {
                if( listBox1.SelectedItem.ToString() == "Polygon" )
                {
                    try
                    {
                        ((Polygon)picture[listBox1.SelectedIndex]).points.RemoveAt(listBox2.SelectedIndex);
                        ((Polygon)picture[listBox1.SelectedIndex]).points.Insert(listBox2.SelectedIndex, new Point(int.Parse(textBox1.Text), int.Parse(textBox2.Text)));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Input data incorrect");
                    }
                    listBox2.Items.Clear();
                    foreach (Point p in ((Polygon)picture[listBox1.SelectedIndex]).points)
                    {
                        listBox2.Items.Add("X=" + p.X + " Y=" + p.Y);
                    }
                }
                if (listBox1.SelectedItem.ToString() == "Ellipse")
                {
                    try
                    {
                        ((Ellipse)picture[listBox1.SelectedIndex]).X = int.Parse(textBox3.Text);
                        ((Ellipse)picture[listBox1.SelectedIndex]).Y = int.Parse(textBox4.Text);
                        ((Ellipse)picture[listBox1.SelectedIndex]).Width = int.Parse(textBox5.Text);
                        ((Ellipse)picture[listBox1.SelectedIndex]).Height = int.Parse(textBox6.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Input data incorrect");
                    }
                }
                if (listBox1.SelectedItem.ToString() == "Rectangle")
                {
                    try
                    {
                        ((Rectangle)picture[listBox1.SelectedIndex]).X = int.Parse(textBox3.Text);
                        ((Rectangle)picture[listBox1.SelectedIndex]).Y = int.Parse(textBox4.Text);
                        ((Rectangle)picture[listBox1.SelectedIndex]).Width = int.Parse(textBox5.Text);
                        ((Rectangle)picture[listBox1.SelectedIndex]).Height = int.Parse(textBox6.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Input data incorrect");
                    }
                }


            }
            if (mode == "Delete")
            {
                picture.RemoveAt(listBox1.SelectedIndex);
            }
            listBox1.Items.Clear();
            foreach (Shape s in picture)
            {
                listBox1.Items.Add(s.Name());
            }
        }
    }
}
