#include "stack.h"
#include <iostream>

//#include <stdio.h>
//
//#define _CRTDBG_MAP_ALLOC
//#include <stdlib.h>
//#include <crtdbg.h>


using namespace std;




int main()
{
	
	{
		const int N = 1000;
		bool test1 = false;
		Stack<int> stack1;

		try
		{
			
			
			for(int i = 0; i < N; i++)
			{
				stack1.push(i);
			}
			if( stack1.size() == N )
				test1 = true;
			}
		catch(...)
		{
			test1 = false;
		}


		bool test2 = true;

		try
		{
			for(int i = N-1; i >= 0; i--)
			{
				if( stack1.top() != i )
				{
					test2 = false;
					break;
				}
				stack1.pop();
			}
			if(!stack1.empty())
				test2 = false;
		}
		catch(...)
		{
			test2 = false;
		}

		bool test3 = false;

		Stack<int> stack3;
		
		//stack3.push(0);
		try
		{
			stack3.pop();
		}
		catch(...)
		{
			test3 = true;
		}

		cout<< "Test 1 " << (test1?"passed":"failed") << ". push(T ), size() work " << (test1?"correct":"incorrect") << endl;
		cout<< "Test 2 " << (test2?"passed":"failed") << ". top(), empty() work " << (test2?"correct":"incorrect")<<endl ;
		cout<< "Test 3 " << (test3?"passed":"failed") << ". stack underflow exeption work " << (test3?"correct":"incorrect")<< endl;
	}

	int* arr = new int[100];

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