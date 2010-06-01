using System;   
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Reflection;

namespace CsDllExplicitUsage
{
    class Program
    {
        [DllImport("CppDllCreate.dll",CharSet = CharSet.Ansi)]
        public static extern double Add(double a, double b);

        [DllImport("CppDllCreate.dll", CharSet = CharSet.Ansi)]
        public static extern double Calc(string str);

        static void Main(string[] args)
        {
            Console.WriteLine("Demo: Explicit DLL usage in C#");
            Console.WriteLine("Press Ctrl + C to exit");
            while (true)
            {
                Console.Write("Enter expression to calculate: ");
                string expression = Console.ReadLine();

                Console.WriteLine(expression + " = " + Calc(expression));
            }
        }
    
    }
}

