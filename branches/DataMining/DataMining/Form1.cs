using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DataMining.DatabaseDataSetTableAdapters;

namespace DataMining
{
    public partial class Form1 : Form
    {
        List<string> categories = new List<string>();
        DatabaseDataSet db = new DatabaseDataSet();
        GolfTableAdapter adapter = new GolfTableAdapter();
        public Form1()
        {
            InitializeComponent();

            adapter.Fill(db.Golf);

            categories.Add("Спостереження");
            categories.Add("Температура");
            categories.Add("Вологість");
            categories.Add("Вітер");

            comboBox1.Items.AddRange(categories.ToArray());
            comboBox1.SelectedIndex = 0;

            comboBox2.Items.AddRange
                (
                    (from g in db.Golf
                     orderby g["Observation"]
                     select g["Observation"]).Distinct().ToArray()
                );

            comboBox3.Items.AddRange
                (
                    (from g in db.Golf
                     orderby g["Temperature"]
                     select g["Temperature"]).Distinct().ToArray()
                );
            comboBox4.Items.AddRange
                (
                    (from g in db.Golf
                     orderby g["Humidity"]
                     select g["Humidity"]).Distinct().ToArray()
                );
            comboBox5.Items.AddRange
                (
                    (from g in db.Golf
                     orderby g["Wind"]
                     select g["Wind"]).Distinct().ToArray()
                );
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseDataSet.Golf' table. You can move, or remove it, as needed.
            this.golfTableAdapter.Fill(this.databaseDataSet.Golf);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();

            List<Rule> allRules = new List<Rule>();
            List<double> errors = new List<double>();

            for(int i = 0; i < categories.Count; i++)
            {
                List<string> values = (from g in db.Golf
                                       orderby g[i]
                                       select g[i] as string).Distinct().ToList();
                foreach(string value in values)
                {
                    var data =
                        (from g in db.Golf
                         where g[i] as string == value
                         select g);
                    int allCount = data.Count();
                    int yesCount = (from p in data
                                    where p.Game == "Є"
                                    select p).Count();
                    int noCount = allCount - yesCount;
                    Rule rule = new Rule
                    {
                        Category = categories[i],
                        Value = value,
                        Result = yesCount >= noCount ? "Є" : "Ні"
                    };
                    allRules.Add(rule);
                    errors.Add((double)(yesCount >= noCount ? noCount : yesCount) / (double)allCount);
                    
                    dataGridView2.Rows.Add(rule.ToString(), (yesCount >= noCount ? noCount : yesCount).ToString() + "/" + allCount.ToString());

                }
            }

            int minIndex = 0;
            double minError = errors[0];

            
            for (int i = 0; i < allRules.Count; i++)
            {

                if (comboBox1.SelectedItem as string == allRules[i].Category || comboBox1.SelectedIndex == 0)
                {
                    if( errors[i] < minError)
                    {
                        minError = errors[i];
                        minIndex = i;
                    }
                }
            }
            textBox1.Text = allRules[minIndex].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();

            List<Hypothesis> hypos = new List<Hypothesis>();

            int yesAll = 
                (from g in db.Golf
                 where g["Game"] as string== "Є"
                 select g).Count();
            int noAll = 
                (from g in db.Golf
                 where g["Game"] as string == "Ні"
                 select g).Count();

            for (int i = 0; i < categories.Count; i++)
            {
                List<string> values = (from g in db.Golf
                       orderby g[i]
                       select g[i] as string).Distinct().ToList();
                foreach (string value in values)
                {

                    int yes = 
                        (from g in db.Golf
                         where g[i] as string == value
                         where g["Game"] as string == "Є"
                         select g).Count();
                    int no =
                        (from g in db.Golf
                         where g[i] as string == value
                         where g["Game"] as string == "Ні"
                         select g).Count();

                    Hypothesis hypoYes = new Hypothesis
                    {
                        Category = categories[i],
                        Value = value,
                        Result = "Є",
                        Probability1 = yes,
                        Probability2 = yesAll
                    };

                    Hypothesis hypoNo = new Hypothesis
                    {
                        Category = categories[i],
                        Value = value,
                        Result = "Ні",
                        Probability1 = no,
                        Probability2 = noAll
                    };

                    hypos.Add(hypoYes);
                    hypos.Add(hypoNo);

                }
            }


            for (int i = 0; i < hypos.Count; i++)
            {
                dataGridView3.Rows.Add(hypos[i].ToString());
            }




        }
    }
}
