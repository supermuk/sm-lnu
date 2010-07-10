#pragma once
#include <string>
#include <iostream>
#include <map>
#include <set>

using namespace std;

namespace Game
{
	/**
		Abstract class that represents any object that can be used in the scene
	*/
	class SceneObject
	{
	protected:
		/**
			Objects responses to all available commands
		*/
		map<string, string> m_objectsResponses;
	public:
		/**
			String representation of object name
		*/
		virtual string Name() = 0;
		/**
			Adds to #m_objectResponses# new pair: key - command, value - response
		*/
		void AddObjectResponse(string, string);
		/**
			\return set of all available commands
		*/
		set<string> GetAllCommands();
		/**
			Response to a specific event
		*/
		string Command(string);
	};

}