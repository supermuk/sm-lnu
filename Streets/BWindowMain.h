#pragma once
#include "BWindow.h"
#include "BWindowListBox.h"
#include "Map.h"
#include <fstream>



class BWindowMain: public BWindow
{

	Map map;
	int selected_item_index;
public:
	BWindowMain()
	{
		selected_item_index = 0;
		readMapFromFile(); //зчитує всі дані з файлу
		

	}

	void fillListBox()
	{
		listBox.createWindow(0, "listbox", "ListBox", WS_VISIBLE|WS_CHILD|WS_BORDER|LBS_NOTIFY, 610, 25, 150, 500, hwnd, 0, hInstance);
		for(int i = 0; i < map.streets.size(); i++)
		{
			SendMessage(listBox.hwnd, LB_ADDSTRING, 0, (LPARAM)	map.streets[i].get_name().c_str()); //додає в список вулицю
			
		}
		SendMessage(listBox.hwnd, LB_SETCURSEL, 0, 0); //виділяє 1 елемент "по дефолту"
	}

	BWindowListBox listBox;

protected:
	
	LRESULT wndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam) 
	{
		PAINTSTRUCT ps;
		HDC hdc;
		
		if ( HIWORD(wParam) == LBN_SELCHANGE)
			RedrawWindow(hwnd, 0, 0, WM_PAINT); //перемальовує граф при зміні вибраної вулиці в списку

		switch( message)
		{	



		case WM_PAINT:
			hdc = BeginPaint(hWnd, &ps);
			onPaint(hdc); //метод який малює усі ребра графа
			EndPaint(hWnd, &ps);
			break;
		case WM_DESTROY:
			PostQuitMessage(0);
		}
		return DefWindowProc( hWnd, message, wParam, lParam);
	}

	void onPaint(HDC hdc)
	{
		HGDIOBJ oldpen1, newpen1;
		newpen1 = CreatePen(PS_SOLID, 2, RGB(115,40,240));
		oldpen1 = SelectObject(hdc, newpen1);
		map.draw(hdc); // метод малює усі вершини і ребра графа
		DeleteObject(newpen1);
		SelectObject(hdc, oldpen1);

		selected_item_index = SendMessage(listBox.hwnd, LB_GETCURSEL, 0, 0) ; // отримуєм індекс виділеної вулиці зі списку
			
		if( selected_item_index >= 0 )
		{
			HGDIOBJ oldpen, newpen;
			newpen = CreatePen(PS_SOLID, 2, RGB(210,90,50));
			oldpen = SelectObject(hdc, newpen);
			map.streets[selected_item_index].draw(hdc); // малює вибрану вулицю (ребро графа) червоним кольором 
			DeleteObject(newpen);
			SelectObject(hdc, oldpen);
		}

	}

	void readMapFromFile()
	{
		ifstream in("data.txt");
		int point_count;
		in >> point_count;
		for(int  i = 0; i < point_count; i++)
		{
			int x, y, id;
			in >> id >> x >> y;
			map.addPoint(Point(x, y, id));
		}
		int street_count;
		in >> street_count;
		for(int i = 0; i < street_count; i++)
		{
			int id;
			in >> id;
			string name;
			in >> name;
			Street st(name, id);
			int count;
			in >> count;
			for(int j = 0; j < count; j++)
			{
				int id;
				in >> id;
				st.add(map.get_point(id));
			}
			map.addStreet(st);
		}
	}




};