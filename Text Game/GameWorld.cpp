#include "GameWorld.h"

using namespace Game;


GameWorld::GameWorld()
{
	p_currentScene = NULL;
	p_startScene = NULL;
	m_allCommands.insert("look");
	m_allCommands.insert("move");
	m_allCommands.insert("pocket");
}

void GameWorld::AddScene(Scene* scene, WorldSide side)
{
	if(p_startScene == NULL)
	{
		p_startScene = scene;
		p_currentScene = scene;
	}
	else
	{
		p_currentScene->SetNeighbor(scene, side);
		WorldSide opSide;
		switch(side)
		{
		case North: opSide = South; break;
		case South: opSide = North; break;
		case West: opSide = East; break;
		case East: opSide = West; break;
		}
		scene->SetNeighbor(p_currentScene, opSide);
	}
	set<string> tmp = scene->GetAllCommands();
	m_allCommands.insert(tmp.begin(), tmp.end());
}

bool GameWorld::MoveTo(WorldSide side)
{
	Scene* next = p_currentScene->GetNeighbor(side);
	if( next != NULL && !next->IsBlocked())
	{
		p_currentScene = next;
		return true;
	}
	return false;
}
void GameWorld::ToStartScene()
{
	p_currentScene = p_startScene;
}

void GameWorld::ToDo(string line, ostream* out)
{
	HANDLE hcon = GetStdHandle(STD_OUTPUT_HANDLE);
	bool incorrectCommand = true;
	for(set<string, greater<string> >::iterator iter = m_allCommands.begin(); iter != m_allCommands.end(); ++iter)
	{
		if( line == "info")
		{			
			SetConsoleTextAttribute(hcon, YELLOW);

			(*out) << "move north - move to the scene to the north.\n";
			(*out) << "move west - move to the scene to the west.\n";
			(*out) << "move south - move to the scene to the south. \n";
			(*out) << "move east- move to the scene to the east. \n";

			
			(*out) << "look - look around. \n";
			(*out) << "look at %object% - look at specific object.\n";
			(*out) << "pick up %item% - pick up specific item.\n";
			(*out) << "use %vehicle% - use specific vehicle.\n";
			(*out) << "eat %item% - eat specific item.\n";
			(*out) << "talk to %npc% - talk to specific character.\n";
			(*out) << "pocket - look to your pocket.\n";

			incorrectCommand = false;
			break;
		}
		if(line.find(*iter)==0)
		{
			incorrectCommand = false;
			string command = *iter;
			string target;
			if( line != command )
			{
				target = line.substr( iter->size() + 1, line.size() - iter->size());
			}
			if( command == "look")
			{
				SetConsoleTextAttribute(hcon, GREEN);
				p_currentScene->Look(out);
			}
			else if(command == "pocket")
			{
				SetConsoleTextAttribute(hcon, GREEN);
				if( m_pocket.size() != 0)
				{
					(*out) << "In your pocket you have: ";
					int count = 0;
					for(set<string>::iterator iter = m_pocket.begin(); iter != m_pocket.end(); ++iter)
					{
						(*out) << *iter << ((count == (m_pocket.size() - 1))?"" : ", ");
						count++;

					}
					(*out) << ".\n";
				}
				else
				{
					(*out) << "Your pocket is empty.\n";
				}
			}
			else if(command == "move")
			{
				WorldSide side;
				incorrectCommand = true;
				if(target == "north")
				{
					side = North;
					incorrectCommand = false;
				}
				if(target == "west")
				{
					side = West;
					incorrectCommand = false;
				}
				if(target == "south")
				{
					side = South;
					incorrectCommand = false;
				}
				if(target == "east")
				{
					side = East;
					incorrectCommand = false;
				}

				if(incorrectCommand )
				{
					break;
				}
				if( MoveTo(side) )
				{
					SetConsoleTextAttribute(hcon, GREEN);
					(*out) << "You walked down the " + p_currentScene->GetShortMsg() + ".\n";
				}
				else
				{
					Scene* next = p_currentScene->GetNeighbor(side);
					if( next == NULL)
					{
						SetConsoleTextAttribute(hcon, DRED);
						(*out) << "You can't " + line + ".\n";
						SetConsoleTextAttribute(hcon, LGREY);
					}
					else if(next->IsBlocked())
					{
						(*out) << "There is " + next->GetShortMsg() + " to the " + target + ".\n";
					}
					else
					{
						SetConsoleTextAttribute(hcon, DRED);
						(*out) << "It's impossible to go to the " + target + ".\n";
						SetConsoleTextAttribute(hcon, LGREY);
					}
				}
			}
			else
			{
				string print = p_currentScene->Command(command, target);
				SetConsoleTextAttribute(hcon, GREEN);
				(*out) << print + ". \n";
				if( command == "pick up")
				{
					if( print.find("You can't") != 0 )
					{
						m_pocket.insert(target);
					}
				}
			}
			break;

		}
	}
	if(incorrectCommand)
	{
		SetConsoleTextAttribute(hcon, DRED);
		(*out) <<  "This command is incorrect.\n";
	}
	SetConsoleTextAttribute(hcon, WHITE);


}


