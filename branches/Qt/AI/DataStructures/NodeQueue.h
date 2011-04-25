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
        void Add(const BaseNode<TState>& node, int priority = 0);
    };

template<class TState>
    void NodeQueue<TState>::Add(const BaseNode<TState>& node, int priority)
    {
        this->mNodes.insertMulti(priority, node);

        this->BaseNodeQueue<TState>::Add(node);
    }



#endif // NODEQUEUE_H
