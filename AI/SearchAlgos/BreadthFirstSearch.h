#ifndef BREADTHFIRSTSEARCH_H
#define BREADTHFIRSTSEARCH_H

#include "BaseSearch.h"
#include "DataStructures/NodeQueue.h"

template<class TState>
    class BreadthFirstSearch: public BaseSearch<TState>
    {
    protected:
        int F(const BaseNode<TState> &node)
        {
            return 0;
        }
    public:
        BreadthFirstSearch(BaseProblem<TState>* problem)
            :BaseSearch<TState>(problem)
        {
            this->mFrontier = new NodeQueue<TState>();
        }
    };


#endif // BREADTHFIRSTSEARCH_H
