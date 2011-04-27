#ifndef ASTARSEARCH_H
#define ASTARSEARCH_H

#include "BaseSearch.h"
#include "DataStructures/PriorityQueue.h"

template<class TState>
    class AStarSearch: public BaseSearch<TState>
    {
    private:
        int (*mHeuristicFuncPtr)(const BaseNode<TState>* );

    protected:
        int F(const BaseNode<TState>* node)
        {
            return node->GetPathCost() + (*mHeuristicFuncPtr)(node);
        }

    public:
        AStarSearch(BaseProblem<TState>* problem, int (* heuristicFuncPtr)(const BaseNode<TState>*))
            :BaseSearch<TState>(problem)
        {
            mHeuristicFuncPtr = heuristicFuncPtr;
            this->mFrontier = new NodeQueue<TState>(Priority);
        }
    };

#endif // ASTARSEARCH_H