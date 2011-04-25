#ifndef GAMEPROBLEM_H
#define GAMEPROBLEM_H

#include "BaseClasses/BaseProblem.h"
#include "BaseClasses/BaseState.h"
#include "BaseClasses/BaseNode.h"
#include "DataStructures/List.h"
#include "GameState.h"
#include "GameAction.h"



class GameProblem: public BaseProblem<GameState>
{
public:
    GameProblem(GameState* initState, GameState* goalState):BaseProblem<GameState>(initState, goalState){}


    List<BaseAction<GameState>*> GetActions(const GameState* state)const;
    GameState* Result(const GameState* state, const BaseAction<GameState>* action);
    QString GetStateName(const GameState* state);

    static int ManhattanDistance(const BaseNode<GameState>& node)
    {
        return 1;
    }
};

#endif // GAMEPROBLEM_H
