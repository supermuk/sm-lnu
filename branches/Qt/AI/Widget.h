#ifndef WIDGET_H
#define WIDGET_H

#include <QWidget>
#include <QPushButton>
#include <QTreeWidget>
#include <QHBoxLayout>
#include <QVBoxLayout>
#include <QAction>
#include <QSpinBox>
#include <algorithm>
#include "Search.h"
#include "GameProblem.h"
#include "GameWidget.h"

class Widget : public QWidget
{
    Q_OBJECT
private:
    QPushButton *mGoButton;
    QPushButton *mRandomButton;
    QTreeWidget *mTree;
    GameWidget *mGameWidget;
    QSpinBox *mSizeSpinBox;
public:
    explicit Widget(QWidget *parent = 0);

signals:

public slots:
    void Go();
    void Random();
    void AddNode(QString parentName,QString name,int cost);

};

#endif // WIDGET_H
