#ifndef BASENODE_H
#define BASENODE_H

#include "BaseState.h"
#include "BaseProblem.h"

template<class TState>
    class BaseNode
    {
    private:
        const BaseNode<TState> *mParent;
        const TState *mState;
        int mPathCost;

    public:
        BaseNode(const BaseNode<TState>& node);
        BaseNode(const BaseNode<TState>* parent, const TState* state, int pathCost);

        ~BaseNode();

        const TState* GetState() const;
        int GetPathCost() const;
        const BaseNode<TState>* GetParent() const;

        const BaseNode<TState>* ChildNode(BaseProblem<TState>* problem, BaseAction<TState>* action) const;

        BaseNode<TState>& operator=(const BaseNode& node);
        const BaseNode<TState>& operator=(const BaseNode& node) const;

    };

template<class TState>
    BaseNode<TState>::BaseNode(const BaseNode<TState> &node)
    {
        mPathCost = node.mPathCost;
        mState = node.mState;
        mParent = node.mParent;
    }
template<class TState>
    BaseNode<TState>& BaseNode<TState>::operator=( const BaseNode<TState> &node)
    {
        mPathCost = node.mPathCost;
        mState = node.mState;
        mParent = node.mParent;
        return *this;
    }

template<class TState>
    const BaseNode<TState>& BaseNode<TState>::operator=( const BaseNode<TState> &node) const
    {
        mPathCost = node.mPathCost;
        mState = node.mState;
        mParent = node.mParent;
        return *this;
    }

template<class TState>
        BaseNode<TState>::~BaseNode()
        {

        }

template<class TState>
    BaseNode<TState>::BaseNode(const BaseNode<TState>* parent, const TState* state, int pathCost)
    {
        mParent = parent;
        mState = state;
        mPathCost = pathCost;
    }

template<class TState>
    const TState* BaseNode<TState>::GetState() const
    {
        return mState;
    }

template<class TState>
    const BaseNode<TState>* BaseNode<TState>::GetParent() const
    {
        return mParent;
    }

template<class TState>
    const BaseNode<TState>* BaseNode<TState>::ChildNode(BaseProblem<TState>* problem, BaseAction<TState>* action)const
    {
        return new BaseNode(this, problem->Result(mState, action), mPathCost + problem->StepCost(mState, action));
    }

template<class TState>
    int BaseNode<TState>::GetPathCost() const
    {
        return mPathCost;
    }

#endif // BASENODE_H
