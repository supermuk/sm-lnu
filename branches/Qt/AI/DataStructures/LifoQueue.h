#ifndef LIFOQUEUE_H
#define LIFOQUEUE_H

#include <QQueue>
#include "BaseQueue.h"

template<class T>
    class LifoQueue: public BaseQueue<T>
    {
    private:
        QQueue<T> mNodes;
    public:
        void Add(T node, int priority);
        T Pop();
        void Update(T item, int priority);
        bool IsEmpty() const;
        int Count() const;

    };

template<class T>
    void LifoQueue<T>::Add(T node, int priority)
    {
        mNodes.push_back(node);
    }

template<class T>
    T LifoQueue<T>::Pop()
    {
        T item = mNodes.first();
        mNodes.pop_front();
        return item;
    }

template<class T>
    void LifoQueue<T>::Update(T item, int priority)
    {

    }

template<class T>
    int LifoQueue<T>::Count() const
    {
        return mNodes.count();
    }

template<class T>
    bool LifoQueue<T>::IsEmpty() const
    {
        return mNodes.empty();
    }

#endif // LIFOQUEUE_H
