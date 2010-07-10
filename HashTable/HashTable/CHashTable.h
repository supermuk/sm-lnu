#pragma once
#include "CTable.h"
#include "CArray.h"


template<class TKey, class TVal>
	class CHashTable
	{
		CArray< CTable<TKey, TVal> > m_arr;
		size_t m_maxAddr;
		
		size_t (*mp_hashFunction) (TKey);

		CHashTable();
	public:
		CHashTable(size_t maxAddr, size_t (*pf) (TKey) );

		void Insert (const TKey, const TVal);
		bool Consist (const TKey);
		void Remove (const TKey);

		TVal& operator[](const TKey);

	};

template<class TKey, class TVal>
	CHashTable<TKey, TVal>::CHashTable(size_t maxAddr, size_t (*pf)(TKey)): m_arr(maxAddr)
	{
		m_maxAddr = maxAddr;
		mp_hashFunction = pf;
	}

template<class TKey, class TVal>
	void CHashTable<TKey, TVal>::Insert(const TKey key, const TVal val)
	{
		m_arr[ mp_hashFunction(key) ].Insert(key, val);
	}

template<class TKey, class TVal>
	bool CHashTable<TKey, TVal>::Consist(const TKey key)
	{
		return m_arr[ mp_hashFunction(key) ].Consist(key);
	}

template<class TKey, class TVal>
	void CHashTable<TKey, TVal>::Remove(const TKey key)
	{
		m_arr[ mp_hashFunction(key) ].Remove(key);
	}

template<class TKey, class TVal>
	TVal& CHashTable<TKey, TVal>::operator [](const TKey key)
	{
		return m_arr[ mp_hashFunction(key) ][key];
	}