#pragma once
#define NULL 0

template<class T>
	class CArray
	{
		T* m_arr;
		//ʳ������ �������� � �����
		size_t m_size;
		//ʳ������ �������� ��� ���� ������� ������
		size_t m_realsize;
	public:
		CArray();
		//����������� ���������
		CArray(const CArray& );
		//������ ����� ������� ������
		CArray(const size_t);
		//����������
		~CArray();

		//�������� ���������
		CArray& operator = (const CArray& );
		//������ �� �������� ������ ����� ������
		T& operator [] (const size_t index);
		
		const T& operator [] (const size_t index) const;

		//���� ������� � ����� ������
		void push_back(const T& );
		//������� ������� ������� � �����
		void pop_back();
		//���� ������� � �������� index 
		void insert(size_t index, const T& value);
		//������� ������� � ������� index
		void remove(size_t index);

		//���� ����� ������, �� �������� � ��������� ������� �� ����� ����� ����������
		void setSize(const size_t );
		//����� �� ������� � �����
		void clear();
		//������� ������� ��������
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
		for(size_t i = 0; i < m_size; ++i)
		{
			m_arr[i] = a.m_arr[i];
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
	void CArray<T>::push_back(const T &item)
	{
		m_size++;
		if( m_size > m_realsize )
		{
			m_realsize *= 2;
			T* temp = new T[m_realsize];
			
			if( temp == NULL)
				throw "memory overflow";
			
			for(size_t i = 0; i < m_size - 1; ++i)
			{
				temp[i] = m_arr[i];
			}
			delete[] m_arr;

			m_arr = temp;
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
 
		if (size != 0)
		{
		
			if ((m_size > m_realsize) || (m_size < m_realsize/2))
			{
	    		m_realsize = m_size;

				T* temp = new T[m_realsize];
				if( temp == NULL)
					throw "memory overflow";

				for(size_t i = 0; i < m_size; ++i)
				{
					temp[i] = m_arr[i];
				}
				delete[] m_arr;

				m_arr = temp;


			}
		}
		else
			clear();

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


		push_back(value);
		for(size_t i = m_size - 1; i > index; i--)
		{
			T tmp = m_arr[i];
			m_arr[i] = m_arr[i-1];
			m_arr[i-1] = tmp;
		}
	}

template<class T>
	void CArray<T>::remove(size_t index)
	{
		if( index >= m_size || index < 0)
			throw "index out of range";
		m_size--;
		for(size_t i = index; i < m_size; i++)
		{
			m_arr[i] = m_arr[i+1];
		}
	}