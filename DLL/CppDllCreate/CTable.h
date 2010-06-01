#pragma once

#define NULL 0

template<class TKey, class TVal>
	struct CNode
	{
		CNode* next;
		TKey m_key;
		TVal m_value;
	
		CNode(const TKey& key, const TVal& value)
			: m_key (key), m_value(value), next(0){}
		CNode(const TKey& key)
			: m_key (key), m_value(), next(0){}
	};

template<class TKey, class TVal>
	class CTable
	{
	protected:
		CNode<TKey, TVal>* m_head;
		size_t m_size;

		CNode<TKey, TVal>* Find(const TKey);
		CNode<TKey, TVal>* FindPrev(const TKey)const;
	public:
		CTable();
		CTable(const CTable&);

		size_t Size() const;
		void Insert(const TKey, const TVal);
		void Insert(const TKey );
		void Change(const TKey, const TVal);
		void Remove(const TKey);
		bool Consist(const TKey)const;
		TVal GetValue(const TKey);
	
		//TVal& operator[](const TKey);

		CTable& operator=(const CTable& );
		TKey& operator[](const size_t);
		TKey& operator[](const size_t)const;

		~CTable();


	};


template<class TKey, class TVal>
	CTable<TKey, TVal>::CTable()
	{
		m_size = 0;
		m_head = NULL;
	}

template<class TKey, class TVal>
	CTable<TKey, TVal>::CTable(const CTable<TKey,TVal> &table)
	{
		*this = table;
	}
template<class TKey, class TVal>
	CTable<TKey, TVal>& CTable<TKey, TVal>::operator =(const CTable<TKey,TVal> &table)
	{
		m_size = table.m_size;
		m_head = NULL;
		if( table.m_head == NULL)
			return *this;
		
		CNode<TKey, TVal>* tmp = table.m_head;
		do
		{
			Insert(tmp->m_key, tmp->m_value);
			tmp = tmp->next;
		}while( tmp != NULL);
		return *this;
	}
template<class TKey, class TVal>
	size_t CTable<TKey, TVal>::Size()const
	{
		return m_size;
	}

template<class TKey, class TVal>
	void CTable<TKey, TVal>::Insert(const TKey key, const TVal value)
{
	if( m_head == NULL)
	{
		m_head = new CNode<TKey, TVal>(key, value);
		m_size = 1;
		return;
	}
	if( Consist(key) )
		throw "This key already exists";

	CNode<TKey, TVal>* tmp = FindPrev(key);
	CNode<TKey, TVal>* save = tmp->next;
	tmp->next = new CNode<TKey, TVal>(key, value);
	tmp->next->next = save;
	m_size++;
}

template<class TKey, class TVal>
	void CTable<TKey, TVal>::Insert(const TKey key)
	{
		if( m_head == NULL)
		{
			m_head = new CNode<TKey, TVal>(key);
			m_size = 1;
			return;
		}
		if( Consist(key) )
			throw "This key already exists";

		if( m_head->m_key > key)
		{
			CNode<TKey, TVal>* save = m_head;
			m_head = new CNode<TKey, TVal>(key);
			m_head->next = save;
		}
		else
		{
			CNode<TKey, TVal>* tmp = FindPrev(key);
			CNode<TKey, TVal>* save = tmp->next;
			tmp->next = new CNode<TKey, TVal>(key);
			tmp->next->next = save;
		}
		m_size++;

	}

template<class TKey, class TVal>
	CNode<TKey, TVal>* CTable<TKey, TVal>::Find(const TKey key)
{
	if(m_head == NULL)
		throw "Table dosnt exist this key";

	CNode<TKey, TVal>* tmp = m_head;
	while( tmp->m_key != key )
	{
		if( tmp->next == NULL)
			throw "Table dosnt exist this key";
		tmp = tmp->next;
	}
	return tmp;
}

template<class TKey, class TVal>
	void CTable<TKey, TVal>::Change(const TKey key, const TVal value)
{
	Find(key)->m_value = value;
}

template<class TKey, class TVal>
	CNode<TKey, TVal>* CTable<TKey, TVal>::FindPrev(const TKey key)const
{
	if(m_head == NULL)
		return m_head;

	CNode<TKey, TVal>* tmp = m_head;

	if( tmp->next == NULL)
		return tmp;
	while( tmp->next->m_key < key )
	{
		tmp = tmp->next;
		if( tmp->next == NULL)
			return tmp;
	}
	return tmp;
}


template<class TKey, class TVal>
	void CTable<TKey, TVal>::Remove(const TKey key)
{
	CNode<TKey, TVal>* prev = FindPrev(key);
	if(prev == NULL)
		return;
	if(prev->m_key == key)
	{
		CNode<TKey, TVal>* tmp = prev;
		m_head = prev->next;
		delete tmp;
		return;
	}

	if(prev->next == NULL)
		return;
	CNode<TKey, TVal>* tmp = prev->next;
	prev->next = tmp->next;
	m_size--;
	delete tmp;
}
template<class TKey, class TVal>
	bool CTable<TKey, TVal>::Consist(const TKey key)const
{
	CNode<TKey, TVal>* prev = FindPrev(key);
	if( prev == NULL)
	{
		return false;
	}
	if( m_head->m_key == key)
	{
		return true;
	}
	if(  prev->next == NULL )
	{
		if ( prev->m_key == key) 
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	else
	{
		if( prev->next->m_key != key )
		{
			return false;
		}
	}
	return true;
}

template<class TKey, class TVal>
	TVal CTable<TKey, TVal>::GetValue(const TKey key)
{
	return Find(key)->m_value;
}

template<class TKey, class TVal>
	CTable<TKey, TVal>::~CTable()
{
	if(m_head == NULL)
		return;
	CNode<TKey, TVal>* tmp = m_head;
	while( tmp->next != NULL)
	{
		CNode<TKey, TVal>* del = tmp;
		tmp = tmp->next;
		delete del;
	}
	delete tmp;
}

//template<class TKey, class TVal>
//	TVal& CTable<TKey, TVal>::operator [](const TKey key)
//	{
//		if( !Consist(key) )
//		{
//			Insert(key);
//		}
//		return Find(key)->m_value;
//	}
//
template<class TKey, class TVal>
	TKey& CTable<TKey, TVal>::operator [](const size_t index)
	{
		if( index >= m_size)
		{
			throw "index out of range";
		}
		CNode<TKey, TVal>* tmp = m_head;
		for(int i=0; i < index; i++)
		{
			tmp = tmp->next;
		}
		return tmp->m_key;
		
	}
template<class TKey, class TVal>
	TKey& CTable<TKey, TVal>::operator [](const size_t index) const
	{
		if( index >= m_size)
		{
			throw "index out of range";
		}
		CNode<TKey, TVal>* tmp = m_head;
		for(int i=0; i < index; i++)
		{
			tmp = tmp->next;
		}
		return tmp->m_key;
		
	}
