class BWindow - ����������� ���� ��� ������ � �����, ��� ���������� ����� wndProc ��� ������� ��� messages.  
class BWindowListBox - ���������� ���� ��� ��������� ���� (� ������ ListBox)
class BWindowMain - ���������� ���� ��� ��������� ����, � ����� ���������� ����� wndProc.
class Point - "�����������" �� ����: x, y ����������, id
class Street - ������ �� ����: vector<Point> way - ����� ����������� ����� �� ���������, name - ����� :))
class Map - 2 ������ - �� ������ �� ����������� (vector<Point> points, vector<Street> streets)

� ���� data.txt ��� ������ ���� � ������:
�������_�����������(int)
id(int) x(int) y(int)
...
�������_������(int)
id(int) �����_������(string)
�������_�����������_��_����_������(int)
id_�����������(int) ... id_�����������(int)
