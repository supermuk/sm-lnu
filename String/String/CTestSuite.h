#pragma once
#include <vector>
#include <string>
#include <iostream>
#include <ctime>

using namespace std;

class CBaseTest
{

};

template<class TResult>
	class CTest: public CBaseTest
	{
	public:
		TResult (*m_function) ();
		CTest(TResult (* pf)()) 
		{ 
			m_function = pf; 
		}

		
	};

class CTestSuite
{
private:
	vector< CBaseTest* > mTests;
	vector< bool > mResults;
	vector< string > mComments;
	vector< long > mTimes;
public:
	
	void Run()
	{
	}

	template<class TResult>
		void AddTest( TResult (* pf)(), TResult correctResult, string comment, bool exeptionTest = false)
		{
			//mTests.push_back( new CTest<TResult> ( pf ));
			
			clock_t c = clock();

			bool result = true;
			try
			{
				if( pf() != correctResult)
				{
					result = false;	
				}
			}
			catch(...)
			{
				result = exeptionTest;
			}
			mTimes.push_back( clock()-c );
			mResults.push_back(result);
			mComments.push_back(comment);

		}

	void PrintResults(ostream* out)
	{
		string print;
		for(size_t i = 0; i < mResults.size(); i++)
		{
			(*out) << "Test ";
			(*out) << i + 1;
			(*out) <<  (string) ": " + ( mResults[i] ? "passed. " : "faild. " ) + mComments[i] + " Time: ";
			(*out) <<  mTimes[i];
			(*out) << "ms. \n";

		}
	}
};