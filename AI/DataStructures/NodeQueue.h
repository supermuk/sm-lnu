#ifndef NODEQUEUE_H
#define NODEQUEUE_H

#include <QQueue>
#include <QMultiHash>
#include "BaseQueue.h"
#include "BaseClasses/BaseNode.h"
#include "StateTable.h"
#include "BaseNodeQueue.h"

template<class TState>
    class NodeQueue: public BaseNodeQueue<TState>
    {
    public:
        void AddNode(const BaseNode<TState>* node, int priority);
    };

template<class TState>
    void NodeQueue<TState>::AddNode(const BaseNode<TState>* node, int priority)
    {
        this->mNodes.insertMulti(priority, node);
    }



#endif // NODEQUEUE_H
