using System;
using System.Collections.Generic;
using System.Text;

namespace WritingAnInterpreterInCSharp.Token
{
    public class TokenType
    {
        public TokenType(string value) { Value = value; }

        private string Value { get; set; }

        public static TokenType ILLEGAL { get { return new TokenType("ILLEGAL"); } }
        public static TokenType EOF { get { return new TokenType("EOF"); } }

        // Identifiers + literals
        public static TokenType IDENT { get { return new TokenType("IDENT"); } }
        public static TokenType INT { get { return new TokenType("INT"); } }

        // Operators
        public static TokenType ASSIGN { get { return new TokenType("="); } }
        public static TokenType PLUS { get { return new TokenType("+"); } }

        // Delimeters
        public static TokenType COMMA { get { return new TokenType(","); } }
        public static TokenType SEMICOLON { get { return new TokenType(";"); } }

        public static TokenType LPAREN { get { return new TokenType("("); } }
        public static TokenType RPAREN { get { return new TokenType(")"); } }
        public static TokenType LBRACE { get { return new TokenType("{"); } }
        public static TokenType RBRACE { get { return new TokenType("}"); } }

        // Keywords
        public static TokenType FUNCTION { get { return new TokenType("FUNCTION"); } }
        public static TokenType LET { get { return new TokenType("LET"); } }

        public override string ToString()
        {
            return this.Value;
        }

        public override bool Equals(object obj)
        {
            if (obj is TokenType other)
                return this.Value.Equals(other.Value);
            else
                return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
