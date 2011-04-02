#ifndef HASHSET_H
#define HASHSET_H

#include <QSet>
#include "BaseQueue.h"

template<class T>
    class HashSet
    {
    private:
        QSet<T> mSet;
    public:

        const void Remove(const T& item);
        void Add(const T& item);
        bool Contains(const T& item);
        bool IsEmpty() const;

    };

template<class T>
    const void HashSet<T>::Remove(const T& item)
    {
        mSet.remove(item);
    }

template<class T>
    void HashSet<T>::Add(const T& item)
    {
        mSet.insert(item);
    }

template<class T>
    bool HashSet<T>::IsEmpty() const
    {
        return mSet.empty();
    }

template<class T>
    bool HashSet<T>::Contains(const T &item)
    {
        return mSet.contains(item);
    }


#endif // HASHSET_H
