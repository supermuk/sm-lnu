#pragma once
#include <windows.h>
#include <vector>
#include <algorithm>



using namespace std;

class BWindow
{
protected:
	virtual LRESULT wndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
	{
		return DefWindowProc( hWnd, message, wParam, lParam);
	}

public:
	static LRESULT CALLBACK windowProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
	{
		BWindow* pwnd;
		if( message == WM_NCCREATE)
		{
			MDICREATESTRUCT* pMDIC = (MDICREATESTRUCT* ) ((LPCREATESTRUCT) lParam)->lpCreateParams;
			pwnd = (BWindow* ) (pMDIC->lParam);
			SetWindowLong( hWnd, GWL_USERDATA, (LONG) pwnd);
		}else
		{
			pwnd = (BWindow* ) GetWindowLong(hWnd, GWL_USERDATA);
		}
		if( pwnd) 
			return pwnd->wndProc(hWnd, message, wParam, lParam);
		else	
			return DefWindowProc( hWnd, message, wParam, lParam);

	}
	virtual void createWindow(DWORD dwExStyle, LPCWSTR lpClassName, LPCWSTR lpWindowName, DWORD dwStyle, int x, int y, int w, int h, HWND hParent, HMENU hMenu, HINSTANCE hInst)
	{
		MDICREATESTRUCT mdic; memset(&mdic, 0, sizeof(mdic));
		mdic.lParam = (LPARAM) this;
		hwnd = CreateWindowEx(dwExStyle, lpClassName, lpWindowName, dwStyle, x, y, w, h, hParent, hMenu, hInst, &mdic);
	}
	void showWindow(int nCmdShow)
	{
		ShowWindow(hwnd, nCmdShow);
		UpdateWindow(hwnd);
	}


	HWND hwnd;
};




