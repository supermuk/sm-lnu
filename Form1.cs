using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace PseudoEdu
{
    public partial class Form1 : Form
    {
        public Course Course = new Course("file:///D:/TopSecret/PseudoEdu/html/");
        public string Path;
        public Form1()
        {
            InitializeComponent();
            Path = System.Reflection.Assembly.GetEntryAssembly().Location;
            Path = Path.Substring(0, Path.LastIndexOf("\\") + 1);
            /*
            XmlCourse c = new XmlCourse();
            c.Tests.Add(new Exam
            {
                Name = "Завдання 1",
                CorrectAnswer = 1,
                Url = "Test1.htm",
                Points = 1,
                Choises = new List<string>(new string[] { "a", "b", "c", "d" })
            });

            c.Tests.Add(new Exam
            {
                Name = "Завдання 2",
                CorrectAnswer = 2,
                Url = "Test2.htm",
                Points = 1,
                Choises = new List<string>(new string[] { "a", "b", "c", "d" })
            });

            c.Theorys.Add(new Theory
            {
                Name = "Означення",
                Url = "Page2.htm"
            });


            c.Theorys.Add(new Theory
            {
                Name = "Графічна модель",
                Url = "Page2.htm"
            });
            StreamWriter sw = new StreamWriter("manifest.xml");
            XmlSerializer xml = new XmlSerializer(typeof(XmlCourse));
            xml.Serialize(sw, c);
            */

            /*
            Course.AddPage("Означення", "Page1.htm");
            Course.AddPage("Графічна модель", "Page2.htm");
            Course.AddPage("Теорія", "Page3.htm");
            Course.AddPage("Приклад 1", "Page4.htm");
            Course.AddPage("Приклад 2", "Page5.htm");
            Course.AddPage("Приклад 3", "Page6.htm");

            Course.AddTest(new ChoiseTest("Завдання 1", "Test1.htm", "1000",
                new string[] { "A", "B", "C", "D" }));
            Course.AddTest(new ChoiseTest("Завдання 2", "Test2.htm", "1000",
                new string[] { "A", "B", "C", "D" }));
            Course.AddTest(new ChoiseTest("Завдання 3", "Test3.htm", "1000",
                new string[] { "A", "B", "C", "D" }));
            Course.AddTest(new ChoiseTest("Завдання 4", "Test4.htm", "1000",
                new string[] { "A", "B", "C", "D" }));
            Course.AddTest(new ChoiseTest("Завдання 5", "Test5.htm", "1000",
                new string[] { "A", "B", "C", "D" }));
            Course.AddTest(new ChoiseTest("Завдання 6", "Test6.htm", "1000",
                new string[] { "A", "B", "C", "D" }));
            */
            Open("manifest.xml");
        }

        public void Open(string manifestPath)
        {
            if (!File.Exists(this.Path + manifestPath))
            {
                return;
            }
            XmlSerializer xml = new XmlSerializer(typeof(XmlCourse));
            StreamReader sr = new StreamReader(this.Path + manifestPath);
            XmlCourse course = (XmlCourse)xml.Deserialize(sr);

            Course = new Course("file:///" + this.Path.Replace("\\", "/"));

            foreach (Exam exam in course.Tests)
            {
                Course.AddTest(new ChoiseTest(exam.Name, exam.Url, exam.CorrectAnswer, exam.Choises.ToArray(), exam.Points));
            }

            foreach(Theory theory in course.Theorys)
            {
                Course.AddPage(theory.Name, theory.Url);
            }
            splitContainer1.Panel1.Controls.Clear();
            splitContainer2.Panel1.Controls.Clear();
            splitContainer1.Panel1.Controls.Add(Course.Tree);
            splitContainer2.Panel1.Controls.Add(Course.Panel);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Course.Prev();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Course.Next();
        }

        private void відкритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.Path = openFileDialog1.FileName;
                int index = Path.LastIndexOf("\\");
                this.Path = Path.Substring(0, index + 1);
                Open(openFileDialog1.FileName.Substring(index));
            }
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Course.SummaryEnable)
            {
                MessageBox.Show("Для збереження результатів потрібно завершити проходження тестів.");
                return;
            }

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false, Encoding.Unicode);
                sw.Write(Course.Summary.GetCSV());
                sw.Close();
            }
        }

        private void проToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }
        
    }
}
