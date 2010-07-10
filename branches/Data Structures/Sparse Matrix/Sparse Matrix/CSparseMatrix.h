#pragma once
#include "CArray.h"

//Compressed Row Storage (CRS)


template<class T>
	class CSparseMatrix
	{
		//Масив всіх не нульових елемнетів матриці
		CArray<T> m_val;
		//і-ий елемнт - індекс колонки елемента m_val[i]
		CArray<size_t> m_colIndex;

		//і-ий елемент - індекс у m_colIndex з якого починаються елементи і-го рядка; 
		//m_height-ий елемент = m_colIndex.size();
		CArray<size_t> m_rowPtr;
		
		size_t m_height;
		size_t m_width;
		

	public:
		CSparseMatrix();
		//Конструктор копіювання
		CSparseMatrix(const CSparseMatrix& );
		//Конструктор з параметрами, створює матрицю розміром height х width
		CSparseMatrix(size_t height, size_t width);

		//Повертає кількість рядків
		size_t getHeight();
		//Повертає кількість колонок
		size_t getWidth();
		//Повертає кількість не нульових елементів
		size_t nonZeroCount();

		CSparseMatrix<T>& operator = (const CSparseMatrix<T>& );
		
		//Повертає копію! обєкта
		const CArray<T> operator [] (const size_t index) const;
		CSparseMatrix<T> operator + (const CSparseMatrix<T>& );
		CSparseMatrix<T> operator - (const CSparseMatrix<T>& );
		CSparseMatrix<T> operator * (const T );
		CSparseMatrix<T> operator * (const CSparseMatrix<T>& );

		//Зажає значення value елемента в рядку rowIndex колонці colIndex
		void setVal(size_t rowIndex, size_t colIndex, T value);
		//Повертає копію обєкта в рядку rowIndex колонці colIndex
		T getVal(size_t rowIndex, size_t colIndex) const;
		//Видаляє усі "0"
		void deleteAllZero();

	};

template<class T>
	CSparseMatrix<T>::CSparseMatrix(): m_height(0), m_width(0)
	{
	}
template<class T>
	CSparseMatrix<T>::CSparseMatrix(const CSparseMatrix<T>& matrix)
	{
		*this = matrix;
	}
template<class T>
	CSparseMatrix<T>& CSparseMatrix<T>::operator = (const CSparseMatrix<T>& matrix)
	{
		m_val  = matrix.m_val;
		m_colIndex = matrix.m_colIndex;
		m_rowPtr = matrix.m_rowPtr;
		m_height = matrix.m_height;
		m_width = matrix.m_width;
		return *this;

	}
template<class T>
	CSparseMatrix<T>::CSparseMatrix(size_t height, size_t width)
	{
		m_height = height;
		m_width = width;
		//m_rowPtr.push_back( m_colIndex.size());
		for(size_t i = 0; i <= height; i++)
			m_rowPtr.push_back(0);
		
	}
template<class T>
	size_t CSparseMatrix<T>::getHeight()
	{
		return m_height;
	}

template<class T>
	size_t CSparseMatrix<T>::getWidth()
	{
		return m_width;
	}

template<class T>
	size_t CSparseMatrix<T>::nonZeroCount()
	{
		return m_val.size();
	}

template<class T>
	const CArray<T> CSparseMatrix<T>::operator [] (const size_t index)const
	{
		if( index >= m_height)
			throw ("row index out of range");

		CArray<T> row(m_width);
		for(size_t i = 0; i < m_width; i++)
		{
			row[i] = 0;
		}
		for(size_t i =   m_rowPtr[index]; i < m_rowPtr[index + 1]; i++)
		{
			row[m_colIndex[i]] = m_val[i];
		}
		return row;

	}

template<class T>
	void CSparseMatrix<T>::setVal(size_t rowIndex, size_t colIndex, T value)
	{
		if( rowIndex >= m_height)
			throw "row index out of range";
		if( colIndex >= m_width)
			throw "collumn index out of range";

		for(size_t i =   m_rowPtr[rowIndex]; i < m_rowPtr[rowIndex + 1]; i++)
		{
			if( colIndex == m_colIndex[i])
			{
				m_val[i] = value;
				return;
			}
		}
		m_colIndex.insert( m_rowPtr[rowIndex], colIndex);
		m_val.insert( m_rowPtr[rowIndex], value);
		for(size_t i = rowIndex + 1; i < m_rowPtr.size(); i++)
		{
			m_rowPtr[i]++;
		}
	}

