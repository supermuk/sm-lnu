#pragma once
#include "BWindow.h"


class BWindowListBox: public BWindow
{
public:
	void createWindow(DWORD dwExStyle, LPCSTR lpClassName, LPCSTR lpWindowName, DWORD dwStyle, int x, int y, int w, int h, HWND hParent, HMENU hMenu, HINSTANCE hInst)
	{
		MDICREATESTRUCT mdic; memset(&mdic, 0, sizeof(mdic));
		mdic.lParam = (LPARAM) this;
		hwnd = CreateWindowEx(dwExStyle, lpClassName, lpWindowName, dwStyle, x, y, w, h, hParent, hMenu, hInst, &mdic);
		hInstance = hInst;
		parent = hParent;
	}

protected:
	LRESULT wndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
	{
		
		return DefWindowProc( hWnd, message, wParam, lParam);
	}
	HWND parent;
};