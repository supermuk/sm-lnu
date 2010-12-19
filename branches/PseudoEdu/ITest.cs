using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PseudoEdu
{
    public interface ITest
    {
        string GetName();
        string GetUrl();
        void SetBaseUrl(string url);
        Control GetControl();
        bool CheckAnswer();
        string GetAnswer();
        string GetCorrectAnswer();
        int GetPoints();
    }
}
