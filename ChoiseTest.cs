using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PseudoEdu
{
    public partial class ChoiseTest : UserControl, ITest
    {
        public List<string> Choises = new List<string>();
        public List<RadioButton> Radios = new List<RadioButton>();
        public int CorrectAnswer;
        public string UserAnswer;
        private string TestName;
        private string Url;
        private int Points;

        public ChoiseTest(string Name, string Url, int CorrectAnswer, string[] Choises, int Points)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.TestName = Name;
            this.Url = Url;
            this.CorrectAnswer = CorrectAnswer;
            this.Points = Points;
            foreach (string choise in Choises)
            {
                this.Choises.Add(choise);
            }
            Radios.Add(radioButton1);
            Radios.Add(radioButton2);
            Radios.Add(radioButton3);
            Radios.Add(radioButton4);
            Initialize();
        }

        public void Initialize()
        {
            for(int i = 0; i < Choises.Count; i++)
            {
                Radios[i].Text = Choises[i];
            }
        }

        public string GetName()
        {
            return TestName;
        }
        public string GetUrl()
        {
            return Url;
        }
        public Control GetControl()
        {
            return this;
        }
        public string GetAnswer()
        {
            foreach (RadioButton rb in Radios)
            {
                if (rb.Checked)
                {
                    return rb.Text;
                }
            }
            return "нема відповіді";
        }
        public string GetCorrectAnswer()
        {
            return Radios[CorrectAnswer - 1].Text;
        }
        public int GetPoints()
        {
            if (GetAnswer() == GetCorrectAnswer())
            {
                return Points;
            }
            return 0;
        }
        public void SetBaseUrl(string url)
        {
            this.Url = url + this.Url;
            webBrowser1.Url = new Uri(this.Url);
        }
        public bool CheckAnswer()
        {
            return true;// UserAnswer == CorrectAnswer;
        }
    }
}
