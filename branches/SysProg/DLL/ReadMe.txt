��������� CppDllCreate.dll �������� �� ��� �++.
� �� ���������� ����� double Calc(const char* expression) ���� ������ ����� ��� ���������� � ������ ����� �� ������� ��������� ���������� ������.
� ����� ������ ����������������� ��� ��������:
+    ���������
-    ��������
*    ��������
/    ������
^    ��������� � ������
ln   ����������� ��������
cos  �������
sin  �����



�������� ������������ DLL:
1. ���� ������������ DLL � �++    -  CppDllExplicitUsage.exe
2. ������ ������������ DLL � �++  -  CppDllImplicitUsage.exe
3. ���� ������������ DLL � C#     -  CsDllExplicitUsage.exe

������� ��������� �������� CsDllExplicitUsage.exe:

Demo: Explicit DLL usage in C#
Press Ctrl + C to exit
Enter expression to calculate: 2+2
2+2 = 4
Enter expression to calculate: 3^2+2
3^2+2 = 11
Enter expression to calculate: (2+2*(3+1))/2
(2+2*(3+1))/2 = 5
Enter expression to calculate: cos(3,1415926)
cos(3,1415926) = -0,989992
Enter expression to calculate: cos(sin(cos(1)))
cos(sin(cos(1))) = 0,870591
Enter expression to calculate: ln(20)
ln(20) = 2,99573

