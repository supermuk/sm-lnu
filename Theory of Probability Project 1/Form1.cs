using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

namespace Theory_of_Probability_Project_1
{
    public partial class Form1 : Form
    {
        private float minVal = 10000000;
        private float maxVal = -10000000;


        private List<float> arr = new List<float>();

        private List<int> n = new List<int>();

        public Form1()
        {
            InitializeComponent();
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = false;
            for (int i = 0; i < 10; i++)
            {
                dataGridView1.Columns.Add(i.ToString(), i.ToString());
                dataGridView1.Columns[i].Width = 50;

            }

            comboBox1.SelectedIndex = 2;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            AddValue(e.RowIndex, e.ColumnIndex);
            RefreshTable();
            RefreshHypothesis();

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            trackBarPro1.ThumbCount = (int)numericUpDown1.Value - 1;
            trackBarPro1.Refresh();
            RefreshTable();
            RefreshDiagram();
            RefreshPolygon();
            RefreshStatistic();
            RefreshHypothesis();
        }

        private void RefreshTable()
        {
            dataGridView2.Columns.Clear();
            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                string begin = (Math.Round(trackBarPro1.Values[i], 3)).ToString();
                string end = (Math.Round(trackBarPro1.Values[i+1], 3)).ToString();
                dataGridView2.Columns.Add((i + 1).ToString(), "[" + begin + "; " + end + ")");

            }
            dataGridView2.Rows.Add(1);
            dataGridView2.Rows[0].HeaderCell.Value = "n";

