using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Macroprocessor
{
    class Macro
    {
        public string Name;
        public string Description;
        public List<string> Arguments = new List<string>();

        protected Regex FindRegex;
        protected int LocalVarsIndex = 0;

        protected Regex localRegex = new Regex(@"#local (.+)");
        protected Regex globalRegex = new Regex(@"#global (.+)");

        public Macro(Match m)
        {
            Name = m.Groups[1].Value;

            string[] arguments = m.Groups[2].Value.Split(',');

            foreach (string arg in arguments)
            {
                Arguments.Add(arg.Trim());
            }

            Description = m.Groups[3].Value;

            FindRegex = new Regex("#" + Name + @"\s*\((.+)\)", RegexOptions.IgnoreCase);
        }

        protected string ParseLocalVars(string input)
        {
            Match match;
            while ((match = localRegex.Match(input)).Success)
            {
                input = input.Substring(0, match.Index) + input.Substring(match.Index + match.Length);

                string[] tmpArgs = match.Groups[1].Value.Trim().Split(',');

                foreach (string arg in tmpArgs)
                {
                    Regex r = new Regex(@"#" + arg);
                    Match m;
                    while ((m = r.Match(input)).Success)
                    {
                        input = input.Substring(0, m.Index) + "LOCAL_VAR_" +  Name + '_' + arg + "_" + LocalVarsIndex + input.Substring(m.Index + m.Length); 

                    }
                }
            }
            return input;
        }

        protected string ParseGlobalVars(string input)
        {
            Match match;

            while ((match = globalRegex.Match(input)).Success)
            {
                input = input.Substring(0, match.Index) + input.Substring(match.Index + match.Length);

                string[] tmpArgs = match.Groups[1].Value.Trim().Split(',');

                foreach (string arg in tmpArgs)
                {
                    Regex r = new Regex(@"#" + arg);
                    Match m;
                    while ((m = r.Match(input)).Success)
                    {
                        input = input.Substring(0, m.Index) + "GLOBAL_VAR_" + Name + '_' + arg  + input.Substring(m.Index + m.Length);

                    }
                }
            }

            return input;
        }


        public bool Replace(ref string input)
        { 
            Match match;
            bool changed = false;

            while ((match = FindRegex.Match(input)).Success)
            {
                LocalVarsIndex++;
                string args = match.Groups[1].Value;
                int count = 0;
                int diff = 0;
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i] == '(')
                    {
                        count++;
                    }
                    else if (args[i] == ')')
                    {
                        if (count == 0)
                        {
                            diff = args.Length - i;
                            args = args.Substring(0, i);
                            break;
                        }
                        count--;
                    }
                }
                List<string> arguments = GetArguments(args);
                string currentBody = Description;

                if (arguments.Count != Arguments.Count)
                {
                   throw new Exception("Argument count is incorrect");
                }

                for (int i = 0; i < arguments.Count; i++)
                {
                    currentBody = currentBody.Replace("#" + Arguments[i], arguments[i]);
                }

                currentBody = ParseLocalVars(currentBody);
                currentBody = ParseGlobalVars(currentBody);

                input = input.Substring(0, match.Index) + currentBody + input.Substring(match.Index + match.Length - diff);

                changed = true;
            }
            return changed;
        }


        public List<string> GetArguments(string text)
        {
            text = text.Trim();
            List<string> arguments = new List<string>();
            int index;

            do
            {
                index = GetNextComma(text);

                if (index >= 0)
                {
                    string str = text.Substring(0, index);
                    text = text.Substring((index == text.Length ? index : index + 1));
                    arguments.Add(str.Trim());
                }
            }
            while (index >= 0 && text != "");

            return arguments;
        }

        public int GetNextComma(string text)
        {
            int inBracket = 0;
            bool inString = false;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ',' && inBracket == 0 && !inString)
                {
                    return i;
                }
                else if (text[i] == '"')
                {
                    inString = !inString;
                }
                else if (text[i] == '(' && !inString)
                {
                    inBracket++;
                }
                else if (text[i] == ')' && !inString)
                {
                    inBracket--;
                }
            }

            if (inBracket > 0 || inString)
            {
                throw new Exception("Bad arguments format");
            }

            return text.Length;
        }





    }
}
