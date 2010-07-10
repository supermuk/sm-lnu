#include "BWindow.h"
#include "BWindowMain.h"
#include "BWindowKid.h"
#include "BWindowImage.h"



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
	wcex.lpszClassName	= "Class";
	wcex.hIconSm		= NULL;
	return RegisterClassEx(&wcex);
}




int APIENTRY WinMain (HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)
{
	MyRegisterClass(hInstance);

	

	//Створення головного вікна програми
	BWindowMain main;
	main.createWindow(0, "Class", "Flying Images", WS_OVERLAPPEDWINDOW, 50, 50, 800, 340, 0, 0, hInstance);
	main.showWindow(nCmdShow);


	//Створення вікна - кнопочки :)
	BWindowKid btn;
	btn.createWindow(NULL, "button", "Зупинити", WS_CHILD , 175 , 250, 120, 30, main.hwnd, (HMENU) 777, hInstance);
	btn.showWindow(nCmdShow);

	//Створення вікна - едіт поля для швидкості
	BWindowKid edit;
	edit.createWindow(NULL, "edit", "0", 
		WS_VISIBLE|WS_CHILD|WS_BORDER|ES_AUTOHSCROLL|ES_AUTOVSCROLL ,
		125, 255, 20, 20, main.hwnd , NULL, hInstance);
	edit.showWindow(SW_SHOW);

	main.editHwnd = edit.hwnd;// Звязок головного вікна і кнопки, едітполя
	main.btnHwnd = btn.hwnd;

	//Створення багато вікон - картинок
	BWindowImage images[IMAGE_COUNT];
	TCHAR path[4][13] = { "images/1.bmp", "images/2.bmp", "images/3.bmp", "images/4.bmp"};

	for(int i =0; i < IMAGE_COUNT; i++)
	{
		images[i].createWindow(NULL, "Class", " ", WS_CHILD | WS_BORDER, 20, 20, 200,150, main.hwnd, 0, hInstance);
		images[i].showWindow(nCmdShow);

		images[i].bmp = (HBITMAP)LoadImage(NULL, path[rand()%4], IMAGE_BITMAP, 0,0, LR_DEFAULTSIZE | LR_LOADFROMFILE); //завантаження Бітмапки з файлу (випадковий файл)
		GetObject(images[i].bmp, sizeof(BITMAP), &images[i].info);
		main.images[i] = images[i].hwnd; // Звязок головного вікна і дочірних
	}

	MSG msg;
	while(GetMessage(&msg, NULL, 0, 0))
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}
}
