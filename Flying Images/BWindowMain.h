#pragma once
#include "BWindow.h"
#include <fstream>

int const IMAGE_COUNT = 50; //Кількість картинок

class BWindowMain: public BWindow
{

public:
	BWindowMain()
	{
		speed = 0;
		for(int i =0; i < IMAGE_COUNT; i++)
		{
			move_x[i] = -i*250; //початкові координати картинок
		}
		run = true;
	}


	HWND editHwnd; 
	HWND btnHwnd;
	HWND images[IMAGE_COUNT];
	int move_x[IMAGE_COUNT];//позиція кожної картинки
	bool run; // зупинитись/продовжити рух
	int speed;//кількість пікселів = зміщення за 100мс
protected:
	
	LRESULT wndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam) 
	{
		PAINTSTRUCT ps;
		HDC hdc;
		

		switch( message)
		{	

		case WM_COMMAND:
			if (HIWORD(wParam) == EN_CHANGE)//Обробка події - зміна швидкості
			{	
				speed = _getData();
				SetWindowText(btnHwnd, "Зупинити");
				RedrawWindow(hWnd, NULL, NULL ,WM_PAINT );
				run = true;
			}
			if( LOWORD(wParam)==777)//Обробка події - натискання на кнопку
			{
				if(run)
				{
					speed = 0;
					SetWindowText(btnHwnd, "Запустити");
					run = false;
				}else
				{
					speed = _getData();
					SetWindowText(btnHwnd, "Зупинити");
					run = true;
				}
			}

			break;
		
		case WM_CREATE:
			SetTimer(hWnd, 20, 100, NULL);//Встановлення таймеру ("клік" кожні 100 мс = 0.1с :)

			break;
		case WM_TIMER:
			move();//"клік" таймера
			RedrawWindow(hwnd, NULL, NULL, WM_PAINT);
		break;
		case WM_PAINT:
			hdc = BeginPaint(hWnd, &ps);
			TextOut(hdc, 13, 255, "Швидкість (0-9)", 15);
			MoveToEx(hdc, 0, 200, 0);
			LineTo(hdc, 1000, 200);
			EndPaint(hWnd, &ps);
			break;
		case WM_DESTROY:
			PostQuitMessage(0);
		}
		return DefWindowProc( hWnd, message, wParam, lParam);
	}

	int _getData()//Повертає число з ЕдітПоля (швидкість)
	{
		wchar_t buf[10];
		GetWindowText(editHwnd, (LPSTR)buf, 10);
		return _wtoi(buf);
	}
	void move()
	{
		
		for(int i = 0; i < IMAGE_COUNT; i++)
		{
			move_x[i] += speed;
			SetWindowPos(images[i], HWND_TOP, move_x[i], 20, 100,100, SWP_NOSIZE); //зміщуєм кожну картинку на величину "speed"
		}
		
		

	}

	

};