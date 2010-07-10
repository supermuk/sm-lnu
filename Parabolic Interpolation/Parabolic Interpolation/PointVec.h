#pragma once

class PointVec
{
public:
	float x, y, z;
	PointVec():x(0), y(0), z(0){}
	PointVec(float _x, float _y, float _z):x(_x), y(_y), z(_z){}
	float operator*(PointVec& pv)
	{
		return x * pv.x + y * pv.y + z * pv.z;
	}
	PointVec& operator*(float a)
	{
		PointVec* res = new PointVec( x*a, y*a, z*a);
		return *res;
	}
	float dist()
	{
		return sqrt( x*x + y*y + z*z );
	}
	PointVec& operator+(PointVec& pv)
	{
		PointVec* res = new PointVec( x + pv.x, y + pv.y, z + pv.z);
		return *res;
	}
	PointVec& operator-(PointVec& pv)
	{
		PointVec* res = new PointVec( x - pv.x, y - pv.y, z - pv.z);
		return *res;
	}
	bool operator != (PointVec& pv)
	{
		return ! ((pv.x == x) && ( pv.y == y) && (pv.z == z));
	}
	void print(HDC hdc)
	{
		LineTo(hdc, x*100, y*100);
	}
};