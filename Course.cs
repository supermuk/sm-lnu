using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace PseudoEdu
{
    public class Course
    {
        public List<Theory> TheoryNodes = new List<Theory>();
        public List<ITest> ExamNodes = new List<ITest>();
        public TreeView Tree = new TreeView();
        public Panel Panel = new Panel();
        public WebBrowser Browser = new WebBrowser();
        public Summary Summary;
        public string BaseUrl;
        private int CurrentType = 0;
        private int CurrentNodeIndex = -1;
        private bool TheoryEnable = true;
        private bool ExamEnable = false;
        public bool SummaryEnable = false;
        public Course(string BaseUrl)
        {
            Tree.BackColor = Color.AliceBlue;
            Panel.Dock = DockStyle.Fill;
            Browser.Dock = DockStyle.Fill;
            Tree.Dock = DockStyle.Fill;
            Tree.Font = new Font("Times New Roman", 16, FontStyle.Italic);
            Tree.AfterSelect += new TreeViewEventHandler(Tree_NodeMouseClick);
            Tree.AfterExpand += new TreeViewEventHandler(Tree_AfterExpand);
            Tree.ImageIndex = 0;
            Tree.Nodes.Add("Theory", "Теорія");
            Tree.Nodes.Add("Exam", "Практика");
            Tree.Nodes.Add("Summary", "Результат");
            this.BaseUrl = BaseUrl;
        }
        public void ExpandTheory()
        {
            if (TheoryEnable)
            {
                Tree.Nodes[0].Expand();
                Tree.Nodes[1].Collapse();
                CurrentType = 0;
                Panel.Controls.Clear();
                Panel.Controls.Add(Browser);
            }
            else
            {
                ExpandExam();
                MessageBox.Show("Для переходу до теоретичної частини потрібно завершити проходження тестів.");
            }
        }
        public void ExpandExam()
        {
            if (ExamEnable)
            {
                Tree.Nodes[0].Collapse();
                Tree.Nodes[1].Expand();
                CurrentType = 1;
                Panel.Controls.Clear();
            }
            else
            {
                ExpandTheory();
                MessageBox.Show("Для проходження тестів потрібно спочатку пройти теоретичний курс.");
            }
        }
        public void ExpandSummary()
        {
            if (SummaryEnable)
            {
                Tree.Nodes[1].Collapse();
                List<string> names = new List<string>();
                List<string> answers = new List<string>();
                List<string> correct = new List<string>();
                List<int> points = new List<int>();
                foreach(ITest test in ExamNodes)
                {
                    names.Add(test.GetName());
                    answers.Add(test.GetAnswer());
                    correct.Add(test.GetCorrectAnswer());
                    points.Add(test.GetPoints());
                }
                Summary = new Summary(names, answers, correct, points);

                Panel.Controls.Clear();
                Panel.Controls.Add(Summary);
            }
            else
            {
                ExpandExam();
                MessageBox.Show("Для перегляду результатів потрібно завершити проходження тестів.");
            }
        }
        public void AddPage(string Name, string Url)
        {
           TheoryNodes.Add(new Theory { Name = Name, Url = BaseUrl + Url });
           Tree.Nodes[0].Nodes.Add(Name, Name);
        }

        public void AddTest(ITest Test)
        {
            Test.SetBaseUrl(this.BaseUrl);
            ExamNodes.Add(Test);
            Tree.Nodes[1].Nodes.Add(Test.GetName(), Test.GetName());
        }

        public void Tree_AfterExpand(object sender, TreeViewEventArgs args)
        {
            if (args.Node.Name == "Exam")
            {
                ExpandExam();
            }
            else
            {
                ExpandTheory();
            }
        }

        public void Tree_NodeMouseClick(object sender, TreeViewEventArgs arg)
        {
            if (arg.Node.Name == "Summary")
            {
                TheoryEnable = true;
                ExamEnable = false;
                CurrentType = 2;
                ExpandSummary();
                return;
            }
            if (arg.Node.Nodes == null)
            {
                return;
            }

            if (arg.Node.Nodes.Count == 0)
            {
                if (CurrentType == 0)
                {
                    SelectPage(arg.Node);
                }
                else
                {
                    SelectTest(arg.Node);
                }
            }
        }
        public void Next()
        {
            if (CurrentNodeIndex < Tree.Nodes[CurrentType].Nodes.Count - 1)
            {
                if (CurrentType == 0)
                {
                    SelectPage(Tree.Nodes[CurrentType].Nodes[CurrentNodeIndex + 1]);
                }
                else if (CurrentType == 1)
                {
                    SelectTest(Tree.Nodes[CurrentType].Nodes[CurrentNodeIndex + 1]);
                }
            }
            else
            {
                if (CurrentType == 0)
                {
                    ExpandExam();
                    SelectTest(Tree.Nodes[CurrentType].Nodes[0]);
                }
                else if (CurrentType == 1)
                {
                    ExpandSummary();
                }
            }
        }
        public void Prev()
        {
            if (CurrentNodeIndex > 0)
            {
                if (CurrentType == 0)
                {
                    SelectPage(Tree.Nodes[CurrentType].Nodes[CurrentNodeIndex - 1]);
                }
                else if(CurrentType == 1)
                {
                    SelectTest(Tree.Nodes[CurrentType].Nodes[CurrentNodeIndex - 1]);
                }
            }
        }
        private void SelectPage(TreeNode Node)
        {
            CurrentNodeIndex = Node.Index;
            foreach (TreeNode n in Tree.Nodes[CurrentType].Nodes)
            {
                n.BackColor = Color.AliceBlue;
                n.ForeColor = Color.Black;
            }
            Node.BackColor = Color.FromArgb(51, 153, 255);
            Node.ForeColor = Color.White;
            Browser.Url = new Uri(TheoryNodes.SingleOrDefault(i => i.Name == Node.Name).Url);

            if (CurrentNodeIndex == TheoryNodes.Count - 1)
            {
                ExamEnable = true;
            }
        }
        private void SelectTest(TreeNode Node)
        {
            TheoryEnable = false;
            CurrentNodeIndex = Node.Index;
            foreach (TreeNode n in Tree.Nodes[CurrentType].Nodes)
            {
                n.BackColor = Color.AliceBlue;
                n.ForeColor = Color.Black;
            }
            Node.BackColor = Color.FromArgb(51, 153, 255);
            Node.ForeColor = Color.White;
            Panel.Controls.Clear();
            ITest test = ExamNodes.SingleOrDefault(i=> i.GetName() == Node.Name);
            Panel.Controls.Add(test.GetControl());
            if (CurrentNodeIndex == ExamNodes.Count - 1)
            {
                SummaryEnable = true;
                TheoryEnable = true;
                ExamEnable = false;
            }
        }
    }
}
