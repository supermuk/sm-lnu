#include "GameState.h"

GameState::GameState(int size)
{
    mSize = size;

    mField = new int*[mSize];

    for(int i = 0; i < mSize; ++i)
    {
        mField[i] = new int[mSize];

        for(int j = 0; j < mSize; ++j)
        {
            mField[i][j] = i * mSize + j + 1;
        }
    }
    mField[mSize-1][mSize-1] = 0;
}

GameState::GameState(const GameState &state)
{
    mSize = state.mSize;

    mField = new int*[mSize];

    for(int i = 0; i < mSize; ++i)
    {
        mField[i] = new int[mSize];

        for(int j = 0; j < mSize; ++j)
        {
            mField[i][j] = state.mField[i][j];
        }
    }
}

bool GameState::operator ==(const GameState& state)const
{
    if(mSize != state.mSize)
    {
        return false;
    }

    for(int i = 0; i < mSize; ++i)
    {
        for(int j = 0; j < mSize; j++)
        {
            if(mField[i][j] != state.mField[i][j])
            {
                return false;
            }
        }
    }
    return true;
}

Position GameState::GetEmptyPosition() const
{
    for(int i = 0; i < mSize; ++i)
    {
        for(int j = 0; j < mSize; j++)
        {
            if(mField[i][j] == 0)
            {
                return Position(i, j);
            }
        }
    }
    throw "No empty cell";
}

int GameState::GetSize() const
{
    return mSize;
}

void GameState::Swap(Position p1, Position p2)
{
    int tmp = mField[p1.Row][p1.Column];
    mField[p1.Row][p1.Column] = mField[p2.Row][p2.Column];
    mField[p2.Row][p2.Column] = tmp;
}
