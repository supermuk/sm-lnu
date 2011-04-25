#ifndef BASENODEQUEUE_H
#define BASENODEQUEUE_H

#include <QQueue>
#include <QMultiHash>
#include "BaseQueue.h"
#include "BaseClasses/BaseNode.h"
#include "StateTable.h"
#include "QMultiMap"
#include "QMap"
//#include <map>
template<class TState>
    class BaseNodeQueue//: public BaseQueue<BaseNode<TState>* >
    {
    protected:
        StateTable<TState> mStates;
        //std::map<int, BaseNode<TState> > mNodes;
        QMultiMap<int, const BaseNode<TState>* > mNodes;
        //QQueue<BaseNode<TState> > mNodes;
    public:
        int MaxCount;
        BaseNodeQueue();

        const BaseNode<TState>* Pop();
        void Add(const BaseNode<TState>* node, int priority = 0);
        void virtual AddNode(const BaseNode<TState>* node, int priority) = 0;
        bool IsEmpty() const;
        bool Contains(const TState* state);
        void virtual Update(const BaseNode<TState>* node, int priority = 0);
    };

template<class TState>
    BaseNodeQueue<TState>::BaseNodeQueue()
    {
        MaxCount = 0;
    }
template<class TState>
    void BaseNodeQueue<TState>::Update(const BaseNode<TState>* node, int priority)
    {
    }

template<class TState>
    void BaseNodeQueue<TState>::Add(const BaseNode<TState>* node, int priority)
    {
        AddNode(node, priority);

        this->mStates.Add(node->GetState());
        if(mNodes.count() > MaxCount)
        {
            MaxCount = mNodes.count();
        }
    }

template<class TState>
    const BaseNode<TState>* BaseNodeQueue<TState>::Pop()
    {
        typename QMap<int,const BaseNode<TState>* >::iterator iter = mNodes.begin();

        const BaseNode<TState>* item = iter.value();
        mNodes.erase(iter);
        mStates.Remove(item->GetState());
        return item;
    }

template<class TState>
    bool BaseNodeQueue<TState>::Contains(const TState *state)
    {
        return mStates.Contains(state);
    }

template<class TState>
    bool BaseNodeQueue<TState>::IsEmpty()const
    {
        return mNodes.empty();
    }

#endif // BASENODEQUEUE_H
