#include "BWindow.h"
#include <map>
#include <string>
#include "Drawing.h"
#include "ParabolicInterpolation.h"



class BWindowMain: public BWindow
{
private:


protected:
	float _getData(string name)
	{
		TCHAR buf[100];
		GetWindowText(kids[name]->hwnd, buf, 100);
		return _wtof(buf);
	}

	LRESULT wndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
	{ 
		int wmId, wmEvent;
		BWindow* pwnd;
		PAINTSTRUCT ps;
		HDC hdc;

		switch( message)
		{
		case WM_COMMAND:
			wmEvent = HIWORD(wParam);
			if (wmEvent == EN_CHANGE)
			{	
				RedrawWindow(hWnd, NULL, NULL ,WM_PAINT );
			}
			
			switch(LOWORD(wParam))  
			{
			case 777: 
			
				//if (SendMessage(kids["check"]->hwnd,BM_GETCHECK,0,0)==BST_UNCHECKED) //If UnChecked Box
				//{
				//	SendMessage(kids["check"]->hwnd,BM_SETCHECK,BST_CHECKED,0); // Then Check Box
				//	RedrawWindow(hWnd, &rect, NULL, WM_PAINT);
				//}
				//else {
				//	SendMessage(kids["check"]->hwnd,BM_SETCHECK,BST_UNCHECKED,0); //  Else Set UnCheck
				//	RedrawWindow(hWnd, &rect, NULL, WM_PAINT);
				//}
				break;
			case 666:
				onClick();
				break;
			}

			
		break;

		case WM_PAINT:
			hdc = BeginPaint(hWnd, &ps);
			onPaint(hdc);
			EndPaint(hWnd, &ps);
			break;
		case WM_DESTROY:

			PostQuitMessage(0);
		}
		return DefWindowProc( hWnd, message, wParam, lParam);
	}
public:
	vector<PointVec> p;
	void onPaint(HDC hdc)
	{
		RECT mrect;
		GetWindowRect(hwnd, &mrect);
		for( map<string, BWindow*>::iterator itr=  kids.begin(); itr != kids.end(); itr++)
		{
			RECT rect;
			GetWindowRect(itr->second->hwnd, &rect);
			TextOut(hdc, rect.left - mrect.left - 30 , rect.top - mrect.top - 20, titles[itr->first], 3);
		}
		MoveToEx(hdc, 0, 500, 0);
		LineTo( hdc, 1000, 500);
		MoveToEx(hdc, 0, 503, 0);
		LineTo( hdc, 1000, 503);
		

		bool added = false;
		PointVec tmp;
		if( kids.size())
		{
		tmp.x = _getData("x");
		tmp.y = _getData("y");
		tmp.z = _getData("z");
		

		if( p.size() == 0)
		{
			p.push_back(tmp);
			added = true;
		}
		else
		{
			if( tmp!= p[p.size() - 1 ] )
			{
				p.push_back(tmp);
				added = true;
			}
		}
		int n;
		if( kids.size())
			n = _getData("Tab");
		if ( n < 2)
			n =2;
		
				

		vector<PointVec> result;	
		vector<bool> bres;
	
		if( p.size() > 2)
		{

			float _t0;
			_t0 = (p[1] - p[0]).dist();
			float _t = 0;

			for(int i = 0; i < n; i ++)
			{
				_t =  _t0 * i / n;
				result.push_back(Left(_t, p[0], p[1], p[2]));
				if(i==0)
					bres.push_back(true);
				else
				bres.push_back(false);

			}
			for(int j = 0; j < p.size() - 3; j++ )
			{
				float t0;
				t0 = (p[2+j] - p[1+j]).dist();
				float t = 0;

				for(int i = 0; i < n; i ++)
				{
					t = t0 * i / n;
					result.push_back(C(t, p[0+j], p[1+j], p[2+j], p[3+j]));
					if(i==0)
					bres.push_back(true);
					else
					bres.push_back(false);


				}
			}

			_t0 = (p[p.size()-2] - p[p.size()-1]).dist();

			for(int i = 0; i <= n; i ++)
			{
				_t = _t0 * i / n;
				result.push_back(Right(_t, p[p.size()-3], p[p.size()-2], p[p.size()-1]));
				if(i==0)
					bres.push_back(true);
				else
				bres.push_back(false);

			}

		}
		Polyline3d line;
		for(int i = 0; i < result.size(); i++)
		{
			line.add( Point3d(result[i]), bres[i]);
		}



		Matrix3d rotOx;
		rotOx.RotateOX( _getData("Rox"));
		Matrix3d rotOy;
		rotOx.RotateOY(_getData("Roy"));
		Matrix3d rotOz;
		rotOx.RotateOZ(_getData("Roz"));
		Matrix3d NORMILIZE;

		NORMILIZE.arr[1][1] = -1;
		NORMILIZE.arr[3][0] = 450;
		NORMILIZE.arr[3][1] = 350;

		
		Matrix3d ZOOM;
		float z = _getData("zoom");
		ZOOM.arr[0][0] = z;
		ZOOM.arr[1][1] = z;
		ZOOM.arr[2][2] = z;
		NORMILIZE = rotOy * rotOx * rotOz * NORMILIZE;

		line.todo(  ZOOM* NORMILIZE );
		if(p.size() > 2)
		line.print(hdc, true);
		
		Point3d _tmp(tmp);
		_tmp = _tmp *ZOOM* NORMILIZE;
		Arc(hdc, _tmp.x -4, _tmp.y -4, _tmp.x + 4, _tmp.y + 4,0,0,0,0);
		Polygon3d coord;
		coord.createCoord(300);

		coord.todo( NORMILIZE);
		coord.print(hdc);
		if( added)
		p.pop_back();

	}
	}
	void onClick()
	{
		if( p.size() == 0)
			p.push_back(PointVec(_getData("x"), _getData("y"), _getData("z")));
		else
		{
		if( PointVec(_getData("x"), _getData("y"), _getData("z")) != p[p.size() - 1 ] )
			p.push_back(PointVec(_getData("x"), _getData("y"), _getData("z")));
		}
		RedrawWindow(hwnd, NULL, NULL, WM_PAINT);
		
	}
	void createWindow(DWORD dwExStyle, LPCWSTR lpClassName, LPCWSTR lpWindowName, DWORD dwStyle, int x, int y, int w, int h, HWND hParent, HMENU hMenu, HINSTANCE hInst)
	{
		MDICREATESTRUCT mdic; memset(&mdic, 0, sizeof(mdic));
		mdic.lParam = (LPARAM) this;
		hwnd = CreateWindowEx(dwExStyle, lpClassName, lpWindowName, dwStyle, x, y, w, h, hParent, hMenu, hInst, &mdic);

	}

	map<string, BWindow*> kids;
	map<string, LPCWSTR> titles;
};