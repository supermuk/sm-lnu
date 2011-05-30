#ifndef STATETABLE_H
#define STATETABLE_H

#include <iterator>
#include <QHash>
#include <QMultiHash>

/**
  States pointers container. Quickly get state by its hash code.
  */
template<class TState>
    class StateTable
    {
    private:
        /**
          Key - hash code, value - state pointer.
          */
        QMultiHash<int, const TState*> mHash;
    public:
        void Remove(const TState* item);
        void Add(const TState* item);
        bool Contains(const TState* item);
        bool IsEmpty() const;
        int Count()const;

        ~StateTable();
    };

template<class TState>
    void StateTable<TState>::Remove(const TState* item)
    {
        int key = item->GetHash();
        //mHash.remove(key, item);

        typename QHash<int, const TState*>::iterator iter = mHash.find(key, item);

        while (iter != mHash.end() && !(*iter.value() == *item))
        {
            ++iter;
        }

        mHash.erase(iter);

    }

template<class TState>
    void StateTable<TState>::Add(const TState* item)
    {
        mHash.insertMulti(item->GetHash(), item);
    }

template<class TState>
    bool StateTable<TState>::IsEmpty() const
    {
        return mHash.empty();
    }

template<class TState>
    bool StateTable<TState>::Contains(const TState* item)
    {
        QList<const TState*> list = mHash.values(item->GetHash());

        for(int i = 0; i < list.count(); ++i)
        {
            if(*list.at(i) == *item)
            {
                return true;
            }
        }
        return false;
    }

template<class TState>
    int StateTable<TState>::Count()const
    {
        return mHash.count();
    }

template<class TState>
    StateTable<TState>::~StateTable()
    {

    }

#endif // STATETABLE_H
