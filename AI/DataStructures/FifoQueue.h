#ifndef FIFOQUEUE_H
#define FIFOQUEUE_H

#include <QQueue>
#include "BaseQueue.h"

/**
  \brief FIFO (First In, First Out) Queue. QQueue wrapper.
  */
template<class T>
    class FifoQueue: public BaseQueue<T>
    {
    private:
        QQueue<T> mNodes;
    public:
        /**
          Adds item to the end of queue.
          \param priority Not used.
          */
        void Add(T node, int priority);
        /**
          Remove first item in queue.
          \return first item.
          */
        T Pop();
        /**
          Ignored.
          */
        void Update(T item, int priority);
        /**
          \return true - if queue is empty.
          */
        bool IsEmpty() const;
        /**
          \return count of items in queue.
          */
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
        T item = mNodes.first();
        mNodes.pop_front();
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
