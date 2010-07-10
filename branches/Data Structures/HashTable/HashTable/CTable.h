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
		CNode<TKey, TVal>* m_head;
		size_t m_size;

		CNode<TKey, TVal>* Find(const TKey);
		CNode<TKey, TVal>* FindPrev(const TKey);
	public:
		CTable();
		CTable(const CTable&);

		size_t Size();
		void Insert(const TKey, const TVal);
		void Insert(const TKey );
		void Change(const TKey, const TVal);
		void Remove(const TKey);
		bool Consist(const TKey);
		TVal GetValue(const TKey);
	
		TVal& operator[](const TKey);

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
	m_size = table.m_size;
	m_head = NULL;
	if( table.m_head == NULL)
		return;
	
	CNode<TKey, TVal>* tmp = table.m_head;
	do
	{
		Insert(tmp->m_key, tmp->m_value);
		tmp = tmp->next;
	}while( tmp != NULL);
}

template<class TKey, class TVal>
	size_t CTable<TKey, TVal>::Size()
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

		CNode<TKey, TVal>* tmp = FindPrev(key);
		CNode<TKey, TVal>* save = tmp->next;
		tmp->next = new CNode<TKey, TVal>(key);
		tmp->next->next = save;
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
	CNode<TKey, TVal>* CTable<TKey, TVal>::FindPrev(const TKey key)
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
	bool CTable<TKey, TVal>::Consist(const TKey key)
{
	CNode<TKey, TVal>* prev = FindPrev(key);
	if( prev == NULL)
		return false;
	if(  prev->next == NULL )
		if ( prev->m_key == key) 
			return true;
		else
			return false;
	else
		if( prev->next->m_key != key )
			return false;
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

template<class TKey, class TVal>
	TVal& CTable<TKey, TVal>::operator [](const TKey key)
{
	if( !Consist(key) )
	{
		Insert(key);
	}
	return Find(key)->m_value;
}
