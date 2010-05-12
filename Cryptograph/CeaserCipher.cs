using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cryptograph
{
    class CeaserCipher: BaseCipher
    {
        public int Key 
        {
            set
            {
                ((NumericUpDown)KeyBox.Controls["CeaserCipherKey"]).Value = value;
            }
            get 
            {
                return (int)((NumericUpDown) KeyBox.Controls["CeaserCipherKey"]).Value;
            }
        }

        public override void Initialize()
        {
            KeyBox.Controls.Clear();
            NumericUpDown key = new  NumericUpDown();
            key.Name = "CeaserCipherKey";
            key.Minimum = 0;
            key.Maximum = Alphabet.GetLength();
            key.Top = 20;
            key.Left = 20;
            KeyBox.Controls.Add(key);
        }

        public override string Encode(string M)
        {
            string C = "";
            for (int i = 0; i < M.Length; i++)
            {
                int newIndex = (Alphabet.GetStringValue().IndexOf(M[i]) + Key) % Alphabet.GetStringValue().Length;
                if (newIndex == -1)
                {
                    throw new Exception("Вибрано неправильний алфавіт");
                }
                C += Alphabet.GetStringValue()[newIndex];
            }
            return C;
        }
        public override string Decode(string C)
        {
            CeaserCipher cc = new CeaserCipher
            {
                KeyBox = new GroupBox(),
                Alphabet = this.Alphabet,
                Key = this.Alphabet.GetLength() - this.Key
            };
            return cc.Encode(C);
        }

        public override string Hack(string C)
        {
            string result = "";
            for (int key = 0; key < Alphabet.GetLength(); key++)
            {
                CeaserCipher cc = new CeaserCipher
                {
                    KeyBox = new GroupBox(),
                    Alphabet = this.Alphabet,
                    Key = key
                };
                string M = cc.Decode(C);
                if (Analizer.Check(M))
                {
                    result += "Secret key is: " + key + "\r\n";
                    result += M + "\r\n";
                }

            }
            return result;
        }
    }
}
