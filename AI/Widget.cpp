#include "Widget.h"

Widget::Widget(QWidget *parent) :
    QWidget(parent)
{
    QHBoxLayout *hbox = new QHBoxLayout();

    button = new QPushButton("Go");
    hbox->addWidget(button);

    tree = new QTreeWidget();
    QStringList list;

    list << "test" << "bob" << "lol";

    tree->setColumnCount(3);
    tree->addTopLevelItem(new QTreeWidgetItem(list));
    tree->topLevelItem(0)->addChild(new QTreeWidgetItem(list));


    //tree->setModel();
    //QAction *action = new QAction(QString("test"), tree);
    //tree->addAction(action);
    hbox->addWidget(tree);

    setLayout(hbox);

    connect(button, SIGNAL(clicked()), this, SLOT(Go()));
}

void Widget::Go()
{
    Search s;

    GameState *init = new GameState(4);

    GameState *goal= new GameState(4);
   // init->Swap(Position(0,0), Position(0, 1));
    init->Swap(Position(3,3), Position(2, 3));
    init->Swap(Position(2,3), Position(2, 2));


    bool res = s.BreadthFirstSearch<GameState>(new GameProblem(init, goal));
    if(res)
    {
    button->setText("Yes");
    }else
    {
        button->setText("No");
    }
}

void Widget::AddNode(const BaseNode<GameState>& node)
{
    QString parentName =  node.GetParent()->GetState()->GetStateName();

    QStringList list;
    list << node.GetState()->GetStateName() << QString(node.GetPathCost()) << ":D";

    tree->findItems(parentName, Qt::MatchExactly).first()->addChild(new QTreeWidgetItem(list));

}
