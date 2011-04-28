#ifndef ASTARSEARCH_H
#define ASTARSEARCH_H

#include "BaseSearch.h"
#include "DataStructures/PriorityQueue.h"

/**
  A* Search algorithm. Uses priority queue as frontier container.
  */
template<class TState>
    class AStarSearch: public BaseSearch<TState>
    {
    private:
        /**
          Pointer to function that specifies heuristic.
          */
        int (*mHeuristicFuncPtr)(const BaseNode<TState>* );

    protected:
        /**
          f(n) = g(n) + h(n).
          \return path cost from beginning to current node + heuristic value of path cost from node to end.
          */
        int F(const BaseNode<TState>* node)
        {
            return node->GetPathCost() + (*mHeuristicFuncPtr)(node);
        }

    public:
        /**
          Creates Priority queue as frontier container. Sets pointer to heuristic function.
          */
        AStarSearch(BaseProblem<TState>* problem, int (* heuristicFuncPtr)(const BaseNode<TState>*))
            :BaseSearch<TState>(problem)
        {
            mHeuristicFuncPtr = heuristicFuncPtr;
            this->mFrontier = new NodeQueue<TState>(Priority);
        }
    };

#endif // ASTARSEARCH_H
