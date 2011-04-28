#ifndef BASESTATE_H
#define BASESTATE_H

/**
  \brief State Interface.
  */
class BaseState
{
public:
    virtual int GetHash() const = 0;
};

#endif // BASESTATE_H
