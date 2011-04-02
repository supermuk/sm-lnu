#ifndef GAMEACTION_H
#define GAMEACTION_H

#include "BaseClasses/BaseAction.h"
#include "GameState.h"


class GameAction: public BaseAction<GameState>
{
public:
    enum Direction
    {
        Up,
        Down,
        Left,
        Right
    };

private:
    Direction mDirtection;

public:
    GameAction(Direction direction);

    GameState* Do(const GameState* state) const;

};

#endif // GAMEACTION_H
