using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


namespace Compression
{
    class CodeDictionary
    {
        private Hashtable encode = new Hashtable(); // character(char) - code(string)
        private Hashtable decode = new Hashtable(); // code(string) - character(char)

        public void Add(char character, string code)
        {
            if (encode.Contains(character))
            {
                encode.Remove(character);
            }
            encode.Add(character, code);
        }
        public void RebuildDecode()
        {
            decode.Clear();
            foreach (object key in encode.Keys)
            {
                decode.Add(encode[key], key);
            }
        }
        public int CountEncode()
        {
            return encode.Count;
        }
        public bool ContainCode(string code)
        {
            return decode.ContainsKey(code);
        }
        public StringBuilder GetEncodeDicDemo()
        {
            StringBuilder dic = new StringBuilder();
            dic.Append("Розмір словника: ");
            dic.Append(encode.Count + "\r\n");
            foreach(object key in encode.Keys)
            {
                dic.Append(key);
                dic.Append(" - ");
                //dic.Append(((string)encode[key]).Length);
                dic.Append(encode[key] + "\r\n");
            }
            return dic;
        }
        public StringBuilder GetEncodeDicReal()
        {
            StringBuilder dic = new StringBuilder();
            dic.Append((char)encode.Count);
            foreach (object key in encode.Keys)
            {
                dic.Append(key);
                dic.Append((char)(((string)encode[key]).Length));
                //char[] bytes = StringToBytes((string)encode[key]);
                //for (int i = 0; i < bytes.Length; i++)
                //{
                 //   dic.Append(bytes[i]);
                //}
                dic.Append(StringToByte((string)encode[key]));
            }
            return dic;
        }
        public static string IntToCode(int c, int length)
        {
            string code = "";
            int[] b = new int[1];
            b[0] = c;
            BitArray ba = new BitArray(b);
            for (int i = 0; i < length; i++)
            {
                code = (ba[i] ? "1" : "0") +code;
            }
            return code;
        }
        public static int GetCode(StringBuilder input, int begin, int count)
        {
            int res = 0;
            int tmp = 1;
            for (int i = 0; i < count; i++)
            {
                res += tmp * (input[count - 1 - i + begin] == '1' ? 1 : 0);
                tmp *= 2;
            }
            return res;
        }
        public static StringBuilder BytesToString(StringBuilder input)
        {
            StringBuilder output = new StringBuilder();
 
            for (int i = 0; i < input.Length; i++)
            {
                output.Append(IntToCode((int)input[i], 8));
            }
            return output;
        }
        public static StringBuilder StringToBytes(StringBuilder input)
        {
            StringBuilder output = new StringBuilder();
            int rest = 8;
            if (input.Length % 8 != 0)
            {
                rest = input.Length % 8;
                int tmp = 8 - input.Length % 8;
                for (int i = 0; i <tmp; i++)
                {
                    input.Append("0");
                }
            }
            for (int i = 0; i < input.Length; i+=8)
            {
            //    if (i == input.Length - 8)
           //     {
             //       output.Append((char)GetCode(input, i, rest));
            //    }
            //    else
           //     {
                    output.Append((char)GetCode(input, i, 8));
             //   }
            }
            return output;
        }
        public static string ByteToCode(char c, int length)
        {
            string code = "";
            byte[] b = new byte[1];
            b[0] = (byte)c;
            BitArray ba = new BitArray(b);
            for (int i = 0; i < length; i++)
            {
                code += (ba[i] ? "1" : "0");// +code;
            }
            return code;
        }
        public string this[char character]
        {
            get
            {
                if(encode.ContainsKey(character))
                {
                    return (string)encode[character];
                }
                encode.Add(character, "");
                //decode.Add("", character);
                return(string) encode[character];
            }
            set
            {
                if (encode.ContainsKey(character))
                {
                    encode[character] = value;
                }
                else
                {
                    encode.Add(character, value);
                }
                /*if (decode.ContainsValue(character))
                {
                    decode.Remove(value);       
                }
                decode.Add(value, character);*/
                decode[value] = character;
            }
        }
        public char this[string code]
        {
            get
            {
                if (decode.ContainsKey(code))
                {
                    return (char)decode[code];
                }
                return '0';
            }
            set
            {
                if (decode.ContainsKey(code))
                {
                    decode[code] = value;
                }
                else
                {
                    decode.Add(code, value);
                }
                /*if (encode.ContainsValue(code))
                {
                    encode.Remove(value);
                }
                encode.Add(value, code);*/
                encode[value] = code;
            }
        }
        public static char StringToByte(string s)
        {
            char res = (char)0;
            byte tmp = 1;
            for (int i = 0; i < s.Length; i++)
            {
                res += (char)(tmp * (s[i] == '1' ? 1 : 0));
                tmp *= 2;
            }
            return res;
        }
        public static char[] StringToBytes(string s)
        {
            char[] res = new char[(s.Length - 1) / 8 + 1];
            uint tmp = 128;
            int index = 0;
            for(int i = 0; i < (s.Length / 8) * 8; i++)
            {
                if ((i % 8 == 0) && (i != 0))
                {
                    index++;
                    tmp = 128;
                }
                res[index] += (char)(tmp * (s[i] == '1' ? 1 : 0));
                tmp /= 2;

            }
            if (s.Length % 8 != 0)
            {
                string last = "";
                for(int i = (s.Length / 8) * 8; i < s.Length; i++)
                {
                    last += s[i];
                }

                res[res.Length - 1] = StringToByte(s);
            }
            return res;
        }
        public static byte BitArrayToByte(BitArray arr)
        {
            byte res = 0;
            byte tmp = 1;
            for (int i = 0; i < arr.Count; i++)
            {
                res += (byte)(tmp * (arr[i] ? 1 : 0));
                tmp *= 2;
            }
            return res;
        }
        public byte[] ToByteArray()
        {
            byte[] arr = new byte[encode.Count + 1];
            arr[0] = (byte)encode.Count;
            int i = 0;
            foreach(object character in encode.Keys)
            {
                arr[i + 1] = (byte)character;
                arr[i + 2] = (byte)((BitArray)encode[character]).Count;
                arr[i + 3] = BitArrayToByte((BitArray)encode[character]);
                i += 3;

            }
            return arr;
        }
        public override string ToString()
        {
            string res = encode.Count.ToString();
            foreach (object character in encode.Keys)
            {
                res += ((char)character).ToString();
                res += ((BitArray)encode[character]).Count.ToString() ;
                foreach(bool bit in (BitArray) encode[character] )
                {
                    res += bit ? "1" : "0";
                }
            }
            return base.ToString();
        }


    }
}
