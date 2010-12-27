using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Compiler.Compile
{
    public sealed class Scanner
    {
        private readonly IList<object> _Result;

        public Scanner(TextReader input)
        {
            _Result = new List<object>();
            Scan(input);
        }

        public IList<object> Tokens
        {
            get { return _Result; }
        }

        #region ArithmiticConstants

        // Constants to represent arithmitic tokens. This could
        // be alternatively written as an enum.
        public static readonly object Add = new object();
        public static readonly object Sub = new object();
        public static readonly object Mul = new object();
        public static readonly object Div = new object();
        public static readonly object Semi = new object();
        public static readonly object Equal = new object();

        #endregion

        private void Scan(TextReader input)
        {
            while (input.Peek() != -1)
            {
                var ch = (char)input.Peek();

                // Scan individual tokens
                if (char.IsWhiteSpace(ch))
                {
                    // eat the current char and skip ahead!
                    input.Read();
                }
                else if (char.IsLetter(ch) || ch == '_')
                {
                    // keyword or identifier

                    var accum = new StringBuilder();

                    while (char.IsLetter(ch) || ch == '_')
                    {
                        accum.Append(ch);
                        input.Read();

                        if (input.Peek() == -1)
                        {
                            break;
                        }

                        ch = (char)input.Peek();
                    }

                    _Result.Add(accum.ToString());
                }
                else if (ch == '"')
                {
                    // string literal
                    var accum = new StringBuilder();

                    input.Read(); // skip the '"'

                    if (input.Peek() == -1)
                    {
                        throw new ScannerException("Unterminated string literal");
                    }

                    while ((ch = (char)input.Peek()) != '"')
                    {
                        accum.Append(ch);
                        input.Read();

                        if (input.Peek() == -1)
                        {
                            throw new ScannerException("Unterminated string literal");
                        }
                    }

                    // skip the terminating "
                    input.Read();
                    _Result.Add(accum);
                }
                else if (char.IsDigit(ch))
                {
                    // numeric literal

                    var accum = new StringBuilder();

                    while (char.IsDigit(ch))
                    {
                        accum.Append(ch);
                        input.Read();

                        if (input.Peek() == -1)
                        {
                            break;
                        }

                        ch = (char)input.Peek();
                    }

                    _Result.Add(int.Parse(accum.ToString()));
                }
                else switch (ch)
                {
                    case '+':
                        input.Read();
                        _Result.Add(Add);
                        break;

                    case '-':
                        input.Read();
                        _Result.Add(Sub);
                        break;

                    case '*':
                        input.Read();
                        _Result.Add(Mul);
                        break;

                    case '/':
                        input.Read();
                        _Result.Add(Div);
                        break;

                    case '=':
                        input.Read();
                        _Result.Add(Equal);
                        break;

                    case ';':
                        input.Read();
                        this._Result.Add(Semi);
                        break;

                    default:
                        throw new ScannerException("Encountered unrecognized character '" + ch + "'");
                }

            }
        }
    }
}
