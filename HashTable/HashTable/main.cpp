#include "CTestSuite.h"
#include "CHashTable.h"
#include <iostream>

using namespace std;

size_t hash1 (string key)
{
	size_t res = 0;
	for(int i = 0 ; i < key.length(); i++)
	{
		res += key[i] - 'a';
	}
	return res%100;
}

size_t hash2 (int key)
{
	return key%100;
}

bool test1()
{
	CHashTable<string, int> table(100, hash1);
	table.Insert("bob", 5);
	return table.Consist("bob");
}

bool test2()
{
	CHashTable<string, int> table(100, hash1);
	table.Insert("bob", 5);
	table.Remove("bob");
	return table.Consist("bob");
}

const int N = 10000;
bool test3()
{
	CHashTable<int, string> table(100, hash2);
	for(int i = 0; i < N; i++)
	{
		table.Insert(i, "bob");
	}
	return table.Consist(N);

}

bool test4()
{
	CTable<int, string> table;
	for(int i = 0; i < N; i++)
	{
		table.Insert(i, "bob");
	}
	return table.Consist(N);

}

string test5()
{
	CHashTable<int, string> table(100, hash2);
	for(int i = 0; i < N; i++)
	{
		table[i] = "bob";
	}
	return table[N-1];

}

int main()
{

	{
		CTestSuite tester;
		
		tester.AddTest<bool>(test1, true, " insert, consist" );
		tester.AddTest<bool>(test2, false, " insert, remove, consist" );

		tester.AddTest<bool>(test3, false, " speed CHashTable" );
		tester.AddTest<bool>(test4, false, " speed CTable" );
		tester.AddTest<string>(test5, "bob", " operator[]" );

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