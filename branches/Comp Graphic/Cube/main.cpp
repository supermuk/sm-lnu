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


void CreateKid(int x, int y, string name, LPCWSTR title, BWindowMain* parent, HINSTANCE hInstance)
{
	BWindow* wind = new BWindowKids();
	wind->createWindow(NULL, L"edit", L"0", 
		WS_VISIBLE|WS_CHILD|WS_BORDER|ES_AUTOHSCROLL|ES_AUTOVSCROLL ,
		x, y, 50, 20, parent->hwnd , NULL, hInstance);
	wind->showWindow(SW_SHOW);

	parent->kids[name] = wind;
	parent->titles[name] = title;

}

int APIENTRY WinMain (HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)
{

	MyRegisterClass(hInstance);
	

	wfstream out;
	
	out.open("log.txt");
	
	BWindowMain main;
	main.createWindow(NULL, L"BOB", L"Mirror Cube v1.0.2", WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU , 300, 200, 1000, 600, NULL, NULL, hInstance, &out);
	main.showWindow(nCmdShow);

	BWindowKids btn;
	btn.createWindow(NULL, L"button", L"Записати перетворення", WS_CHILD /*| WS_VISIBLE*/, 750, 450, 200, 50, main.hwnd, (HMENU) 666, hInstance);
	btn.showWindow(nCmdShow);

	BWindowKids check;
	check.createWindow(NULL, L"button", L"Показувати назви точок",  WS_VISIBLE | WS_CHILD | BS_CHECKBOX,
		750, 350, 200, 20, main.hwnd, (HMENU) 777, hInstance);
	check.showWindow(nCmdShow);
	main.kids["check"]= &check;



	CreateKid(730, 65, "Ax", L"x=", &main, hInstance);
	CreateKid(820, 65, "Ay", L"y=", &main, hInstance);
	CreateKid(910, 65, "Az", L"z=", &main, hInstance);

	CreateKid(730, 115, "Cox", L"ox=", &main, hInstance);
	CreateKid(820, 115, "Coy", L"oy=", &main, hInstance);
	CreateKid(910, 115, "Coz", L"oz=", &main, hInstance);

	CreateKid(730, 185, "Qx", L"x=", &main, hInstance);
	CreateKid(820, 185, "Qy", L"y=", &main, hInstance);
	CreateKid(910, 185, "Qz", L"z=", &main, hInstance);

	
	CreateKid(730, 225, "Rx", L"x=", &main, hInstance);
	CreateKid(820, 225, "Ry", L"y=", &main, hInstance);
	CreateKid(910, 225, "Rz", L"z=", &main, hInstance);
	
	CreateKid(730, 265, "Sx", L"x=", &main, hInstance);
	CreateKid(820, 265, "Sy", L"y=", &main, hInstance);
	CreateKid(910, 265, "Sz", L"z=", &main, hInstance);

	CreateKid(730, 315, "Rox", L"ox=", &main, hInstance);
	CreateKid(820, 315, "Roy", L"oy=", &main, hInstance);
	CreateKid(910, 315, "Roz", L"oz=", &main, hInstance);


	CreateKid(730, 25, "Crad", L"r=", &main, hInstance);


	RedrawWindow(main.hwnd, NULL, NULL, WM_PAINT);
	MSG msg;
	while(GetMessage(&msg, NULL, 0, 0))
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}
}