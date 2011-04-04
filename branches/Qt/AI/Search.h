#ifndef SEARCH_H
#define SEARCH_H

#include <QObject>
#include "BaseClasses/BaseProblem.h"
#include "BaseClasses/BaseNode.h"
#include "DataStructures/BaseQueue.h"
#include "DataStructures/HashSet.h"
#include "DataStructures/FifoQueue.h"
#include "DataStructures/PriorityQueue.h"

class Search: public QObject
{
    Q_OBJECT
public:
    Search():QObject() {}
    ~Search() {}

    template<class TState>
        bool BreadthFirstSearch(BaseProblem<TState>* problem);

    template<class TState>
        bool UniformCostSearch(BaseProblem<TState>* problem);

signals:
    void NodeAdded(QString parentStateName, QString stateName, int pathCost);
};


template<class TState>
    bool Search::BreadthFirstSearch(BaseProblem<TState> *problem)
    {
        BaseNode<TState> node (NULL, problem->GetInitState(), 0);

        if(problem->IsGoalState(node.GetState()))
        {
            return true;
        }

        BaseQueue<BaseNode<TState> > *frontierNodes = new FifoQueue<BaseNode<TState> >();
        frontierNodes->Add(node);
        HashSet<const TState*> *frontierStates = new HashSet<const TState*>();
        frontierStates->Add(node.GetState());
        HashSet<const TState*> *exploredStates = new HashSet<const TState*>();

        emit NodeAdded(QString(), problem->GetStateName(node.GetState()), node.GetPathCost());

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
                delete actions[i];
                if(!exploredStates->Contains(child.GetState()) && !frontierStates->Contains(child.GetState()))
                {
                    emit NodeAdded(problem->GetStateName(child.GetParent()->GetState()), problem->GetStateName(child.GetState()), child.GetPathCost());

                    if(problem->IsGoalState(child.GetState()))
                    {
                        return true;
                    }

                    frontierStates->Add(child.GetState());
                    frontierNodes->Add(child);

                }
            }

        }

        return false;
    }

template<class TState>
    bool Search::UniformCostSearch(BaseProblem<TState> *problem)
    {
        BaseNode<TState> node(NULL, problem->GetInitState(), 0);

        PriorityQueue<BaseNode<TState> > *frontierNodes = new PriorityQueue<BaseNode<TState> > ();
        frontierNodes->Add(node, node.GetPathCost());

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

            if(problem->IsGoalState(node.GetState()))
            {
                return true;
            }

            exploredStates->Add(node.GetState());

            List<BaseAction<TState>*> actions = problem->GetActions(node.GetState());
            for(int i = 0; i < actions.Size(); ++i)
            {
                BaseNode<TState> child = node.ChildNode(problem, actions[i]);
                delete actions[i];
                if(!exploredStates->Contains(child.GetState()) && !frontierStates->Contains(child.GetState()))
                {
                    emit NodeAdded(problem->GetStateName(child.GetParent()->GetState()), problem->GetStateName(child.GetState()), child.GetPathCost());

                    if(problem->IsGoalState(child.GetState()))
                    {
                        return true;
                    }

                    frontierStates->Add(child.GetState());
                    frontierNodes->Add(child);

                }
            }

        }
        return false;
    }



#endif // SEARCH_H
