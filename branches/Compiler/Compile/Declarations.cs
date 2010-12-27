using System;

namespace Compiler.Compile
{
    public abstract class Statement
    {
    }

    public class DeclareVariable : Statement
    {
        public string Ident;
        public Expression Expr;
    }

    public class Print : Statement
    {
        public Expression Expr;
    }

    public class Assign : Statement
    {
        public string Ident;
        public Expression Expr;
    }

    public class ForLoop : Statement
    {
        public string Ident;
        public Expression From;
        public Expression To;
        public Statement Body;
    }

    public class ReadInt : Statement
    {
        public string Ident;
    }

    public class Sequence : Statement
    {
        public Statement First;
        public Statement Second;
    }

    public abstract class Expression
    {
    }

    public class StringLiteral : Expression
    {
        public string Value;
    }

    public class IntLiteral : Expression
    {
        public int Value;
    }

    public class Variable : Expression
    {
        public string Ident;
    }

    public class BinaryExpression : Expression
    {
        public Expression Left;
        public Expression Right;
        public BinaryOperator Op;
    }

    public enum BinaryOperator
    {
        Add,
        Sub,
        Mul,
        Div
    }

    public class ParserException : Exception
    {
        public ParserException(string message)
            : base(message)
        {
        }
    }

    public class GeneratorException : Exception
    {
        public GeneratorException(string message)
            : base(message)
        {
        }
    }

    public class ScannerException : Exception
    {
        public ScannerException(string message)
            : base(message)
        {
        }
    }
}