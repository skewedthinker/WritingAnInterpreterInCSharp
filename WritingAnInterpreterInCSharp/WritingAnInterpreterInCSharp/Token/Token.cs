using System;
using System.Collections.Generic;
using System.Text;

namespace WritingAnInterpreterInCSharp.Token
{
    public class Token
    {
        public Token(TokenType type, string ch)
        {
            this.Type = type;
            this.Literal = ch;
        }

        public TokenType Type;

        public string Literal;
    }
}
