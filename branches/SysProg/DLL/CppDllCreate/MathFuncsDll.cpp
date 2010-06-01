#include "MyMathFuncs.h"

#include<string>

using namespace std;


extern "C"__declspec (dllexport) double __stdcall Add (double a, double b)
{
	return a + b;
}

extern "C"__declspec (dllexport) double __stdcall Calc (const char* a)
{
	CParser parser;
	return parser.Calculate(a);
}

