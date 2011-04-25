#include "GameState.h"

GameState::GameState(int size)
{
    mSize = size;

    mField = new char*[mSize];

    for(int i = 0; i < mSize; ++i)
    {
        mField[i] = new char[mSize];

        for(int j = 0; j < mSize; ++j)
        {
            char c = i * mSize + j + 1;

            mField[i][j] = c;// c > 9 ? c + 55 : c + 48;
        }
    }
    mField[mSize-1][mSize-1] = 0;                   //' ';
}

GameState::GameState(const GameState &state)
{
    mSize = state.mSize;

    mField = new char*[mSize];

    for(int i = 0; i < mSize; ++i)
    {
        mField[i] = new char[mSize];

        for(int j = 0; j < mSize; ++j)
        {
            mField[i][j] = state.mField[i][j];
        }
    }
}

GameState::~GameState()
{
    for(int i = 0; i < mSize; ++i)
    {
        delete[] mField[i];
    }

    delete[] mField;
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

QString GameState::GetStateName() const
{
    QString s;

    for(int i = 0; i < mSize; ++i)
    {
        for(int j = 0; j < mSize; j++)
        {
            char c = mField[i][j] ;
            if(c == 0)
            {
                c= ' ';
            }
            else
            {
                c = c > 9 ? c + 55 : c + 48;
            }
            s.append(c);
        }
    }
    return s;
}

void GameState::Swap(Position p1, Position p2)
{
    int tmp = mField[p1.Row][p1.Column];
    mField[p1.Row][p1.Column] = mField[p2.Row][p2.Column];
    mField[p2.Row][p2.Column] = tmp;
}

void GameState::SetItem(int x, int y, char value)
{
    mField[x][y] = value;
}

char GameState::GetItem(int x, int y)const
{
    return mField[x][y];
}

int GameState::GetHash()const
{
    int hash = 0;
    int tmp = 1;
    for(int i = 0; i < mSize; ++i)
    {
        for(int j = 0; j < mSize; j++)
        {
            hash += (mField[i][j] + 1) * tmp;
            tmp*= 10;
        }
    }
    return hash;
}