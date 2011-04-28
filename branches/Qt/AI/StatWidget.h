#ifndef STATWIDGET_H
#define STATWIDGET_H

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
#include <QCheckBox>

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

class StatWidget : public QWidget
{
    Q_OBJECT
private:
    QPushButton *mGoButton;
    QSpinBox *mSizeSpinBox;
    QTableWidget *mTable;
    QTextEdit *mStatLineEdit;
    QCheckBox *mBFS;
    QCheckBox *mDFS;
    QCheckBox *mUCS;
    QCheckBox *mASM;
    QCheckBox *mASH;

    QCheckBox *mLen;
    QCheckBox *mMem;
    QCheckBox *mExp;
    QCheckBox *mTime;

    QMap<Algos, int> mCounter;

public:
    explicit StatWidget(QWidget *parent = 0);

    void AddSolution(Algos algo, Solution<GameState> solution);

};
#endif // STATWIDGET_H
