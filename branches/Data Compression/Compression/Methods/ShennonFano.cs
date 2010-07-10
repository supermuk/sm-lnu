using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Compression
{
    class ShennonFano
    {
        private static void FindCodes(Probabilities p, ref CodeDictionary dic)
        {
            if (p.Count == 1)
            {
                dic[p.Char(0)] = dic[p.Char(0)] + "0";
                return;
            }
            if (p.Count == 2)
            {
                dic[p.Char(0)] = dic[p.Char(0)] + "0";
                dic[p.Char(1)] = dic[p.Char(1)] + "1";
                return;
            }
            double tmp = 0;
            int index = 0;
            while (tmp  <= p.Sum() / 2)
            {
                dic[p.Char(index)] = dic[p.Char(index)] + "0";
                tmp += p[index];
                index++;
            }
            for (int i = index; i < p.Count; i++)
            {
                dic[p.Char(i)] = dic[p.Char(i)] + "1";

            }
            FindCodes(new Probabilities(p.ToList().GetRange(0, index)), ref dic);
            FindCodes(new Probabilities(p.ToList().GetRange(index, p.Count - index)), ref dic);
        }


        public static StringBuilder EncodeDemo(StringBuilder input)
        {
            StringBuilder output = new StringBuilder();
            Probabilities p = new Probabilities(input);
            CodeDictionary dic  = new CodeDictionary();

            FindCodes(p, ref dic);
            output.Append(dic.GetEncodeDicDemo());
            StringBuilder tmp = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                tmp.Append(" ");
                tmp.Append(dic[input[i]]);
            }
            output.Append("Bits_count % 8 = " + ((tmp.Length - input.Length)%8).ToString() + "\r\n");
            output.Append(tmp);

            return output;
        }
        public static StringBuilder EncodeReal(StringBuilder input)
        {
            StringBuilder output = new StringBuilder();
            Probabilities p = new Probabilities(input);
            CodeDictionary dic = new CodeDictionary();

            FindCodes(p, ref dic);
            output.Append(dic.GetEncodeDicReal());
            //536mb
            StringBuilder tmp = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                tmp.Append(dic[input[i]]);
            }
            char rest = (char)(tmp.Length % 8);
            output.Append(rest);
            string str_byte = "";
            for (int i = 0; i < tmp.Length; i++)
            {
                if ((i % 8 == 0) && (i != 0))
                {
                    output.Append(CodeDictionary.StringToByte(str_byte));
                    str_byte = "";
                }
                str_byte += tmp[i];

            }
            int strlength = str_byte.Length;
            for (int i = 0; i < 8 - strlength; i++)
            {
                str_byte += "0";
            }
            output.Append(CodeDictionary.StringToByte(str_byte));
            return output;
        }
       
        public static StringBuilder Decode(StringBuilder input)
        {
            StringBuilder output = new StringBuilder();
            CodeDictionary dic = new CodeDictionary();
            int dicSize = (int)input[0];
            for (int i = 1; i < dicSize * 3 + 1; i+=3)
            {
                int codeLength = (int)input[i + 1];
                dic[input[i]] = CodeDictionary.ByteToCode(input[i + 2], codeLength);
            }
            /*
            int index = 1;
            int countCodes = 0;
            while( countCodes < dicSize) 
            {
                int codeLength = (int)input[index + 1];
                int byteCount = (codeLength - 1) / 8 + 1;
                byte[] bytes = new byte[byteCount];
                for (int i = 0; i < byteCount; i++)
                {
                    if (i == byteCount - 1)
                    {
                        dic[input[index]] = dic[input[index]] + CodeDictionary.ByteToCode(input[index + 2 + i], codeLength - 8 * (byteCount - 1));
                    }
                    else
                    {
                        dic[input[index]] = dic[input[index]] + CodeDictionary.ByteToCode(input[index + 2 + i], 8);
                    }

                }
                //dic.RebuildDecode();

               // dic[input[index]] = CodeDictionary.ByteToCode(input[i + 2], codeLength);
                index += byteCount;
                index += 2;
                countCodes++;

            }*/

            int rest = (int)input[dicSize*3 + 1];
            StringBuilder tmp = new StringBuilder();
            for (int i = dicSize * 3 + 2; i < input.Length; i++)
            {
                string curCode = CodeDictionary.ByteToCode(input[i], 8);
                tmp.Append(curCode);
            }
            for (int i = 0; i < tmp.Length; i++)
            {
                if (i == ( tmp.Length - 8 + rest ))
                {
                    break;
                }
                string curCode = tmp[i].ToString();
                while (!dic.ContainCode(curCode))
                {
                    i++;
                    curCode += tmp[i];
                }
                output.Append(dic[curCode]);
            }
            return output;
        }

    }
}
