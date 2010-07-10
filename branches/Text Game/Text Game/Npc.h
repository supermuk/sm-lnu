#pragma once;
#include <string>
#include "SceneObject.h"

using namespace std;

namespace Game
{
	/**
		Abstract class that represents each non player character(NPC) in the scene
	*/
	class Npc: public SceneObject
	{
	public:
		/**
			String representation of NPC name
		*/
		virtual string Name()
		{
			return "NPC";
		}
	};

	/**
		Concrete NPC - Reader Rabbit
	*/
	class ReaderRabbit: public Npc
	{
	public:
		/**
			Default constructor that initializes base event responses
		*/
		ReaderRabbit()
		{
			m_objectsResponses["look"] = "Reader Rabbit is looking for some carrot on the magic tree";
			m_objectsResponses["look at"] = "Reader Rabbit is really busy and has no time to pay any attention to you";
			m_objectsResponses["talk to"] = "Sorry, I am too busy right now";
		}
		string Name ()
		{
			return "Reader Rabbit";
		}
	};

	/**
		Concrete NPC -Sam the Lion
	*/
	class SamTheLion: public Npc
	{
	public:
		/**
			Default constructor that initializes base event responses
		*/
		SamTheLion()
		{
			m_objectsResponses["look"] = "Sam the Lion is combing his long curly hair";
			m_objectsResponses["look at"] = "He stops combing and smiles at you in a friendly way";
			m_objectsResponses["talk to"] = "Hey, Budddy! How are you?";
		}
		string Name()
		{
			return "Sam the Lion";
		}
	};

	/**
		Concrete NPC - Flower Man
	*/
	class FlowerMan: public Npc
	{
	private:
		/**
			What Flower Man is doing
		*/
		string m_business;
	public:
		/**
			Constructor with parameter that initializes base event responses
		*/
		FlowerMan(string business)
		{
			m_business = business;
			m_objectsResponses["look"] = "There is a " + Name();
			m_objectsResponses["look at"] = "The Flower Man is "+ m_business;
			m_objectsResponses["talk to"] = "Hey! What a nice weather today";
		}
		string Name ()
		{
			return "Flower Man " + m_business;
		}
	};

	/**
		Concrete NPC - Frog
	*/
	class Frog: public Npc
	{
	public:
		/**
			Default constructor that initializes base event responses
		*/
		Frog()
		{
			m_objectsResponses["look"] = "There is a fat Frog sitting under the leaf";
			m_objectsResponses["look at"] = "Frog is jumping from one stone to another";
			m_objectsResponses["talk to"] = "Let's have fun together";
		}
		string Name ()
		{
			return "Frog";
		}
	};

	/**
		Concrete NPC - Fish
	*/
	class Fish: public Npc
	{
	public:
		/**
			Default constructor that initializes base event responses
		*/
		Fish()
		{
			m_objectsResponses["look"] = "There is a little Fish enjoying clear water in the pond";
			m_objectsResponses["look at"] = "She is speechlessly staring at you";
			m_objectsResponses["talk to"] = "[Silence...]";
		}
		string Name ()
		{
			return "Fish";
		}
	};
	
	/**
		Concrete NPC - Squirrel
	*/
	class Squirrel: public Npc
	{
	public:
		/**
			Default constructor that initializes base event responses
		*/
		Squirrel()
		{
			m_objectsResponses["look"] = "There is a little Squirrel sitting on the highest branch of the tree";
			m_objectsResponses["look at"] = "The Squirrel looks back at you with a funny expression on his face";
			m_objectsResponses["talk to"] = "Do you have any nuts";
		}
		string Name ()
		{
			return "Squirrel";
		}
	};
}