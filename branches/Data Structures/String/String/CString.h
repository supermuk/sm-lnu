#pragma once
#include "CArray.h"


class CString
{
	CArray<char> m_arr;

	
public:
	CString();
	CString(const char* );

	//Повертає довжину рядка
	size_t Length()const;
	//Визначає чи в даному рядку міститься підрядок
	bool SubString(CString );
	//Повертає підрядок починаючи з певної позиції певної довжини 
	CString GetSubString(size_t begin, size_t count);

	void Remove(size_t begin, size_t count);
	void Insert(size_t begin, const CString str);
	void Replace(size_t begin, size_t count, const CString newstr);

	void ReplaceAllSubStrings(const CString substr, const CString newstr);
	CArray<size_t> FindAllSubStrings(size_t begin,const CString str);
	//Повертає символ на певній позиції
	char& operator[] (size_t );
	const char& operator[] (size_t )const;
	//Додавання 1 символу
	CString& operator+(const char);
	//Додавання рядка
	CString operator+(const CString );
	//Порівняння двох рядків
	bool operator==(const CString);
	bool operator!=(const CString);
	//Перетворює на масив символів	
	char* ToString();

	CArray<char> ToArray()const;
	



};
CString::CString()
{
}
CString::CString(const char *arr)
{
	size_t i = 0;
	while( arr[i] != '\0' )
	{
		m_arr.push_back(arr[i]);
		i++;
	}
}

size_t CString::Length()const
{
	return m_arr.size();
}

char& CString::operator[] (size_t index)
{
	return m_arr[index];
}
const char& CString::operator[] (size_t index)const
{
	return m_arr[index];
}
CString& CString::operator +(const char chr)
{
	m_arr.push_back(chr);
	return *this;
}

CString CString::operator +(const CString str)
{
	CString s(*this);
	for(int i = 0; i < str.Length(); i++)
	{
		s = s +  str[i];
	}
	return s;
}
bool CString::operator==(const CString str)
{
	for(int i = 0 ; i < m_arr.size(); i++)
	{
		if( m_arr[i] != str.m_arr[i])
			return false;
	}
	return  true;
}

bool CString::operator!=(const CString str)
{
	return !(*this == str);
}

bool CString::SubString(CString str)
{
	if( str.Length() > Length())
		return false;
	for(int i = 0; i <= Length() - str.Length(); i++)
	{
		if( GetSubString(i, str.Length()) == str )
		{
			return true;
		}
	}
	return false;
}

CString CString::GetSubString(size_t start, size_t count)
{
	if( start + count > Length())
		throw "Error";
	CString result; 
	for(int i = start; i < start + count; i++)
	{
		result = result + m_arr[i];
	}
	return result;
}

CArray<size_t> CString::FindAllSubStrings(size_t begin, const CString str)
{
	CArray<size_t> pf (str.Length());
 
	pf[0] = 0;
	int k = 0;
	for (int i = 1; i<str.Length(); ++i)
	{
		while(k>0 && str[i] != str[k])
		{
			k = pf[k-1];
		}
		if (str[i] == str[k])
		{
			k++;
		}
 
		pf[i] = k;
	}
	CArray<size_t> result;
	k = 0;
	for (int i = begin; i<Length(); ++i)
	{
		while ((k>0) && (str[k] != m_arr[i]))
		{
			k = pf[k-1];
		}
 
		if (str[k] == m_arr[i])
		{
			k++;
		}
		if (k==str.Length())
		{
			result.push_back(i-str.Length()+1);
			k = 0;
		}
		
	}
 
	return result;

}

void CString::ReplaceAllSubStrings(const CString substr, const CString newstr)
{
	CArray<size_t> pos = FindAllSubStrings(0, substr);
	//int m = newstr.Length() - substr.Length();
	for(int i = pos.size() - 1; i >= 0; i--)
	{
		Replace(pos[i], substr.Length(), newstr);
	}
}

void CString::Remove(size_t begin, size_t count)
{
	m_arr.remove(begin, count);
}


void CString::Insert(size_t begin, const CString str)
{
	m_arr.insert(begin, str.ToArray());
}

void CString::Replace(size_t begin, size_t count, const CString newstr)
{
	Remove(begin, count);
	Insert(begin, newstr);
}

CArray<char> CString::ToArray()const
{
	return m_arr;
}