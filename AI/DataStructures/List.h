#ifndef LIST_H
#define LIST_H

#include <QList>

/**
  \brief QList wrapper.
  */
template<class T>
    class List
    {
    private:
        QList<T> mList;
    public:
        void Add(const T& item);
        int Size();
        T& operator[] (int index);
        const T& operator[] (int index) const;
    };

template<class T>
    void List<T>::Add(const T &item)
    {
        mList.push_back(item);
    }

template<class T>
    int List<T>::Size()
    {
        return mList.size();
    }

template<class T>
    T& List<T>::operator[] (int index)
    {
        return mList[index];
    }

template<class T>
    const T& List<T>::operator[] (int index) const
    {
        return mList[index];
    }

#endif // LIST_H
