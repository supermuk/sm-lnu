#ifndef PRIORITYQUEUE_H
#define PRIORITYQUEUE_H

#include <QMultiMap>
#include "BaseQueue.h"

template<class T>
    class PriorityQueue: public BaseQueue<T>
    {
    private:
        int mUniqueCount;
        QMultiMap<int, T> mNodes;
    public:
        void Add(T node, int priority);
        T Pop();
        void Update(T item, int priority);
        bool IsEmpty() const;
        int Count() const;

    };

template<class T>
    void PriorityQueue<T>::Add(T node, int priority)
    {
        mUniqueCount++;

        mNodes.insertMulti(priority, node);
    }

template<class T>
    T PriorityQueue<T>::Pop()
    {
        mUniqueCount--;

        typename QMap<int, T>::iterator iter = mNodes.begin();

        T item = iter.value();
        mNodes.erase(iter);

        return item;
    }

template<class T>
    void PriorityQueue<T>::Update(T item, int priority)
    {
        mNodes.insertMulti(priority, item);
    }

template<class T>
    int PriorityQueue<T>::Count() const
    {
        return mNodes.count();//mUniqueCount;
    }

template<class T>
    bool PriorityQueue<T>::IsEmpty() const
    {
        return mNodes.empty();//mUniqueCount == 0;
    }

#endif // PRIORITYQUEUE_H
