#include "CString.h"
#include "CArray.h"
#include <string>

#include <iostream>

	struct Rule
	{
		//˳�� ������� �������
		CString in;
		//����� ������� �������
		CString out;
		//������������ �������
		bool term;
		Rule():in(),out(),term(false){};
		Rule(CString _in, CString _out, bool b = false): in(_in), out(_out), term(b){};

		Rule& operator = (const Rule& rule)
		{
			in = rule.in;
			out = rule.out;
			term = rule.term;
			return *this;
		}
	};


	class CMarkovAlgo
	{
		//������ ��� ������
		CArray< Rule > m_rules;
	public:
		
		CMarkovAlgo():m_rules(){};
		//����������� � ����������
		CMarkovAlgo(CArray<Rule> rules);
		//���� ���� �������
		void AddRule(Rule rule);
		//������ ��������
		CString Compile(const CString input);

	};

	CMarkovAlgo::CMarkovAlgo(CArray<Rule> rules)
	{
		m_rules = rules;
	}
	void CMarkovAlgo::AddRule(Rule rule)
	{
		m_rules.push_back(rule);
	}
	CString CMarkovAlgo::Compile(const CString input)
	{
		CString output(input);
		int i = 0;
		while( true )
		{
			while( output.FindAllSubStrings(0, m_rules[i].in).size() > 0 )
			{
				output.ReplaceAllSubStrings(m_rules[i].in, m_rules[i].out);
				i = 0;
			}
			i++;
			if( i == m_rules.size()) 
			{
				return output;
			}
			if( m_rules[i].term == true)
			{
				output.ReplaceAllSubStrings(m_rules[i].in, "");
				return output;
			}

		}
		return output;
	}