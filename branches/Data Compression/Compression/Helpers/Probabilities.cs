using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;
namespace Compression
{
    class PairComparer : IComparer<KeyValuePair<char, double>>
    {
        public int Compare(KeyValuePair<char, double> p1, KeyValuePair<char, double> p2)
        {
            return p2.Value.CompareTo(p1.Value);
        }
    }
    class Probabilities
    {
        private List<KeyValuePair<char, double>> p = new List<KeyValuePair<char, double>>();
        public int Count
        {
            get
            {
                return p.Count;
            }
        }
        public Probabilities(StringBuilder text)
        {
            Hashtable count = new Hashtable();
            for (int i = 0; i < text.Length; i++)
            {
                if (!count.Contains((char)text[i]))
                {
                    count[(char)text[i]] = 0.0;
                }
                count[(char)text[i]] = (double)count[(char)text[i]] + 1.0;
            }
            foreach (object b in count.Keys)
            {
                p.Add(new KeyValuePair<char, double>((char)b, (double)count[b] / (double)text.Length));
            }
            p.Sort(new PairComparer());
        }
        public Probabilities(List<KeyValuePair<char, double>> list)
        {
            p = list;
        }
        public List<KeyValuePair<char, double>> ToList()
        {
            return p;
        }
        public double Sum()
        {
            double sum = 0.0;
            foreach (KeyValuePair<char, double> pair in p)
            {
                sum += pair.Value;
            }
            return sum;
        }
        public char Char(int index)
        {
            return p[index].Key;
        }
        public double this[int index]
        {
            get
            {
                return p[index].Value;
            }
        }



    }
}
