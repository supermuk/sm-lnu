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

QString GameProblem::GetStateName(const GameState *state)
{
    return state->GetStateName();
}

int GameProblem::ManhattanDistance(const BaseNode<GameState> *node)
{
    const GameState* state = node->GetState();
    int n = state->GetSize();
    int d = 0;
    for(int i = 0; i < n; ++i)
    {
        for(int j = 0; j < n; ++j)
        {
            char c = state->GetItem(i, j);
            if(c == 0)
            {
                d += 2*n - 2 - i - j;
            }
            else
            {
                int x = (c - 1) / n;
                int y = (c - 1) % n;
                d += qAbs(i - x) + qAbs(j - y);
            }
        }
    }
    return d;

}


int GameProblem::HammingDistance(const BaseNode<GameState> *node)
{
    const GameState* state = node->GetState();
    int n = state->GetSize();
    int d = 0;
    for(int i = 0; i < n; ++i)
    {
        for(int j = 0; j < n; ++j)
        {
            char c = state->GetItem(i, j);

            if(c == 0)
            {
                if( i != n - 1 || j != n -1)
                {
                    d += 1;
                }
            }
            else
            {
                if(c != n*i + j + 1)
                {
                    d += 1;
                }
            }
        }
    }

    return d;
}
