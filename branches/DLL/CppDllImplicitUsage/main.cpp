// MyExecRefsDll.cpp
// compile with: /EHsc /link MathFuncsDll.lib

#include <iostream>

#include "MyMathFuncs.h"

using namespace std;

int main()
{
    double a = 7.4;
    int b = 99;
	cout << Add(a,b);
    cout << "a + b = " <<
        MathFuncs::MyMathFuncs::Add1(a, b) << endl;
    cout << "a - b = " <<
        MathFuncs::MyMathFuncs::Subtract(a, b) << endl;
    cout << "a * b = " <<
        MathFuncs::MyMathFuncs::Multiply(a, b) << endl;
    cout << "a / b = " <<
        MathFuncs::MyMathFuncs::Divide(a, b) << endl;

    return 0;
}
