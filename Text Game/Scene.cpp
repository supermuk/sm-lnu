#include "Scene.h"

using namespace Game;

Scene::Scene()
{
	m_isBlocked = true;
	m_shortMsg = "big rock blocking the path";

	for(int i = 0; i < 4; i++)
	{
		p_neighbours[i] = NULL;
	}
}
Scene::Scene(const Scene& scene)
{
	m_isBlocked = scene.m_isBlocked;
	m_lookMsg = scene.m_lookMsg;
	m_shortMsg = scene.m_shortMsg;
	for(int i = 0; i < 4; i++)
	{
		p_neighbours[i] = scene.p_neighbours[i];
	}
	for(map<string, SceneObject*>::iterator i = m_objects.begin(); i != m_objects.end(); ++i)
	{
		m_objects.insert(*i);
	}

}

Scene::Scene(string lookMsg, string shortMsg, bool isBlocked)
{
	m_isBlocked = isBlocked;
	m_lookMsg = lookMsg;
	m_shortMsg = shortMsg;
	
	for(int i = 0; i < 4; i++)
	{
		p_neighbours[i] = NULL;
	}
}

void Scene::Look(ostream* out)
{
	(*out) << m_lookMsg << endl;
	for( map<string, SceneObject* >::iterator iter = m_objects.begin(); iter != m_objects.end(); ++iter)
	{
		(*out) << iter->second->Command("look") +".\n";
	}
	vector<string> sides; 
	sides.push_back("north");
	sides.push_back("west");
	sides.push_back("south");
	sides.push_back("east");

	for(int i = 0; i < 4; i++)
	{
		if( p_neighbours[i] != NULL)
		{
			(*out) << "To the "+sides[i]+" you can see a " + p_neighbours[i]->GetShortMsg() + ".\n";
		}
	}

}



void Scene::AddObject(SceneObject* object)
{
	m_objects.insert( make_pair( object->Name(), object));
}

void Scene::SetNeighbor(Scene* scene, WorldSide side)
{
	p_neighbours[(int)side] = scene;
}

Scene* Scene::GetNeighbor(WorldSide side)
{
	return p_neighbours[(int)side];
}

set<string> Scene::GetAllCommands()
{
	set<string> allCommands;
	for( map<string, SceneObject* >::iterator iter = m_objects.begin(); iter != m_objects.end(); ++iter)
	{
		set<string> tmp = iter->second->GetAllCommands();
		allCommands.insert(tmp.begin(), tmp.end());
	}
	return allCommands;
}

string Scene::Command(string command,string target)
{

	if( m_objects.count(target) > 0 )
	{
		string res = m_objects[target]->Command(command);
		if(command == "eat" && target == "apple")
		{
			m_objects.erase("apple");
		}
		if(command == "pick up")
		{
			if( res.find("You can't") != 0 )
			{
				m_objects.erase(target);
			}
		}
		return res;

	}
	else
	{
		return "You can't " + command + " " + target;
	}
}

bool Scene::IsBlocked()
{
	return m_isBlocked;
}

string Scene::GetShortMsg()
{
	return m_shortMsg;
}