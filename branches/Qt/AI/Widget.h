#ifndef WIDGET_H
#define WIDGET_H

#include <QWidget>
#include <QPushButton>
#include <QTreeWidget>
#include <QHBoxLayout>
#include <QAction>
#include "Search.h"
#include "GameProblem.h"

class Widget : public QWidget
{
    Q_OBJECT
private:
    QPushButton *button;
    QTreeWidget *tree;
public:
    explicit Widget(QWidget *parent = 0);

signals:

public slots:
    void Go();
    void AddNode(const BaseNode<GameState>& node);

};

#endif // WIDGET_H
