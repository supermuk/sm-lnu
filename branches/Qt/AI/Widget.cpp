#include "Widget.h"

Widget::Widget(QWidget *parent) :
    QWidget(parent)
{
    QHBoxLayout *hbox = new QHBoxLayout();



    mTree = new QTreeWidget();
    //mTree->setFixedWidth(200);
    mTree->setColumnCount(2);
    hbox->addWidget(mTree);


    QVBoxLayout *vbox = new QVBoxLayout();

    mGameWidget = new GameWidget(4);
    vbox->addWidget(mGameWidget);

    mGoButton = new QPushButton("Go");
    vbox->addWidget(mGoButton);

    hbox->addLayout(vbox);

    setLayout(hbox);

    connect(mGoButton, SIGNAL(clicked()), this, SLOT(Go()));
    connect(mTree, SIGNAL(itemActivated(QTreeWidgetItem*,int)), mGameWidget, SLOT(SetGame(QTreeWidgetItem*,int)));
}

void Widget::Go()
{
    Search s;

    connect(&s, SIGNAL(NodeAdded(QString,QString,int)), this, SLOT(AddNode(QString,QString,int)));

    GameState *init = new GameState(4);

    GameState *goal= new GameState(4);
    //init->Swap(Position(0,0), Position(0, 1));
    init->Swap(Position(3,3), Position(2, 3));
    init->Swap(Position(2,3), Position(2, 2));


    bool res = s.BreadthFirstSearch<GameState>(new GameProblem(init, goal));
    if(res)
    {
        mGoButton->setText("Yes");
    }else
    {
        mGoButton->setText("No");
    }
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
