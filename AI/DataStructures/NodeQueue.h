#ifndef NODEQUEUE_H
#define NODEQUEUE_H

#include "BaseQueue.h"
#include "BaseClasses/BaseNode.h"
#include "DataStructures/FifoQueue.h"
#include "DataStructures/LifoQueue.h"
#include "DataStructures/PriorityQueue.h"
#include "StateTable.h"

/**
  \brief Node containter.
  */
template<class TState>
    class NodeQueue: public BaseQueue<const BaseNode<TState>* >
    {
    protected:
        /**
          Container for states pointers.
          */
        StateTable<TState> mStates;
        /**
          Nodes queue. \see FifoQueue LifoQueue PriorityQueue
          */
        BaseQueue<const BaseNode<TState>* >* mNodes;

    public:
        /**
          Keeps max queue size.
          */
        int MaxCount;

        NodeQueue(QueueType queue);
        /**
          Destructor. Deletes all nodes and free memory.
          */
        ~NodeQueue();

        /**
          Addes node to queue and its state to StateTable
          */
        void Add(const BaseNode<TState>* node, int priority);
        /**
          Remove node from queue.
          \return node
          */
        const BaseNode<TState>* Pop();
        /**
          Inserts node with lower priority to queue.
          */
        void Update(const BaseNode<TState>* node, int priority);

        /**
          \return true - if queue is empty.
          */
        bool IsEmpty() const;
        /**
          \return count of items in queue.
          */
        int Count() const;

        /**
          Checks if node with specified state exists in queue. \see StateTable::Contain
          */
        bool Contains(const TState* state);

    };

template<class TState>
    NodeQueue<TState>::NodeQueue(QueueType queue)
    {
        MaxCount = 0;

        switch(queue)
        {
        case Fifo:
            mNodes = new FifoQueue<const BaseNode<TState>*>();
            break;
        case Lifo:
            mNodes = new LifoQueue<const BaseNode<TState>*>();
            break;
        case Priority:
            mNodes = new PriorityQueue<const BaseNode<TState>*>();
            break;
        }
    }

template<class TState>
    NodeQueue<TState>::~NodeQueue()
    {
        while(!mNodes->IsEmpty())
        {
            const BaseNode<TState>* node = mNodes->Pop();
            delete node;
        }
        delete mNodes;
    }

template<class TState>
    void NodeQueue<TState>::Add(const BaseNode<TState>* node, int priority)
    {
        mNodes->Add(node, priority);
        mStates.Add(node->GetState());

        int count = mNodes->Count();

        if(count > MaxCount)
        {
            MaxCount =count;
        }
    }

template<class TState>
    const BaseNode<TState>* NodeQueue<TState>::Pop()
    {
        const BaseNode<TState>* item = mNodes->Pop();
        mStates.Remove(item->GetState());

        return item;
    }

template<class TState>
    void NodeQueue<TState>::Update(const BaseNode<TState> *node, int priority)
    {
        mNodes->Update(node, priority);

        int count = mNodes->Count();

        if(count > MaxCount)
        {
            MaxCount = count;
        }
    }

template<class TState>
    bool NodeQueue<TState>::Contains(const TState *state)
    {
        return mStates.Contains(state);
    }

template<class TState>
    bool NodeQueue<TState>::IsEmpty()const
    {
        return mNodes->IsEmpty();
    }

template<class TState>
    int NodeQueue<TState>::Count() const
    {
        return mNodes->Count();
    }

#endif // NodeQueue_H
