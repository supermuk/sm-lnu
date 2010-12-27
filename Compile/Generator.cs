using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.IO;

namespace Compiler.Compile
{
    public sealed class Generator
    {
        readonly ILGenerator _Il = null;
        readonly Dictionary<string, LocalBuilder> _SymbolsTable;

        public Generator(Statement stmt, string moduleName)
        {
            if (Path.GetFileName(moduleName) != moduleName)
            {
                throw new GeneratorException("Only can output to current directory");
            }

            var assemblyName = new AssemblyName(Path.GetFileNameWithoutExtension(moduleName));
            var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Save);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule(moduleName);
            var typeBuilder = moduleBuilder.DefineType("OrestIgor");

            var methodBuilder = typeBuilder.DefineMethod("Main", MethodAttributes.Static, typeof(void), System.Type.EmptyTypes);

            // CodeGenerator
            _Il = methodBuilder.GetILGenerator();
            _SymbolsTable = new Dictionary<string, LocalBuilder>();

            // Go Compile!
            GenerateStatement(stmt);

            _Il.Emit(OpCodes.Ret);
            typeBuilder.CreateType();
            moduleBuilder.CreateGlobalFunctions();
            assemblyBuilder.SetEntryPoint(methodBuilder);
            assemblyBuilder.Save(moduleName);
            
            _SymbolsTable = null;
            _Il = null;
        }


        private void GenerateStatement(Statement stmt)
        {
            if (stmt is Sequence)
            {
                var seq = (Sequence)stmt;
                
                GenerateStatement(seq.First);
                GenerateStatement(seq.Second);
            }		
            else if (stmt is DeclareVariable)
            {
                var declare = (DeclareVariable)stmt;
                
                _SymbolsTable[declare.Ident] = _Il.DeclareLocal(TypeOfExpr(declare.Expr));

                var assign = new Assign { Ident = declare.Ident, Expr = declare.Expr };
                
                GenerateStatement(assign);
            }        
            else if (stmt is Assign)
            {
                var assign = (Assign)stmt;

                GenerateExpression(assign.Expr, TypeOfExpr(assign.Expr));
                Store(assign.Ident, TypeOfExpr(assign.Expr));
            }			
            else if (stmt is Print)
            {
                GenerateExpression(((Print)stmt).Expr, typeof(string));
                _Il.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new [] { typeof(string) }));
            }	

            else if (stmt is ReadInt)
            {
                _Il.Emit(OpCodes.Call, typeof(Console).GetMethod("ReadLine", BindingFlags.Public | BindingFlags.Static, null, new Type[] { }, null));
                _Il.Emit(OpCodes.Call, typeof(int).GetMethod("Parse", BindingFlags.Public | BindingFlags.Static, null, new [] { typeof(string) }, null));
                Store(((ReadInt)stmt).Ident, typeof(int));
            }
            else if (stmt is ForLoop)
            {
                var forLoop = (ForLoop)stmt;
                var assign = new Assign { Ident = forLoop.Ident, Expr = forLoop.From };
                GenerateStatement(assign);

                var test = _Il.DefineLabel();
                _Il.Emit(OpCodes.Br, test);

                var body = _Il.DefineLabel();
                _Il.MarkLabel(body);
                GenerateStatement(forLoop.Body);

                _Il.Emit(OpCodes.Ldloc, _SymbolsTable[forLoop.Ident]);
                _Il.Emit(OpCodes.Ldc_I4, 1);
                _Il.Emit(OpCodes.Add);
                Store(forLoop.Ident, typeof(int));

                _Il.MarkLabel(test);
                _Il.Emit(OpCodes.Ldloc, _SymbolsTable[forLoop.Ident]);
                GenerateExpression(forLoop.To, typeof(int));
                _Il.Emit(OpCodes.Blt, body);
            }
            else
            {
                throw new GeneratorException("Cant generate a " + stmt.GetType().Name);
            }
        }    
    	
        private void Store(string name, Type type)
        {
            if (!_SymbolsTable.ContainsKey(name))
            {
                throw new GeneratorException("Undeclared variable '" + name + "'");
            }
            
            var localBuilder = _SymbolsTable[name];

            if (localBuilder.LocalType == type)
            {
                _Il.Emit(OpCodes.Stloc, _SymbolsTable[name]);
            }
            else
            {
                throw new GeneratorException("'" + name + "' is of type " + localBuilder.LocalType.Name + " but attempted to store value of type " + type.Name);
            }
        }


        private void GenerateExpression(Expression expr, Type expectedType)
        {
            Type deliveredType;
		
            if (expr is StringLiteral)
            {
                deliveredType = typeof(string);
                _Il.Emit(OpCodes.Ldstr, ((StringLiteral)expr).Value);
            }
            else if (expr is IntLiteral)
            {
                deliveredType = typeof(int);
                _Il.Emit(OpCodes.Ldc_I4, ((IntLiteral)expr).Value);
            }        
            else if (expr is Variable)
            {
                var ident = ((Variable)expr).Ident;
                deliveredType = TypeOfExpr(expr);

                if (!_SymbolsTable.ContainsKey(ident))
                {
                    throw new GeneratorException("Undeclared variable '" + ident + "'");
                }

                _Il.Emit(OpCodes.Ldloc, _SymbolsTable[ident]);
            } 
            else if (expr is BinaryExpression)
            {
                deliveredType = typeof(int);

                GenerateExpression(((BinaryExpression)expr).Left, typeof(int));
                GenerateExpression(((BinaryExpression)expr).Right, typeof(int));
                
                var binExpr = (BinaryExpression) expr;

                switch (binExpr.Op)
                {
                    case BinaryOperator.Add:
                        _Il.Emit(OpCodes.Add);
                        break;
                    case BinaryOperator.Sub:
                        _Il.Emit(OpCodes.Sub);
                        break;
                    case BinaryOperator.Mul:
                        _Il.Emit(OpCodes.Mul);
                        break;
                    case BinaryOperator.Div:
                        _Il.Emit(OpCodes.Div);
                        break;
                }
            }
            else
            {
                throw new GeneratorException("Unable to generate " + expr.GetType().Name);
            }

            if (deliveredType != expectedType)
            {
                if (deliveredType == typeof(int) && expectedType == typeof(string))
                {
                    _Il.Emit(OpCodes.Box, typeof(int));
                    _Il.Emit(OpCodes.Callvirt, typeof(object).GetMethod("ToString"));
                }
                else
                {
                    throw new GeneratorException("Can't convert type " + deliveredType.Name + " to " + expectedType.Name);
                }
            }
        }

        private Type TypeOfExpr(Expression expr)
        {
            if (expr is StringLiteral)
            {
                return typeof(string);
            }
            
            if (expr is IntLiteral)
            {
                return typeof(int);
            }
            
            if (expr is Variable)
            {
                var var = (Variable)expr;
                
                if (_SymbolsTable.ContainsKey(var.Ident))
                {
                    return _SymbolsTable[var.Ident].LocalType;
                }

                throw new GeneratorException("Undeclared variable '" + var.Ident + "'");
            }
            
            if (expr is BinaryExpression)
            {
                return typeof(int);
            }

            throw new GeneratorException("Unable to find the type of " + expr.GetType().Name);
        }	
    }
}
