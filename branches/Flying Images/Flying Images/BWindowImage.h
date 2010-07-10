#pragma once
#include "BWindow.h"
#include "BWindowKid.h"
#include <string>
class BWindowImage: public BWindowKid
{
public:
	BWindowImage(){}
	BWindowImage(TCHAR* path)
	{
		bmp = (HBITMAP)LoadImage(NULL, path, IMAGE_BITMAP, 0,0, LR_DEFAULTSIZE | LR_LOADFROMFILE);
		
		GetObject(bmp, sizeof(BITMAP), &info);


	}
	LRESULT wndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam) 
	{
		PAINTSTRUCT ps;
		HDC hdc;
		

		switch( message)
		{	
			case WM_LBUTTONUP:
				ShowWindow(hwnd, SW_HIDE);
			break;
			case WM_PAINT:
				hdc = BeginPaint(hWnd, &ps);
				onPaint(hdc); 
				EndPaint(hWnd, &ps);
			break;
		}
		return DefWindowProc( hWnd, message, wParam, lParam);
	}

	HBITMAP bmp;
	BITMAP info;
protected:
	void onPaint(HDC hdc)//Малює Картинку!
	{
			HDC srcdc = CreateCompatibleDC(0);
	             
			HBITMAP holdbmp = (HBITMAP)SelectObject(srcdc, bmp);

			BitBlt(hdc, 0, 0, info.bmWidth, info.bmHeight, srcdc, 0, 0, SRCCOPY);

			SelectObject(srcdc, holdbmp);
			DeleteDC(srcdc);
	        
	}

};
