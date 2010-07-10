Бібліотека CppDllCreate.dll створена на мові С++.
У ній реалізовано метод double Calc(const char* expression) який приймає вираз для обчислення у вигляді рядка та повертає результат обчислення виразу.
у виразі можуть використовуватись такі операції:
+    додавання
-    віднімання
*    множення
/    ділення
^    піднесення у степінь
ln   натуральний логарифм
cos  косинус
sin  синус



Приклади використання DLL:
1. Явне завантаження DLL у С++    -  CppDllExplicitUsage.exe
2. Неявне завантаженян DLL у С++  -  CppDllImplicitUsage.exe
3. Явне завантаження DLL у C#     -  CsDllExplicitUsage.exe

Приклад виконання програми CsDllExplicitUsage.exe:

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

