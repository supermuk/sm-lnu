using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Iteration_Methods
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        private int MAX_ERROR = 10000;

        private List<string> Split(List<string> formula, string separators)
        {
            for (int k = 0; k < separators.Length; k++)
            {
                List<string> copy = new List<string>();
                foreach (string sformula in formula)
                {
                    string[] arr; 
                    arr = sformula.Split(separators[k]);

                    for (int i = 0; i < arr.Length; i++)
                    {
                        copy.Add(arr[i]);
                        if (i != arr.Length - 1)
                            copy.Add(separators[k].ToString());
                    }
                }
                formula.Clear();
                formula = copy;
            }
            return formula;
            
        }
        private void ToDo(string op,  List<string> formula, double arg)
        {
            int mode = 2;
            if( op == "sin" || op == "cos" || op == "ln")
                mode = 1;
            bool exist = true;
            while (exist)
            {
                exist = false;
                for (int i = 0; i < formula.Count; i++)
                {
                    if (op == "+-" && (formula[i] == "+" || formula[i] == "-"))
                    {
                            exist = true;
                            double left = 0;
                            double right;
                            left = double.Parse(formula[i - 1]);
                            right = double.Parse(formula[i + 1]);
                            double result = 0;
                            switch (formula[i])
                            {
                                case "+": result = left + right; break;
                                case "-": result = left - right; break;
                            }
                            formula.RemoveRange(i - mode + 1, 1 + mode);
                            
                            formula.Insert(i - mode + 1, result.ToString());
                    }
                    else
                    {
                        if (formula[i] == op)
                        {
                            exist = true;
                            double left = 0;
                            double right;
                            if (mode != 1)
                            {
                                if (formula[i - 1] == "x")
                                    left = arg;
                                else
                                    left = double.Parse(formula[i - 1]);
                            }
                            if (formula[i + 1] == "x")
                                right = arg;
                            else
                                right = double.Parse(formula[i + 1]);
                            double result = 0;
                            switch (op)
                            {
                                case "*": result = left * right; break;
                                case "/": if (right == 0) throw (new Exception("Помилка при діленні на 0")); result = left / right; break;
                             //   case "+": result = left + right; break;
                             //   case "-": result = left - right; break;
                                case "^": result = Math.Pow(left, right); break;
                                case "sin": result = Math.Sin(right); break;
                                case "cos": result = Math.Cos(right); break;
                                case "ln": if (right <= 0) throw (new Exception("Error")); result = Math.Log(right); break;

                            }
                            formula.RemoveRange(i - mode + 1, 1 + mode);
                            formula.Insert(i - mode + 1, result.ToString());
                        }
                    }
                }
                    
            }
        }
        private List<string> Separator(string text)
        {
            
            for (int i = 0; i < text.Length; i++)
            {
               
                if (text[i] == '.') 
                {
                    text = text.Remove(i, 1);
                    text = text.Insert(i, ",");
                }
            }

            List<string> formula = new List<string>();
            formula.Add(text);
            formula = Split(formula, "()/*+-^x ");
            while (formula.Remove(""))
            {
            }
            while (formula.Remove(" "))
            {
            }
            return formula;
        }
        private string calculateFormula(string text, double arg)
        {
            List<string> formula = Separator(text);
            for (int i = 0; i < formula.Count; i++)
            {
                if (formula[i] == "(")
                {
                    string newform = "" ;
                    int count = 1;
                    int j = i + 1;
                    while (count > 0 && j < formula.Count)
                    {
                        if (formula[j] == ")")
                            count--;
                        if (formula[j] == "(")
                            count++;
                        newform += formula[j];
                        j++;
                    }
                    if (count > 0)
                        throw (new Exception("Синтаксична Помилка"));
                    formula.RemoveRange(i, j - i);
                    formula.Insert(i, calculateFormula(newform.Substring(0, newform.Length - 1), arg));

                }
            }

            for (int i = 0; i < formula.Count; i++)
            {
                if (formula[i] == "x")
                {
                    formula.RemoveAt(i);
                    formula.Insert(i, arg.ToString());
                }

            }
            ToDo("ln", formula, arg);
            ToDo("sin", formula, arg);
            ToDo("cos", formula, arg);
            ToDo("^", formula, arg);
            ToDo("*", formula, arg);
            ToDo("/", formula, arg);
            ToDo("+-", formula, arg);
          //  ToDo("-", formula, arg);
            string result = "" ;
            foreach (string s in formula)
                result += s;
            return result ;
        
        }
        private void Draw(int RANGE)
        {
            double a = Double.Parse(textBoxA.Text);
            double b = Double.Parse(textBoxB.Text);

            //int RANGE = 100;
            int MAX = 999999;


            Graphics gr;
            gr = pictureBoxGraphic.CreateGraphics();
            pictureBoxGraphic.Refresh();
            int w = pictureBoxGraphic.Width;
            int h = pictureBoxGraphic.Height;
            int z = 50;
            
            gr.DrawLine(Pens.Blue, new Point(0, h / 2), new Point(w, h / 2));
            gr.DrawLine(Pens.Blue, new Point(w / 2, 0), new Point(w / 2, h));
            for (int i = w / 2; i < w; i += z)
            {
                gr.DrawLine(Pens.Blue, new Point(i, h / 2 - 5), new Point(i, h / 2 + 5));
            }
            for (int i = h / 2; i < h; i += z)
            {
                gr.DrawLine(Pens.Blue, new Point(w / 2 - 5, i), new Point(w / 2 + 5, i));
            }
            for (int i = w / 2; i > 0; i -= z)
            {
                gr.DrawLine(Pens.Blue, new Point(i, h / 2 - 5), new Point(i, h / 2 + 5));
            }
            for (int i = h / 2; i > 0; i -= z)
            {
                gr.DrawLine(Pens.Blue, new Point(w / 2 - 5, i), new Point(w / 2 + 5, i));
            }

            Point oldp;
            try
            {
                oldp = new Point(w / 2 - RANGE * z, h / 2 - (int)(Double.Parse(calculateFormula(textBoxFunction.Text, -RANGE)) * z));
            }
            catch (Exception ex)
            {
                oldp = new Point(w / 2 - RANGE * z, 0);
            }
            Point newp;
            for (double i = 1 - RANGE; i < RANGE; i += 0.1)
            {
                Pen pen = new Pen(Color.Red, 1);
                if (i > a)
                    pen.Width = 2;
                if (i > b)
                    pen.Width = 1;
                try
                {
                    newp = new Point((int)(i * z) + w / 2, h / 2 - (int)(Double.Parse(calculateFormula(textBoxFunction.Text, i)) * z));
                }
                catch (Exception ex)
                {
                    newp = new Point((int)(i * z) + w / 2, MAX);
                }
                if (Math.Abs(newp.Y - oldp.Y) < MAX_ERROR)
                {
                    gr.DrawLine(pen, oldp, newp);
                }
                oldp = newp;
            }

        }

        private string BinaryMethod()
        {
            double a = Double.Parse(textBoxA.Text);
            double b = Double.Parse(textBoxB.Text);
            if (a < 0)
            {
                double t = a;
                a = b;
                b = t;
            }
            
            double eps = Double.Parse(textBoxEps.Text);
            string text = textBoxFunction.Text;
            double arg;
            double f;
            int n = 0;
            
            do
            {
                arg = (a + b) / 2.0;
                f = Double.Parse(calculateFormula(text, arg));
                if (f < 0)
                {
                    a = arg;
                }
                else
                {
                    b = arg;
                }
                n++;
                if (n > MAX_ERROR)
                {
                    break;
                }
                 //   throw (new Exception("Проміжок існування розв'язку заданий неправильно"));

            } while (Math.Abs(f) > eps);

            return "Метод дихотолій: \r\n x= "+arg.ToString()+" \r\n f(x)=" + f.ToString()+"\r\n n=" + n.ToString() + "\r\n";


        }
        private string IterationMethod()
        {
            double a = Double.Parse(textBoxA.Text);
            double b = Double.Parse(textBoxB.Text);
            double eps = Double.Parse(textBoxEps.Text);
            string text = textBoxFunction.Text;
            double arg = b;
            double f;
            double f0;
            int n = 0;                     

            do
            {
                f = Double.Parse(calculateFormula(text, arg));
                f0 = Double.Parse(calculateFormula(text, arg + eps));
                arg =arg - f*(arg - (arg+eps) ) / (f-f0);

                n++;
                if (n > MAX_ERROR)
                    break;
                    //throw( new Exception("Проміжок існування розв'язку заданий неправильно"));
            } while (Math.Abs(f) > eps);

            return "Метод Ітерацій: \r\n x= " + arg.ToString() + " \r\n f(x)=" + f.ToString() + "\r\n n=" + n.ToString() + "\r\n";

        }
        private string ChordMethod()
        {
            double a = Double.Parse(textBoxA.Text);
            double b = Double.Parse(textBoxB.Text);
            double eps = Double.Parse(textBoxEps.Text);
            string text = textBoxFunction.Text;
            double arg = b;
            double f;
            double fc;
            int n = 0;

            double c = a;
            do
            {

                fc = Double.Parse(calculateFormula(text, c));
                
                f = Double.Parse(calculateFormula(text, arg));

                arg = arg - f * (c - arg) / (fc - f);
                n++;
                if (n > MAX_ERROR)
                {
                    break;
                    //throw (new Exception("Проміжок існування розв'язку заданий неправильно"));
                }
            } while (Math.Abs(f) > eps);

            return "Метод Хорд: \r\n x= " + arg.ToString() + " \r\n f(x)=" + f.ToString() + "\r\n n=" + n.ToString() + "\r\n";


        }
        private string TangentMethod()
        {
            double a = Double.Parse(textBoxA.Text);
            double b = Double.Parse(textBoxB.Text);
            double eps = Double.Parse(textBoxEps.Text);
            string text = textBoxFunction.Text;
            double arg = a;
            double f;
            double f0;

            int n = 0;


            do
            {
                f0 = Double.Parse(calculateFormula(text, b));
                f = Double.Parse(calculateFormula(text, arg));
                arg = arg - (arg - b) * f / (f - f0);

                n++;
                if (n > MAX_ERROR)
                {
                    break;
                    //throw (new Exception("Проміжок існування розв'язку заданий неправильно"));
                }

            } while (Math.Abs(f) > eps);
          

            return "Метод Дотичних: \r\n x= " + arg.ToString() + " \r\n f(x)=" + f.ToString() + "\r\n n=" + n.ToString() + "\r\n";

        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                Draw(100);
            }
            catch (Exception ex)
            {
                Draw(10);
            }

           // calculateFormula(textBoxFunction.Text, 0);

            try
            {
                textBoxResult.Text = BinaryMethod();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка в методі Дихотомій \r\n" + ex.Message);
            }
            try
            {
                textBoxResult.Text += IterationMethod();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка в методі Ітерацій \r\n" + ex.Message);
            }
            try
            {
                textBoxResult.Text += ChordMethod();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка в методі Хорд \r\n" + ex.Message);
            }
            try
            {
                textBoxResult.Text += TangentMethod();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка в методі Дотичних \r\n" + ex.Message);
            }
            
            
            
            
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {

            try
            {
                Draw(100);
            }
            catch (Exception ex)
            {
                Draw(10);
            }
        }
        private string findRange(double range)
        {
            double MIN_ERROR = 0.000001;
            string res = "";
            double step = 0.05;
            double fold;
            try
            {
                fold = Double.Parse(calculateFormula(textBoxFunction.Text, -range));
            }
            catch (Exception ex)
            {
                fold = 0;
            }
            double fnew;
            for (double i = -range; i < range; i += step)
            {
                try
                {
                    fnew = Double.Parse(calculateFormula(textBoxFunction.Text, i));
                }
                catch (Exception ex)
                {
                    fnew = 0;
                }
                if (fnew * fold <0)
                {
                    
                    res += "( "+(Math.Round(i - 2*step, 1)).ToString() + "; " + (Math.Round(i+2*step,1)).ToString() + " )\r\n";
                }
                fold = fnew;
            }
            return res;
        }
        private void buttonFindRange_Click(object sender, EventArgs e)
        {
            try
            {

                MessageBox.Show("Проміжки існування розвязку \r\n" +findRange(100));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Проміжки існування розвязку \r\n" + findRange(10));
            }
        }
    }
}
