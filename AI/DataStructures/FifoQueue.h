#ifndef FIFIOQUEUE_H
#define FIFIOQUEUE_H

#include "BaseQueue.h"
#include <QQueue>

template<class T>
    class FifoQueue: public BaseQueue<T>
    {
    private:
        QQueue<T> mQueue;
    public:
        FifoQueue();

        const T Pop();
        void Add(const T& item);
        bool IsEmpty() const;
    };

template<class T>
    FifoQueue<T>::FifoQueue()
    {

    }

template<class T>
    const T FifoQueue<T>::Pop()
    {
        T item = mQueue.last();

        mQueue.pop_back();

        return item;
    }

template<class T>
    void FifoQueue<T>::Add(const T& item)
    {
        mQueue.push_front(item);
    }

template<class T>
    bool FifoQueue<T>::IsEmpty() const
    {
        return mQueue.empty();
    }


#endif // FIFIOQUEUE_H
