#include<iostream>
#include<windows.h>

using namespace std;

//double (__stdcall *importFunction)(double, double);
typedef double (*importFunction)(double, double);

int main()
{

	double result;
	importFunction add;

	HINSTANCE dll = LoadLibrary("CppDllCreate.dll");
	if(dll != NULL)
	{
		//((FARPROC&)importFunction) = GetProcAddress(dll, (LPTSTR)"_Add@16");
		add = (importFunction)GetProcAddress(dll, (LPTSTR)"_Add@16");
		result = add(2,3);
	}
	cout << result;//importFunction(2,3);
	FreeLibrary(dll);
	return 0;
}