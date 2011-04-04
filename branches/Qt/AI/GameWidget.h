#ifndef GAMEWIDGET_H
#define GAMEWIDGET_H

#include <QWidget>
#include <QTableWidget>
#include <QHeaderView>
#include <QTreeWidgetItem>
#include <QString>
#include <qmath.h>
#include "GameState.h"

class GameWidget : public QWidget
{
    Q_OBJECT
private:
    const static int WIDGET_SIZE = 500;
    int mSize;
    QTableWidget *table;
    GameState *mState;


    void FillTable();
public:
    GameWidget(int size, QWidget *parent = 0);
    void SetGame(QString stateName);
    GameState* GetState();
signals:

public slots:
    void SetGame(QTreeWidgetItem* item, QTreeWidgetItem*);
    void Move();
    void CreateGame(int size);
};

#endif // GAMEWIDGET_H
