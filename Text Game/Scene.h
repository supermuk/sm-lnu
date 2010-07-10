#pragma once
#include <map>
#include <set>
#include <vector>
#include <string>
#include <iostream>
#include "SceneObject.h"

using namespace std;

#define NULL 0

namespace Game
{
	/**
		All sides of the world
	*/
	enum WorldSide{
		North = 0,
		West,
		South,
		East
	};



	/**
		Concrete scene in the game
	*/
	class Scene
	{
		/**
			Tree of all objects from the scene: key - name, value - pointer to object
		*/
		map<string, SceneObject*> m_objects;
		/**
			Pointers to all neighbours
		*/
		Scene* p_neighbours[4];
		/**
			Means if player can move to this scene
		*/
		bool m_isBlocked;
		/**
			Message that is printed if player is looking around
		*/
		string m_lookMsg;
		/**
			Short description of this scene.
			Message that is printed when player is in the neighbour scene 
		*/
		string m_shortMsg;

		/**
			Forbbiden default constructor
		*/
		Scene();
	public:
		/**
			Copy constructor.
			Copy all pointers to objects, but not objects
		*/
		Scene(const Scene&);
		/**
			Constructor with parameters.
			\param lookMsg Full description of the scene
			\param shortMsg Short description of the scene
			\param isBlocked Indicates if this scene is blocked
		*/
		Scene(string lookMsg, string shortMsg, bool isBlocked);

		/**
			Adds specific object pointer to this scene
		*/
		void AddObject(SceneObject* object);
		/**
			Sets the pointer to neighbour scene at specific side
		*/
		void SetNeighbor(Scene* scene, WorldSide side);
		/**
			Gets the pointer to neighbour scene from specific side
		*/
		Scene* GetNeighbor(WorldSide);
		/**
			true if player can move to this scene, false in another case
		*/
		bool IsBlocked();
		/**
			Returns short description of the scene
		*/
		string GetShortMsg();
		/**
			Returns set of all commands available in the scene
		*/
		set<string> GetAllCommands();
		/**
			Prints to ostream all the information about scene and onbject in it
		*/
		void Look(ostream* out);
		/**
			Executes specific command
			\param command Command typed by player
			\param target Name of object
			\return Response message
		*/
		string Command(string command, string target);

	};

	
}