template<class T>
	T CSparseMatrix<T>::getVal(size_t rowIndex, size_t colIndex) const
	{
		if( rowIndex >= m_height)
			throw "row index out of range";
		if( colIndex >= m_width)
			throw "collumn index out of range";

		for(size_t i =   m_rowPtr[rowIndex]; i < m_rowPtr[rowIndex + 1]; i++)
		{
			if( colIndex == m_colIndex[i])
			{
				return m_val[i];
			}
		}
		return 0;
	}

template<class T>
	void CSparseMatrix<T>::deleteAllZero()
	{
		for(size_t i = 0; i < m_val.size(); i++)
		{
			if( m_val[i] == 0)
			{
				m_val.remove(i);
				m_colIndex.remove(i);
				size_t j = 0;
				while( i < m_rowPtr[j])
				{
					j++;
				}
				j++;
				for( j; j < m_rowPtr.size(); j++)
				{
					m_rowPtr[j]--;
				}
				i--;
			}
		}

	}



template<class T>
	CSparseMatrix<T> CSparseMatrix<T>::operator +(const CSparseMatrix<T>& matrix)
	{
		if( m_width != matrix.m_width || m_height != matrix.m_height )
			throw "matrix doesn't match";
		
		CSparseMatrix<T> result (m_height, m_width); 

		for(size_t i = 0; i < m_rowPtr.size()-1; i++)
		{
			for(size_t j = m_rowPtr[i]; j < m_rowPtr[i+1]; j++)
			{
				result.setVal(i, m_colIndex[j], getVal(i, m_colIndex[j]) + matrix.getVal(i, m_colIndex[j]) );
			}
		}
		for(size_t i = 0; i < matrix.m_rowPtr.size()-1; i++)
		{
			for(size_t j = matrix.m_rowPtr[i]; j < matrix.m_rowPtr[i+1]; j++)
			{
				result.setVal(i, matrix.m_colIndex[j], getVal(i, matrix.m_colIndex[j]) + matrix.getVal(i, matrix.m_colIndex[j]) );
			}
		}
		result.deleteAllZero();
		return result;

	}

template<class T>
	CSparseMatrix<T> CSparseMatrix<T>::operator -(const CSparseMatrix<T>& matrix)
	{
		if( m_width != matrix.m_width || m_height != matrix.m_height )
			throw "matrix doesn't match";
		
		CSparseMatrix<T> result (m_height, m_width); 

		for(size_t i = 0; i < m_rowPtr.size()-1; i++)
		{
			for(size_t j = m_rowPtr[i]; j < m_rowPtr[i+1]; j++)
			{
				result.setVal(i, m_colIndex[j], getVal(i, m_colIndex[j]) - matrix.getVal(i, m_colIndex[j]) );
			}
		}
		for(size_t i = 0; i < matrix.m_rowPtr.size()-1; i++)
		{
			for(size_t j = matrix.m_rowPtr[i]; j < matrix.m_rowPtr[i+1]; j++)
			{
				result.setVal(i, matrix.m_colIndex[j], getVal(i, matrix.m_colIndex[j]) - matrix.getVal(i, matrix.m_colIndex[j]) );
			}
		}
		result.deleteAllZero();
		return result;

	}



template<class T>
	CSparseMatrix<T> CSparseMatrix<T>::operator *(const T k)
	{

		
		
		CSparseMatrix<T> result (m_height, m_width); 

		for(size_t i = 0; i < m_rowPtr.size()-1; i++)
		{
			for(size_t j = m_rowPtr[i]; j < m_rowPtr[i+1]; j++)
			{
				result.setVal(i, m_colIndex[j], getVal(i, m_colIndex[j]) * k );
			}
		}
		result.deleteAllZero();
		return result;

	}


template<class T>
	CSparseMatrix<T> CSparseMatrix<T>::operator *(const CSparseMatrix<T>& matrix)
	{
		
		if( m_width != matrix.m_height || m_height != matrix.m_width)
			throw "matrix doesn't match";
		CSparseMatrix<T> result (m_height, matrix.m_width); 

		for(size_t i = 0; i < m_height; i++)
		{
			for(size_t j = 0; j < m_height; j++)
			{
				T val = 0;
				for(size_t k = m_rowPtr[i]; k < m_rowPtr[i+1]; k++)
				{
					val+= m_val[k] * matrix.getVal(m_colIndex[k], j);
				}
				if( val != 0)
					result.setVal(i, j, val);
			}
		}
		
		result.deleteAllZero();
		return result;

	}
