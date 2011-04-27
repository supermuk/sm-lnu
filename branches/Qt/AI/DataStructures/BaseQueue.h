#ifndef BASEQUEUE_H
#define BASEQUEUE_H

enum QueueType
{
    Fifo,
    Lifo,
    Priority
};

template<class T>
    class BaseQueue
    {
    public:
        virtual void Add(T item, int priority) = 0;
        virtual T Pop()=0;
        virtual void Update(T item, int priority) = 0;
        virtual bool IsEmpty() const = 0;
        virtual int Count() const = 0;
    };

#endif // BASEQUEUE_H
