using System;
using System.Collections.Generic;
using System.Text;
using WritingAnInterpreterInCSharp.Tokens;

namespace WritingAnInterpreterInCSharp.AST
{
    class ExpressionStatement : IStatement
    {
        Token Token;
        IExpression Expression;

        public void statementNode()
        {

        }

        public string TokenLiteral()
        {
            return this.Token.Literal;
        }

        public string OutputString()
        {
            if (this.Expression != null)
                return Expression.OutputString();

            return string.Empty;
        }
    }
}
