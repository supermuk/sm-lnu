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
    public partial class Summary : UserControl
    {
        public Summary(List<string> TestNames, List<string> UserAnswers, List<string> CorrectAnswers, List<int> Points)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            int sum = 0;
            for (int i = 0; i < UserAnswers.Count; i++)
            {
                dataGridView1.Rows.Add( (i + 1).ToString(), TestNames[i], UserAnswers[i], CorrectAnswers[i], Points[i] );
                sum += Points[i];
            }
            dataGridView1.Rows.Add("", "", "", "Сума балів:", sum);
        }
        public string GetCSV()
        {
            string line = "";
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for(int j = 0; j < dataGridView1.Rows[i].Cells.Count; j++)
                {
                    line += "\"" +dataGridView1.Rows[i].Cells[j].Value.ToString() + "\"\t";
                }
                line += "\r\n";
            }
            return line;
        }
    }
}
