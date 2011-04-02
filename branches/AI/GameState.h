#ifndef GAMESTATE_H
#define GAMESTATE_H

#include "BaseClasses/BaseState.h"
#include "Position.h"

class GameState : public BaseState
{
private:
    int ** mField;
    int mSize;
public:
    GameState(int size);
    GameState(const GameState& state);

    Position GetEmptyPosition() const;
    int GetSize()const;
    void Swap(Position p1, Position p2);

    bool operator == (const GameState& state) const;

};

#endif // GAMESTATE_H
