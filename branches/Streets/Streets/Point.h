#pragma once



class Point
{
	
	int id;
public:
	Point(int _x, int _y, int _id):x(_x), y(_y), id(_id){}

	int get_id(){ return id; }

	void draw(HDC hdc)
	{
		HGDIOBJ oldpen, newpen;
		newpen = CreatePen(PS_SOLID, 2, RGB(115,40,240));
		oldpen = SelectObject(hdc, newpen);
		Arc(hdc, x - 2, y - 2, x + 2, y + 2, 0, 0, 0, 0);
		wchar_t name[20];
		_itow(id, name, 10);
		TextOut(hdc, x + 5, y - 25, (LPCSTR)name , 3);
		DeleteObject(newpen);
		SelectObject(hdc, oldpen);
	}

	int x;
	int y;
};
