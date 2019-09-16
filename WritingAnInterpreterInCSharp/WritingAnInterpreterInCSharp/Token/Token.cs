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

        public static Dictionary<string, TokenType> keywords = new Dictionary<string, TokenType>()
        {
            { "fn", TokenType.FUNCTION },
            { "let", TokenType.LET },
            { "true", TokenType.TRUE },
            { "false", TokenType.FALSE },
            { "if", TokenType.IF },
            { "else", TokenType.ELSE },
            { "return", TokenType.RETURN }
        };

        public static TokenType LookupIdent(string ident)
        {
            if (keywords.TryGetValue(ident, out TokenType value))
            {
                return value;
            }

            return TokenType.IDENT;
        }
    }
}
