#include "SceneObject.h"

using namespace Game;

void SceneObject::AddObjectResponse(string _event, string _handle)
{
	m_objectsResponses[_event] = _handle;
}

string SceneObject::Command(string _event)
{
	if( m_objectsResponses.count(_event) > 0)
	{
		return m_objectsResponses[_event];
	}
	else
	{
		return "You can't " + _event + " " + Name();
	}
}
set<string> SceneObject::GetAllCommands()
{
	set<string> allCommands;
	for(map<string, string>::iterator iter = m_objectsResponses.begin(); iter != m_objectsResponses.end(); ++iter)
	{
		allCommands.insert( iter->first);
	}
	return allCommands;
}