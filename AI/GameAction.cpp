#include "GameAction.h"

GameAction::GameAction(Direction direction)
{
    mDirtection = direction;
}

GameState* GameAction::Do(const GameState* state) const
{
    Position pos = state->GetEmptyPosition();
    GameState* newState = new GameState(*state);

    switch(mDirtection)
    {
    case Up:
        newState->Swap(pos, Position(pos.Row - 1, pos.Column));
        break;
    case Down:
        newState->Swap(pos, Position(pos.Row + 1, pos.Column));
        break;
    case Left:
        newState->Swap(pos, Position(pos.Row, pos.Column - 1));
        break;
    case Right:
        newState->Swap(pos, Position(pos.Row, pos.Column + 1));
        break;
    }

    return newState;
}
