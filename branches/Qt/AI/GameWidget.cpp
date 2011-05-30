#include "GameWidget.h"

GameWidget::GameWidget(int size, QWidget *parent) :
    QWidget(parent)
{
    mState = NULL;

    setFixedSize(WIDGET_SIZE, WIDGET_SIZE);

    mTable = new QTableWidget(this);
    CreateGame(size);

    mTable->horizontalHeader()->setVisible(false);
    mTable->verticalHeader()->setVisible(false);
    mTable->setFixedSize(WIDGET_SIZE * 1.1 , WIDGET_SIZE * 1.1 );
    mTable->setEditTriggers(QAbstractItemView::NoEditTriggers);
    mTable->setSelectionMode(QAbstractItemView::SingleSelection);
    mTable->setFont(QFont("Arial", 20, 4));
    connect(mTable, SIGNAL(itemSelectionChanged()), this, SLOT(Move()));
}

void GameWidget::CreateGame(int size)
{
    if(mState != NULL)
    {
        delete mState;
    }
    mState = new GameState(size);

    mTable->setRowCount(size);
    mTable->setColumnCount(size);

    int cellSize = WIDGET_SIZE / size;

    for(int i = 0; i < size; ++i)
    {
        mTable->setRowHeight(i, cellSize);
        mTable->setColumnWidth(i, cellSize);
    }

    FillTable();
}


void GameWidget::SetGame(QString stateName)
{
    CreateGame(sqrt((float)stateName.length()));

    for(int i = 0; i < mState->GetSize(); ++i)
    {
        for(int j = 0; j < mState->GetSize(); ++j)
        {
            mState->SetItem(i, j, ToInt(stateName[j + mState->GetSize() * i].toAscii()));
        }
    }

    FillTable();
}

void GameWidget::FillTable()
{
    for(int i = 0; i < mState->GetSize(); ++i)
    {
        for(int j = 0; j < mState->GetSize(); ++j)
        {
            QTableWidgetItem *cell = new QTableWidgetItem();
            cell->setText(QString(ToChar(mState->GetItem(i, j))));
            cell->setTextAlignment(Qt::AlignCenter);
            mTable->setItem(i, j, cell);
        }
    }
}

char GameWidget::ToChar(char i)
{
    if(i == 0)
    {
        return ' ';
    }
    return i > 9 ? i + 55 : i + 48;
}

char GameWidget::ToInt(char c)
{
    if(c == ' ')
    {
        return 0;
    }
    return c > 64 ? c - 55 : c - 48;
}

void GameWidget::Move()
{
    int row = mTable->selectedItems().first()->row();
    int column = mTable->selectedItems().first()->column();

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
