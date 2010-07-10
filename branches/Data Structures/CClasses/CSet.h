#pragma once
#include "CTable.h"



template<class T>
	class CSet: public CTable<T, int>
	{
	private:
		//void Insert(const T, const int);
		void Change(const T, const int);
		int GetValue(const T);
		//int& operator[](const T);
	public:
		CSet(const CSet<T>& set):CTable<T,int>(set){}
		CSet():CTable<T,int>(){}
		void Insert(const T);
		
		CSet<T> Union(const CSet<T>& );
		CSet<T> Intersection(const CSet<T>& );
		CSet<T> Difference(const CSet<T>& );
		bool IsSubsetOf(const CSet<T>& );

	};

template<class T>
	void CSet<T>::Insert(const T element)
	{
		if(! Consist(element) )
		{
			CTable<T,int>::Insert(element);
		}
	}
template<class T>
	CSet<T> CSet<T>::Union(const CSet<T>& set)
	{
		CSet<T> res(*this);
		for(int i=0 ; i < set.Size(); i++)
		{
			res.Insert( set[i] );
		}
		return res;
	}
template<class T>
	CSet<T> CSet<T>::Intersection(const CSet<T>& set)
	{
		CSet<T> res;
		for(int i = 0; i < set.Size(); i++)
		{
			if( this->Consist(set[i]) )
			{
				res.Insert(set[i]);
			}
		}
		return res;
	}
template<class T>
	CSet<T> CSet<T>::Difference(const CSet<T>& set)
	{
		CSet<T> res;
		for(int i = 0; i < set.Size(); i++)
		{
			if(!this->Consist(set[i]) )
			{
				res.Insert(set[i]);
			}
		}
		for(int i = 0; i < m_size; i++)
		{
			T key = (*this)[i];
			if(! set.Consist( key))
			{
				res.Insert(this->operator [](i));
			}
		}
		return res;
	}
template<class T>
	bool CSet<T>::IsSubsetOf(const CSet<T>& set)
	{
		for(int i = 0; i < m_size; i++)
		{
			if(! set.Consist( this->operator [](i) ) )
			{
				return false;
			}
		}
		return true;
	}