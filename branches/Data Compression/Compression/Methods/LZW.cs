using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;

namespace Compression
{
    class LZW
    {
        private static StringBuilder Encode(StringBuilder input, int codeSize)
        {
            StringBuilder output = new StringBuilder();
            Hashtable dic = new Hashtable(); // key - string, value - int
            for (int i = 0; i < 256; i++)
            {
                dic.Add((((char)i).ToString()), i);
            }
            string line = input[0].ToString();
            int index = 1;
            int dicMaxCount = (int) Math.Pow(2, codeSize);
            while (index < input.Length)
            {
                if (dic.ContainsKey(line + input[index]))
                {
                    line = line + input[index];
                }
                else
                {
                    output.Append(CodeDictionary.IntToCode((int)dic[line], codeSize));
                    if (dic.Count < dicMaxCount)
                    {
                        dic.Add(line + input[index].ToString(), dic.Count);
                    }
                    
                    line = input[index].ToString();
                }
                index++;
            }
            output.Append(CodeDictionary.IntToCode((int)dic[line], codeSize));
            return output;

        }
        public static StringBuilder EncodeReal(StringBuilder input, int codeSize)
        {
            StringBuilder output = new StringBuilder();
            output = Encode(input, codeSize);
            output = CodeDictionary.StringToBytes(output);
            return output;
            
        }
        public static StringBuilder EncodeDemo(StringBuilder input, int codeSize)
        {
            StringBuilder output = new StringBuilder();
            Hashtable dic = new Hashtable(); // key - string, value - int
            List<string> dicList = new List<string>();

            for (int i = 0; i < 256; i++)
            {
                dic.Add((((char)i).ToString()), i);
                dicList.Add((((char)i).ToString()));
            }
            string line = input[0].ToString();
            int index = 1;
            int dicMaxCount = (int)Math.Pow(2, codeSize);
            while (index < input.Length)
            {
                if (dic.ContainsKey(line + input[index]))
                {
                    line = line + input[index];
                }
                else
                {
                    output.Append(dic[line].ToString() + " ");
                    if (dic.Count < dicMaxCount)
                    {
                        dic.Add(line + input[index].ToString(), dic.Count);
                        dicList.Add(line + input[index].ToString());
                    }

                    line = input[index].ToString();
                }
                index++;
            }
            output.Append(dic[line].ToString() + " ");
            StringBuilder dictionary = new StringBuilder();
            for (int i = 256; i < dicList.Count; i++)
            {
                dictionary.Append(i.ToString() + " - " + dicList[i] + "\r\n");
            }
            return dictionary.Append(  output);

        }
        public static StringBuilder Decode(StringBuilder input, int codeSize)
        {
            StringBuilder output = new StringBuilder();
            Hashtable dic = new Hashtable(); // key - int, value - string
            for (int i = 0; i < 256; i++)
            {
                dic.Add(i, (((char)i).ToString()));
            }
            input = CodeDictionary.BytesToString(input);
            int oldCode = CodeDictionary.GetCode(input, 0, codeSize);
            output.Append((string)dic[oldCode]);
            string s = (string)dic[oldCode];
            string line = "";
            int index = codeSize;
            int newCode;
            int dicMaxCount = (int)Math.Pow(2, codeSize);

            while(input.Length - index >= codeSize)
            {
                newCode = CodeDictionary.GetCode(input, index, codeSize);
                if (!dic.ContainsKey(newCode))
                {
                    line = (string)dic[oldCode];
                    line += s;
                }
                else
                {
                    line = (string)dic[newCode];
                }
                output.Append(line);
                if (line.Length != 0)
                {
                    s = line[0].ToString();
                }
                else
                {
                    s = "";
                }
                if (dic.Count < dicMaxCount)
                {
                    dic.Add(dic.Count, (string)dic[oldCode] + s);
                }
                oldCode = newCode;
                index += codeSize;
            }
            return output;
        }
    }
}
