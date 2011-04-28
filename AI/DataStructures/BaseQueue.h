#ifndef BASEQUEUE_H
#define BASEQUEUE_H


/**
  \brief Queue Interface. Abstract class.
  */
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

enum QueueType
{
    Fifo,
    Lifo,
    Priority
};

#endif // BASEQUEUE_H
