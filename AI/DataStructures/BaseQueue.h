#ifndef BASEQUEUE_H
#define BASEQUEUE_H

template<class T>
    class BaseQueue
    {
    public:
        virtual const T Pop()=0;
        virtual void Add(const T& item, int priority) = 0;
        virtual bool IsEmpty() const = 0;
    };

#endif // BASEQUEUE_H
