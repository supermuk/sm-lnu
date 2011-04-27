#ifndef BASEPROBLEM_H
#define BASEPROBLEM_H

#include "BaseClasses/BaseAction.h"
#include "DataStructures/BaseQueue.h"
#include "DataStructures/StateTable.h"
//#include "DataStructures/FifoQueue.h"
#include "DataStructures/List.h"

template<class TState>
    class BaseProblem
    {
    private:
        TState* mInitState;
        TState* mGoalState;
    public:
        BaseProblem(TState* initState, TState* goalState);

        TState* GetInitState();
        bool IsGoalState(const TState* state)const;

        int StepCost(const TState* state, const BaseAction<TState>* action) const;
        virtual List<BaseAction<TState>*> GetActions(const TState* state) const = 0;
        virtual TState* Result(const TState* state, const BaseAction<TState>* action) = 0;
        virtual QString GetStateName(const TState* state) = 0;
    };

template<class TState>
    BaseProblem<TState>::BaseProblem(TState* initState, TState* goalState)
    {
        mInitState = initState;
        mGoalState = goalState;
    }


template<class TState>
    TState* BaseProblem<TState>::GetInitState()
    {
        return mInitState;
    }

template<class TState>
    bool BaseProblem<TState>::IsGoalState(const TState* state)const
    {
        return (*state) == (*mGoalState);
    }

template<class TState>
    int BaseProblem<TState>::StepCost(const TState *state, const BaseAction<TState> *action) const
    {
        return 1;
    }



#endif // BASEPROBLEM_H
