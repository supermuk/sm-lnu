using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.Compile
{
    public sealed class Parser
    {
        #region Protected Fields

        private int _Index;
        private readonly IList<object> _Tokens;
        private readonly Statement _Result;

        #endregion

        #region Public Properties

        public Statement Result
        {
            get { return _Result; }
        }

        #endregion

        #region Constructors

        public Parser(IList<object> tokens)
        {
            _Tokens = tokens;
            _Index = 0;
            _Result = ParseStatement();

            if (_Index != _Tokens.Count)
            {
                throw new ParserException("Expected EOF");
            }
        }

        #endregion

        private Statement ParseStatement()
        {
            if (_Index == _Tokens.Count)
            {
                throw new ParserException("Unexpected EOF - Expected Statement");
            }

            Statement result;
            var currentToken = _Tokens[_Index].ToString();

            if (currentToken.Equals("print"))
            {
                _Index++;
                var endIndex = _Index;

                while (_Tokens[endIndex] != Scanner.Semi)
                {
                    endIndex++;
                }

                var print = new Print { Expr = ParseExpression(endIndex) };
                
                result = print;
            }
            else if (currentToken.Equals("var"))
            {
                _Index++;
                var declareVar = new DeclareVariable();

                if (_Index < _Tokens.Count && _Tokens[_Index] is string)
                {
                    declareVar.Ident = (string)_Tokens[_Index];
                }
                else
                {
                    throw new ParserException("Expected variable name after 'var'");
                }

                _Index++;

                if (_Index == _Tokens.Count || _Tokens[_Index] != Scanner.Equal)
                {
                    throw new ParserException("Expected = after 'var ident'");
                }

                _Index++;

                var endIndex = _Index;

                while (_Tokens[endIndex] != Scanner.Semi)
                {
                    endIndex++;
                }

                declareVar.Expr = ParseExpression(endIndex);

                result = declareVar;
            }
            else if (currentToken.Equals("read_int"))
            {
                _Index++;
                var readInt = new ReadInt();

                if (_Index < _Tokens.Count && _Tokens[_Index] is string)
                {
                    readInt.Ident = (string)_Tokens[_Index++];

                    result = readInt;
                }
                else
                {
                    throw new ParserException("Expected variable name after 'read_int'");
                }
            }
            else if (currentToken.Equals("for"))
            {
                _Index++;
                var forLoop = new ForLoop();

                if (_Index < _Tokens.Count && _Tokens[_Index] is string)
                {
                    forLoop.Ident = (string)_Tokens[_Index];
                }
                else
                {
                    throw new ParserException("Expected identifier after 'for'");
                }

                _Index++;

                if (_Index == _Tokens.Count || _Tokens[_Index] != Scanner.Equal)
                {
                    throw new ParserException("Missing '=' in for loop");
                }

                _Index++;

                forLoop.From = ParseExpression();

                if (_Index == _Tokens.Count || !_Tokens[_Index].Equals("to"))
                {
                    throw new ParserException("Expected 'to' after for");
                }

                _Index++;

                forLoop.To = ParseExpression();

                if (_Index == _Tokens.Count || !_Tokens[_Index].Equals("do"))
                {
                    throw new ParserException("Expected 'do' after from expression in for loop");
                }

                _Index++;

                forLoop.Body = ParseStatement();
                result = forLoop;

                if (_Index == _Tokens.Count || !_Tokens[_Index].Equals("end"))
                {
                    throw new ParserException("Unterminated 'for' loop body");
                }

                _Index++;
            }
            else if (_Tokens[_Index] is string)
            {
                var assign = new Assign { Ident = _Tokens[_Index++].ToString() };

                if (_Index == _Tokens.Count || _Tokens[_Index] != Scanner.Equal)
                {
                    throw new ParserException("Expected '='");
                }

                _Index++;

                var endIndex = _Index;

                while (_Tokens[endIndex] != Scanner.Semi)
                {
                    endIndex++;
                }

                assign.Expr = ParseExpression(endIndex);

                result = assign;
            }
            else
            {
                throw new System.Exception("Parse error at token " + _Index + ": " + _Tokens[_Index]);
            }

            if (_Index < _Tokens.Count && _Tokens[_Index] == Scanner.Semi)
            {
                _Index++;

                if (_Index < _Tokens.Count && !_Tokens[_Index].Equals("end"))
                {
                    var sequence = new Sequence { First = result, Second = ParseStatement() };

                    result = sequence;
                }
            }

            return result;
        }

        private Expression ParseExpression(int endIndex)
        {
            if (_Index + 1 == endIndex)
            {
                return ParseExpression();
            }

            var  binExpr = new BinaryExpression { Left = ParseExpression() };

            if (_Tokens[_Index] == Scanner.Add)
            {
                binExpr.Op = BinaryOperator.Add;
            }
            else if (_Tokens[_Index] == Scanner.Div)
            {
                binExpr.Op = BinaryOperator.Div;
            }
            else if (_Tokens[_Index] == Scanner.Mul)
            {
                binExpr.Op = BinaryOperator.Mul;
            }
            else if (_Tokens[_Index] == Scanner.Sub)
            {
                binExpr.Op = BinaryOperator.Sub;
            }
            else
            {
                throw new ParserException("Expected binary operation");
            }

            _Index++;

            binExpr.Right = ParseExpression(endIndex);

            return binExpr;
        }
        private Expression ParseExpression()
        {
            if (_Index == _Tokens.Count)
            {
                throw new ParserException("Unexpected EOF - Expected Expression");
            }

            if (_Tokens[_Index] is StringBuilder)
            {
                return new StringLiteral { Value = _Tokens[_Index++].ToString() };
            }
            
            if (_Tokens[_Index] is int)
            {
                return new IntLiteral { Value = (int)_Tokens[_Index++] };
            }
            
            if (_Tokens[_Index] is string)
            {
                return new Variable { Ident = _Tokens[_Index++].ToString() };
            }

            throw new ParserException("Expected string literal, integer literal, or variable");
        }
    }
}
