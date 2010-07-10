#pragma once
#include <string>
#include <set>
#include "Item.h"
#include "Vehicle.h"
#include "SceneObject.h"
#include "Npc.h"
#include "Scene.h"

#include <windows.h>

#define NULL 0

using namespace std;

namespace Game
{


	enum Color { DBLUE=1,GREEN,GREY,DRED,DPURP,BROWN,LGREY,DGREY,BLUE,LIMEG,TEAL, RED,PURPLE,YELLOW,WHITE,B_B };
 
	/**
		Represents map of the Game World.
	*/
	class GameWorld
	{
		/**
			Pointer to the scene in which the player is at the moment
		*/
		Scene* p_currentScene;
		/**
			Pointer to the initial scene of the game
		*/
		Scene* p_startScene;
		/**
			Collection of available commands
		*/
		set<string, greater<string> > m_allCommands;
		/**
			Collection of items in player pocket
		*/
		set<string> m_pocket;
		/**
			Forbidden copy constructor
		*/
		GameWorld(const GameWorld&);
	public:
		/**
			Default constructor
		*/
		GameWorld();
		/**
			Adds scene as neighbour to the #m_currentScene# at specific side
		*/
		void AddScene(Scene* , WorldSide);
		/**
			Move #m_currentScene# to specific neighbour side
			\return If movement was successful
		*/
		bool MoveTo(WorldSide);
		/**
			Sets #m_currentScene# with value #m_startScene#
		*/
		void ToStartScene();
		/**
			Executes specific command and prints information to ostream
		*/
		void ToDo(string, ostream* );

	};

	
}