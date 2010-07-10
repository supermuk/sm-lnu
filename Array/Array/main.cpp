#include "CArray.h"
#include <iostream>
#include <vector>
#include <ctime>
#include "CTestSuite.h"


using namespace std;

const int N = 100;
size_t test1()
{
	CArray<int> array1;
	for(int i = 0; i < N; ++i)
	{
		array1.push_back(i);
	}
	return array1.size();
}

bool test2()
{
		CArray<int> array1;
		for(int i = 0; i < N; ++i)
		{
			array1.push_back(i);
		}
		CArray<int> array2(array1);
		for(size_t i = 0; i < array2.size(); ++i)
		{
			if( array2[i] != i )
			{
				return false;
			}
		}
		return true;

}
const int M = 500;
size_t test3()
{
	CArray<int> arr;
	for(int i =0; i < M; i++)
	{
		arr.push_back(i);
	}
	return arr.size();
}

size_t test4()
{
	vector<int> vec;
	for(int i =0; i < M; i++)
	{
		vec.push_back(i);
	}
	return vec.size();
}

size_t test5()
{
	CArray<int> arr;
	for(int i =0; i < M; i++)
	{
		arr.insert( arr.size()/2, i);
	}
	return arr.size();
}

size_t test6()
{
	vector<int> vec;
	for(int i =0; i < M; i++)
	{
		vec.insert( vec.begin() + vec.size()/2, i);
	}
	return vec.size();
}

size_t test7()
{
	CArray<int> arr;
	arr.setSize(10);
	arr[1] = 1;
	arr[9] = 9;
	return arr.size();
}

size_t test8()
{
	CArray<int> arr;
	for(int i = 0; i < 10; ++i)
	{
		arr.push_back(i);
	}
	arr.setRealSize(5,5);
	for(int i = 0; i < 5; i++)
	{
		if( arr[i] != i )
			throw "error";
	}
	return arr.size();
}

int test9()
{
	CArray<int> arr;
	for(int i = 0; i < 8; ++i)
	{
		arr.insert(i/2, i);
	}
	int k = 1;
	int res = 0;
	for(int i = 0; i < 8; i++)
	{
		res += k * arr[i];
		k *= 10;
	}
	return res;
}

int test10()
{
	CArray<int> arr;
	for(int i = 0; i < 5; i++)
	{
		arr.insert(arr.size(), i);
	}
	CArray<int> paste;
	for(int i = 0; i < 3; i++)
	{
		paste.insert(0, i);
	}
	arr.insert(2, paste);
	int k = 1;
	int res = 0;
	for(int i = 0; i < arr.size(); i++)
	{
		res += k * arr[i];
		k *= 10;
	}
	return res;
}
int test11()
{
	CArray<int> arr;
	for(int i = 0; i < 10; i++)
	{
		arr.push_back(i);
	}
	
	arr.remove(3,5);
	int k = 1;
	int res = 0;
	for(int i = 0; i < arr.size(); i++)
	{
		res += k * arr[i];
		k *= 10;
	}
	return res;
}

bool test12()
{
	CArray< CArray<int> > arr;
	CArray<int> a(3);
	a[0] = 1; a[1] = 2; a[2] = 3;
	arr.push_back(a);
	arr.push_back(a);
	arr.push_back(a);
	return arr[2][2] == 3;
}

int main()
{

	{
		CTestSuite tester;

		tester.AddTest<size_t>(test1, N, "pus_back, size");
		tester.AddTest<bool>(test2, true, " operator[]");

		
		tester.AddTest<size_t>(test3, M, "speed test CArray push_back" );
		tester.AddTest<size_t>(test4, M, "speed test vector push_back" );
			
		tester.AddTest<size_t>(test5, M, "speed test CArray insert" );
		tester.AddTest<size_t>(test6, M, "speed test vector insert" );

		tester.AddTest<size_t>(test7, 10, "setSize");

		tester.AddTest<size_t>(test8, 5, " setRealSize");

		tester.AddTest<int>(test9, 2467531,"insert(value)");
		tester.AddTest<int>(test10, 43201210,"insert(values)");
		
		tester.AddTest<int>(test11, 98210,"remove(index = 3 , count = 5)");

		tester.AddTest<bool>(test12, true, " CArray<CArray<int>>");
		tester.PrintResults(&cout);





	}

	//Перевірка втрати памяті
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