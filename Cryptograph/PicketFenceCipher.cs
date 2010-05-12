using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cryptograph
{
    class PicketFenceCipher:BaseCipher
    {

        public int Key
        {
            set
            {
                ((NumericUpDown)KeyBox.Controls["PicketFenceCipherKey"]).Value = value;
            }
            get
            {
                return (int)((NumericUpDown)KeyBox.Controls["PicketFenceCipherKey"]).Value;
            }
        }

        public override void Initialize()
        {
            KeyBox.Controls.Clear();
            NumericUpDown key = new NumericUpDown();
            key.Name = "PicketFenceCipherKey";
            key.Minimum = -100;
            key.Maximum = 100;
            key.Top = 20;
            key.Left = 20;
            KeyBox.Controls.Add(key);
        }

        public override string Encode(string M)
        {
            if (Key == 1)
            {
                return M;
            }
            string C = "";
            for(int j = 0; j < Key; j++)
            {
                for(int i = 0; i <= M.Length / (Key - 1) + 1; i++)
                {
                    int index = (2 * i + 1) * (Key - 1) - j;
                    if(index < M.Length)
                    {
                        C += M[index];
                    }

                    if (j != 0 && j != Key - 1)
                    {
                        if (index + 2 * j < M.Length)
                        {
                            C += M[index + 2 * j];
                        }
                    }
                }
            }
            return C;
        }
        public override string Decode(string C)
        {
            if (Key == 1)
            {
                return C;
            }
            string M = "";
            int L = C.Length;
            Dictionary<int,int> alias = new Dictionary<int, int>();
            for (int j = 0; j < Key; j++)
            {
                for (int i = 0; i <= L / (Key - 1) + 1; i++)
                {
                    int index = (2 * i + 1) * (Key - 1) - j;
                    if (index < L)
                    {
                        alias[index] = alias.Count;
                    }
                    if (j != 0 && j != Key - 1)
                    {
                        if (index + 2 * j < L)
                        {
                            alias[index + 2*j] = alias.Count;
                        }
                    }
                }
            }
            for (int i = 0; i < L; i++)
            {
                M += C[alias[i]];
            }
            return M;
            
        }
        public override string Hack(string C)
        {
            throw new NotImplementedException();
        }
    }
}
