#include "BWindow.h"
#include <map>
#include <string>
#include "Drawing.h"

void updateCoef(vector<Point3d> pps, float& A, float& B, float& C)
{
	A = (pps[2].y - pps[0].y)*(pps[1].z - pps[0].z) - (pps[1].y - pps[0].y)*(pps[2].z - pps[0].z);
	B = (pps[2].z - pps[0].z)*(pps[1].x - pps[0].x) - (pps[1].z - pps[0].z)*(pps[2].x - pps[0].x);
	C = (pps[2].x - pps[0].x)*(pps[1].y - pps[0].y) - (pps[1].x - pps[0].x)*(pps[2].y - pps[0].y);

}

class BWindowMain: public BWindow
{
private:
	wfstream* out;
	Matrix3d mdata[8];
	Point3d pdata[19];


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

		RECT rect;
		rect.bottom=600;
		rect.top=0;
		rect.left=0;
		rect.right=700;	
		switch( message)
		{
		case WM_COMMAND:
			wmEvent = HIWORD(wParam);
			if (wmEvent == EN_CHANGE)
			{	
				RedrawWindow(hWnd, &rect, NULL ,WM_PAINT );
			}

			switch(LOWORD(wParam))  // Get Indentification of CheckBox who send command <strong>(HMENU) 1</strong>
			{
			case 777: // If Command send By <strong>(HMENU) 1</strong>
			
				if (SendMessage(kids["check"]->hwnd,BM_GETCHECK,0,0)==BST_UNCHECKED) //If UnChecked Box
				{
					SendMessage(kids["check"]->hwnd,BM_SETCHECK,BST_CHECKED,0); // Then Check Box
					RedrawWindow(hWnd, &rect, NULL, WM_PAINT);
				}
				else {
					SendMessage(kids["check"]->hwnd,BM_SETCHECK,BST_UNCHECKED,0); //  Else Set UnCheck
					RedrawWindow(hWnd, &rect, NULL, WM_PAINT);
				}
				break;
			case 666:
				onClick();
				break;
			}

			
		break;

		case WM_PAINT:
			hdc = BeginPaint(hWnd, &ps);
			onPaint(hdc);
	//		TextOut(hdc, 200, 200, L" ", 4);
			EndPaint(hWnd, &ps);
			break;
		case WM_DESTROY:
			*out << "© Orest Mykhaylovych 2009" << endl;
			for(int i=0; i < 1000; i ++)
				*out<< endl;
			PostQuitMessage(0);
		}
		return DefWindowProc( hWnd, message, wParam, lParam);
	}
