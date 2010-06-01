#include <iostream>
#include <string>

#include "MyMathFuncs.h"

using namespace std;

int main()
{

	cout << "Demo: Implicit DLL usage in C++";
	cout << "Press Ctrl + C to exit" << endl;
	while( true )
	{
		cout << "Enter expression to calculate: ";
		string expression;
		cin >> expression;
		cout <<expression << " = " << Calc(expression.c_str()) << endl;
	}
    return 0;
}
