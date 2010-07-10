#include <iostream>
#include <string>

#include "GameWorld.h"

using namespace std;

using namespace Game;

int main()
{

	Scene* sceneWithPond = new Scene(
		"You look around in and see a pond. The sun is smiling at its glassy surface. The water is so calm that it is moveless. There are five big stones near the pond",
		"road leading to the pond",
		false
		);

	sceneWithPond->AddObject(new miningChart());
	sceneWithPond->AddObject(new FlowerMan("dragging Leafs"));
	sceneWithPond->AddObject(new Frog());
	sceneWithPond->AddObject(new Fish());
	sceneWithPond->AddObject(new Ruby("red"));
	sceneWithPond->AddObject(new Ring());
	sceneWithPond->AddObject(new SamTheLion());





	Scene* sceneWithBushes = new Scene(
		"You look around in and realize that you are standing in the road which is surrounded by bushes. You can hear the birds singing spring melodies", 
		"road that is losing its way between the roots of the bushes",
		false
		);
	sceneWithBushes->AddObject(new Car());
	sceneWithBushes->AddObject(new Dreamship());
	sceneWithBushes->AddObject(new FlowerMan("carrying a basket"));
	sceneWithBushes->AddObject(new Star());
	sceneWithBushes->AddObject(new Basketball());



	Scene* sceneWithTree = new Scene(
		"You can enjoy the perfect spring weather. The shade of the big old tree is falling on the grass and it feels quite comfortable to have a rest here",
		"trial leading to a big tree",
		false
		);
	sceneWithTree->AddObject(new ReaderRabbit());
	sceneWithTree->AddObject(new FlowerMan("pulling a Liana"));
	sceneWithTree->AddObject(new Squirrel());
	sceneWithTree->AddObject(new Apple());
	sceneWithTree->AddObject(new Ruby("purple"));
	sceneWithTree->AddObject(new Umbrella());


	GameWorld world;
	world.AddScene(sceneWithPond, North);
	world.AddScene(sceneWithBushes, North);
	world.AddScene(sceneWithTree, West);


	cout << "Hello!\nIf you want to get more information enter 'info'.\nIf you want to exit the game enter 'end'\n";

	HANDLE hcon = GetStdHandle(STD_OUTPUT_HANDLE);
	SetConsoleTextAttribute(hcon, WHITE);

	string command;
	getline(cin, command);

	while( command != "end")
	{
		world.ToDo(command, &cout);
		getline(cin, command);
	}

	SetConsoleTextAttribute(hcon, LGREY);
	cout << "Bye-Bye!\n";
	return 0;
}