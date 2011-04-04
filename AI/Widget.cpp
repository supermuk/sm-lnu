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

    Search s;

    connect(&s, SIGNAL(NodeAdded(QString,QString,int)), this, SLOT(AddNode(QString,QString,int)));

    GameState *init = mGameWidget->GetState();

    GameState *goal= new GameState(mSizeSpinBox->value());

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

void Widget::Random()
{
    QList<char> items;

    int size = mSizeSpinBox->value();

    for(int i = 1; i < size * size; ++i)
    {
        items.push_back(i > 9 ? i + 55 : i + 48);
    }
    items.push_back(0);

    QString stateName;

    while(!items.empty())
    {
        int r = qrand();
        stateName.append(items.takeAt(r % items.count()));
    }

    mGameWidget->SetGame(stateName);
}
