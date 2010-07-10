#pragma once
#include "Point.h"
#include <vector>
#include <string>

class Street
{
	vector<Point> way;
	string name;
	int id;
public:
	Street(string _name, int _id):name(_name), id(_id){}

	void add(Point p)
	{
		way.push_back(p);
	}

	string get_name(){ return name; }

	void draw(HDC hdc)
	{
		if( ! way.empty() )
			MoveToEx(hdc, way[0].x, way[0].y, 0);
		for(int i = 1; i < way.size() ; i++)
		{
			LineTo(hdc, way[i].x, way[i].y);
		}
	}

};