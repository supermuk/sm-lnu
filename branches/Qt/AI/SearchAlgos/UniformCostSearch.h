#ifndef UNIFORMCOSTSEARCH_H
#define UNIFORMCOSTSEARCH_H

#include "BaseSearch.h"
#include "DataStructures/NodePriorityQueue.h"

template<class TState>
    class UniformCostSearch: public BaseSearch<TState>
    {
    protected:
        int F(const BaseNode<TState> &node)
        {
            return node.GetPathCost();
        }
    public:
        UniformCostSearch(BaseProblem<TState>* problem)
            :BaseSearch<TState>(problem)
        {
            this->mFrontier = new NodePriorityQueue<TState>();
        }
    };

#endif // UNIFORMCOSTSEARCH_H
