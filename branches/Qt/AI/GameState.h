#ifndef GAMESTATE_H
#define GAMESTATE_H

#include "BaseClasses/BaseState.h"
#include <QString>
#include "Position.h"

class GameState : public BaseState
{
private:
    char** mField;
    int mSize;
public:
    GameState(int size);
    GameState(const GameState& state);

    ~GameState();

    Position GetEmptyPosition() const;
    int GetSize()const;
    QString GetStateName() const;
    void Swap(Position p1, Position p2);


    bool operator == (const GameState& state) const;

};

#endif // GAMESTATE_H