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

    QTableWidget *mTable;
    GameState *mState;

    void FillTable();
public:
    GameWidget(int size, QWidget *parent = 0);
    GameState* GetState();

    char static ToInt(char c);
    char static ToChar(char i);

signals:

public slots:
    void SetGame(QString stateName);
    void Move();
    void CreateGame(int size);
};

#endif // GAMEWIDGET_H
