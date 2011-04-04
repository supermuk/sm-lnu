#ifndef PRIORITYQUEUE_H
#define PRIORITYQUEUE_H

#include <QMultiMap>

template<class T>
    class PriorityQueue
    {
    private:
        QMultiMap<int, T> mMap;
    public:
        void Add(const T& item, int price);
        const T& Pop();
        bool IsEmpty() const;
        void Replace(const T& item, int price);

    };

template<class T>
    void PriorityQueue<T>::Add(const T &item, int price)
    {
        mMap.insert(price, item);
    }

template<class T>
    const T& PriorityQueue<T>::Pop()
    {
        int key = mMap.keys().last();
        const T value = mMap.values(key).last();

        mMap.remove(key, value);

        return value;
    }

template<class T>
    bool PriorityQueue<T>::IsEmpty() const
    {
        return mMap.isEmpty();
    }

template<class T>
    void PriorityQueue<T>::Replace(const T &item, int price)
    {
        //return mMap.replace()= ;
    }
#endif // PRIORITYQUEUE_H
