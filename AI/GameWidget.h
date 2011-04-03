#ifndef GAMEWIDGET_H
#define GAMEWIDGET_H

#include <QWidget>
#include <QTableWidget>
#include <QHeaderView>
#include <QTreeWidgetItem>
#include <QString>
#include <qmath.h>

class GameWidget : public QWidget
{
    Q_OBJECT
private:
    const static int WIDGET_SIZE = 500;
    int mSize;
    QTableWidget *table;

    void CreateGame(int size);
public:
    explicit GameWidget(int size, QWidget *parent = 0);

signals:

public slots:
    void SetGame(QTreeWidgetItem* item, int column);

};

#endif // GAMEWIDGET_H
