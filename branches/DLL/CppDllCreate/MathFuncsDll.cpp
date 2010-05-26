// MathFuncsDll.cpp
// compile with: /EHsc /LD

#include "MyMathFuncs.h"

#include <stdexcept>

using namespace std;


// Returns a + b
extern "C"__declspec (dllexport) double __stdcall Add (double a, double b)
//__declspec(dllexport) double Add(double a, double b)
{
	return a+b;
}

namespace MathFuncs
{
    double MyMathFuncs::Add1(double a, double b)
    {
        return a + b;
    }

    double MyMathFuncs::Subtract(double a, double b)
    {
        return a - b;
    }

    double MyMathFuncs::Multiply(double a, double b)
    {
        return a * b;
    }

    double MyMathFuncs::Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new invalid_argument("b cannot be zero!");
        }

        return a / b;
    }
}
