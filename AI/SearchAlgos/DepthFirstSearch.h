#ifndef DEPTHFIRSTSEARCH_H
#define DEPTHFIRSTSEARCH_H

#include "BaseSearch.h"
#include "DataStructures/NodeQueue.h"

template<class TState>
    class DepthFirstSearch: public BaseSearch<TState>
    {
    protected:
        int F(const BaseNode<TState>* node)
        {
            return 0;
        }
    public:
        DepthFirstSearch(BaseProblem<TState>* problem)
            :BaseSearch<TState>(problem)
        {
            this->mFrontier = new NodeQueue<TState>(Fifo);
        }
    };

#endif // DEPTHFIRSTSEARCH_H
