#ifndef SOLUTION_H
#define SOLUTION_H

#include <QList>

template<class TState>
    struct Solution
    {
        bool IsFailure;
        QList<TState> States;
        int RunTime;
        int PathCost;
        int ExploredNodesCount;
        int MaxQueueSize;
    };

#endif // SOLUTION_H
