﻿using System;
using System.Collections.Generic;
using System.Text;
using WritingAnInterpreterInCSharp.Tokens;

namespace WritingAnInterpreterInCSharp.AST
{
    public class ReturnStatement : IStatement
    {
        Token Token;
        IExpression ReturnValue;

        public ReturnStatement(Token curToken)
        {
            this.Token = curToken;
        }

        public void statementNode()
        {

        }

        public string TokenLiteral()
        {
            return Token.Literal;
        }
    }
}
