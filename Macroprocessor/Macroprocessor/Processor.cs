using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace Macroprocessor
{
    class Processor
    {
        public int MaxIncludeDepth = 2;

        //Defaults values
        public string BeginMacro = "macro";
        public string EndMacro = "endmacro";
        public string Include = "include";

        public string IncludePath = @"C:\Program Files\Microsoft Visual Studio 9.0\VC\include";

        public Regex FindMacro;
        public Regex FindInclude;

        protected List<Macro> macros;
        protected string text;

        public Processor() 
        {
            Initialize();
        }
        public void Initialize()
        {
            FindMacro = new Regex(@"#" + BeginMacro + @"\s+([a-zA-z0-9]+)\s*\((.+?)\)[\n\s\r]*(.+?)[\n\s\r]*#" + EndMacro, RegexOptions.Singleline);
            FindInclude = new Regex(@"#" + Include + @"\s*<(.+?)>");
            macros = new List<Macro>();
        }
        protected string CompileIncludes(string input, int depth)
        {
            if (depth > MaxIncludeDepth)
            {
                return input;
            }
            Match match;
            while ((match = FindInclude.Match(input)).Success)
            {
                string path = Path.Combine(IncludePath, match.Groups[1].Value);
                if (File.Exists(path))
                {
                    string include = File.ReadAllText(path);
                    include = CompileIncludes(include, depth + 1);
                    input = FindInclude.Replace(input, include);
                }
                else
                {
                    throw new Exception("Include file " + match.Groups[1].Value + " not found");
                }

            }
            return input;
        }

        protected string CreateMacros(string input)
        {
            Match match;
            while ((match = FindMacro.Match(input)).Success)
            {
                macros.Add(new Macro(match));
                input = input.Remove(match.Index, match.Length);

            }
            return input;
        }

        protected string CompileMacros(string input)
        {
            bool changed;

            do
            {
                changed = false;

                foreach (Macro macro in macros)
                {
                    changed |= macro.Replace(ref input);
                }
            }
            while (changed);
            return input;
        }


        public string Compile(string input)
        {
            Initialize();

            text = input;

            text = CompileIncludes(text, 1);
            text = CreateMacros(text);
            text = CompileMacros(text);
            return text;
        }
    }
    public static class Extends
    {
        public static string Replace(this string str, int start, int length, string replace)
        {
            return str.Substring(0, start) + replace + str.Substring(start + length);
        }
    }
}
