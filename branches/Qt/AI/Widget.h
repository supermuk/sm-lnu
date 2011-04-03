#ifndef WIDGET_H
#define WIDGET_H

#include <QWidget>
#include <QPushButton>
#include <QTreeWidget>
#include <QHBoxLayout>
#include <QVBoxLayout>
#include <QAction>
#include "Search.h"
#include "GameProblem.h"
#include "GameWidget.h"

class Widget : public QWidget
{
    Q_OBJECT
private:
    QPushButton *mGoButton;
    QTreeWidget *mTree;
    GameWidget *mGameWidget;
public:
    explicit Widget(QWidget *parent = 0);

signals:

public slots:
    void Go();
    void AddNode(QString parentName,QString name,int cost);

};

#endif // WIDGET_H
