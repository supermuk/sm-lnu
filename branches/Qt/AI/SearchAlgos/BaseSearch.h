#ifndef BASESEARCH_H
#define BASESEARCH_H

#include "Solution.h"
#include "BaseClasses/BaseProblem.h"
#include "DataStructures/BaseNodeQueue.h"
#include "DataStructures/StateTable.h"
#include "QTime"

template<class TState>
    class BaseSearch
    {
    protected:
        BaseProblem<TState> *mProblem;
        BaseNodeQueue<TState> *mFrontier;
        StateTable<TState> *mExplored;

        int virtual F(const BaseNode<TState>& node) = 0;

        Solution<TState> GetSolution(const BaseNode<TState>* node);
        Solution<TState> GetFailure();
        Solution<TState> SearchRun();
    public:
        BaseSearch(BaseProblem<TState>* problem);

        Solution<TState> Run();

    };

template<class TState>
    BaseSearch<TState>::BaseSearch(BaseProblem<TState> *problem)
    {
        mProblem = problem;
        mExplored = new StateTable<TState>();
    }

template<class TState>
    Solution<TState> BaseSearch<TState>::Run()
    {
        QTime begin = QTime::currentTime();

        Solution<TState> s = SearchRun();

        QTime end = QTime::currentTime();

        s.RunTime = begin.msecsTo(end);
        s.ExploredNodesCount = mExplored->Count();
        s.MaxQueueSize = mFrontier->MaxCount;

        return s;
    }

template<class TState>
    Solution<TState> BaseSearch<TState>::GetSolution(const BaseNode<TState>* node)
    {
        Solution<TState> s;
        s.IsFailure = false;
        s.PathCost = node->GetPathCost();
        s.States.append(*(node->GetState()));

        const BaseNode<TState>* parent = node->GetParent();
        while(parent != NULL)
        {
            s.States.append(*parent->GetState());
            parent = parent->GetParent();

        }
        return s;
    }

template<class TState>
    Solution<TState> BaseSearch<TState>::GetFailure()
    {
        Solution<TState> s;
        s.IsFailure = true;
        return s;
    }

template<class TState>
    Solution<TState> BaseSearch<TState>::SearchRun()
    {
        const BaseNode<TState>* node = new BaseNode<TState>(NULL, mProblem->GetInitState(), 0);

        mFrontier->Add(node);

        while(!mFrontier->IsEmpty())
        {
            node = mFrontier->Pop();

            if(mProblem->IsGoalState(node->GetState()))
            {
                return GetSolution(node);
            }

            mExplored->Add(node->GetState());

            List<BaseAction<TState>*> actions = mProblem->GetActions(node->GetState());
            for(int i = 0; i < actions.Size(); ++i)
            {
                const BaseNode<TState>* child = node->ChildNode(mProblem, actions[i]);
                delete actions[i];

                bool frontierContains = mFrontier->Contains(child->GetState());

                if(!mExplored->Contains(child->GetState()) && !frontierContains)
                {
                    if(mProblem->IsGoalState(child->GetState()))
                    {
                        return GetSolution(child);
                    }
                    mFrontier->Add(child);
                }
                else if(frontierContains)
                {
                    mFrontier->Update(child);
                }
            }
        }

        return GetFailure();
    }
#endif // BASESEARCH_H
