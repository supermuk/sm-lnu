#ifndef UNIFORMCOSTSEARCH_H
#define UNIFORMCOSTSEARCH_H

#include "BaseSearch.h"
#include "DataStructures/PriorityQueue.h"

template<class TState>
    class UniformCostSearch: public BaseSearch<TState>
    {
    protected:
        int F(const BaseNode<TState>* node)
        {
            return node->GetPathCost();
        }
    public:
        UniformCostSearch(BaseProblem<TState>* problem)
            :BaseSearch<TState>(problem)
        {
            this->mFrontier = new NodeQueue<TState>(Priority);
        }
    };

#endif // UNIFORMCOSTSEARCH_H
