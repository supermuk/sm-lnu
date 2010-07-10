#pragma once;
#include <string>
#include "SceneObject.h"

using namespace std;

namespace Game
{
	/**
		Abstract class that represents each item in the scene
	*/
	class Item: public SceneObject
	{
	protected:
		/**
			Initialization of the common event responses for all items
		*/
		void Initialize()
		{
			m_objectsResponses["pick up"] = "You pick up " + Name() + " and put it in your pocket";
			if( Eatable() )
			{
				m_objectsResponses["eat"] = "You've eaten up " + Name() + ". Yummy..";
			}
			else
			{
				m_objectsResponses["eat"] = "You are not enough hungry to eat up the " + Name();
			}
		}
	public:
		/**
			String representation of NPC name
		*/
		virtual string Name()
		{
			return "Item";
		}
		/**
			\return #true# if item is eatable, #false# in another case
		*/
		virtual bool Eatable()
		{
			return false;
		}

	};

	/**
		Concrete Item - Apple
	*/
	class Apple:public Item
	{
	public:
		/**
			Default constructor that initializes base event responses
		*/
		Apple()
		{
			Initialize();
			m_objectsResponses["look"] = "There is an apple lying under the tree";
			m_objectsResponses["look at"] = "The apple is juicy and looks tasty";
		}
		string Name()
		{
			return "apple";
		}
		bool Eatable()
		{
			return true;
		}
	};
	/**
		Concrete Item - Star
	*/
	class Star:public Item
	{
	public:
		/**
			Default constructor that initializes base event responses
		*/
		Star()
		{
			Initialize();
			m_objectsResponses["look"] = "There is a star shining in the background";
			m_objectsResponses["look at"] = "The star is astonishing";
		}
		string Name()
		{
			return "star";
		}
	};

	/**
		Concrete Item - Ruby
	*/
	class Ruby:public Item
	{
		/**
			Colour of the ruby
		*/
		string m_colour;
	public:
		/**
			Constructor with parameter that initializes base event responses
		*/
		Ruby(string colour)
		{
			Initialize();
			m_colour = colour;
			m_objectsResponses["look"] = "There is a " + Name() +" hidden in the green grass";
			m_objectsResponses["look at"] = "The ruby seems to be a precious stone";
		}
		string Name()
		{
			return m_colour + " ruby";
		}
	};

	/**
		Concrete Item - Ring
	*/
	class Ring:public Item
	{
	public:
		/**
			Default constructor that initializes base event responses
		*/
		Ring()
		{
			Initialize();
			m_objectsResponses["look"] = "The ring is lying not far from the pond";
			m_objectsResponses["look at"] = "The ring has probably been lost by a young lady";
		}
		string Name()
		{
			return "ring";
		}
	};

	/**
		Concrete Item - Basketball
	*/
	class Basketball:public Item
	{
	public:
		/**
			Default constructor that initializes base event responses
		*/
		Basketball()
		{
			Initialize();
			m_objectsResponses["look"] = "There is a basketball just next to you";
			m_objectsResponses["look at"] = "The basketball is looking forward to a big game";
		}
		string Name()
		{
			return "basketball";
		}
	};

	/**
		Concrete Item - Umbrella
	*/
	class Umbrella:public Item
	{
	public:
		/**
			Default constructor that initializes base event responses
		*/
		Umbrella()
		{
			Initialize();
			m_objectsResponses["look"] = "There is an umbrella hanging upside down";
			m_objectsResponses["look at"] = "The umbrella is striped and dotted at the same time";
		}
		string Name()
		{
			return "umbrella";
		}
	};


}