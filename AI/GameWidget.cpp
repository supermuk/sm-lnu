#include "GameWidget.h"

GameWidget::GameWidget(int size, QWidget *parent) :
    QWidget(parent)
{
    mState = NULL;

    setFixedSize(WIDGET_SIZE, WIDGET_SIZE);

    mSize = size;

    table = new QTableWidget(this);
    CreateGame(size);

    table->horizontalHeader()->setVisible(false);
    table->verticalHeader()->setVisible(false);

    table->setEditTriggers(QAbstractItemView::NoEditTriggers);

    connect(table, SIGNAL(itemSelectionChanged()), this, SLOT(Move()));
}

void GameWidget::CreateGame(int size)
{
    mSize = size;

    if(mState != NULL)
    {
        delete mState;
    }

    mState = new GameState(size);

    table->setFixedSize(WIDGET_SIZE * 1.1 , WIDGET_SIZE * 1.1 );
    table->setRowCount(size);
    table->setColumnCount(size);
    table->setSelectionMode(QAbstractItemView::SingleSelection);

    int cellSize = WIDGET_SIZE / size;

    for(int i = 0; i < size; ++i)
    {
        table->setRowHeight(i, cellSize);
        table->setColumnWidth(i, cellSize);
    }

    FillTable();
}

void GameWidget::SetGame(QTreeWidgetItem* item, QTreeWidgetItem*)
{
    QString stateName = item->text(0);

    SetGame(stateName);
}

void GameWidget::SetGame(QString stateName)
{
    mSize = sqrt((float)stateName.length());

    CreateGame(mSize);

    for(int i = 0; i < mSize; ++i)
    {
        for(int j = 0; j < mSize; ++j)
        {
            char val = stateName[i + mSize * j].toAscii();
            if(val == ' ')
            {
                val = 0;
            }
            else
            {
                val = val > 64 ? val - 55 : val - 48;
            }

            mState->SetItem(i, j, val);
        }
    }

    FillTable();
}

void GameWidget::FillTable()
{
    for(int i = 0; i < mSize; ++i)
    {
        for(int j = 0; j < mSize; ++j)
        {
            QTableWidgetItem *cell = new QTableWidgetItem();

            char val = mState->GetItem(i, j);
            if(val == 0)
            {
                val = ' ';
            }
            else
            {
                val = val > 9 ? val + 55 : val + 48;
            }

            cell->setText(QString(val));
            cell->setTextAlignment(Qt::AlignCenter);
            table->setItem(i, j, cell);
        }
    }
}

void GameWidget::Move()
{
    int row = table->selectedItems().first()->row();
    int column = table->selectedItems().first()->column();
    Position p = mState->GetEmptyPosition();
    int expr = (row - p.Row)*(row - p.Row) + (column - p.Column)*(column - p.Column);

    if(expr == 1)
    {
        mState->Swap(p, Position(row, column));
        FillTable();
    }
}

GameState* GameWidget::GetState()
{
    return mState;
}
