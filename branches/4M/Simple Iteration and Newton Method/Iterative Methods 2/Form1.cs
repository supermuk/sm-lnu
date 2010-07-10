using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Collections;

namespace Iterative_Methods_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string ABC = "abcdefghijklmnopqrstuvwxyz";
        private string variable = "xyzt";

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
        private void ToDo(string op, List<string> formula, Hashtable args)
        {
            int mode = 2;
            if (op == "sin" || op == "cos" || op == "ln")
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
                                if (ABC.Contains( formula[i - 1] ))
                                    left = (double) args[ formula[i - 1] ];
                                else
                                    left = double.Parse(formula[i - 1]);
                            }
                            if (ABC.Contains( formula[i + 1] ))
                                right = (double)args[formula[i + 1]];
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
            formula = Split(formula, "()/*+-^ xyzt");
            while (formula.Remove(""))
            {
            }
            while (formula.Remove(" "))
            {
            }
            return formula;
        }
        private string calculateFormula(string text, Hashtable args)
        {
            List<string> formula = Separator(text);
            for (int i = 0; i < formula.Count; i++)
            {
                if (formula[i] == "(")
                {
                    string newform = "";
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
                    formula.Insert(i, calculateFormula(newform.Substring(0, newform.Length - 1), args));

                }
            }

            for (int i = 0; i < formula.Count; i++)
            {
                if (ABC.Contains(formula[i]))
                {
                    string tmp = formula[i];
                    formula.RemoveAt(i);
                    formula.Insert(i, args[ tmp ].ToString());
                }

            }
            ToDo("ln", formula, args);
            ToDo("sin", formula, args);
            ToDo("cos", formula, args);
            ToDo("^", formula, args);
            ToDo("*", formula, args);
            ToDo("/", formula, args);
            ToDo("+-", formula, args);
            //  ToDo("-", formula, arg);
            string result = "";
            foreach (string s in formula)
                result += s;
            return result;

        }

        private double Differencial(string formula, Hashtable args, string variable, double eps)
        {
            double f0 = double.Parse(calculateFormula(formula, args));
            args[ variable ] = (double) args[ variable ] + eps;
            double f1 = double.Parse(calculateFormula(formula, args));
            return (f1 - f0) / eps;
        }



        private void button1_Click(object sender, EventArgs e)
        {
           
        }


        private int firstCount = 0;
        private Hashtable vars1 = new Hashtable();

        private void button2_Click(object sender, EventArgs e)
        {
            int n = (int)numericUpDown1.Value;
            if (firstCount == 0)
            {
                vars1["x"] = double.Parse(textBox2.Text);
                vars1["y"] = double.Parse(textBox3.Text);
                vars1["z"] = double.Parse(textBox4.Text);
                vars1["t"] = double.Parse(textBox5.Text);

            }
            firstCount++;
            label19.Text = "n=" + firstCount.ToString();
            for (int i = 0; i < n; i++)
            {
                vars1[ variable[i].ToString() ] = double.Parse( calculateFormula( textBox1.Lines[i], vars1) );
            }
            string print = "(";
            for(int i = 0 ;i < n; i++)
            {
                print +=  vars1[variable[i].ToString()].ToString() + ((i == n-1)?") \r\n":", ");
            }
            textBox6.Text = print + textBox6.Text;
            
        }



        private int secondCount = 0;
        private Hashtable vars2 = new Hashtable();

        private void button3_Click(object sender, EventArgs e)
        {
            int n = (int)numericUpDown2.Value;
            if (secondCount == 0)
            {
                vars2["x"] = double.Parse(textBox10.Text);
                vars2["y"] = double.Parse(textBox11.Text);
                vars2["z"] = double.Parse(textBox12.Text);
                vars2["t"] = double.Parse(textBox13.Text);

            }
           
            secondCount++;
            label20.Text = "n=" + secondCount.ToString();

            double eps = 0.00001;
            Matrix f = new Matrix(n, 1);

            Matrix fx = new Matrix(n, n);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    fx.arr[i][j] = Differencial(textBox8.Lines[i], vars2, variable[j].ToString(), eps);
                }
            }
            for (int i = 0; i < n; i++)
            {
                f.arr[i][0] = double.Parse(calculateFormula(textBox8.Lines[i], vars2 ));
            }




            string print = "Det Fx = " + fx.Determinant() + "\r\n";
            

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    print += fx.arr[i][j].ToString() + "  ";
                }
                print += "\r\n";
            }

            Matrix fx1 = fx.Inverse();

           /*
            print += "Inverse \r\n";
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    print += fx1.arr[i][j].ToString() + "  ";
                }
                print += "\r\n";
            }
*/
            Matrix res = fx1*f;
            /*
            print += f.arr[0][0] + "  ;  " + f.arr[1][0] + "\r\n";
            print += vars2["x"] + "  ;  " + vars2["y"] + "\r\n";
            print += res.arr[0][0] + "  ;  " + res.arr[1][0] + "\r\n";
            */
            for (int i = 0; i < n; i++)
            {
                vars2[variable[i].ToString()] = (double)vars2[variable[i].ToString()] - res.arr[i][0];

            }

           
            print += "(";
            for (int i = 0; i < n; i++)
            {
                print += vars2[variable[i].ToString()].ToString() + ((i == n - 1) ? ") \r\n" : ", ");
            }
            textBox7.Text = print + textBox7.Text;

        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value == 2)
            {
                textBox4.Enabled = false;
                textBox5.Enabled = false;
            }
            if (numericUpDown1.Value == 3)
            {
                textBox4.Enabled = true;
                textBox5.Enabled = false;
            }
            if (numericUpDown1.Value == 4)
            {
                textBox4.Enabled = true;
                textBox5.Enabled = true;
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown2.Value == 2)
            {
                textBox12.Enabled = false;
                textBox13.Enabled = false;
            }
            if (numericUpDown2.Value == 3)
            {
                textBox12.Enabled = true;
                textBox13.Enabled = false;
            }
            if (numericUpDown2.Value == 4)
            {
                textBox12.Enabled = true;
                textBox13.Enabled = true;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            firstCount = 0;
            textBox6.Text = "";
            label19.Text = "n=0";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox7.Text = "";
            secondCount = 0;
            label20.Text = "n=0";
        }

    }
}

/*

(x^3+y^3+3)/6
(x^3-y^3+2)/6

x = (1-y^2-z^2)^0,5
y = (3*x^2+z^2)/4
z = (2*x^2+y^2)/4

x^2+y^2+z^2-1
2*x^2+y^2-4*z
3*x^2-4*y+z^2
 * 
2*x^2+3*y^2-6*y-4
x^2-3*y^2+4*x-2
 * 
 * 
*/