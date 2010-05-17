using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cryptograph
{
    class VigenereCipher:BaseCipher
    {
        public string Key
        {
            get
            {
                return KeyBox.Controls["VigenereCipher"].Text;
            }
            set
            {
                KeyBox.Controls["VigenereCipher"].Text = value;
            }
        }
        private Dictionary<char, int> Alias;
        public override void Initialize()
        {
            KeyBox.Controls.Clear();
            TextBox key = new TextBox();
            key.Name = "VigenereCipher";
            key.Text = " ";
            key.Top = 20;
            key.Left = 20;
            Alias = new Dictionary<char, int>();
            string alpha = Alphabet.GetStringValue();
            for (int i = 0; i < Alphabet.GetLength(); i++)
            {
                Alias.Add(alpha[i], i);
            }
            KeyBox.Controls.Add(key);
        }
        public override string Encode(string M)
        {
            string C = "";
            for (int i = 0; i < M.Length; i++)
            {
                int newCode = Alias[M[i]] + Alias[Key[i % Key.Length]];
                C += Alphabet.GetStringValue()[newCode % Alphabet.GetLength()];
            }
            return C;
        }
        public override string Decode(string C)
        {
            string key = "";
            for(int i = 0; i < Key.Length; i++)
            {
                key += Alphabet.GetStringValue()[(Alphabet.GetLength() - Alias[Key[i]])%Alphabet.GetLength()];
            }
            VigenereCipher cipher = new VigenereCipher
            {
                KeyBox = new GroupBox(),
                Alphabet = Alphabet,
                Key = key
            };

            return cipher.Encode(C);
        }
        public override string Hack(string C)
        {
            throw new NotImplementedException();
        }
    }
}
