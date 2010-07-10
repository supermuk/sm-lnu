#include "BWindow.h"
#include "BWindowMain.h"
#include "BWindowKids.h"


ATOM MyRegisterClass(HINSTANCE hInstance)
{
	WNDCLASSEX wcex;

	wcex.cbSize = sizeof(WNDCLASSEX);
	wcex.style			= CS_HREDRAW | CS_VREDRAW;
	wcex.lpfnWndProc	= BWindow::windowProc;
	wcex.cbClsExtra		= 0;
	wcex.cbWndExtra		= 0;
	wcex.hInstance		= hInstance;
	wcex.hIcon			= NULL;
	wcex.hCursor		= LoadCursor(NULL, IDC_ARROW);
	wcex.hbrBackground	= (HBRUSH)(COLOR_WINDOW+1);
	wcex.lpszMenuName	=  NULL;
	wcex.lpszClassName	= L"BOB";
	wcex.hIconSm		= NULL;
	return RegisterClassEx(&wcex);
}


void CreateKid(int x, int y, string name, LPCWSTR title, BWindowMain* parent, HINSTANCE hInstance, LPWSTR text = L"0")
{
	BWindow* wind = new BWindowKids();
	wind->createWindow(NULL, L"edit", text, 
		WS_VISIBLE|WS_CHILD|WS_BORDER|ES_AUTOHSCROLL|ES_AUTOVSCROLL ,
		x, y, 50, 20, parent->hwnd , NULL, hInstance);
	wind->showWindow(SW_SHOW);

	parent->kids[name] = wind;
	parent->titles[name] = title;

}

int APIENTRY WinMain (HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)
{

	MyRegisterClass(hInstance);
	
	
	BWindowMain main;
	main.createWindow(NULL, L"BOB", L"Parabolic Interpolation v1.0.1", WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU , 100, 100, 1000, 600, NULL, NULL, hInstance);
	main.showWindow(nCmdShow);

	BWindowKids btn;
	btn.createWindow(NULL, L"button", L"Додати точку", WS_CHILD /*| WS_VISIBLE*/, 350 , 515, 120, 30, main.hwnd, (HMENU) 666, hInstance);
	btn.showWindow(nCmdShow);

	CreateKid(710, 520, "Rox", L"ox=", &main, hInstance, L"17");
	CreateKid(810, 520, "Roy", L"oy=", &main, hInstance, L"-22.5");
	CreateKid(910, 520, "Roz", L"oz=", &main, hInstance);

	CreateKid(530, 520, "Tab", L"t =", &main, hInstance, L"10");
	CreateKid(620, 520, "zoom", L"M =", &main, hInstance, L"50");

	CreateKid(50, 520, "x", L"x =", &main, hInstance);
	CreateKid(150, 520, "y", L"y =", &main, hInstance);
	CreateKid(250, 520, "z", L"z =", &main, hInstance);

	RedrawWindow(main.hwnd, NULL, NULL, WM_PAINT);
	MSG msg;
	while(GetMessage(&msg, NULL, 0, 0))
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}
}