#ifndef UNIFORMCOSTSEARCH_H
#define UNIFORMCOSTSEARCH_H

#include "BaseSearch.h"
#include "DataStructures/PriorityQueue.h"

/**
  Uniform Cost Search algorithm. Uses Priority queue as frontier container.
  */
template<class TState>
    class UniformCostSearch: public BaseSearch<TState>
    {
    protected:
        /**
          f(n) = h(n).
          \return path cost from beginning to current node.
          */
        int F(const BaseNode<TState>* node)
        {
            return node->GetPathCost();
        }
    public:
        /**
          Creates Priority queue as frontier container.
          */
        UniformCostSearch(BaseProblem<TState>* problem)
            :BaseSearch<TState>(problem)
        {
            this->mFrontier = new NodeQueue<TState>(Priority);
        }
    };

#endif // UNIFORMCOSTSEARCH_H
