#pragma once
#include "CArray.h"

#define INFINITY 2147483647

//Граф заданий матрицею суміжності
class CGraph
{
	//Матриця суміжності. i,j елемент - вага ребра, якщо -1, то вершини незвязані
	CArray< CArray<int> > m_arr;
	//Кількість вершин у графі
	size_t m_size;
public:
	CGraph();
	//Утворює граф, який складається з певної кількості вершин
	CGraph(size_t);
	//Додає ребро з вагою (за замовчуванням 0)
	void AddLink(size_t v1, size_t v2, int weight);
	//Повертає кількість вершин у графі
	size_t Size();
	//Змінює кількість вершин у графі
	void Resize(size_t size);
	//Повертає шлях з найменошою вагою від start до finish
	CArray<size_t> DijkstraPath(size_t start, size_t finish);
	//Повертає наймешу вагу шляху від  start до finish
	int DijkstraPathWeight(size_t start, size_t finish);
	//Повертає вагу і,j-го ребра
	CArray<int>& operator[] (const size_t index);

};

CGraph::CGraph()
{
	m_size = 0;
}
CGraph::CGraph(size_t count):m_arr(count), m_size(count)
{
	for(int i = 0; i < count; i++)
	{
		m_arr[i].setSize(count);
	}
	for(int i = 0; i < count; i++)
	{
		for(int j = 0; j < count; j++)
		{
			m_arr[i][j] = -1;
		}
	}
}

void CGraph::AddLink(size_t v1, size_t v2, int weight = 1)
{
	size_t maxsize = (v1 > v2)? v1:v2;
	maxsize++;
	if( m_size < maxsize)
	{
		Resize(maxsize);
	}
	m_arr[v1][v2] = weight;
	m_size++;
}

CArray<int>& CGraph::operator[] (const size_t index)
{
	if( index +1  > m_size)
	{
		throw "index out of range";
	}
	return m_arr[index];
}

CArray<size_t> CGraph::DijkstraPath(size_t start, size_t finish)
{

	CArray<int> w(m_size);
	CArray<int> from(m_size);
	CArray<bool> fixed(m_size);
	for(int  i = 0; i < m_size; i++)
	{
		w[i] = INFINITY;
		from[i] = -1;
		fixed[i] = false;
	}
	w[start] = 0;
	fixed[start] = true;
	size_t x = start;
	while( x != finish )
	{
		for(int i =0; i < m_size; i++)
		{
			if( (m_arr[x][i] >= 0) &&( m_arr[x][i] + w[x] < w[i]))
			{
				w[i] =  m_arr[x][i] + w[x];
				from[i] = x;
			}
		}
		int min = INFINITY;
		for(int i = 0; i < m_size; i++)
		{
			if( fixed[i] == false)
			{
				if(w[i] < min)
				{
					min = w[i];
					x = i;
				}
			}
		}
		if( min == INFINITY)
		{
			return CArray<size_t>();
		}
		fixed[x] = true;
	}
	size_t tmp = finish;
	CArray<size_t> path;

	while( tmp != start)
	{
		path.insert(0, tmp);
		tmp = from[tmp];
		if( tmp == -1)
		{
			return CArray<size_t>();
		}
	}
	path.insert(start, 0);
	
	return path;
}

int CGraph::DijkstraPathWeight(size_t start, size_t finish)
{
	CArray<size_t> v = DijkstraPath(start, finish);
	int weight = 0;
	if( v.size() == 0)
	{
		return -1;
	}
	for(int i = 0; i < v.size() - 1; i++)
	{
		weight += m_arr[v[i]][v[i+1]];
	}
	
	return weight;
}

size_t CGraph::Size()
{
	return m_size;
}

void CGraph::Resize(size_t size)
{
	m_arr.setSize(size);
	for(int i = 0; i < size; i++)
	{
		m_arr[i].setSize(size);
	}
}