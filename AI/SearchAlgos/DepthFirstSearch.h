#ifndef DEPTHFIRSTSEARCH_H
#define DEPTHFIRSTSEARCH_H

#include "BaseSearch.h"
#include "DataStructures/NodeQueue.h"

/**
  Depth First Search algorithm. Uses Lifo queue as frontier container.
  */
template<class TState>
    class DepthFirstSearch: public BaseSearch<TState>
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
          Creates Lifo queue as frontier container.
          */
        DepthFirstSearch(BaseProblem<TState>* problem)
            :BaseSearch<TState>(problem)
        {
            this->mFrontier = new NodeQueue<TState>(Lifo);
        }
    };

#endif // DEPTHFIRSTSEARCH_H
