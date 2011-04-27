#include "Widget.h"

Widget::Widget(QWidget *parent) : QWidget(parent)
{
    SolutionMaxLength = 1000;

    QHBoxLayout *hbox = new QHBoxLayout();

    mList = new QListWidget();

    hbox->addWidget(mList);

    QVBoxLayout *vbox = new QVBoxLayout();

    mGameWidget = new GameWidget(2);
    vbox->addWidget(mGameWidget);

    QHBoxLayout *hboxBottom = new QHBoxLayout();

    mAlgoComboBox = new QComboBox();
    mAlgoComboBox->addItem("BFS");
    mAlgoComboBox->addItem("DFS");
    mAlgoComboBox->addItem("UCS");
    mAlgoComboBox->addItem("A* Manhattan");
    mAlgoComboBox->addItem( "A* Hamming");

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
    connect(mList, SIGNAL(currentTextChanged(QString)), mGameWidget, SLOT(SetGame(QString)));
    connect(mSizeSpinBox, SIGNAL(valueChanged(int)), mGameWidget, SLOT(CreateGame(int)));
}

void Widget::Go()
{
    BaseSearch<GameState>* s;

    GameState *init = mGameWidget->GetState();
    GameState *goal= new GameState(mSizeSpinBox->value());

    BaseProblem<GameState> *problem = new GameProblem(init, goal);

    switch(mAlgoComboBox->currentIndex())
    {
    case 0:
         s = new BreadthFirstSearch<GameState>(problem);
        break;
    case 1:
         s = new DepthFirstSearch<GameState>(problem);
        break;
    case 2:
        s = new UniformCostSearch<GameState>(problem);
        break;
    case 3:
        s = new AStarSearch<GameState>(problem, &GameProblem::ManhattanDistance);
        break;
    case 4:
        s = new AStarSearch<GameState>(problem, &GameProblem::HammingDistance);
        break;
    }

    Solution<GameState> result = s->Run();
    ShowSolution(result);
}

void Widget::Random()
{
    QList<char> items;

    int size = mSizeSpinBox->value();

    for(int i = 0; i < size * size; ++i)
    {
        items.push_back(GameWidget::ToChar(i));
    }

    QString stateName;

    while(!items.empty())
    {
        stateName.append(items.takeAt(qrand() % items.count()));
    }

    mGameWidget->SetGame(stateName);
}

void Widget::ShowSolution(Solution<GameState> solution)
{
    mList->clear();

    QString log;
    log += "\r\nAlgo = " + mAlgoComboBox->currentText() + "\r\n";
    log +="Time = " + QString::number(solution.RunTime) + "ms\r\n";
    log += "Max node queue size = " + QString::number(solution.MaxQueueSize) + "\r\n";
    log += "Explored queue size = " + QString::number(solution.ExploredNodesCount) + "\r\n";

    if(solution.IsFailure)
    {
        mList->addItem("No Solution");
        log += "There is no Solution\r\n";
    }
    else
    {
        for(int i = 0; i < solution.States.count(); ++i)
        {
            GameState state = solution.States.at(i);
            mList->addItem(state.GetStateName());
        }
        if(solution.SolutionLength >= solution.MAX_SOLUTION_LENGTH)
        {
            mList->addItem("Solution contains more then " + QString::number(solution.MAX_SOLUTION_LENGTH) + " states.");
            log += "Solution length > " + QString::number(solution.SolutionLength) + "\r\n";
        }
        else
        {
            log += "Solution length = " + QString::number(solution.SolutionLength) + "\r\n";
        }
    }

    mStatLineEdit->setText(log + mStatLineEdit->toPlainText());
}
