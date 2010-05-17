using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;


namespace Cryptograph
{

    public partial class AnalizerForm : Form
    {
        private Alphabets alphabet = Alphabets.Latin;

        public AnalizerForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in openFileDialog1.FileNames)
                {
                    StreamReader sr = new StreamReader(file);
                    textBox1.Text += sr.ReadToEnd();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pattern = "";
            if (alphabet == Alphabets.Latin)
            {
                pattern = @"\b[a-zA-Z]+\b";
            }
            else if (alphabet == Alphabets.Ukrainian)
            { 
                pattern = @"\b[а-яА-ЯіІїЇєЄґҐ]+\b";
            }

            MatchCollection matches = Regex.Matches(textBox1.Text, pattern);

            Dictionary<string, int> wordDic = new Dictionary<string, int>();
              
            foreach (Match m in matches)
            {
                if (wordDic.Keys.Contains(m.Value.ToLowerInvariant()))
                {
                    wordDic[m.Value.ToLowerInvariant()]++;
                }
                else
                {
                    wordDic[m.Value.ToLowerInvariant()] = 1;
                }
            }
            List<KeyValuePair<string, int>> wordSource = new List<KeyValuePair<string,int>>();

            wordSource.AddRange(wordDic.ToList());
            wordSource.Sort(PairComparer);

            dataGridView1.DataSource = wordSource;
            dataGridView1.Columns[0].HeaderText = "Слово";
            dataGridView1.Columns[1].HeaderText = "Кількість";

            label3.Text = matches.Count.ToString();
            label4.Text = wordSource.Count.ToString();

            Dictionary<char, double> letterDic = new Dictionary<char, double>();

            for (int i = 0; i < alphabet.GetLength(); i++)
            {
                letterDic[alphabet.GetStringValue()[i]] = 0;
            }
            int letterCount = 0;
            foreach (string word in wordDic.Keys)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    letterDic[word[i]]+= wordDic[word];
                    letterCount += wordDic[word];
                }
            }
            letterCount += wordDic.Count - 1 ;
            letterDic[' '] = wordDic.Count - 1;

            List<char> keys = new List<char>();
            keys.AddRange(letterDic.Keys.ToList());
            foreach (char key in keys)
            {
                letterDic[key] = Math.Round(letterDic[key] * 100 / letterCount, 2);
            }
            List<KeyValuePair<char, double>> letterSource = new List<KeyValuePair<char, double>>();

            letterSource.AddRange(letterDic.ToList());

            letterSource.Sort(PairComparer);


            dataGridView2.DataSource = letterSource;
            dataGridView2.Columns[0].HeaderText = "Буква";
            dataGridView2.Columns[1].HeaderText = "Частота";

            label6.Text = letterCount.ToString();


            Dictionary<string, double> letterPairDic = new Dictionary<string, double>();
            foreach (string word in wordDic.Keys)
            {
                string prev = " ";
                string next;
                for (int i = 0; i <= word.Length; i++)
                {
                    if (i < word.Length)
                    {
                        next = word[i].ToString();
                    }
                    else
                    {
                        next = " ";
                    }
                    if (letterPairDic.Keys.Contains(prev + next))
                    {
                        letterPairDic[prev + next]+= wordDic[word];
                    }
                    else
                    {
                        letterPairDic[prev + next] = wordDic[word];
                    }
                    prev = next;
                }

                List<string> keys2 = new List<string>();
                keys2.AddRange(letterPairDic.Keys.ToList());
                foreach (string key in keys2)
                {
                    letterPairDic[key] = Math.Round(letterPairDic[key] * 100 / letterCount, 7);
                }
                List<KeyValuePair<string, double>> letterPairSource = new List<KeyValuePair<string, double>>();

                letterPairSource.AddRange(letterPairDic.ToList());

                letterPairSource.Sort(PairComparer);


                dataGridView3.DataSource = letterPairSource;
                dataGridView3.Columns[0].HeaderText  = "Буква";
                dataGridView3.Columns[1].HeaderText = "Частота";

            }
        }
        public int PairComparer(KeyValuePair<string, int> p1, KeyValuePair<string, int> p2)
        {
            return p2.Value.CompareTo(p1.Value);
        }
        public int PairComparer(KeyValuePair<char, double> p1, KeyValuePair<char, double> p2)
        {
            return p2.Value.CompareTo(p1.Value);
        }
        public int PairComparer(KeyValuePair<string, double> p1, KeyValuePair<string, double> p2)
        {
            return p2.Value.CompareTo(p1.Value);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            alphabet = Alphabets.Latin;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            alphabet = Alphabets.Ukrainian;
        }

    }
}
