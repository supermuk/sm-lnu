#include "StatWidget.h"

StatWidget::StatWidget( QWidget *parent) : QWidget(parent)
{
    QVBoxLayout* vbox = new QVBoxLayout();

    QHBoxLayout* hbox = new QHBoxLayout();

    mBFS = new QCheckBox("BFS");
    mDFS = new QCheckBox("DFS");
    mUCS = new QCheckBox("UCS");
    mASM = new QCheckBox("A* Manhattan");
    mASH = new QCheckBox("A* Hemming");

    hbox->addWidget(mBFS);
    hbox->addWidget(mDFS);
    hbox->addWidget(mUCS);
    hbox->addWidget(mASM);
    hbox->addWidget(mASH);

    vbox->addLayout(hbox);

    mTable =  new QTableWidget();

    mTable->setColumnCount(4 * 5);
    mTable->setRowCount(20);


    QStringList list;
    list << "BFS " << "Memory" << "Explored" << "Time"
         << "DFS " << "Memory" << "Explored" << "Time"
         << "UCS " << "Memory" << "Explored" << "Time"
         << "A*M " << "Memory" << "Explored" << "Time"
         << "A*H " << "Memory" << "Explored" << "Time";
         //<< "DFS" << "UCS" << "A* Manhattan" << "A* Hemming";
    mTable->setHorizontalHeaderLabels(list);

    for(int i = 0; i < 4 * 5; i++)
    {
        mTable->setColumnWidth(i, 50);
    }

    vbox->addWidget(mTable);

    mCounter.insert(BFS, 0);
    mCounter.insert(DFS, 0);
    mCounter.insert(UCS, 0);
    mCounter.insert(AStarManhattan, 0);
    mCounter.insert(AStarHemming, 0);

    setLayout(vbox);
}

void StatWidget::AddSolution(Algos algo, Solution<GameState> solution)
{
    int row = mCounter[algo]++;

    QTableWidgetItem *cell = new QTableWidgetItem();
    cell->setText(QString::number(solution.SolutionLength));
    cell->setData(Qt::BackgroundRole, QColor(250, 210, 150));
    mTable->setItem(row, algo * 4, cell);

    cell = new QTableWidgetItem();
    cell->setText(QString::number(solution.MaxQueueSize));
    cell->setData(Qt::BackgroundRole, QColor(180, 250, 150));
    mTable->setItem(row, algo * 4 + 1, cell);

    cell = new QTableWidgetItem();
    cell->setText(QString::number(solution.ExploredNodesCount));
    cell->setData(Qt::BackgroundRole, QColor(150, 210, 250));
    mTable->setItem(row,  algo * 4 + 2, cell);

    cell = new QTableWidgetItem();
    cell->setText(QString::number(solution.RunTime));
    cell->setData(Qt::BackgroundRole, QColor(250, 150, 180));
    mTable->setItem(row, algo * 4 + 3, cell);
}
