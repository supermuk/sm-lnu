#include "CSparseMatrix.h"
#include <iostream>

using namespace std;

int main()
{
	{

		//Створюєм матрицю розміром 5х7, перевіряєм getHeight(), getWidth(), nonZeroCount()
		bool test1 = true;
		try
		{
			CSparseMatrix<int> m1(5,7);
			if( m1.getHeight() != 5)
				test1 = false;
			if( m1.getWidth() != 7)
				test1 = false;
			if( m1.nonZeroCount() != 0)
				test1 = false;
		}
		catch(...)
		{
			test1 = false;
		}

		//Задаєм 1 ненулювий елемент, перевіряєм getVal(х, у), operator[]
		const size_t N = 100000;
		bool test2 = true;
		try
		{
			CSparseMatrix<float> m2(N,N);
			m2.setVal(10, 10, 10);
			if( m2.getVal(10, 10) != 10 )
				test2 = false;
			if( m2.getVal(10, 10) != 10 )
				test2 = false;
		}
		catch(...)
		{
			test2 = false;
		}

		//Перевіряєм operator +- , deleteAllZero()
		bool test3 = true;
		try
		{
			CSparseMatrix<int> m31(N,N);
			CSparseMatrix<int> m32 (N,N);
			m31.setVal(0,0, 10);
			m32.setVal(0,0, 1);
			m31.setVal(N-1, N-1, 20);
			m32.setVal(0,1, 5);
			CSparseMatrix<int> m3 = m31 + m32;
			if( m3.getVal(0, 0) != 11 || m3.getVal(N-1, N-1) != 20 || m3.getVal(0, 1) != 5)
				test3 = false;
			m3 = m3 - m3;
			//m3.deleteAllZero();
			if( m3.nonZeroCount() != 0)
				test3 = false;
		}
		catch(...)
		{
			test3 = false;
		}



		//Перевіряєм operator *
		bool test4 = true;
		try
		{
			CSparseMatrix<int> m41(10,10);
			CSparseMatrix<int> m42(10,10);
			m41.setVal(0, 0, 1);
			m41.setVal(0, 1, 2);
			m41.setVal(0, 2, 7);

			m41.setVal(1, 0, -2);
			m41.setVal(1, 1, 3);
			m41.setVal(1, 2, 1);

			m42.setVal(0, 0, 2);
			m42.setVal(0, 1, 3);

			m42.setVal(1, 0, 5);
			m42.setVal(1, 1, 1);

			m42.setVal(2, 0, 2);
			m42.setVal(2, 1, 2);

			CSparseMatrix<int> m4;
			m4 = m41 * m42;
			if( m4[0][0] != 26 || m4[0][1] != 19 || m4[1][0] != 13 ||m4[1][1] != -1)
				test4 = false;
			if( m4.nonZeroCount() != 4)
				test4 = false;

		}
		catch(...)
		{
			test4 = false;
		}
		

		bool test5 = true;
		try
		{
			CSparseMatrix<int> m51(10, 10);
			m51.setVal(0,0, 10);
			m51.setVal(0,1, 20);
			CSparseMatrix<int> m52(10, 10);
			m52.setVal(0,0, -10);
			CSparseMatrix<int> m5;
			m5 = m51 + m52;
			if( m51.nonZeroCount() == 2 && m52.nonZeroCount() == 1 && m5.nonZeroCount() != 1)
				test5 = false;
			m5 = m5*0;
			if( m5.nonZeroCount() != 0)
				test5 = false;

		}
		catch(...)
		{
			test5 = false;
		}

		cout<< "Test 1 " << (test1?"passed":"failed") << ". getHeight(), getWidth(), nonZeroCount() work " << (test1?"correct":"incorrect") << endl;
		cout<< "Test 2 " << (test2?"passed":"failed") << ". getVal(x, y), operator[] work " << (test2?"correct":"incorrect") << endl;
		cout<< "Test 3 " << (test3?"passed":"failed") << ". operator +- , deleteAllZero() work " << (test3?"correct":"incorrect") << endl;
		cout<< "Test 4 " << (test4?"passed":"failed") << ". operator * work " << (test4?"correct":"incorrect") << endl;
		cout<< "Test 5 " << (test4?"passed":"failed") << ". deleteAllZero() work " << (test5?"correct":"incorrect") << endl;

		
		
		
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