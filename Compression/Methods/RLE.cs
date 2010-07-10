using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compression
{
    class RLE
    {
        static public StringBuilder EncodeReal(StringBuilder input)
        {
            StringBuilder output = new StringBuilder();
            string buf = "";
            int minusCount = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int curLength = 1;
                while (i + 1 < input.Length && input[i] == input[i + 1])
                {
                    curLength++;
                    i++;
                    if (curLength == 127)
                    {
                        break;
                    }
                }
                if (curLength == 1)
                {
                    buf += input[i];
                    minusCount--;
                    if (i == input.Length - 1)
                    {
                        output.Append((char)((byte)minusCount + 1));
                        output.Append(buf);
                    }
                }
                else
                {
                    if (minusCount == 0)
                    {
                        output.Append((char)curLength);
                        output.Append(input[i]);
                    }
                    else
                    {
                        output.Append((char)((byte)minusCount+1));
                        output.Append(buf);
                        output.Append((char)curLength);
                        output.Append(input[i]);
                        buf = "";
                        minusCount = 0;
                    }
                }
            }
            return output;
        }
        static public StringBuilder EncodeDemo(StringBuilder input)
        {
            StringBuilder output = new StringBuilder();
            string buf = "";
            int minusCount = -1;
            for (int i = 0; i < input.Length; i++)
            {
                int curLength = 1;
                while (i + 1 < input.Length && input[i] == input[i + 1])
                {
                    curLength++;
                    i++;
                    if (curLength == 127)
                    {
                        break;
                    }
                }
                if (curLength == 1)
                {
                    buf += input[i];
                    minusCount--;
                    if (i == input.Length - 1)
                    {
                        output.Append((minusCount + 1).ToString());
                        output.Append(buf);
                    }
                }
                else
                {
                    if (minusCount == -1)
                    {
                        output.Append(curLength.ToString());
                        output.Append(input[i]);
                    }
                    else
                    {
                        output.Append((minusCount+1).ToString());
                        output.Append(buf);
                        output.Append(curLength.ToString());
                        output.Append(input[i]);
                        buf = "";
                        minusCount = -1;
                    }
                }
            }
            return output;
        }
        static public StringBuilder Decode(StringBuilder input)
        {
            StringBuilder output = new StringBuilder();
            for(int i = 0; i < input.Length; i+=2)
            {
                int number = (byte)input[i];
                if (number > 128 || number == 0)
                {
                    if (number == 0)
                    {
                        number = 1;
                    }
                    else
                    {
                    number = 257 - number;
                    }
                    for (int j = 0; j < number; j++)
                    {
                        output.Append(input[i + 1 + j]);
                    }
                    i +=  number-1;
                }
                else
                {
                    output.Append(input[i + 1], number);
                }
		    }
    		return output;
        }

    }
}
