#ifndef FIFOQUEUE_H
#define FIFOQUEUE_H

#include <QQueue>
#include "BaseQueue.h"

template<class T>
    class FifoQueue: public BaseQueue<T>
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
    void FifoQueue<T>::Add(T node, int priority)
    {
        mNodes.push_back(node);
    }

template<class T>
    T FifoQueue<T>::Pop()
    {
        T item = mNodes.last();
        mNodes.pop_back();
        return item;
    }

template<class T>
    void FifoQueue<T>::Update(T item, int priority)
    {

    }

template<class T>
    int FifoQueue<T>::Count() const
    {
        return mNodes.count();
    }

template<class T>
    bool FifoQueue<T>::IsEmpty() const
    {
        return mNodes.empty();
    }

#endif // FIFOQUEUE_H
