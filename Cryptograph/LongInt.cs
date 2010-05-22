using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cryptograph
{
    
    class LongInt
    {
        private static  int MAX = 200;
        public static  int BASE = 10000;
        public static int SIGNS = (int)Math.Log10((int)BASE);

        private int[] arr =  new int[MAX];
        public int Size { get; set; }

        public LongInt()
        {
            Size = 0;
        }
        public static LongInt Parse(string s)
        {
            LongInt res = new LongInt();
            for (int i = s.Length - SIGNS; i >= 0; i -= SIGNS)
            {
                res.arr[res.Size] = int.Parse(s.Substring(i, SIGNS));
                res.Size++;
            }
            if (s.Length % SIGNS != 0)
            {
                int tmp = s.Length / SIGNS;
                res.arr[res.Size] = int.Parse(s.Substring(0, s.Length - tmp * SIGNS));
                res.Size++;
            }
            return res;
        }
        public static LongInt operator +(LongInt a, LongInt b)
        {
            LongInt res = new LongInt();
            int tmp = 0;
            for(int i = 0; i < Math.Max(a.Size, b.Size); i++)
            {
                res.Size++;
                res.arr[i] = (a.arr[i] + b.arr[i] + tmp) % BASE;
                tmp = (a.arr[i] + b.arr[i] + tmp) / BASE; 
            }
            if (tmp > 0)
            {
                res.arr[res.Size] = tmp;
                res.Size++;
            }
            return res;
        }
        public static LongInt operator -(LongInt a, LongInt b)
        {
            if (a < b)
            {
                throw new Exception("First argument is less then second");
            }
            LongInt res = new LongInt();
            int tmp = 0;
            for (int i = 0; i < a.Size; i++)
            {
                res.arr[i] = a.arr[i] - b.arr[i] - tmp;
                tmp = 0;
                if (res.arr[i] < 0)
                {
                    res.arr[i] += BASE;
                    tmp = 1;
                }
                res.Size++;
            }

            while (res.arr[res.Size - 1] == 0 && res.Size > 1)
            {
                res.Size--;
            }
            return res;
        }

        public static LongInt operator *(LongInt a, int b)
        {
            if (b >= BASE)
            {
                throw new Exception("Argument is greater then BASE");
            }
            LongInt res = new LongInt();
            int tmp = 0;
            for (int i = 0; i < a.Size; i++)
            {
                res.arr[i] = (a.arr[i] * b + tmp) % BASE;
                tmp = (a.arr[i] * b + tmp) / BASE;
                res.Size++;
            }
            if (tmp > 0)
            {
                res.arr[res.Size] = tmp;
                res.Size++;
            }
            while (res.arr[res.Size - 1] == 0 && res.Size > 1)
            {
                res.Size--;
            }
            return res;

        }

        public static LongInt operator *(LongInt a, LongInt b)
        {
            LongInt res = new LongInt();
            LongInt tmp = new LongInt();
            for(int i = 0; i < b.Size; i++)
            {
                tmp  = a * b.arr[i];
                tmp = tmp.Shift(i);
                res = tmp + res;
            }
            while (res.arr[res.Size - 1] == 0 && res.Size > 1)
            {
                res.Size--;
            }
            return res;
        }

        public static LongInt operator %(LongInt a, LongInt b)
        {
            return a - (a / b) * b;
        }
        public static bool operator <(LongInt a, LongInt b)
        {
            return !(a > b) && !(a == b) ;
        }
        public static bool operator >(LongInt a, LongInt b)
        {
            int i = a.Size - 1;

            if (a.Size == b.Size)
            {
                while (i > 0 && (a.arr[i] == b.arr[i]))
                {
                    i--;
                }
            }
            return (a.Size == b.Size ? a.arr[i] > b.arr[i] : a.Size > b.Size);
        }
        public static bool operator ==(LongInt a, LongInt b)
        {
            if (a.Size == b.Size)
            {
                for (int i = 0; i < a.Size; i++)
                {
                    if (a.arr[i] != b.arr[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(LongInt a, LongInt b)
        {
            return !(a == b);
        }
        private LongInt Shift(int positions)
        {
            LongInt res = new LongInt();
            arr.Take(Size).ToArray().CopyTo(res.arr, positions);
            res.Size = Size + positions;
            return res;
        }

        public LongInt PowWithMod(LongInt pow, LongInt mod)
        {/*
            BigInt tmp = new BigInt(this.ToString());
            BigInt res = new BigInt(1);
            int[] bin = pow.ToBinary();
            BigInt bigMod = new BigInt(mod.ToString());
            for (int i = 0; i < bin.Length; i++)
            {
                if (bin[i] == 1)
                {
                    res = (res * tmp) % bigMod;
                }
                tmp = (tmp * tmp) % bigMod;
            }
            return LongInt.Parse(res.ToString());
            */
            int[] bin = pow.ToBinary();
            LongInt res = new LongInt();
            res = LongInt.Parse("1");
            LongInt tmp = new LongInt();
            tmp = this;
            for (int i = 0; i < bin.Length; i++)
            {
                if (bin[i] == 1)
                {
                    res = (res * tmp) % mod;
                }
                tmp = (tmp * tmp) % mod;
            }
            return res ;
        }
        public static LongInt GenerateRandom(LongInt max)
        {
            LongInt res = new LongInt();
            Random rand = new Random();
            int length = rand.Next(max.Size);
            for (int i = 0; i <= length; i++)
            {
                if (i != max.Size - 1)
                {
                    res.arr[i] = rand.Next(BASE);
                }
                else
                {
                    res.arr[i] = rand.Next(max.arr[i]);
                }
                res.Size++;
            }
            return res;
        }
        public int[] ToBinary()
        {
            List<LongInt> pows = new List<LongInt>();
            LongInt tmp = new LongInt();
            tmp = LongInt.Parse("1");
            while (this > tmp)
            {
                pows.Add(tmp);
                tmp = tmp * 2;
            }
            LongInt rest = new LongInt();
            rest = this;
            int[] res = new int[pows.Count];
            for (int i = pows.Count - 1; i >= 0; i--)
            {

                tmp = rest % pows[i];
                if (rest != tmp)
                {
                    res[i] = 1;
                }
                rest = tmp;
            }
            return res;
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < Size; i++)
            {
                string tmp = arr[i].ToString();
                if (i != Size - 1)
                {
                    int length = tmp.Length;
                    for (int j = 0; j < SIGNS - length; j++)
                    {
                        tmp = "0" + tmp;
                    }
                }

                str = tmp + str;
            }
            return str;
        }
        public static LongInt operator /(LongInt a, LongInt b)
        {
            if (b.Size == 1 && b.arr[0] == 1)
            {
                return a;
            }
            if (b.Size == 1 && b.arr[0] == 0)
            {
                throw new Exception("Devision by 0");
            }
            return BinarySearch(LongInt.Parse("0"), a, a, b);
        }
        public static LongInt Avg(LongInt a, LongInt b)
        {
            LongInt res = new LongInt();
            LongInt x = a + b;
            int carry = 0;
            for (int i = x.Size - 1; i >= 0; --i)
            {
                int cur = x.arr[i] + carry * BASE;
                x.arr[i] = cur / 2;
                carry = cur % 2;
            }
            while (x.Size > 1 && x.arr[x.Size - 1] == 0)
            {
                x.Size--;
            }
            return x;
        }
        private static LongInt BinarySearch(LongInt begin, LongInt end, LongInt a, LongInt b)
        {
            LongInt middle = LongInt.Avg(begin, end);
            LongInt c =  middle * b;
            if (begin == middle)
            {
                return middle;
            }
            if( c > a)
            {
                return BinarySearch(begin, middle, a, b);
            }
            else if(c < a)
            {
                return BinarySearch(middle, end, a, b);
            }
            return middle;

        }
    }
}
