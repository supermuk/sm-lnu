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
        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string csFileName);

        [DllImport("kernel32.dll")]
        static extern IntPtr GetProcAddress(IntPtr IntPtr_Module, string  csProcName);

        [DllImport("kernel32.dll")]
        static extern bool FreeLibrary(IntPtr IntPtr_Module);

        [DllImport("CppDllCreate.dll",CharSet = CharSet.Auto)]
        public static extern double Add(double a, double b);


        static void Main(string[] args)
        {
            IntPtr lib = LoadLibrary("CppDllCreate.dll");
            IntPtr func = GetProcAddress(lib, "Add");
            Console.WriteLine(lib);
            Console.WriteLine(Add(2,3));
        }
    
    }
}

