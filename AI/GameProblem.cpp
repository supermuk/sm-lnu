#include "GameProblem.h"



List<BaseAction<GameState>*> GameProblem::GetActions(const GameState *state) const
{
    List<BaseAction<GameState>*> list;
    Position pos = state->GetEmptyPosition();
    int size = state->GetSize();

    if(pos.Column != 0)
    {
        list.Add(new GameAction(GameAction::Left));
    }

    if(pos.Column != size - 1)
    {
        list.Add(new GameAction(GameAction::Right));
    }

    if(pos.Row != 0)
    {
        list.Add(new GameAction(GameAction::Up));
    }

    if(pos.Row != size - 1)
    {
        list.Add(new GameAction(GameAction::Down));
    }

    return list;
}
GameState* GameProblem::Result(const GameState* state, const BaseAction<GameState>* action)
{
    return action->Do(state);
}
