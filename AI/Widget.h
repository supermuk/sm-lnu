#ifndef WIDGET_H
#define WIDGET_H

#include <QWidget>
#include <QPushButton>
#include <QHBoxLayout>
#include "Search.h"
#include "GameProblem.h"

class Widget : public QWidget
{
    Q_OBJECT
private:
    QPushButton *button;
public:
    explicit Widget(QWidget *parent = 0);

signals:

public slots:
    void Go();

};

#endif // WIDGET_H
