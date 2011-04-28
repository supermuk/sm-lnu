#ifndef BREADTHFIRSTSEARCH_H
#define BREADTHFIRSTSEARCH_H

#include "BaseSearch.h"
#include "DataStructures/NodeQueue.h"

/**
  Breadth First Search algorithm. Uses Fifo queue as frontier container.
  */
template<class TState>
    class BreadthFirstSearch: public BaseSearch<TState>
    {
    protected:
        /**
          Is not used.
          \return Always 0
          */
        int F(const BaseNode<TState>* node)
        {
            return 0;
        }
    public:
        /**
          Creates Fifo queue as frontier container.
          */
        BreadthFirstSearch(BaseProblem<TState>* problem)
            :BaseSearch<TState>(problem)
        {
            this->mFrontier = new NodeQueue<TState>(Fifo);
        }
    };


#endif // BREADTHFIRSTSEARCH_H
