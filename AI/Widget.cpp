#include "Widget.h"

Widget::Widget(QWidget *parent) :
    QWidget(parent)
{
    QHBoxLayout *hbox = new QHBoxLayout();

    button = new QPushButton("Go");
    hbox->addWidget(button);

    setLayout(hbox);

    connect(button, SIGNAL(clicked()), this, SLOT(Go()));
}

void Widget::Go()
{
    Search s;

    GameState *init = new GameState(3);

    GameState *goal= new GameState(3);
    init->Swap(Position(0,0), Position(0, 1));

    bool res = s.BreadthFirstSearch<GameState>(new GameProblem(init, goal));
    if(res)
    {
    button->setText("Yes");
    }else
    {
        button->setText("No");
    }
}
