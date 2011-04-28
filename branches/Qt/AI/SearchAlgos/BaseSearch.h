#ifndef BASESEARCH_H
#define BASESEARCH_H

#include "Solution.h"
#include "BaseClasses/BaseProblem.h"
#include "DataStructures/NodeQueue.h"
#include "DataStructures/StateTable.h"
#include "QTime"

enum Algos
{
    BFS = 0,
    DFS = 1,
    UCS = 2,
    AStarManhattan = 3,
    AStarHemming = 4
};

/**
  \brief Base class for all search algorithms.
  */
template<class TState>
    class BaseSearch
    {
    protected:
        /**
          Pointer to problem.
          */
        BaseProblem<TState> *mProblem;
        /**
          Container for frontier nodes.
          */
        NodeQueue<TState> *mFrontier;
        /**
          Container for explored nodes.
          */
        NodeQueue<TState> *mExplored;
        /**
          Virtual function that is used for informed search algorimths.
          \return path cost.
          */
        int virtual F(const BaseNode<TState>* node) = 0;

        /**
          Gets full information about solution. \see Solution
          */
        Solution<TState> GetSolution(const BaseNode<TState>* node);
        /**
          Gets information about failure. \see Solution
          */
        Solution<TState> GetFailure();
        /**
          Common part of all search algrorithms.
          */
        Solution<TState> SearchRun();
    public:
        /**
          Constructor with parameter. Takes pointer to problem.
          */
        BaseSearch(BaseProblem<TState>* problem);
        /**
          Desctructor. Delete all nodes in mFrontier and mExplored containters and free memory.
          */
        ~BaseSearch();

        /**
          Run search algorithm.
          \return solution or failure information. \see Solution.
          */
        Solution<TState> Run();

    };

template<class TState>
    BaseSearch<TState>::BaseSearch(BaseProblem<TState> *problem)
    {
        mProblem = problem;
        mExplored = new NodeQueue<TState>(Fifo);
    }

template<class TState>
    BaseSearch<TState>::~BaseSearch()
    {
        delete mFrontier;
        delete mExplored;
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

        int i = 0;

        while(node != NULL &&  i < s.MAX_SOLUTION_LENGTH)
        {
            s.States.append(*(node->GetState()));
            node = node->GetParent();
            i++;
        }

        s.SolutionLength = i;

        return s;
    }

template<class TState>
    Solution<TState> BaseSearch<TState>::GetFailure()
    {
        Solution<TState> s;
        s.IsFailure = true;
        s.SolutionLength = -1;
        return s;
    }

template<class TState>
    Solution<TState> BaseSearch<TState>::SearchRun()
    {
        const BaseNode<TState>* node = new BaseNode<TState>(NULL, new TState(mProblem->GetInitState()), 0);

        mFrontier->Add(node, F(node));

        while(!mFrontier->IsEmpty())
        {
            node = mFrontier->Pop();
            mExplored->Add(node, NULL);

            if(mProblem->IsGoalState(node->GetState()))
            {
                return GetSolution(node);
            }

            List<BaseAction<TState>*> actions = mProblem->GetActions(node->GetState());

            for(int i = 0; i < actions.Size(); ++i)
            {
                const BaseNode<TState>* child = node->ChildNode(mProblem, actions[i]);
                delete actions[i];

                bool frontierContains = mFrontier->Contains(child->GetState());

                if(!mExplored->Contains(child->GetState()) && !frontierContains)
                {
                    mFrontier->Add(child, F(child));

                    if(mProblem->IsGoalState(child->GetState()))
                    {
                        return GetSolution(child);
                    }
                }
                else if(frontierContains)
                {
                    mFrontier->Update(child, F(child));
                }
                else
                {
                    delete child;
                }
            }
        }

        return GetFailure();
    }

#endif // BASESEARCH_H
