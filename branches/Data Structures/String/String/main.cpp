#include "CTestSuite.h"
#include "CString.h"
#include <iostream>
#include <string>

using namespace std;

size_t test1()
{
	CString s("bob");
	s = s + "!!!";
	return s.Length();
}


bool test3()
{
	CString s("bob");
	return s.SubString("bo");
}



bool test5()
{
	CString s("bob");
	return s.SubString("bobs");
}

CString test6()
{
	CString s("bob");
	return s.GetSubString(0, 2);
}

const int N = 2000;
bool test9()
{
	CString s("bob");
	for(int i = 0; i < N; i++)
	{
		s = s + "bob";
	}
	s = s + "s";
	return s.SubString("bobs");
}

CString test10()
{
	CString s("bobob");
	s.Remove(1,2);
	return s;
}
CString test11()
{
	CString s("bob");
	s.Insert(1,CString("123"));
	return s;
}

size_t test12()
{
	CString s("bobobobobob");
	return s.FindAllSubStrings(0, "bob").size();
}

CString test13()
{
	CString s("bobobobobob");
	s.ReplaceAllSubStrings("bob", "lol");
	return s;
}

CString test14()
{
	CString s("bobobobobob");
	s.ReplaceAllSubStrings("bob", "boblol");
	return s;
}

int main()
{

	{
		CTestSuite tester;

		tester.AddTest<size_t>(test1,6, " Concatination 2 CStrings");
		tester.AddTest<bool>(test3, true, " SubString(CString str) ");
		tester.AddTest<bool>(test5, false, " SubString(CString str)  str.Length > Length ");
		tester.AddTest<CString>(test6, CString("bo"), "GetSubString(size_t start, size_t count)");
		tester.AddTest<bool>(test9, true, "speed test");

		tester.AddTest<CString>(test10, CString("bob"),"Remove");
		tester.AddTest<CString>(test11, CString("b123ob"),"Insert");
		tester.AddTest<size_t>(test12,3,"FindAllSubStrings");
		tester.AddTest<CString>(test13, CString("lololololol"),"ReplaceAllSubStrings");
		tester.AddTest<CString>(test14, CString("boblolobobloloboblol"),"ReplaceAllSubStrings");
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