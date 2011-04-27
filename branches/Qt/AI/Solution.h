#ifndef SOLUTION_H
#define SOLUTION_H

#include <QList>

template<class TState>
    struct Solution
    {
        const static int MAX_SOLUTION_LENGTH = 1000;

        bool IsFailure;
        QList<TState> States;
        int RunTime;
        int PathCost;
        int ExploredNodesCount;
        int MaxQueueSize;
        int SolutionLength;

    };

#endif // SOLUTION_H
