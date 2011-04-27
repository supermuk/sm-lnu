#ifndef BASEACTION_H
#define BASEACTION_H

#include "BaseClasses/BaseState.h"

template<class TState>
    class BaseAction
    {
    public:
        virtual TState* Do(const TState* state) const = 0;
    };

#endif // BASEACTION_H
