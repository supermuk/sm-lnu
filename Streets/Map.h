#pragma once
#include "Street.h"
#include <vector>


class Map
{
	

public:

	void addPoint(Point p)
	{
		points.push_back(p);
	}
	void addStreet(Street s)
	{
		streets.push_back(s);
	}
	Point get_point(int id)
	{
		for(int i = 0; i < points.size(); i++)
		{
			if(points[i].get_id() == id)
				return points[i];
		}
		return Point(0,0, -1);
	}

	void draw(HDC hdc)
	{
		for(int i = 0; i < points.size(); i++)
		{
			points[i].draw(hdc);
		}
		for(int i = 0; i < streets.size(); i++)
		{
			streets[i].draw(hdc);
		}
	}


	vector<Point> points;
	vector<Street> streets;
};