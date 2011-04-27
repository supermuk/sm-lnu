#ifndef WIDGET_H
#define WIDGET_H

#include <QWidget>
#include <QPushButton>
#include <QTreeWidget>
#include <QHBoxLayout>
#include <QVBoxLayout>
#include <QAction>
#include <QSpinBox>
#include <QComboBox>
#include <QTextEdit>
#include <QTime>
#include <QListWidget>

#include <algorithm>
#include "Search.h"
#include "GameProblem.h"
#include "GameWidget.h"
#include "SearchAlgos/BaseSearch.h"
#include "SearchAlgos/BreadthFirstSearch.h"
#include "SearchAlgos/DepthFirstSearch.h"
#include "SearchAlgos/UniformCostSearch.h"
#include "SearchAlgos/AStarSearch.h"
#include "Solution.h"

class Widget : public QWidget
{
    Q_OBJECT
private:
    int SolutionMaxLength;
    QPushButton *mGoButton;
    QPushButton *mRandomButton;
    QListWidget *mList;
    GameWidget *mGameWidget;
    QSpinBox *mSizeSpinBox;
    QComboBox *mAlgoComboBox;
    QTextEdit *mStatLineEdit;

public:
    explicit Widget(QWidget *parent = 0);

signals:

public slots:
    void Go();
    void Random();
    void ShowSolution(Solution<GameState> solution);

};

#endif // WIDGET_H
