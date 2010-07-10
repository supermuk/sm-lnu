#pragma once

#define NULL 0

template<class T> static bool IsSimpleType() { return false; }
template<> static bool IsSimpleType<bool>() { return true; }
template<> static bool IsSimpleType<int>() { return true; }
template<> static bool IsSimpleType<double>() { return true; }
template<> static bool IsSimpleType<float>() { return true; }
template<> static bool IsSimpleType<char>() { return true; }

template<class T> static bool IsSimpleType(const T& t) { return IsSimpleType<T>(); }





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

		void setRealSize(const size_t, const size_t);

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
		if( IsSimpleType(T()) )
		{
			memcpy(m_arr, a.m_arr, sizeof(T) * m_size);
		}
		else
		{
			for(size_t i = 0; i < m_size; ++i)
			{
				m_arr[i] = a.m_arr[i];
			}
			
		}
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
	void CArray<T>::push_back(const T& item)
	{
		m_size++;
		if( m_size > m_realsize )
		{
			this->setRealSize(m_realsize*2, m_size-1);
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
		size_t copycount = min(size, m_size);
		m_size = size;
		if ((m_size > m_realsize) || (m_size <= m_realsize/2))
		{
			this->setRealSize(m_size, copycount);
		}
	}
template<class T>
	void CArray<T>::setRealSize(const size_t realsize, const size_t copycount)
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
		if( IsSimpleType(T()) )
		{
			memcpy(temp, m_arr, sizeof(T) * copycount);
		}
		else
		{
			for(size_t i = 0; i < copycount; ++i)
			{
				temp[i] = m_arr[i];
			}
		}
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
			this->setRealSize( m_realsize * 2, m_size - values.size() );
		}
		if(IsSimpleType(T()))
		{
			memmove(m_arr + index + values.size() , m_arr + index  , sizeof(T) * (m_size - index - values.size()));
			memcpy(m_arr + index , values.m_arr, sizeof(T) * values.size());
		}
		else
		{
			CArray<T> tmp(values.size() + m_size);
			for(int i = 0; i < index; i++)
			{
				tmp[i] = m_arr[i];
			}
			for(int i = index; i < index + values.size(); i++)
			{
				tmp[i] = values[i - index];
			}
			for(int i = index + values.size(); i < m_size + values.size(); i++)
			{
				tmp[i] = m_arr[i - values.size()];
			}
			*this = tmp;	
		}
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
		if(IsSimpleType(T()))
		{
			memmove(m_arr + index, m_arr + index + count, sizeof(T) * (m_size - index ));
		}
		else
		{
			for(size_t i = index; i < m_size; i++)
			{
				m_arr[i] = m_arr[i+count];
			}
		}
		while( m_size < m_realsize / 2)
		{
			setRealSize( m_realsize / 2, m_size);
		}

	}