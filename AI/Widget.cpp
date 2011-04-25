#include "Widget.h"

Widget::Widget(QWidget *parent) :
    QWidget(parent)
{
    QHBoxLayout *hbox = new QHBoxLayout();

    mTree = new QTreeWidget();

    mTree->setColumnCount(2);
    mTree->setColumnWidth(0, 200);

    hbox->addWidget(mTree);

    QVBoxLayout *vbox = new QVBoxLayout();

    mGameWidget = new GameWidget(2);
    vbox->addWidget(mGameWidget);

    QHBoxLayout *hboxBottom = new QHBoxLayout();

    mAlgoComboBox = new QComboBox();
    mAlgoComboBox->addItem("BFS");
    mAlgoComboBox->addItem("UCS");
    hboxBottom->addWidget(mAlgoComboBox);

    mGoButton = new QPushButton("Go");
    hboxBottom->addWidget(mGoButton);

    mRandomButton = new QPushButton("Random");
    hboxBottom->addWidget(mRandomButton);

    mSizeSpinBox = new QSpinBox();
    mSizeSpinBox->setMaximum(5);
    mSizeSpinBox->setMinimum(2);
    hboxBottom->addWidget(mSizeSpinBox);

    vbox->addLayout(hboxBottom);
    hbox->addLayout(vbox);

    mStatLineEdit = new QTextEdit();

    hbox->addWidget(mStatLineEdit);

    setLayout(hbox);

    connect(mGoButton, SIGNAL(clicked()), this, SLOT(Go()));
    connect(mRandomButton, SIGNAL(clicked()), this, SLOT(Random()));
    connect(mTree, SIGNAL(currentItemChanged(QTreeWidgetItem*,QTreeWidgetItem*)), mGameWidget, SLOT(SetGame(QTreeWidgetItem*,QTreeWidgetItem*)));
    connect(mSizeSpinBox, SIGNAL(valueChanged(int)), mGameWidget, SLOT(CreateGame(int)));
}

void Widget::Go()
{
    while(mTree->topLevelItemCount() != 0)
    {
        delete mTree->takeTopLevelItem(0);
    }

    QString algo = mAlgoComboBox->currentText();

    BaseSearch<GameState>* s;
    //connect(&s, SIGNAL(NodeAdded(QString,QString,int)), this, SLOT(AddNode(QString,QString,int)));

    GameState *init = mGameWidget->GetState();
    GameState *goal= new GameState(mSizeSpinBox->value());

    BaseProblem<GameState> *problem = new GameProblem(init, goal);

    if(algo == QString("BFS"))
    {
         s = new BreadthFirstSearch<GameState>(problem);
    }
    else if( algo == QString("UCS"))
    {
        s = new UniformCostSearch<GameState>(problem);
    }
    else if(algo == QString("A*Manhattan"))
    {
        s = new AStarSearch<GameState>(problem, &GameProblem::ManhattanDistance);
    }

    Solution<GameState> result = s->Run();
    ShowSolution(result);
}

void Widget::AddNode(QString parentName, QString name, int cost)
{
    QStringList list;

    list << name << QString::number(cost);

    if(parentName == QString())
    {
        mTree->addTopLevelItem(new QTreeWidgetItem(list));
    }
    else
    {
        mTree->findItems(parentName, Qt::MatchExactly | Qt::MatchRecursive).first()->addChild(new QTreeWidgetItem(list));
    }
}

void Widget::Random()
{
    QList<char> items;

    int size = mSizeSpinBox->value();

    for(int i = 1; i < size * size; ++i)
    {
        items.push_back(i > 9 ? i + 55 : i + 48);
    }
    items.push_back(' ');

    QString stateName;

    while(!items.empty())
    {
        stateName.append(items.takeAt(qrand() % items.count()));
    }

    mGameWidget->SetGame(stateName);
}

void Widget::ShowSolution(Solution<GameState> solution)
{


    mStatLineEdit->insertPlainText("\r\nAlgo = " + mAlgoComboBox->currentText() + "\r\n");
    mStatLineEdit->insertPlainText("Time = " + QString::number(solution.RunTime) + "ms\r\n");
    mStatLineEdit->insertPlainText("Max node queue size = " + QString::number(solution.MaxQueueSize) + "\r\n");
    mStatLineEdit->insertPlainText("Explored queue size = " + QString::number(solution.ExploredNodesCount) + "\r\n");

    if(solution.IsFailure)
    {
        mStatLineEdit->insertPlainText("No Solution\r\n");
    }
    else
    {
        for(int i = 0; i < solution.States.count(); ++i)
        {
            GameState state = solution.States.at(i);
            AddNode(QString(), QString::number(state.GetHash()), i);
        }
    }

/*
    QTreeWidgetItem *item = mTree->findItems(node.GetState()->GetStateName(),  Qt::MatchExactly | Qt::MatchRecursive).first();

    while( item->parent() != NULL)
    {
        item->setExpanded(true);
        item = item->parent();
    }
    item->setExpanded(true);
*/
}
