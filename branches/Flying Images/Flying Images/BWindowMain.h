#pragma once
#include "BWindow.h"
#include <fstream>

int const IMAGE_COUNT = 50; //ʳ������ ��������

class BWindowMain: public BWindow
{

public:
	BWindowMain()
	{
		speed = 0;
		for(int i =0; i < IMAGE_COUNT; i++)
		{
			move_x[i] = -i*250; //�������� ���������� ��������
		}
		run = true;
	}


	HWND editHwnd; 
	HWND btnHwnd;
	HWND images[IMAGE_COUNT];
	int move_x[IMAGE_COUNT];//������� ����� ��������
	bool run; // ����������/���������� ���
	int speed;//������� ������ = ������� �� 100��
protected:
	
	LRESULT wndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam) 
	{
		PAINTSTRUCT ps;
		HDC hdc;
		

		switch( message)
		{	

		case WM_COMMAND:
			if (HIWORD(wParam) == EN_CHANGE)//������� ��䳿 - ���� ��������
			{	
				speed = _getData();
				SetWindowText(btnHwnd, "��������");
				RedrawWindow(hWnd, NULL, NULL ,WM_PAINT );
				run = true;
			}
			if( LOWORD(wParam)==777)//������� ��䳿 - ���������� �� ������
			{
				if(run)
				{
					speed = 0;
					SetWindowText(btnHwnd, "���������");
					run = false;
				}else
				{
					speed = _getData();
					SetWindowText(btnHwnd, "��������");
					run = true;
				}
			}

			break;
		
		case WM_CREATE:
			SetTimer(hWnd, 20, 100, NULL);//������������ ������� ("���" ���� 100 �� = 0.1� :)

			break;
		case WM_TIMER:
			move();//"���" �������
			RedrawWindow(hwnd, NULL, NULL, WM_PAINT);
		break;
		case WM_PAINT:
			hdc = BeginPaint(hWnd, &ps);
			TextOut(hdc, 13, 255, "�������� (0-9)", 15);
			MoveToEx(hdc, 0, 200, 0);
			LineTo(hdc, 1000, 200);
			EndPaint(hWnd, &ps);
			break;
		case WM_DESTROY:
			PostQuitMessage(0);
		}
		return DefWindowProc( hWnd, message, wParam, lParam);
	}

	int _getData()//������� ����� � ������� (��������)
	{
		wchar_t buf[10];
		GetWindowText(editHwnd, (LPSTR)buf, 10);
		return _wtoi(buf);
	}
	void move()
	{
		
		for(int i = 0; i < IMAGE_COUNT; i++)
		{
			move_x[i] += speed;
			SetWindowPos(images[i], HWND_TOP, move_x[i], 20, 100,100, SWP_NOSIZE); //����� ����� �������� �� �������� "speed"
		}
		
		

	}

	

};