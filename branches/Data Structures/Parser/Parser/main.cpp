#include "CParser.h"
#include "CTestSuite.h"
#include <iostream>

using namespace std;

double test0()
{
	CParser parser("2+2");
	return parser.Calculate();
}

double test1()
{
	CParser parser("2+2*2");
	return parser.Calculate();
}
double test2()
{
	CParser parser("(2+2)^2");
	return parser.Calculate();
}
double test3()
{
	CParser parser;
	return parser.Calculate("sin(sin(sin(1.0)))");
}
double test4()
{
	CParser parser;
	return parser.Calculate("5/0+2-3*7-0*2");
}
double test5()
{
	CParser parser;
	return parser.Calculate("(5+(2-3)*7-0*2");
}
int main()
{
	{
		CTestSuite tester;
		tester.AddTest<double>(test0, 4, "2+2");
		tester.AddTest<double>(test1, 6, "2+2*2");
		tester.AddTest<double>(test2, 16, "(2+2)^2");
		tester.AddTest<double>(test3, 0.67843, "sin(sin(sin(1)))");
		tester.AddTest<double>(test4, 0, "5/0", true);
		tester.AddTest<double>(test5, 0, "Syntax incorrect", true);

		tester.PrintResults(&cout);
	}

	cout << "Memory status: " ;
	if( _CrtDumpMemoryLeaks() == 0)
	{
		cout<< "Ok" << endl;
	}
	else
	{
		cout << "Bad" << endl;
	}
	return 0;
}