            n.Clear();
            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                n.Add(0);
            }
            for (int i = 0; i < arr.Count; i++)
            {
                int index = 0;
                for (index = 1; index < trackBarPro1.Values.Count - 1; index++)
                {
                    if (trackBarPro1.Values[index] > arr[i] || (trackBarPro1.Values[index] > arr[i] && index == numericUpDown1.Value))
                        break;
                }
                
                n[index - 1]++;
            }

            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                dataGridView2.Rows[0].Cells[i].Value = n[i];
            }

        }
 
        private void RefreshPolygon()
        {
            tabControl1.TabPages[1].Refresh();
            int height = tabControl1.TabPages[1].Height;
            int width = tabControl1.TabPages[1].Width;
            Graphics gr = tabControl1.TabPages[1].CreateGraphics();
            Pen axePen = new Pen(Color.Red, 1);
            Pen polPen = new Pen(Color.Gray, 2);
            Pen gridPen = new Pen(Color.LightGray, 1);
            int marginTop = (int) ( height * 0.90);
            int marginLeft = (int)(width * 0.05);



            float maxCount = 0F;
            foreach (float f in n)
            {
                if (f > maxCount)
                    maxCount = f;
            }
            float hx = (float)((width * 0.90) / Math.Max((trackBarPro1.MaxValue - trackBarPro1.MinValue), Math.Abs( trackBarPro1.MaxValue) ));

            float hy = (float)((height * 0.75) / maxCount);


            int centerX = marginLeft;
            if (trackBarPro1.MinValue < 0)
                centerX = (int)(-hx * trackBarPro1.MinValue + marginLeft);

            if (checkBox1.Checked)
            {
                for (float i = hx; i < width; i += hx)
                {
                    gr.DrawLine(gridPen, i + centerX, 0, i + centerX, height);
                }
                for (float i = -hx; i > 0; i -= hx)
                {
                    gr.DrawLine(gridPen, i + centerX, 0, i + centerX, height);
                }
                for (float i = hy; i < height; i += hy)
                {
                    gr.DrawLine(gridPen, 0, marginTop - i, width, marginTop - i);
                }
                for (float i = -hy; i > 0; i -= hy)
                {
                    gr.DrawLine(gridPen, 0, marginTop - i, width, marginTop - i);
                }
            }



            gr.DrawLine(axePen, (int)(width * 0.025), marginTop, width - marginLeft, marginTop);
            gr.DrawLine(axePen, width - marginLeft - 8, marginTop + 5, width - marginLeft, marginTop);
            gr.DrawLine(axePen, width - marginLeft - 8, marginTop - 5, width - marginLeft, marginTop);




            gr.DrawLine(axePen, centerX, (int)(height * 0.95), centerX, (int)(height * 0.05));
            gr.DrawLine(axePen, centerX - 5, (int)(height * 0.05) + 8, centerX, (int)(height * 0.05));
            gr.DrawLine(axePen, centerX + 5 , (int)(height * 0.05) + 8, centerX, (int)(height * 0.05));


            List<float> avgVal = new List<float>();
            for (int i = 0; i < trackBarPro1.Values.Count - 1; i++)
            {
                avgVal.Add((float) ( (trackBarPro1.Values[i] + trackBarPro1.Values[i + 1]) / 2.0));
            }
            for (int i = 0; i < avgVal.Count - 1; i++)
            {
                gr.DrawLine(polPen, (int)((avgVal[i]) * hx + centerX), (int)(marginTop - n[i] * hy), (int)(avgVal[i + 1] * hx + centerX), (int)(marginTop - n[i + 1] * hy));
            }

            System.Drawing.Font font = new Font("arial", 12);
            Brush brush = Brushes.Blue;
            for (int i = 0; i < avgVal.Count; i++)
            {
                gr.DrawLine(axePen, (int)(avgVal[i] * hx + centerX), marginTop - 3, (int)(avgVal[i] * hx + centerX), marginTop + 3);
                gr.DrawString(Math.Round(avgVal[i], 3).ToString(), font, brush, new PointF((int)(avgVal[i] * hx + centerX), marginTop + 4));
                gr.DrawLine(axePen, centerX - 3, (int)(marginTop - n[i] * hy), centerX + 3, (int)(marginTop - n[i] * hy));
                gr.DrawString(n[i].ToString(), font, brush, centerX - 22, (int)(marginTop - n[i] * hy));
            }


        }

        private void RefreshDiagram()
        {
            tabControl1.TabPages[2].Refresh();
            int height = tabControl1.TabPages[2].Height;
            int width = tabControl1.TabPages[2].Width;
            Graphics gr = tabControl1.TabPages[2].CreateGraphics();
            Pen axePen = new Pen(Color.Red, 1);
            Pen diaPen = new Pen(Color.Gray, 2);
            Pen gridPen = new Pen(Color.LightGray, 1);
            int marginTop = (int)(height * 0.90);
            int marginLeft = (int)(width * 0.05);

            float maxCount = 0F;
            foreach (float f in n)
            {
                if (f > maxCount)
                    maxCount = f;
            }
            float hx = (float)((width * 0.85) / Math.Max((trackBarPro1.MaxValue - trackBarPro1.MinValue), Math.Abs(trackBarPro1.MaxValue)));

            float hy = (float)((height * 0.75) / maxCount);


            int centerX = marginLeft;
            if (trackBarPro1.MinValue < 0)
                centerX = (int)(-hx * trackBarPro1.MinValue + marginLeft);


            if (checkBox2.Checked)
            {
                for (float i = hx; i < width; i += hx)
                {
                    gr.DrawLine(gridPen, i + centerX, 0, i + centerX, height);
                }
                for (float i = -hx; i > 0; i -= hx)
                {
                    gr.DrawLine(gridPen, i + centerX, 0, i + centerX, height);
                }
                for (float i = hy; i < height; i += hy)
                {
                    gr.DrawLine(gridPen, 0, marginTop - i, width, marginTop - i);
                }
                for (float i = -hy; i > 0; i -= hy)
                {
                    gr.DrawLine(gridPen, 0, marginTop - i, width, marginTop - i);
                }
            }
            gr.DrawLine(axePen, (int)(width * 0.025), marginTop, width - marginLeft, marginTop);
            gr.DrawLine(axePen, width - marginLeft - 8, marginTop + 5, width - marginLeft, marginTop);
            gr.DrawLine(axePen, width - marginLeft - 8, marginTop - 5, width - marginLeft, marginTop);




            gr.DrawLine(axePen, centerX, (int)(height * 0.95), centerX, (int)(height * 0.05));
            gr.DrawLine(axePen, centerX - 5, (int)(height * 0.05) + 8, centerX, (int)(height * 0.05));
            gr.DrawLine(axePen, centerX + 5, (int)(height * 0.05) + 8, centerX, (int)(height * 0.05));

            for (int i = 0; i < trackBarPro1.Values.Count - 1; i++)
            {
                gr.DrawLine(diaPen, (int)((trackBarPro1.Values[i]) * hx + centerX), (int)(marginTop - n[i] * hy), (int)(trackBarPro1.Values[i + 1] * hx + centerX), (int)(marginTop - n[i] * hy));
                gr.DrawLine(diaPen, (int)((trackBarPro1.Values[i]) * hx + centerX), marginTop, (int)((trackBarPro1.Values[i]) * hx + centerX), (int)(marginTop - n[i] * hy));
                gr.DrawLine(diaPen, (int)((trackBarPro1.Values[i+1]) * hx + centerX), marginTop, (int)((trackBarPro1.Values[i+1]) * hx + centerX), (int)(marginTop - n[i] * hy));
            }

            System.Drawing.Font font = new Font("arial", 12);
            Brush brush = Brushes.Blue;
            for (int i = 0; i < trackBarPro1.Values.Count; i++)
            {
                gr.DrawLine(axePen, (int)(trackBarPro1.Values[i] * hx + centerX), marginTop - 3, (int)(trackBarPro1.Values[i] * hx + centerX), marginTop + 3);
                gr.DrawString(Math.Round(trackBarPro1.Values[i], 3).ToString(), font, brush, new PointF((int)(trackBarPro1.Values[i] * hx + centerX), marginTop + 4));
                if (i != trackBarPro1.Values.Count - 1)
                {
                    gr.DrawLine(axePen, centerX - 3, (int)(marginTop - n[i] * hy), centerX + 3, (int)(marginTop - n[i] * hy));
                    gr.DrawString(n[i].ToString(), font, brush, centerX - 22, (int)(marginTop - n[i] * hy));
                }
            }


        }

        private void RefreshStatistic()
        {
            //mediana
            
            //int medianaIndex = 0;
            int sum = 0;
            foreach (int i in n)
                sum += i;
            /*
            int tmp = 0;
            while (tmp <= sum / 2)
            {
                tmp += n[medianaIndex];
                medianaIndex++;
            }
            medianaIndex--;
            labelMe.Text = "Me = [" + Math.Round(trackBarPro1.Values[medianaIndex], 3).ToString() + "; " + Math.Round(trackBarPro1.Values[medianaIndex +1], 3).ToString() + ");";
            */
            KeyValuePair<float, float> mediana = Mediana(arr);
            if (mediana.Key == mediana.Value)
            {
                labelMe.Text = "Me = " + Mediana(arr).Key.ToString();

            }
            else
            {
                labelMe.Text = "Me = " + Mediana(arr).Key.ToString() + ", " + Mediana(arr).Value.ToString();

            }

            
            //moda
            /*
            int maxVal = 0;
            int modaIndex = 0;
            for(int i =0 ; i < n.Count; i++)
            {
                if (n[i] > maxVal)
                {
                    maxVal = n[i];
                    modaIndex = i;
                }
            }
            labelModa.Text = "Mo = [" + Math.Round(trackBarPro1.Values[modaIndex], 3).ToString() + "; " + Math.Round(trackBarPro1.Values[modaIndex + 1], 3).ToString() + ");";
            */
            labelModa.Text = "Mo = [" + Math.Round(Moda(trackBarPro1.Values, n).Key, 3).ToString() + "; "
                + Math.Round(Moda(trackBarPro1.Values, n).Value, 3).ToString() + ")";

            // average
            
            /*
            float avg = 0;
            foreach (float f in arr)
            {
                avg += f;
            }
            avg /= sum;
             */
            //labelAvg.Text = "x =  " + Math.Round(avg, 3).ToString();

            labelAvg.Text = "x = " + Math.Round( Average(trackBarPro1.Values, n), 3).ToString();


            //variance
           
            
            /*float ss = 0;
            foreach (float f in arr)
            {
                ss += (f - avg) * (f - avg);
            }
            ss /= sum - 1;
            labelSS.Text = "S² = " + Math.Round(ss, 3).ToString();
            */
            labelSS.Text = "S² = " + Math.Round(Variance(trackBarPro1.Values, n), 3).ToString();


            //D
            float d = Variance(trackBarPro1.Values, n) * (arr.Count - 1) / arr.Count;
            labelD.Text = "D = " + Math.Round(d, 3).ToString();


            //p
            float avg = Average(trackBarPro1.Values, n);
            float max = arr[0];
            float min = arr[0];
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
                if (arr[i] < min)
                    min = arr[i];
            }
            float r = max - min;
            labelR.Text = "ρ = " + r.ToString();


            float m2 = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                m2 += (arr[i] - avg) * (arr[i] - avg);
            }
            m2 /= arr.Count;

            float m3 = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                m3 += (arr[i] - avg) * (arr[i] - avg) * (arr[i] - avg);
            }
            m3 /= arr.Count;

            float m4 = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                m4 += (arr[i] - avg) * (arr[i] - avg) * (arr[i] - avg) * (arr[i] - avg);
            }
            m4 /= arr.Count;

            //Skewness
            float skewness = m3 / (float)Math.Pow( m2, 1.5);
            labelSkewness.Text = "γ₁ = " + Math.Round(skewness, 3);
            //Kurtosis
            float kurtosis = m4 / (m2 * m2) - 3;
            labelKurtosis.Text = "γ₂ = " + Math.Round(kurtosis, 3);

        }
        private KeyValuePair<float, float> Mediana(List<float> var)
        {
            var.Sort();
            return new KeyValuePair<float,float>(var[var.Count / 2], var[ var.Count / 2 +1]);
        }
        private KeyValuePair<float, float> Moda(List<float> x, List<int> countx)
        {
            int maxVal = 0;
            int modaIndex = 0;
            for (int i = 0; i < countx.Count; i++)
            {
                if (countx[i] > maxVal)
                {
                    maxVal = countx[i];
                    modaIndex = i;
                }
            }
            return new KeyValuePair<float, float>( x[modaIndex], x[modaIndex+1]);
        }
        private float Average (List<float> x, List<int> countx)
        {
            float avg = 0;
            float sum = 0;
            for (int i = 0; i < x.Count - 1; i++)
            {
                avg += (x[i] + x[i + 1]) * (float) countx[i] / 2.0F;
                sum += (float) countx[i];
            }
            return avg /sum;

        }
        private float Variance(List<float> x, List<int> countx)
        {
            float ss = 0;
            float sum = 0;
            float avg = Average(x, countx);
            for (int i = 0; i < countx.Count - 1; i++)
            {
                sum += countx[i];
            }
            for (int i = 0; i < x.Count - 1; i++)
            {
                ss += ((x[i] + x[i + 1]) / 2 - avg) * ((x[i] + x[i + 1]) / 2 - avg);
            }
            ss /= sum - 1;
            return ss;
        }

        private void RefreshHypothesis()
        {

            float avg = 0;
            foreach (float f in arr)
            {
                avg += f;
            }
            avg /= arr.Count;

            
            float ss = 0;
            foreach (float f in arr)
            {
                ss += (f - avg) * (f - avg);
            }
            ss /= arr.Count - 1;
            float sigma = (float) Math.Pow(ss, 0.5);

            List<float> t = new List<float>();
            t.Add(-5);
            for (int i = 1; i < trackBarPro1.Values.Count - 1; i++)
            {
                t.Add( ( (trackBarPro1.Values[i]+trackBarPro1.Values[i+1])/2F - avg )/ sigma);
            }
            t.Add(5);
            List<float> p = new List<float>();
            string res = "";
            for (int i = 0; i < numericUpDown1.Value ; i++)
            {
                p.Add(FLaplasa(t[i + 1]) - FLaplasa(t[i]));
                res += "p[" + i.ToString() + "] = " + Math.Round(p[i], 4).ToString() + "\r\n";
            }
            textBox1.Text = res;
            float xiemp = 0;
            if( n.Count != 0)
            for (int i = 1; i < numericUpDown1.Value ; i++)
            {
                xiemp += (n[i] - arr.Count * p[i]) * (n[i] - arr.Count * p[i]) / (p[i] * arr.Count);
            }

            labelXiEmp.Text = "χ                = " + xiemp;
            float xicrytical =  XiCritical((int)numericUpDown1.Value - 3, comboBox1.SelectedIndex + 1);
            labelXiCritical.Text = "χ               = " + xicrytical;
            if (xiemp <= xicrytical)
            {
                labelOk.Visible = true;
                labelBad.Visible = false;
            }
            else
            {
                labelOk.Visible = false;
                labelBad.Visible = true;
            }
        }

        private void trackBarPro1_ThumbMoved(int index)
        {
            RefreshTable();
            RefreshDiagram();
            RefreshPolygon();
            RefreshStatistic();
            RefreshHypothesis();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshTable();
            RefreshDiagram();
            RefreshPolygon();
            RefreshStatistic();
            RefreshHypothesis();
        }

        private void tabPage2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void tabPage3_Paint(object sender, PaintEventArgs e)
        {
           // RefreshDiagram();
        }

        private void tabPage4_Paint(object sender, PaintEventArgs e)
        {
            RefreshStatistic();
        }

        private void tabPage5_Paint(object sender, PaintEventArgs e)
        {
            //RefreshHypothesis();
        }

        private float FLaplasa(float x)
        {
            float c = 1;
            if (x < 0)
                c = -1;
            x = Math.Abs(x);
            if (x >= 5)
                return c*0.5F;
            StreamReader reader = new StreamReader("table.txt");
            string line;
            string[] f;
            do
            {
                line = reader.ReadLine();
                f = line.Split(' ');
            } while (float.Parse(f[0]) < x);
            return c*float.Parse(f[1]);
            

        }

        private float XiCritical(int r, int a)
        {
            StreamReader reader = new StreamReader("tableXi.txt");
            string line;
            string[] f;
            for (int i = 0; i < r - 1; i++)
            {
                reader.ReadLine();
            }
            line = reader.ReadLine();
            f = line.Split(' ');
            return float.Parse(f[a]);
            
        }


        private void AddValue(int row, int column)
        {

            float curVal = 0;
            try
            {

                curVal = float.Parse(dataGridView1.Rows[row].Cells[column].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Incorrect format of input data");
                dataGridView1.Rows[row].Cells[column].Value = "";
            }
            if (curVal > maxVal)
            {
                maxVal = curVal;
                trackBarPro1.MaxValue = maxVal;
            }
            if (curVal < minVal)
            {
                minVal = curVal;
                trackBarPro1.MinValue = minVal;
            }
            arr.Add(curVal);
            tabControl1.Enabled = true;
            RefreshTable();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshHypothesis();
        }

        private void відкритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(openFileDialog1.FileName);
                string line;
                string[] f = new string[10];
                int i = 0;
                arr.Clear();
                dataGridView1.Rows.Clear();
                n.Clear();
                minVal = 10000000;
                maxVal = -10000000;
                while ((line = reader.ReadLine()) != null)
                {
                    f = line.Split('\t');
                    dataGridView1.Rows.Add(1);
                    for (int j = 0; j < f.Length; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = f[j];
                        AddValue(i, j);
                    }
                    i++;
                }


            }
        }

        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(saveFileDialog1.FileName);
                for(int i =0; i < arr.Count; i++)
                {
                    writer.Write(arr[i].ToString());
                    if ( (i+1) % 10 == 0)
                        writer.Write("\r\n");
                    else
                        if (i != arr.Count - 1)
                          writer.Write("\t");


                }
                writer.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < n.Count - 1; i++)
            {
                if (n[i] < 5)
                {
                    List<float> copy = new List<float>();

                    if (n[i + 1] < n[i - 1])
                    {
                        int val = n[i] + n[i+1];
                        n.RemoveAt(i+1);
                        n.RemoveAt(i);
                        n.Insert(i, val);
                        trackBarPro1.Values.RemoveAt(i + 1);
                        foreach (float f in trackBarPro1.Values)
                            copy.Add(f);
                        //i--;

                    }
                    else
                    {
                        int val = n[i] + n[i - 1];
                        n.RemoveAt(i);
                        n.RemoveAt(i - 1);
                        n.Insert(i - 1, val);
                        trackBarPro1.Values.RemoveAt(i-1);
                        foreach (float f in trackBarPro1.Values)
                            copy.Add(f);
                       // i--;

                    }
                    numericUpDown1.Value--;
                    trackBarPro1.Values = copy;
                }

            }
            if (n.Count >= 2)
            {
                List<float> copy = new List<float>();

                if (n[0] < 5)
                {
                    int val = n[0] + n[1];
                    n.RemoveAt(1);
                    n.RemoveAt(0);
                    n.Insert(0, val);
                    trackBarPro1.Values.RemoveAt(1);
                    foreach (float f in trackBarPro1.Values)
                        copy.Add(f);
                    numericUpDown1.Value--;
                    trackBarPro1.Values = copy;
                }
            }
            if (n.Count >= 2)
            {
                 List<float> copy = new List<float>();
                if (n[n.Count - 1] < 5)
                {
                    int val = n[n.Count - 1] + n[n.Count - 2];
                    n.RemoveAt(n.Count - 2);
                    n.RemoveAt(n.Count - 1);
                    n.Insert(n.Count - 1, val);
                    trackBarPro1.Values.RemoveAt(trackBarPro1.Values.Count - 1);
                    foreach (float f in trackBarPro1.Values)
                        copy.Add(f);
                    numericUpDown1.Value--;
                    trackBarPro1.Values = copy;
                }

            }
            RefreshTable();
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            RefreshDiagram();
            RefreshPolygon();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            RefreshDiagram();
            RefreshPolygon();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            RefreshDiagram();
            RefreshPolygon();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDiagram();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            RefreshPolygon();
        }


    }
}

/*
3,082	0,767	0,597	1,634	1,494	2,217	1,316	0,744	-0,508	0,901
0,885	1,517	0,878	0,23	2,976	-0,0788	0,471	0,404	-0,174	1,068
0,218	0,464	1,727	1,036	3,407	0,486	1,816	0,44	-0,03	0,618
1,88	0,641	0,447	0,249	1,023	0,554	-0,548	0,665	2,296	-0,349
3,139	0,843	0,28	1,574	2,626	0,806	-0,322	1,369	1,019	0,274
*/
/*
1	2	4	4	4	4	6	6	6	6
6	6	8	8	8	8	8	8	8	8
8	8	10	10	10	10	10	10	10	10
10	10	10	10	10	10	10	10	10	10
12	12	12	12	12	12	12	12	12	12
12	12	12	12	12	12	12	12	12	12
14	14	14	14	14	14	14	14	14	14
14	14	14	14	14	14	16	16	16	16
16	16	16	16	16	16	16	18	18	18
18	18	18	18	20	20	20	20	20	23
 * 
 * 

 */
