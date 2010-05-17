using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace Cryptograph
{
    class SimpleReplacementCipher: BaseCipher
    {
        public Dictionary<char, char> Key
        {
            get
            {
                Dictionary<char, char> dic = new Dictionary<char, char>();
                DataGridViewRowCollection rows = (KeyBox.Controls["SimpleReplacementCipher"] as DataGridView).Rows;
                for(int i = 0; i < rows.Count; i++)
                {
                    try
                    {
                        dic.Add(rows[i].Cells[0].Value.ToString()[0], rows[i].Cells[1].Value.ToString()[0]);
                    }
                    catch(Exception ex)
                    {
                        throw new Exception("Ключ задано не правильно");
                    }
                }
                return dic;
            }
        }
        public override void Initialize()
        {
            KeyBox.Controls.Clear();
            DataGridView key = new DataGridView();
            key.Name = "SimpleReplacementCipher";
            key.RowHeadersVisible = false;
            key.ColumnHeadersVisible = false;
            key.Columns.Add("1", "1");
            key.Columns.Add("2", "2");
            key.AllowUserToAddRows = false;
            key.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            string alpha = Alphabet.GetStringValue();
            for(int i = 0; i < Alphabet.GetLength(); i++)
            {
                key.Rows.Add(alpha[i], alpha[i]);
            }
            key.Top = 20;
            key.Left = 20;
            key.Height = 300;
            KeyBox.Controls.Add(key);
        }
        public override string Encode(string M)
        {
            string C = "";
            for(int i = 0; i < M.Length; i++)
            {
                C += Key[M[i]];
            }
            return C;
        }

        public override string Decode(string C)
        {
            string M = "";
            for (int i = 0; i < C.Length; i++)
            {
                M += Key.Single(t => t.Value == C[i]).Key;
            }
            return M;
        }

        public override string Hack(string C)
        {
            throw new NotImplementedException();
        }
    }
}
