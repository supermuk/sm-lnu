#include "CTable.h"
#include "CTestSuite.h"
#include <string>
#include <iostream>

#include <map>

using namespace std;


const size_t N = 10;


size_t test1()
{
	CTable<int, string> table;
	for(int i = 0; i < N; i++)
	{
		table.Insert(i, "bob");
	}
	return table.Size();
}

bool test2()
{
	CTable<int, string> table;
	for(int i = 0; i < N; i++)
	{
		table.Insert(i, "bob");
	}
	CTable<int, string> table2(table);
	return table2.Consist(5);
}

string test3()
{
	CTable<int, string> table;
	for(int i = 0; i < N; i++)
	{
		table.Insert(i, "bob");
	}
	table.Change(5, "bobby");
	return table.GetValue(5);
}




int test4()
{
	CTable<string, int> table;
	table.Insert("bob", 2);
	table.Insert("lol", 5);
	table["bob2"]++;
	return table["bob2"];
}

int test5()
{
	CTable<int, int> table;
	table.Insert(1, 2);
	table.Insert(2, 5);
	table[3]++;
	return table[3];
}

bool test6()
{
	CTable<string, int> table;
	table.Insert("bob", 2);
	table.Insert("lol", 5);
	return table.Consist("bob2");;
}


//speed tests
const int MAX = 100000;
bool test7()
{
	CTable<int, string> table;
	for(int i = MAX ; i  > 0; i--)
	{
		table.Insert(i, "bob");
	}
	table.Consist(MAX+1);
	return true;
}

bool test8()
{
	map<int, string> table;
	for(int i = MAX ; i  > 0; i--)
	{
		table.insert( make_pair<int, string> ( i, "bob" ));
		//table. iInsert(rand(), "bob");
	}
	table.find(MAX+1);
	return true;
}

bool test9()
{
	CTable<string, int> table;
	table["bob"] = 1;
	return table.Consist("bob");
}

bool test10()
{
	CTable<string, int> table;
	table["bob"] = 1;
	table.Remove("bob");
	return table.Consist("bob");

}

int main()
{
	{
	
		CTestSuite tester;

		tester.AddTest<size_t>(test1, N, "Create and fill CTable by elements with keys 1..N ");
		tester.AddTest<bool>(test2, true, "Copy CTable, return Consist(key)");
		tester.AddTest<string>(test3, "bobby", "Change value of element with key = '5' ");
		tester.AddTest<int>(test4, 1 , " ");
		tester.AddTest<int>(test5, 1 , " ");
		tester.AddTest<bool>(test6, false , " Consist(key) ");

		//tester.AddTest<bool>(test7, true , "CTable ");
		//tester.AddTest<bool>(test7, true , " map ");

		tester.AddTest<bool>(test9, true , " [] ");
		tester.AddTest<bool>(test10, false , " remove ");

		tester.Run();
		 
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