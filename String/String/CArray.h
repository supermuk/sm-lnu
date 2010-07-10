#pragma once

#define NULL 0


template<class T>
	class CArray
	{
		T* m_arr;
		//Кількість елементів в масиві
		size_t m_size;
		//Кількість елементів для яких виділено память
		size_t m_realsize;

	public:
		CArray();
		//Конструктор копіювання
		CArray(const CArray& );
		//Створєю масив певного розміру
		CArray(const size_t);
		//Деструктор
		~CArray();

		//Оператор присвоєння
		CArray& operator = (const CArray& );
		//Доступ до елементів масиву через індекс
		T& operator [] (const size_t index);
		
		const T& operator [] (const size_t index) const;

		//Додає елемент в кінець масиву
		void push_back(const T& );
		//Видаляє останній елемент в масиві
		void pop_back();
		//Додає елемент в позиццію index 
		void insert(size_t index, const T& value);
		void insert(size_t index, const CArray& values);
		//Видаляэ елемент з позиції index
		void remove(size_t index);
		void remove(size_t index, size_t count);
		//Задає розмір масиву, усі елементи з індексами більшими за новий розмір знищуються
		void setSize(const size_t );

		void setRealSize(const size_t);

		//Знищує усі елемент в масиві
		void clear();
		//Повертає кількість елементів
		size_t size() const;
	};

template<class T>
	CArray<T>::CArray()
	{
		m_size = 0;
		m_realsize = 1;
		m_arr = new T[m_realsize];
	}
template<class T>
	CArray<T>::CArray(const size_t size)
	{
		m_size = size;
		m_realsize = size;
		if( size == 0 )
			m_realsize = 1;
		m_arr = new T[m_realsize];
		if( m_arr == NULL)
			throw "memory overflow";
	}

template<class T>
CArray<T>::CArray(const CArray<T> &a):m_arr(NULL)
	{
		*this = a;
	}
template<class T>
	CArray<T>::~CArray()
	{
		if( m_arr != NULL)
			delete[] m_arr;
	}

template<class T>
	CArray<T>& CArray<T>::operator =(const CArray<T> &a)
	{
		if( this == &a)
			return *this;

		if (m_arr != NULL) 
			delete[] m_arr;
		m_arr = new T[ a.m_realsize ];

		if( m_arr == NULL)
			throw "memory overflow";

		m_size = a.m_size;
		m_realsize = a.m_realsize;
		memcpy(m_arr, a.m_arr, sizeof(T) * m_size);
		return *this;
	}

template<class T>
	T& CArray<T>::operator [](const size_t index)
	{
		if( index >= m_size )
			throw "index out of range";
		return m_arr[index];
	}

template<class T>
	const T& CArray<T>::operator [](const size_t index) const
	{
		if( index >= m_size )
			throw "index out of range";
		return m_arr[index];
	}

template<class T>
	void CArray<T>::push_back(const T &item)
	{
		m_size++;
		if( m_size > m_realsize )
		{
			this->setRealSize(m_realsize*2);
		}
		m_arr[m_size - 1] = item;
	}

template<class T>
	void CArray<T>::pop_back()
	{
	
		if(m_size == 0 )
			throw "array is empty";
		m_size--;

	}
template<class T>
	void CArray<T>::setSize(const size_t size)
	{
		m_size = size;
		if ((m_size > m_realsize) || (m_size <= m_realsize/2))
		{
			setRealSize(m_size);
		}
	}
template<class T>
	void CArray<T>::setRealSize(const size_t realsize)
	{
		if( realsize == m_realsize)
		{
			return;
		}
		if( realsize == 0)
		{
			clear();
			return;
		}

		m_realsize = realsize;

		T* temp = new T[m_realsize];
		if( temp == NULL)
			throw "memory overflow";

		m_size = min(m_size, m_realsize);
		memcpy(temp, m_arr, sizeof(T) * m_size);
		delete[] m_arr;
		m_arr = temp;
	}

template<class T>
	size_t CArray<T>::size()const
	{
		return m_size;
	}

template<class T>
	void CArray<T>::clear()
	{
		m_size = 0;
		m_realsize = 1;
		if ( m_arr != NULL)
			delete[] m_arr;
		m_arr = new T[m_realsize];
	}
template<class T>
	void CArray<T>::insert(size_t index, const T &value)
	{
		if( index > m_size || index < 0)
			throw "index out of range";
		CArray<T> arr(1);
		arr[0] = value;
		this->insert(index, arr);
	}
template<class T>
	void CArray<T>::insert(size_t index, const CArray& values)
	{
		if( index > m_size || index < 0)
			throw "index out of range";

		m_size += values.size();
		while( m_size > m_realsize )
		{
			this->setRealSize( m_realsize * 2 );
		}
		memmove(m_arr + index + values.size() , m_arr + index  , sizeof(T) * (m_size - index - values.size()));
		memcpy(m_arr + index , values.m_arr, sizeof(T) * values.size());
	}
template<class T>
	void CArray<T>::remove(size_t index)
	{
		remove(index, 1);
	}

template<class T>
	void CArray<T>::remove(size_t index, size_t count)
	{
		if( index + count > m_size || index < 0)
			throw "index out of range";
		m_size -= count;
		memmove(m_arr + index, m_arr + index + count, sizeof(T) * (m_size - index ));
		if( m_size < m_realsize / 2)
		{
			setRealSize( m_realsize / 2);
		}

	}