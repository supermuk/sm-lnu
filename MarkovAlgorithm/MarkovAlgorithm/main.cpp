#include "CMarkovAlgo.h"
#include "CMarkovAlgoString.h"
#include "CString.h"
#include "CTestSuite.h"
#include <iostream>
#include <string>

using namespace std;


CString test1()
{
	CMarkovAlgo algo;
	algo.AddRule(Rule("11","1"));
	return algo.Compile("111111111");
}

CString test2()
{
	CMarkovAlgo algo;
	algo.AddRule(Rule("|b","ba|"));
	algo.AddRule(Rule("ab","ba"));
	algo.AddRule(Rule("b",""));
	algo.AddRule(Rule("*|","b*"));
	algo.AddRule(Rule("*","c"));
	algo.AddRule(Rule("|c","c"));
	algo.AddRule(Rule("ac","c|"));
	algo.AddRule(Rule("c","",true));

	return algo.Compile("|*||");
}

CString test3()
{
	CMarkovAlgo algo;
	algo.AddRule(Rule("|0","0||"));
	algo.AddRule(Rule("1","0|"));
	algo.AddRule(Rule("0",""));

	return algo.Compile("101");
}
CString test4()
{
	CMarkovAlgo algo;
	algo.AddRule(Rule("1*","x"));
	algo.AddRule(Rule("_1","1_Z"));
	algo.AddRule(Rule("Z1","1Z"));
	algo.AddRule(Rule("1x","x_"));
	algo.AddRule(Rule("x",""));
	algo.AddRule(Rule("_",""));
	algo.AddRule(Rule("Z","1"));

	return algo.Compile("11*1111");
}

CString test5()
{
	CMarkovAlgo algo;
	algo.AddRule(Rule("1*","x"));
	algo.AddRule(Rule("_1","1_Z"));
	algo.AddRule(Rule("Z1","1Z"));
	algo.AddRule(Rule("1x","x_"));
	algo.AddRule(Rule("x",""));
	algo.AddRule(Rule("_",""));
	algo.AddRule(Rule("Z","1"));

	return algo.Compile("1111111111111111*1111111111111111");
}
string test5s()
{
	CMarkovAlgoString algo;
	algo.AddRule(RuleString("1*","x"));
	algo.AddRule(RuleString("_1","1_Z"));
	algo.AddRule(RuleString("Z1","1Z"));
	algo.AddRule(RuleString("1x","x_"));
	algo.AddRule(RuleString("x",""));
	algo.AddRule(RuleString("_",""));
	algo.AddRule(RuleString("Z","1"));

	return algo.Compile("1111111111111111*1111111111111111");
}

CString test6()
{
	CMarkovAlgo algo;
	algo.AddRule(Rule("1*","x"));
	algo.AddRule(Rule("_1","1_Z"));
	algo.AddRule(Rule("Z1","1Z"));
	algo.AddRule(Rule("1x","x_"));
	algo.AddRule(Rule("x",""));
	algo.AddRule(Rule("_",""));
	algo.AddRule(Rule("Z","1"));

	return algo.Compile("11111111111111111111111111111111*11111111111111111111111111111111");
}
string test6s()
{
	CMarkovAlgoString algo;
	algo.AddRule(RuleString("1*","x"));
	algo.AddRule(RuleString("_1","1_Z"));
	algo.AddRule(RuleString("Z1","1Z"));
	algo.AddRule(RuleString("1x","x_"));
	algo.AddRule(RuleString("x",""));
	algo.AddRule(RuleString("_",""));
	algo.AddRule(RuleString("Z","1"));

	return algo.Compile("11111111111111111111111111111111*11111111111111111111111111111111");
}

int main()
{

	{
		CString result1;
		string resultstr1;
		for(int i =0; i < 256; i++)
		{
			result1 =result1 + "1";
			resultstr1 += "1";
		}
		CString result2;
		string resultstr2;
		for(int i =0; i < 1024; i++)
		{
			result2 =result2 + "1";
			resultstr2 += "1";
		}

		CTestSuite tester;
		tester.AddTest<CString>(test1, CString("1"), "simple test");
		tester.AddTest<CString>(test2, CString("||"), "wiki test");
		tester.AddTest<CString>(test3, CString("|||||"), "binary to unary");
		tester.AddTest<CString>(test4, CString("11111111"), " multiplying 2*4");

		tester.AddTest<CString>(test5, result1, " speed test 16*16 CString");
		tester.AddTest<string>(test5s, resultstr1, " speed test 16*16 string");

		tester.AddTest<CString>(test6, result2, " speed test 32*32 CString");
		tester.AddTest<string>(test6s, resultstr2, " speed test 32*32 string");


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