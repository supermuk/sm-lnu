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

#include <algorithm>
#include "Search.h"
#include "GameProblem.h"
#include "GameWidget.h"
#include "SearchAlgos/BaseSearch.h"
#include "SearchAlgos/BreadthFirstSearch.h"
#include "SearchAlgos/UniformCostSearch.h"
#include "SearchAlgos/AStarSearch.h"
#include "Solution.h"

class Widget : public QWidget
{
    Q_OBJECT
private:
    QPushButton *mGoButton;
    QPushButton *mRandomButton;
    QTreeWidget *mTree;
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
    void AddNode(QString parentName,QString name,int cost);
    void ShowSolution(Solution<GameState> solution);

};

#endif // WIDGET_H
