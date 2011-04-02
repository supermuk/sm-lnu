#ifndef POSITION_H
#define POSITION_H

struct Position
{
public:
    int Row;
    int Column;

    Position(int row, int column)
    {
        Row = row;
        Column = column;
    }
};

#endif // POSITION_H
