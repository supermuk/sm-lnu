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
        BaseNode(const BaseNode<TState>* parent, const TState* state, int pathCost);

        const TState* GetState();
        int GetPathCost();

        BaseNode<TState> ChildNode(BaseProblem<TState>* problem, BaseAction<TState>* action);

    };

template<class TState>
    BaseNode<TState>::BaseNode(const BaseNode<TState>* parent, const TState* state, int pathCost):mState(state)
    {
        mParent = parent;
        //mState = state;
        mPathCost = pathCost;
    }

template<class TState>
    const TState* BaseNode<TState>::GetState()
    {
        return mState;
    }

template<class TState>
    BaseNode<TState> BaseNode<TState>::ChildNode(BaseProblem<TState>* problem, BaseAction<TState>* action)
    {
        return BaseNode(this, problem->Result(mState, action), mPathCost + problem->StepCost(mState, action));
    }

template<class TState>
    int BaseNode<TState>::GetPathCost()
    {
        return mPathCost;
    }

#endif // BASENODE_H
