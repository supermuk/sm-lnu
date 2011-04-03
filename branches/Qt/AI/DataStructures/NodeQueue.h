#ifndef NODEQUEUE_H
#define NODEQUEUE_H

#include <QQueue>
#include "BaseQueue.h"

class NodeQueue: public BaseQueue
{
private:
    QQueue<T> mQueue;
public:
    NodeQueue();

    const BaseNode Pop();
    void Add(const T& item);
    bool IsEmpty() const;
};

#endif // NODEQUEUE_H
