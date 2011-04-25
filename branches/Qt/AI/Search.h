#ifndef SEARCH_H
#define SEARCH_H

#include <QObject>
#include "BaseClasses/BaseProblem.h"
#include "BaseClasses/BaseNode.h"
#include "DataStructures/BaseQueue.h"
#include "DataStructures/StateTable.h"
#include "DataStructures/FifoQueue.h"
#include "DataStructures/NodeQueue.h"
#include "DataStructures/BaseNodeQueue.h"
#include "DataStructures/NodePriorityQueue.h"
#include "DataStructures/NodeQueue.h"

template<class TState>
    class Search
    {

    public:
        BaseNodeQueue<TState> *frontier;
        StateTable<TState> *explored;

        Search();
        ~Search();

        BaseNode<TState> BreadthFirstSearch(BaseProblem<TState>* problem);

        BaseNode<TState> UniformCostSearch(BaseProblem<TState> *problem);
    };

template<class TState>
    Search<TState>::Search()
    {
        frontier = new NodeQueue<TState>();
        explored = new StateTable<TState>();
    }

template<class TState>
    Search<TState>::~Search()
    {
        delete frontier;
    }

template<class TState>
    BaseNode<TState> Search<TState>::BreadthFirstSearch(BaseProblem<TState> *problem)
    {
        BaseNode<TState> node (NULL, problem->GetInitState(), 0);

        if(problem->IsGoalState(node.GetState()))
        {
            return node;
        }

        frontier->Add(node);

        while(!frontier->IsEmpty())
        {
            node = frontier->Pop();

            explored->Add(node.GetState());

            List<BaseAction<TState>*> actions = problem->GetActions(node.GetState());
            for(int i = 0; i < actions.Size(); ++i)
            {
                BaseNode<TState> child = node.ChildNode(problem, actions[i]);
                delete actions[i];

                if(!explored->Contains(child.GetState()) && !frontier->Contains(child.GetState()))
                {
                    if(problem->IsGoalState(child.GetState()))
                    {
                        return child;
                    }

                    frontier->Add(child);
                }
                else
                {
                    delete child.GetState();
                }
            }

        }

        return BaseNode<TState>(NULL, NULL, -1);
    }

template<class TState>
    BaseNode<TState> Search<TState>::UniformCostSearch(BaseProblem<TState> *problem)
    {
        BaseNode<TState> node(NULL, problem->GetInitState(), 0);

        frontier = new NodePriorityQueue<TState>();
        frontier->Add(node);

        while(!frontier->IsEmpty())
        {
            node = frontier->Pop();

            if(problem->IsGoalState(node.GetState()))
            {
                return node;
            }

            explored->Add(node.GetState());

            List<BaseAction<TState>*> actions = problem->GetActions(node.GetState());
            for(int i = 0; i < actions.Size(); ++i)
            {
                BaseNode<TState> child = node.ChildNode(problem, actions[i]);
                delete actions[i];

                bool frontierContains = frontier->Contains(child.GetState());

                if(!explored->Contains(child.GetState()) && !frontierContains)
                {
                    if(problem->IsGoalState(child.GetState()))
                    {
                        return child;
                    }
                    frontier->Add(child);
                }
                else if(frontierContains)
                {
                    frontier->Update(child);
                }
            }
        }
        return BaseNode<TState>(NULL, NULL, -1);
    }

#endif // SEARCH_H
