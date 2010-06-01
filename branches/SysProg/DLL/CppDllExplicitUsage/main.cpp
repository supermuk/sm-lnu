#include<iostream>
#include<windows.h>
#include<string>
using namespace std;


int main()
{

	double (__stdcall *Calc)(const char*);

	HINSTANCE dll = LoadLibrary("CppDllCreate.dll");
	if(dll != NULL)
	{
		cout << "Demo: Explicit DLL usage in C++" << endl;
		cout << "Dll loaded successfully" << endl;
		cout << "Press Ctrl + C to exit" << endl;

		while( true )
		{
			cout << "Enter expression to calculate: ";

			string expression;
			cin >> expression;

			((FARPROC&)Calc) = GetProcAddress(dll, (LPTSTR)"_Calc@4");
			
			cout <<expression +  " = ";
			cout << Calc(expression.c_str()) << endl;
		}
		FreeLibrary(dll);
	}
	return 0;
}