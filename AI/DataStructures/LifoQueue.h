#ifndef LIFOQUEUE_H
#define LIFOQUEUE_H

#include <QQueue>
#include "BaseQueue.h"

/**
  \brief LIFO (Last In, First Out) Queue. QQueue wrapper.
  */
template<class T>
    class LifoQueue: public BaseQueue<T>
    {
    private:
        QQueue<T> mNodes;
    public:
        /**
          Adds item to the beginning of queue.
          \param priority Not used.
          */
        void Add(T node, int priority);
        /**
          Remove last item in queue.
          \return last item.
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
    void LifoQueue<T>::Add(T node, int priority)
    {
        mNodes.push_back(node);
    }

template<class T>
    T LifoQueue<T>::Pop()
    {
        T item = mNodes.last();
        mNodes.pop_back();
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
