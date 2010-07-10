class BWindow - абстрактний клас дл€ роботи з в≥кном, маж в≥ртуальний метод wndProc дл€ обробки вс≥х messages.  
class BWindowListBox - конкретний клас дл€ доч≥рного в≥кна (у вигл€д≥ ListBox)
class BWindowMain - конкретний клас дл€ головного в≥кна, в €кому реал≥зовано метод wndProc.
class Point - "перехресток" маЇ пол€: x, y координати, id
class Street - вулиц€ маЇ поле: vector<Point> way - масив перехрестк≥в через €к≥ проходить, name - назва :))
class Map - 2 масиви - ус≥ вулиц≥ та перехрестки (vector<Point> points, vector<Street> streets)

у файл≥ data.txt дан≥ повинн≥ бути у формат≥:
к≥льк≥сть_перехрестк≥в(int)
id(int) x(int) y(int)
...
к≥льк≥сть_вулиць(int)
id(int) назва_вулиц≥(string)
к≥льк≥сть_перехрестк≥в_на_дан≥й_вулиц≥(int)
id_перехрестка(int) ... id_перехрестка(int)
