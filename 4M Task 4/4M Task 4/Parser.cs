using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace _4M_Task_4
{
    class Parser
    {
        public String Formula;
        private List<String> tokens = new List<String>();
        private List<Hashtable> priority = new List<Hashtable>();
        public Parser()
        {
            Hashtable opFunc = new Hashtable();
            opFunc.Add("sin", 1);
            opFunc.Add("cos", 1);
            opFunc.Add("ln", 1);

            Hashtable opPow = new Hashtable();
            opPow.Add("^", 2);

            Hashtable opMult = new Hashtable();
            opMult.Add("/", 2);
            opMult.Add("*", 2);

            Hashtable opAdd = new Hashtable();
            opAdd.Add("+", 2);
            opAdd.Add("-", 2);

            Hashtable opSep = new Hashtable();
            opSep.Add("(", 0);
            opSep.Add(")", 0);

            priority.Add(opSep);
            priority.Add(opFunc);
            priority.Add(opPow);
            priority.Add(opMult);
            priority.Add(opAdd);
        }
        private void CalculateTokens()
        {
            tokens.Clear();
            tokens.Add(Formula);
            tokens[0] = tokens[0].Replace(" ", "");
            tokens[0] = tokens[0].Replace('.', ',');
            tokens[0] = tokens[0].Replace("e", "2,71828183");

            foreach(Hashtable priorTable in priority)
            {
                foreach (Object separator in priorTable.Keys)
                {
                    List<string> copy = new List<string>();
                    for(int k = 0; k < tokens.Count; k++)
                    {
                        int pos = tokens[k].IndexOf(separator.ToString());
                        if (pos != -1)
                        {
                            string left = tokens[k].Substring(0, pos);
                            string right = tokens[k].Substring(pos + separator.ToString().Length, tokens[k].Length - pos - separator.ToString().Length);
                            tokens.RemoveRange(k, 1);
                            if (right.Length != 0)
                            {
                                tokens.Insert(k, right);
                            }
                            tokens.Insert(k, separator.ToString());
                            if (left.Length != 0)
                            {
                                tokens.Insert(k, left);
                            }
                            if (right.Length * left.Length != 0)
                            {
                                k++;
                            }

                        }
                    }
                }
            }
        }
        public double Calculate(double x)
        {
            return Calculate(x, 0);
        }
        public double Calculate(double x, double y)
        {
            string saveFormula = Formula;

            Formula = Formula.Replace("x", x.ToString().Replace("-", "m"));
            Formula = Formula.Replace("y", y.ToString().Replace("-", "m"));


            double result = Calculate();
            Formula = saveFormula;
            return result;
        }

        public double Calculate()
        {
            CalculateTokens();

            for(int i =0; i < tokens.Count; i++)
            {
                if( tokens[i] == "(")
                {
                    string newform = "";
                    int count = 1;
                    int j = i + 1;
                    while (count > 0 && j < tokens.Count)
                    {
                        if (tokens[j] == ")")
                        {
                            count--;
                        }
                        if (tokens[j] == "(")
                        {
                            count++;
                        }
                        newform = newform + tokens[j];
                        j++;
                    }
                    if (count > 0)
                    {
                        throw new Exception("Syntax Error");
                    }
                    newform = newform.Substring(0, newform.Length - 1);
                    Parser res = new Parser();
                    res.Formula = newform;
                    tokens.RemoveRange(i, j - i);
                    tokens.Insert(i, res.Calculate().ToString());
                }
            }
            for (int priorLvl = 1; priorLvl < priority.Count; priorLvl++)
            {
                for (int i = 0; i < tokens.Count; i++)
                {
                    if (priority[priorLvl].Contains(tokens[i]))
                    {
                        if ((int)priority[priorLvl][tokens[i]] == 1)
                        {
                            ToDoUnary(i);
                        }
                        else if ((int)priority[priorLvl][tokens[i]] == 2)
                        {
                            ToDoBinary(i);
                            i--;
                        }
                    }
                }
            }
            return double.Parse(tokens[0].Replace("m", "-"));

        }

        private void ToDoUnary(int index)
        {
            string op = tokens[index];
            string rtoken = tokens[index + 1].Replace("m", "-");
            double right = double.Parse(rtoken);
            double result = 0;
            if (op == "sin")
            {
                result = Math.Sin(right);
            }
            if (op == "cos")
            {
                result = Math.Cos(right);
            }
            if (op == "ln")
            {
                result = Math.Log(right);
            }
            tokens.RemoveRange(index, 2);
            tokens.Insert(index, result.ToString());
        }

        private void ToDoBinary(int index)
        {
            string op = tokens[index];
            string rtoken = tokens[index + 1].Replace("m", "-");
            string ltoken = tokens[index - 1].Replace("m", "-");
            double right = double.Parse(rtoken);
            double left = double.Parse(ltoken);
            double result = 0;
            if (op == "+")
            {
                result = left + right;
            }
            if (op == "-")
            {
                result = left - right;
            }
            if (op == "*")
            {
                result = left * right;
            }
            if (op == "/")
            {
                if (right == 0)
                {
                    throw new Exception("division by 0");
                }
                result = left / right;
            }
            if (op == "^")
            {
                result = Math.Pow(left, right);
            }
            tokens.RemoveRange(index - 1, 3);
            tokens.Insert(index - 1, result.ToString());
        }


    }
    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}
