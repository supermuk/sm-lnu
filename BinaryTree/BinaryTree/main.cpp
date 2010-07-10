#include "CBinaryTree.h"
#include "CTestSuite.h"
#include <iostream>

using namespace std;

size_t test1()
{
	CBinaryTree<int, string> tree;
	tree.Insert(1, "bob");
	tree.Insert(2, "123");
	tree.Insert(0, "");
	return tree.Size();
}

bool test2()
{
	CBinaryTree<int, string> tree;
	tree.Insert(1, "bob");
	tree.Insert(2, "123");
	tree.Insert(0, "");
	return tree.Consist(2);
}
bool test3()
{
	CBinaryTree<int, string> tree;
	tree.Insert(1, "bob");
	tree.Insert(2, "123");
	tree.Insert(0, "");
	tree.Remove(2);
	return tree.Consist(2);
}
bool test4()
{
	CBinaryTree<int, int> tree;
	tree.Insert(5, 0);
	tree.Insert(9, 1);
	tree.Insert(3, 2);
	tree.Insert(4, 3);
	tree.Insert(6, 4);
	tree.Insert(7, 5);
	tree.Insert(10, 6);
	tree.Insert(1, 7);
	tree.Insert(2, 8);
	tree.Insert(8, 9);

	tree.Remove(9);
	for(int i = 1; i < 9; i++)
	{
		if( !tree.Consist(i) )
			return false;
	}
	return tree.Consist(10);
}
bool test5()
{
	CBinaryTree<int, int> tree;
	tree[5] = 0;
	tree[9] = 1;
	tree[3] = 2;
	tree[4] = 3;
	tree[6] = 4;
	tree[7] = 5;
	tree[10] = 6;
	tree[1] = 7;
	tree[2] = 8;
	tree[8] = 9;
	tree[8] = 8;
	if( tree[8] != 8)
	{
		return false;
	}
	tree.Remove(9);
	for(int i = 1; i < 9; i++)
	{
		if( !tree.Consist(i) )
			return false;
	}
	return tree.Consist(10);
}

int main()
{
	
	{
		CTestSuite tester;
		tester.AddTest<size_t>(test1, 3, "Insert, Size");
		tester.AddTest<bool>(test2, true, "Insert, Consist");
		tester.AddTest<bool>(test3, false, "Insert,Remove, Consist");
		tester.AddTest<bool>(test4, true, "Insert, Remove, Consist");
		tester.AddTest<bool>(test5, true, "operator[], Remove, Consist");

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
