#include "BWindow.h"


class BWindowKids: public BWindow
{
protected:
	LRESULT wndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
	{
		int wmId, wmEvent;
		BWindowKids* pwnd;
		BWindowMain* parent;
		PAINTSTRUCT ps;
		HDC hdc;

		switch( message)
		{
		case WM_COMMAND:


		break;

		case WM_PAINT:
			hdc = BeginPaint(hWnd, &ps);
			EndPaint(hWnd, &ps);
			break;
		case WM_DESTROY:
			PostQuitMessage(0);
		}
		return DefWindowProc( hWnd, message, wParam, lParam);
	}
public:

	void createWindow(DWORD dwExStyle, LPCWSTR lpClassName, LPCWSTR lpWindowName, DWORD dwStyle, int x, int y, int w, int h, HWND hParent, HMENU hMenu, HINSTANCE hInst)
	{
		MDICREATESTRUCT mdic; memset(&mdic, 0, sizeof(mdic));
		mdic.lParam = (LPARAM) this;
		hwnd = CreateWindowEx(dwExStyle, lpClassName, lpWindowName, dwStyle, x, y, w, h, hParent, hMenu, hInst, &mdic);
		parent = hParent;
	}

	HWND parent;
};