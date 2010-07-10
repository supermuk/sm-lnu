#include <iostream>
#include "CTestSuite.h"
#include "CSet.h"

using namespace std;

size_t test1()
{
	CSet<int> set;
	set.Insert(1);
	set.Insert(2);
	set.Insert(3);
	set.Insert(3);
	set.Insert(3);
	return set.Size();
}

bool test2()
{
	CSet<int> a;
	a.Insert(0);
	a.Insert(1);
	a.Insert(2);

	CSet<int> b;
	b.Insert(2);
	b.Insert(3);
	b.Insert(4);

	CSet<int> set = a.Union(b);
	for(size_t i  =0; i < 5; i++)
	{
		if( set[i] != i)
		{
			return false;
		}
	}
	return set.Size()==5;


}
bool test3()
{
	CSet<int> a;
	a.Insert(0);
	a.Insert(1);
	a.Insert(2);

	CSet<int> b;
	b.Insert(2);
	b.Insert(3);
	b.Insert(4);

	CSet<int> set = a.Intersection(b);
	
	return (set.Size() == 1) && (set[0] == 2);


}
bool test4()
{
	CSet<int> a;
	a.Insert(0);
	a.Insert(1);
	a.Insert(2);

	CSet<int> b;
	b.Insert(2);
	b.Insert(3);
	b.Insert(4);

	CSet<int> set = a.Difference(b);
	for(size_t i  =0; i < 5; i++)
	{
		if( (set[i - ((i > 2)? 1 : 0 )] != i )&& i != 2)
		{
			return false;
		}
	}
	return set.Size() == 4;


}
int main()
{
	{
	
		CTestSuite tester;
	
		tester.AddTest<size_t>(test1, 3, " Insert, Size");
		tester.AddTest<bool>(test2, true, " Union");
		tester.AddTest<bool>(test3, true, " Intersection");
		tester.AddTest<bool>(test4, true, " Difference");

		
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