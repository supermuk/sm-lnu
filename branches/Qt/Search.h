#ifndef SEARCH_H
#define SEARCH_H

#include "BaseClasses/BaseProblem.h"
#include "BaseClasses/BaseNode.h"
#include "DataStructures/BaseQueue.h"
#include "DataStructures/HashSet.h"
#include "DataStructures/FifoQueue.h"

class Search
{
public:
    template<class TState>
        bool BreadthFirstSearch(BaseProblem<TState>* problem);

};


template<class TState>
    bool Search::BreadthFirstSearch(BaseProblem<TState> *problem)
    {
        BaseNode<TState> node (0, problem->GetInitState(), 0);

        if(problem->IsGoalState(node.GetState()))
        {
            return true;
        }

        BaseQueue<BaseNode<TState> > *frontierNodes = new FifoQueue<BaseNode<TState> >();
        frontierNodes->Add(node);
        HashSet<const TState*> *frontierStates = new HashSet<const TState*>();
        frontierStates->Add(node.GetState());
        HashSet<const TState*> *exploredStates = new HashSet<const TState*>();

        while(true)
        {
            if(frontierNodes->IsEmpty())
            {
                return false;
            }

            node = frontierNodes->Pop();
            frontierStates->Remove(node.GetState());

            exploredStates->Add(node.GetState());

            List<BaseAction<TState>*> actions = problem->GetActions(node.GetState());
            for(int i = 0; i < actions.Size(); ++i)
            {
                BaseNode<TState> child = node.ChildNode(problem, actions[i]);

                if(!exploredStates->Contains(child.GetState()) && !frontierStates->Contains(child.GetState()))
                {
                    if(problem->IsGoalState(child.GetState()))
                    {
                        return true;
                    }

                    exploredStates->Add(child.GetState());
                }
            }

        }

        return false;
    }


#endif // SEARCH_H
