#pragma once
#include "Drawing.h"

PointVec P(float r,float x, float d,float alpha, PointVec P0, PointVec P1, PointVec P2)
{
	PointVec res;
	res = P0 + (P2 - P0)* (r/d)+  ( (P1 - P0) - (P2 - P0) *x )*alpha * r * ( d - r) ;
	return res;
}
PointVec Q(float s,float x, float e, float beta, PointVec P0, PointVec P1, PointVec P2)
{
	PointVec res;
	res = P0 + (P2 - P0) *(s/e)+ ( (P1 - P0) - (P2 - P0)*x )*beta * s * ( e - s)  ;
	return res;
}



PointVec C(float t,  PointVec P0, PointVec P1, PointVec P2, PointVec P3)
{
	PointVec res;
	float t0;
	t0 = (P2 - P1).dist();
	float rx, sx, d, e;

	d = (P2 - P0).dist();
	e = (P3 - P1).dist();

	rx =  (P1 - P0) * ( P2 - P0)* 1/(d*d) ;
	sx = (P2 - P1) * ( P3 - P1) * 1/(e*e) ;

	float cosTetaR, cosTetaS;

	cosTetaR =(P2 - P1) * ( P2 - P0) * 1/( t0 * d);
	cosTetaS =  (P2 - P1) * ( P3 - P1) *  1/(t0 * e);


	float alpha, beta;

	alpha = 1 / ( d*d * rx * (1 - rx) );
	beta = 1 / ( e*e * sx * (1 - sx) );


	float r, s;
	r = rx * d + t * cosTetaR;
	s = t * cosTetaS;

	res =  P(r, rx, d, alpha, P0, P1, P2) *(1 - t/t0) +  Q(s, sx, e, beta, P1, P2, P3) *( t / t0); 
	return res;

}

PointVec Right(float t, PointVec P0, PointVec P1, PointVec P2)
{
	PointVec res;
	float t0;
	t0 = (P2 - P1).dist();
	float rx, d;

	d = (P2 - P0).dist();

	rx =  (P1 - P0) * ( P2 - P0)* 1/(d*d) ;

	float cosTetaR;

	cosTetaR =(P2 - P1) * ( P2 - P0) * 1/( t0 * d);


	float alpha, beta;

	alpha = 1 / ( d*d * rx * (1 - rx) );


	float r;
	r = rx * d + t * cosTetaR;
	

	res =  P(r, rx, d, alpha, P0, P1, P2) ; 
	return res;
}


PointVec Left(float t, PointVec P1, PointVec P2, PointVec P3)
{
PointVec res;
	float t0;
	t0 = (P2 - P1).dist();
	float  sx, e;

	e = (P3 - P1).dist();

	sx = (P2 - P1) * ( P3 - P1) * 1/(e*e) ;

	float  cosTetaS;

	cosTetaS =  (P2 - P1) * ( P3 - P1) *  1/(t0 * e);


	float  beta;

	beta = 1 / ( e*e * sx * (1 - sx) );


	float  s;
	s = t * cosTetaS;

	res = Q(s, sx, e, beta, P1, P2, P3) ; 
	return res;
}

