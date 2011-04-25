#ifndef NODEPRIORITYQUEUE_H
#define NODEPRIORITYQUEUE_H

#include "BaseQueue.h"
#include "BaseClasses/BaseNode.h"
#include "BaseNodeQueue.h"

template<class TState>
    class NodePriorityQueue: public BaseNodeQueue<TState>
    {
    private:
        int mSize;
    public:
        void AddNode(const BaseNode<TState>* node, int priority);
        const BaseNode<TState> Pop();
        void Update(const BaseNode<TState>& node, int priority);
        int Find(const BaseNode<TState>& node, int priority);
        bool IsEmpty() const;
   };

template<class TState>
    void NodePriorityQueue<TState>::AddNode(const BaseNode<TState>* node, int priority)
    {
        mSize++;

        //int pos = Find(node);

        //this->mNodes.insert(pos, node);

        this->mNodes.insert(priority, node);
    }
/*
template<class TState>
    int NodePriorityQueue<TState>::Find(const BaseNode<TState> &node, int priority)
    {
        int start = 0;
        int end = this->mNodes.count();

        if(end == 0)
        {
            return 0;
        }

        while(end - start > 1)
        {
            int middle = (end + start) / 2;
            int cost = this->mNodes.at(middle).GetPathCost();
            if(cost < key)
            {
               end = middle;
            }
            else if(cost > key)
            {
               start = middle;
            }
            else
            {
               return middle;
            }
        }

        if(this->mNodes.at(start).GetPathCost() > key)
        {
            return start + 1;
        }

        return start;
    }
*/
template<class TState>
    void NodePriorityQueue<TState>::Update(const BaseNode<TState> &node, int priority)
    {
        //int pos = Find(node);
        //this->mNodes.insert(pos, node);

        this->mNodes.insert(priority, node);
    }

template<class TState>
    const BaseNode<TState> NodePriorityQueue<TState>::Pop()
    {
        mSize--;
        return this->BaseNodeQueue<TState>::Pop();
    }

template<class TState>
    bool NodePriorityQueue<TState>::IsEmpty() const
    {
        return mSize == 0;
    }

#endif // NODEPRIORITYQUEUE_H
