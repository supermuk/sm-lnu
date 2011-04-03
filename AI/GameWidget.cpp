#include "GameWidget.h"

GameWidget::GameWidget(int size, QWidget *parent) :
    QWidget(parent)
{

    setFixedSize(WIDGET_SIZE, WIDGET_SIZE);

    mSize = size;
    CreateGame(size);

    table->horizontalHeader()->setVisible(false);
    table->verticalHeader()->setVisible(false);

    table->setEditTriggers(QAbstractItemView::NoEditTriggers);
}

void GameWidget::CreateGame(int size)
{
    table = new QTableWidget(this);
    table->setFixedSize(WIDGET_SIZE, WIDGET_SIZE);

    table->setRowCount(size);
    table->setColumnCount(size);

    int cellSize = WIDGET_SIZE / size;

    for(int i = 0; i < size; ++i)
    {
        table->setRowHeight(i, cellSize);
        table->setColumnWidth(i, cellSize);
    }
}

void GameWidget::SetGame(QTreeWidgetItem* item, int column)
{
    QString game = item->text(0);

    mSize = sqrt(game.length());
    CreateGame(mSize);
QTableWidgetItem *cell;
    for(int i = 0; i < mSize; ++i)
    {
        for(int j = 0; j < mSize; ++j)
        {
            cell = new QTableWidgetItem();
            QString s;
            s.append(game[i + mSize * j]);
            cell->setText(game);
            table->setItem(i, j, cell);
            //table->itemAt(i, j)->setText(s);
        }
    }
}
