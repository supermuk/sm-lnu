#include "BWindow.h"
#include "BWindowMain.h"
#include "BWindowListBox.h"



//using namespace std;
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
	wcex.lpszMenuName	= NULL;
	wcex.lpszClassName	= "BOB";
	wcex.hIconSm		= NULL;
	return RegisterClassEx(&wcex);
}




int APIENTRY WinMain (HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)
{
	MyRegisterClass(hInstance);

	

	//Створення головного вікна програми
	BWindowMain main;
	main.createWindow(0, "BOB", "Streets", WS_OVERLAPPEDWINDOW, 50, 50, 800, 600, 0, 0, hInstance);
	main.showWindow(nCmdShow);

	//Стоврення Списку велиць
	main.fillListBox();


	
	MSG msg;
	while(GetMessage(&msg, NULL, 0, 0))
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}
}
