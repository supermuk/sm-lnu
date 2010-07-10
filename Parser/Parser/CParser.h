#pragma once
#include "CString.h"
#include "CArray.h"
#include "CSet.h"
#include <iostream>
#include <sstream>
#include <cmath>

class CParser
{
	//Вираз який обчислюється
	CString m_formula;
	//Масив літералів 
	CArray<CString> m_tokens;
	//Масив операцій з пріорітетами: sin,cos,ln,^,*,/,+,-
	CArray< CTable<CString, int> > m_priority;
	
public:
	CParser();
	//Створення парсера з готовим виразом для обчислення
	CParser(const CString& );
	//Обчислення виразу який був вказаний у конструкторі
	double Calculate();
	//Обчислення даного виразу
	double Calculate(const CString&);
private:
	//Розбиття виразу на літерали
	void CalculateTokens();
	//Обчислення унарних операцій
	void ToDoUnary( CString&);
	//Обчислення бінарних операцій
	void ToDoBinary( CString&);

};
CParser::CParser()
{
	*this = CParser("");
}
CParser::CParser(const CString& formula)
{
	m_formula = formula;
	
	CTable<CString, int> opFunc;
	opFunc.Insert("sin", 1);
	opFunc.Insert("cos", 1);
	opFunc.Insert("ln", 1);
	
	CTable<CString, int> opPow;
	opPow.Insert("^", 2);

	CTable<CString, int> opMult;
	opMult.Insert("/", 2);
	opMult.Insert("*", 2);

	CTable<CString, int> opAdd;
	opAdd.Insert("+", 2);
	opAdd.Insert("-", 2);

	CTable<CString, int> opSep;
	opSep.Insert("(", 0);
	opSep.Insert(")", 0);

	m_priority.push_back(opFunc);
	m_priority.push_back(opPow);
	m_priority.push_back(opMult);
	m_priority.push_back(opAdd);
	m_priority.push_back(opSep);




}

void CParser::CalculateTokens()
{
	m_tokens.clear();
	m_tokens.push_back(m_formula);
	m_tokens[0].ReplaceAllSubStrings(" ", "");
	for(int i = 0; i < m_priority.size(); i++)
	{
		for(int j = 0; j < m_priority[i].Size(); j++)
		{
			for(int k = 0; k < m_tokens.size(); k++)
			{
				size_t pos = m_tokens[k].FindFirstSubString(0, m_priority[i][j]);
				if( pos != m_tokens[k].Length() )
				{
					CString left = m_tokens[k].GetSubString(0, pos);
					CString right = m_tokens[k].GetSubString(pos +  m_priority[i][j].Length(), m_tokens[k].Length() - pos - m_priority[i][j].Length() );
					
					m_tokens.remove(k);
					if( right.Length() != 0)
					{
						m_tokens.insert(k, right);
					}
					m_tokens.insert(k,  m_priority[i][j]);
					if( left.Length() != 0)
					{
						m_tokens.insert(k, left);
					}
					if( right.Length()*left.Length() != 0)
					{
						k++;
					}
				}
			}
		}
	}

}
double CParser::Calculate()
{
	CalculateTokens();

	for (int i = 0; i < m_tokens.size(); i++)
    {
        if (m_tokens[i] == "(")
        {
            CString newform;
            int count = 1;
            int j = i + 1;
            while (count > 0 && j < m_tokens.size())
            {
                if (m_tokens[j] == ")")
				{
                    count--;
				}
                if (m_tokens[j] == "(")
				{
                    count++;
				}
				newform = newform + m_tokens[j];
                j++;
            }
            if (count > 0)
			{
                throw ("Синтаксична помилка у виразі");
			}
			newform.Remove(newform.Length() - 1, 1);
			CParser parser(newform);
			std::ostringstream ostm;
			ostm << parser.Calculate();
			m_tokens.remove(i, j - i);
			m_tokens.insert(i, CString(ostm.str().c_str()));
        }
    }
	for(int i = 0; i < m_priority.size(); i++)
	{
		for(int j = 0; j < m_priority[i].Size(); j++)
		{
			if( m_priority[i].GetValue( m_priority[i][j] ) == 1)
			{
				ToDoUnary(m_priority[i][j]);
			}
			if( m_priority[i].GetValue( m_priority[i][j] ) == 2)
			{
				ToDoBinary(m_priority[i][j]);
			}
		}
	}
	std::istringstream istm( m_tokens[0].ToString() );
	double result;
	istm >> result;

	return result;
}

void CParser::ToDoUnary(CString& op)
{
	for(int i = 0; i < m_tokens.size(); i++)
	{
		if( m_tokens[i] == op)
		{
			std::istringstream istm( m_tokens[i+1].ToString() );
			double right;
			istm >> right;
			double result;
			if( op == CString("sin"))
			{
				result = sin(right);
			}
			if( op == CString("cos"))
			{
				result = cos(right);
			}
			if( op == CString("ln"))
			{
				result = log(right);
			}
			std::ostringstream ostm;
			ostm << result;
			m_tokens.remove(i, 2);
			m_tokens.insert(i, CString(ostm.str().c_str()));
		}
	}
}
void CParser::ToDoBinary(CString& op)
{
	for(int i = 0; i < m_tokens.size(); i++)
	{
		if( m_tokens[i] == op)
		{
			std::istringstream istmr( m_tokens[i+1].ToString() );
			std::istringstream istml( m_tokens[i-1].ToString() );

			double right;
			double left;

			istmr >> right;
			istml >> left;

			double result;
			if( op == CString("+"))
			{
				result = left + right;
			}
			if( op == CString("-"))
			{
				result = left - right;
			}
			if( op == CString("*"))
			{
				result = left*right;
			}
			if( op == CString("/"))
			{
				if( right == 0)
				{
					throw "division by 0";
				}
				result = left / right;
			}
			if( op == CString("^"))
			{
				result = pow(left, right);
			}
			std::ostringstream ostm;
			ostm << result;
			m_tokens.remove(i-1, 3);
			m_tokens.insert(i - 1, CString(ostm.str().c_str()));
		}
	}
}
double CParser::Calculate(const CString& formula)
{
	m_formula = formula;
	return Calculate();
}