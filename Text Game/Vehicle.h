#pragma once;
#include <string>
#include "SceneObject.h"

using namespace std;

namespace Game
{
	/**
		Abstract class that represents each vehicle in the scene
	*/
	class Vehicle: public SceneObject
	{
	protected:
		/**
			Initialization of the common event responses for all vehicles
		*/
		void Initialize()
		{
			m_objectsResponses["use"] = "You used the " + Name();
		}
	public:
		/**
			String representation of NPC name
		*/
		virtual string Name()
		{
			return "Vehicle";
		}
	};

	/**
		Concrete vehicle - Car
	*/
	class Car:public Vehicle
	{
	public:
		/**
			Default constructor that initializes base event responses
		*/
		Car()
		{
			Initialize();
			m_objectsResponses["look"] = "There is a car standing in the middle of the road";
			m_objectsResponses["look at"] = "The car is starting its engine";
		}
		string Name()
		{
			return "car";
		}
	};

	/**
		Concrete vehicle - Dreamship
	*/
	class Dreamship:public Vehicle
	{
	public:
		/**
			Default constructor that initializes base event responses
		*/
		Dreamship()
		{
			Initialize();
			m_objectsResponses["look"] = "There is a dreamship behind the bushes";
			m_objectsResponses["look at"] = "The dreamship is getting further while you are looking at it";
		}
		string Name()
		{
			return "dreamship";
		}
	};

	/**
		Concrete vehicle - mining Chart
	*/
	class miningChart:public Vehicle
	{
	public:
		/**
			Default constructor that initializes base event responses
		*/
		miningChart()
		{
			Initialize();
			m_objectsResponses["look"] = "There is a mining chart containing sparkling coal";
			m_objectsResponses["look at"] = "The coal is changing its colours from dark red to light violet";
		}
		string Name()
		{
			return "mining chart";
		}
	};

}