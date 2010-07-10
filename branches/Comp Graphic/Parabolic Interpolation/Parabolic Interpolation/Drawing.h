#pragma once

#include <vector>
#include <cmath>
#include <fstream>
#include <sstream>

#include "PointVec.h"

using namespace std;


const float pi = 3.1415926;



class Matrix3d
{
public:

	float arr[4][4];

	Matrix3d(){
		for(int i=0; i < 4; i++)
			for(int j=0; j<4; j++)
				if( i != j)
					arr[i][j] = 0;
				else
					arr[i][j] = 1;
	}
	Matrix3d(float a, float b, float c, float p, float d, float e, float f, float q, float i, float j, float k, float r, float l, float m, float n, float s)
	{
		arr[0][0]=a; arr[0][1]=b; arr[0][2]=c; arr[0][3]=p; 
		arr[1][0]=d; arr[1][1]=e; arr[1][2]=f; arr[1][3]=q; 
		arr[2][0]=i; arr[2][1]=j; arr[2][2]=k; arr[2][3]=r; 
		arr[3][0]=l; arr[3][1]=m; arr[3][2]=n; arr[3][3]=s; 
	}
	void RotateOX(float alpha)
	{
		float s = sin(alpha  * pi / 180 );
		float c = cos(alpha  * pi / 180 );
	
		arr[1][1] = c;
		arr[1][2] = s;
		arr[2][1] = -s;
		arr[2][2] = c;
	}
	void RotateOY(float alpha)
	{
		float s = sin(alpha  * pi / 180 );
		float c = cos(alpha  * pi / 180 );
	
		arr[0][0] = c;
		arr[0][2] = -s;
		arr[2][0] = s;
		arr[2][2] = c;
	}
	void RotateOZ(float alpha)
	{
		
		float s = sin(alpha  * pi / 180 );
		float c = cos(alpha  * pi / 180 );
	
		arr[0][0] = c;
		arr[0][1] = s;
		arr[1][0] = -s;
		arr[1][1] = c;
	}
	void Transport(float xx, float yy, float zz)
	{
		arr[3][0] = xx;
		arr[3][1] = yy;
		arr[3][2] = zz;
	}

	Matrix3d& operator= (Matrix3d& mat)
	{

		for(int i=0; i < 4; i++)
			for(int j=0; j<4; j++)
				arr[i][j] = mat.arr[i][j];
		return *this;
	}
	Matrix3d& operator*( Matrix3d& mat)
	{
		Matrix3d* res = new Matrix3d();
		for(int i=0; i < 4; i++)
			for(int j=0; j<4; j++)
			{
				float tmp = 0;
				for(int k=0; k<4; k++)
					tmp += arr[i][k] * mat.arr[k][j];
				res->arr[i][j] = tmp;
			}

		return *res;
	}
	

};

class Point3d
{
public:
	float x, y, z, h;
	Point3d():x(0), y(0), z(0), h(0){}
	Point3d(float xx, float yy, float zz, float hh):x(xx), y(yy), z(zz), h(hh){}
	Point3d(PointVec pv): x( pv.x), y( pv.y), z(pv.z), h(1){}
	Point3d& operator = (const Point3d& p)
	{
		x = p.x;
		y = p.y;
		z = p.z;
		h = p.h;
		return *this;
	}
	Point3d& operator* ( Matrix3d& mat)
	{
		float _x, _y, _z, _h;
		_x = x * mat.arr[0][0] + y * mat.arr[1][0] + z * mat.arr[2][0] + h * mat.arr[3][0];
		_y = x * mat.arr[0][1] + y * mat.arr[1][1] + z * mat.arr[2][1] + h * mat.arr[3][1];
		_z = x * mat.arr[0][2] + y * mat.arr[1][2] + z * mat.arr[2][2] + h * mat.arr[3][2];
		_h = x * mat.arr[0][3] + y * mat.arr[1][3] + z * mat.arr[2][3] + h * mat.arr[3][3];
		_x = _x / _h;
		_y = _y / _h;
		_z = _z / _h;
		_h = 1;
		Point3d* res = new Point3d(_x, _y, _z, _h);
		return *res;
	}
	void print (wfstream* out, string name)
	{
		*out<< name.c_str()<<" (" << x << ", "<< y << ", " << z << ")" ;
		
	}


};

void Line3d(HDC hdc, Point3d from, Point3d to)
{
	MoveToEx(hdc, from.x, from.y, NULL);
	LineTo(hdc, to.x, to.y);
}



class Polygon3d
{
public:
	vector<Point3d> arr;
	vector<wstring> names; 
	void add(Point3d p)
	{
		arr.push_back(p);
		names.push_back(L"");
	}
	void add(Point3d p, LPCWSTR n)
	{
		arr.push_back(p);
		names.push_back(n);
	}
	void add(float x, float y, float z)
	{
		Point3d p (x, y, z, 1);
		arr.push_back(p);
		names.push_back(L"");
	}
	void todo(Matrix3d& mat)
	{
		for(int i=0; i < arr.size(); i++)
			arr[i] = arr[i] * mat;
	}
	void print(HDC hdc, bool text = false)
	{
		for(int i=0; i < arr.size(); i++)
		{
			Line3d(hdc, arr[i], arr[(i+1)%arr.size()]);
			if( text)
				TextOut(hdc, arr[i].x + 3 , arr[i].y - 20, names[i].c_str(), names[i].size());
		}

	}
	void clear()
	{
		arr.clear();
		names.clear();
	}
	void createCoord(int l)
	{

		add(  Point3d(0, 0, 0, 1));
		
		add(  Point3d(l, 0, 0, 1), L"x");
		add(  Point3d(l-5, 3, 0, 1));
		add(  Point3d(l, 0, 0, 1));
		add(  Point3d(l-5, -3, 0, 1));
		add(  Point3d(l, 0, 0, 1));

		add(  Point3d(0, 0, 0, 1));
		
		add(  Point3d(0, l, 0, 1), L"y");
		add(  Point3d(3, l-5, 0, 1));
		add(  Point3d(0, l, 0, 1));
		add(  Point3d(-3, l-5, 0, 1));
		add(  Point3d(0, l, 0, 1));
		
		add(  Point3d(0, 0, 0, 1));

		add(  Point3d(0, 0, l, 1), L"z");
		add(  Point3d(3, 0, l-5, 1));
		add(  Point3d(0, 0, l, 1));
		add(  Point3d(-3, 0, l-5, 1));
		add(  Point3d(0, 0, l, 1));
	}

};


class Polyline3d
{
public:
	vector<Point3d> arr;
	vector<bool> show; 
	void add(Point3d p)
	{
		arr.push_back(p);
		show.push_back(L"");
	}
	void add(Point3d p, bool _show = false)
	{
		arr.push_back(p);
		show.push_back(_show);
	}
	void add(float x, float y, float z)
	{
		Point3d p (x, y, z, 1);
		arr.push_back(p);
		show.push_back(false);

	}
	void todo(Matrix3d& mat)
	{
		for(int i=0; i < arr.size(); i++)
			arr[i] = arr[i] * mat;
	}
	void print(HDC hdc, bool text = false)
	{
		for(int i=0; i < arr.size() -1; i++)
		{
		
			if( show[i] && text)
			Arc(hdc, arr[i].x - 2, arr[i].y - 2, arr[i].x + 3, arr[i].y+3, 0, 0, 0, 0);
			
			Line3d(hdc, arr[i], arr[i+1]);
			
		}

	}
	void clear()
	{
		arr.clear();
		show.clear();
	}
};
