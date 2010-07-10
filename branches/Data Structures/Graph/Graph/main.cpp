#include "CGraph.h"
#include "CTestSuite.h"
#include <iostream>

using namespace std;

size_t test1()
{
	CGraph graph;
	graph.AddLink(0, 1);
	graph.AddLink(1, 2);
	graph.AddLink(0, 2);
	return graph.Size();
}
bool test2()
{
	CGraph graph(3);
	graph[0][1]  = 10;
	graph[1][2] = 0;
	graph[0][2] = 3;
	return graph.Size() == graph[0][2];

}

int test3()
{
	CGraph graph(6);
	graph[0][1] = 4;
	graph[0][2] = 2;
	graph[2][1] = 1;
	graph[2][3] = 8;
	graph[2][4] = 10;
	graph[1][3] = 5;
	graph[3][4] = 2;
	graph[3][5] = 6;
	graph[4][5] = 3;
	return graph.DijkstraPathWeight(0,5);
}
int test4()
{
	CGraph graph(4);
	graph[0][1]  = 10;
	graph[1][2] = 1;
	graph[0][2] = 3;
	return graph.DijkstraPathWeight(0,3);
}
int main()
{

	{
		CTestSuite tester;
		tester.AddTest<size_t>(test1, 3, "AddLink, Size");
		tester.AddTest<bool>(test2, true, "operator[], Size");
		tester.AddTest<int>(test3, 13, "DeijkstraPathWeight");
		tester.AddTest<int>(test4, -1 , "DeijkstraPathWeight NoWay");



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