public:
	void paintCube(HDC hdc)
	{
		if(kids.size() > 5)
		{

			Matrix3d NORM(
						1, 0, 0, 0,
						0, -1, 0, 0,
						0, 0, 1, 0,
						300, 300, 0, 1);
			Polygon3d coord;
			
			coord.createCoord(300);

			Polygon3d cube;

			cube.createCube(_getData("Crad"));

			
			float Cox, Coy, Coz;

			Cox = _getData("Cox");
			Coy = _getData("Coy");
			Coz = _getData("Coz");

			Matrix3d rotCox, rotCoy, rotCoz;
			rotCox.RotateOX(Cox);
			rotCoy.RotateOY(Coy);
			rotCoz.RotateOZ(Coz);
			
			cube.todo(rotCox);
			cube.todo(rotCoy);
			cube.todo(rotCoz);


			float Ax, Ay, Az;

			Ax = _getData("Ax");
			Ay = _getData("Ay");
			Az = _getData("Az");

			Matrix3d transport;
			transport.arr[3][0] = Ax;
			transport.arr[3][1] = Ay;
			transport.arr[3][2] = Az;

			cube.todo(transport);

			Polygon3d plane;
			Polygon3d resultCube(cube);
			resultCube.Res();


			float Qx, Qy, Qz;
			float Rx, Ry, Rz;
			float Sx, Sy, Sz;

			Qx = _getData("Qx");
			Qy = _getData("Qy");
			Qz = _getData("Qz");

			Rx = _getData("Rx");
			Ry = _getData("Ry");
			Rz = _getData("Rz");

			Sx = _getData("Sx");
			Sy = _getData("Sy");
			Sz = _getData("Sz");


			plane.add( Point3d(Qx,Qy,Qz,1), L"Q");
			plane.add( Point3d(Rx,Ry,Rz,1), L"R");
			plane.add( Point3d(Sx,Sy,Sz,1), L"S");
			Polygon3d plane2(plane);

			Matrix3d trans;
			trans.Transport(-Sx, -Sy, -Sz);

			plane.todo(trans);

			float A, B, C;
			updateCoef(plane.arr, A, B, C);
	
			float fi = atan( - A / C)* 180 / pi;
			Matrix3d rotFi;
			rotFi.RotateOY(fi);
			
			plane.todo(rotFi);


			updateCoef(plane.arr, A, B, C);
			float teta = atan(  - B / C)* 180 / pi;
			Matrix3d rotTeta;
			rotTeta.RotateOX(-teta);

			plane.todo(rotTeta);


			Matrix3d tmp_rot_fi;
			Matrix3d tmp_rot_teta;
			Matrix3d tmp_rot_hama;
			Matrix3d NORMILIZE;
			
			float rox, roy, roz;

			rox = _getData("Rox");
			roy = _getData("Roy");
			roz = _getData("Roz");

			tmp_rot_teta.RotateOX(17 + rox);
			tmp_rot_fi.RotateOY(-22.5 + roy);
			tmp_rot_hama.RotateOZ(roz);
			NORMILIZE =tmp_rot_fi*tmp_rot_teta * tmp_rot_hama* NORM;
			

			
			Matrix3d symetricZ;
			symetricZ.arr[2][2] = -1;
			


			Matrix3d rotFi_rev;
			rotFi_rev.RotateOY(-fi);
			Matrix3d rotTeta_rev;
			rotTeta_rev.RotateOX(teta);
			Matrix3d trans_rev;
			trans_rev.Transport(-trans.arr[3][0],  -trans.arr[3][1], -trans.arr[3][2]);


			bool show;
			if (SendMessage(kids["check"]->hwnd,BM_GETCHECK,0,0)==BST_UNCHECKED) 
			{
				show=false;
			}else
			{
				show = true;
			}

			Matrix3d all;
			all = trans * rotFi * rotTeta * symetricZ * rotTeta_rev * rotFi_rev * trans_rev;

			mdata[0] = trans;
			mdata[1] = rotFi;
			mdata[2] = rotTeta;
			mdata[3] = symetricZ;
			mdata[4] = rotFi_rev;
			mdata[5] = rotTeta_rev;
			mdata[6] = trans_rev;
			mdata[7] = all;
			

		

			resultCube.todo(trans * rotFi * rotTeta * symetricZ);
			resultCube.todo(rotTeta_rev * rotFi_rev * trans_rev);
			resultCube.todo(NORMILIZE);
			resultCube.print(hdc, show);

			
			pdata[0] = cube.arr[0];
			pdata[1] = cube.arr[1];
			pdata[2] = cube.arr[2];
			pdata[3] = cube.arr[3];
			pdata[4] = cube.arr[5];
			pdata[5] = cube.arr[6];
			pdata[6] = cube.arr[9];
			pdata[7] = cube.arr[12];
			pdata[8] = resultCube.arr[0];
			pdata[9] = resultCube.arr[1];
			pdata[10] = resultCube.arr[2];
			pdata[11] = resultCube.arr[3];
			pdata[12] = resultCube.arr[5];
			pdata[13] = resultCube.arr[6];
			pdata[14] = resultCube.arr[9];
			pdata[15] = resultCube.arr[12];
			pdata[16] = plane2.arr[0];
			pdata[17] = plane2.arr[1];
			pdata[18] = plane2.arr[2];


			plane2.todo(NORMILIZE);
			plane2.print(hdc, show);

			coord.todo(NORMILIZE);
			coord.print(hdc, show);
			cube.todo(NORMILIZE);
			cube.print(hdc, show);
		}
	}
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
		
		TextOut(hdc, 800, 0, L"Кубик:", 6);
		TextOut(hdc, 730, 45, L"Координати точки А:", 19);
		TextOut(hdc, 730, 95, L"Кути повороту відносно осей:", 28);
		TextOut(hdc, 800, 145, L"Площина:", 9);
		TextOut(hdc, 730, 165, L"Координати точки Q:", 19);
		TextOut(hdc, 730, 205, L"Координати точки R:", 19);
		TextOut(hdc, 730, 245, L"Координати точки S:", 19);

		TextOut(hdc, 730, 295, L"Поворот камери:", 15);
		paintCube(hdc);

		MoveToEx(hdc, 700, 0, 0);
		LineTo(hdc, 700, 599);
		LineTo(hdc, 0, 599);
	}
	void onClick()
	{

			pdata[0].print(out, "A");
			*out<<"  ->  ";
			pdata[8].print(out, "A'");
			*out << endl;
			pdata[1].print(out, "B");
			*out<<"  ->  ";
			pdata[9].print(out, "B'");
			*out << endl;
			pdata[2].print(out, "C");
			*out<<"  ->  ";
			pdata[10].print(out, "C'");
			*out << endl;
			pdata[3].print(out, "D");
			*out<<"  ->  ";
			pdata[11].print(out, "D'");
			*out << endl;
			pdata[4].print(out, "E");
			*out<<"  ->  ";
			pdata[12].print(out, "E'");
			*out << endl;
			pdata[5].print(out, "F");
			*out<<"  ->  ";
			pdata[13].print(out, "F'");
			*out << endl;
			pdata[6].print(out, "G");
			*out<<"  ->  ";
			pdata[14].print(out, "G'");
			*out << endl;
			pdata[7].print(out, "H");
			*out<<"  ->  ";
			pdata[15].print(out, "H'");
			
			*out << endl;
			
			
			
			pdata[16].print(out, "Q");
			*out << endl;
			pdata[17].print(out, "R");
			*out << endl;
			pdata[18].print(out, "S");
			*out << endl;


			mdata[0].print(out,"Перенесення в початок координат:");
			mdata[1].print(out, "Поворот відносно осі оУ:");
			mdata[2].print(out,"Поворот відносно осі оХ:");
			mdata[3].print(out, "Симетричне відображення відносно площини ХоУ:");
			mdata[4].print(out, "Зворотній поворот відносно осі оХ:");
			mdata[5].print(out,"Зворотній поворот відносно осі оУ:");
			mdata[6].print(out, "Зворотнє перенесення:");
			mdata[7].print(out, "Добуток всіх матриць:");

			*out<< endl << " ----------------------------------------" << endl;

		
	}

	void createWindow(DWORD dwExStyle, LPCWSTR lpClassName, LPCWSTR lpWindowName, DWORD dwStyle, int x, int y, int w, int h, HWND hParent, HMENU hMenu, HINSTANCE hInst,  wfstream* _out)
	{
		MDICREATESTRUCT mdic; memset(&mdic, 0, sizeof(mdic));
		mdic.lParam = (LPARAM) this;
		hwnd = CreateWindowEx(dwExStyle, lpClassName, lpWindowName, dwStyle, x, y, w, h, hParent, hMenu, hInst, &mdic);
		out = _out;
	}

	map<string, BWindow*> kids;
	map<string, LPCWSTR> titles;
};