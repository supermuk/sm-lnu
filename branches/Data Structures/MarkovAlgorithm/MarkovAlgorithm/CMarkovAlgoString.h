#include "CString.h"
#include "CArray.h"
#include <string>

#include <iostream>
using namespace std;
	struct RuleString
	{
		string in;
		string out;
		bool term;
		RuleString():in(),out(),term(false){};
		RuleString(string _in, string _out, bool b = false): in(_in), out(_out), term(b){};
	};


	class CMarkovAlgoString
	{
		CArray< RuleString > m_rules;
	public:
		CMarkovAlgoString():m_rules(){};
		CMarkovAlgoString(CArray<RuleString> rules);
		
		void AddRule(RuleString rule);
		string Compile(const string input);

	};

	CMarkovAlgoString::CMarkovAlgoString(CArray<RuleString> rules)
	{
		m_rules = rules;
	}
	void CMarkovAlgoString::AddRule(RuleString rule)
	{
		m_rules.push_back(rule);
	}
	string CMarkovAlgoString::Compile(const string input)
	{
		string output(input);
		int i = 0;
		while( true )
		{
			while( output.find(m_rules[i].in) < output.length() )
			{
				int pos = output.find(m_rules[i].in);
				output.erase( pos, m_rules[i].in.length());
				output.insert(pos, m_rules[i].out);
				i = 0;
			}
			i++;
			if( i == m_rules.size()) 
			{
				return output;
			}
			if( m_rules[i].term == true)
			{
				output.replace( output.find(m_rules[i].in), 1, "");
				return output;
			}

		}
		return output;
	}