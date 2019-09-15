using System;
using System.Collections.Generic;
using System.Text;
using WritingAnInterpreterInCSharp.Token;

namespace WritingAnInterpreterInCSharp.Lexer
{
    public class Lexer
    {
        public Lexer(string input)
        {
            this.input = input;
            this.readChar();
        }

        private string input;
        private int position;       // current position in input (points to current char)
        private int readPosition;   // current reading position in input (after current char)
        private char ch;             // current char under examination

        private void readChar()
        {
            if (this.readPosition >= this.input.Length)
                this.ch = Char.MinValue;
            else
                this.ch = this.input[this.readPosition];

            this.position = this.readPosition;
            this.readPosition += 1;
        }

        public Token.Token NextToken()
        {
            Token.Token token;

            switch (this.ch)
            {
                case '=':
                    token = new Token.Token(TokenType.ASSIGN, ch.ToString());
                    break;
                case ';':
                    token = new Token.Token(TokenType.SEMICOLON, this.ch.ToString());
                    break;
                case '(':
                    token = new Token.Token(TokenType.LPAREN, this.ch.ToString());
                    break;
                case ')':
                    token = new Token.Token(TokenType.RPAREN, this.ch.ToString());
                    break;
                case ',':
                    token = new Token.Token(TokenType.COMMA, this.ch.ToString());
                    break;
                case '+':
                    token = new Token.Token(TokenType.PLUS, this.ch.ToString());
                    break;
                case '{':
                    token = new Token.Token(TokenType.LBRACE, this.ch.ToString());
                    break;
                case '}':
                    token = new Token.Token(TokenType.RBRACE, this.ch.ToString());
                    break;
                case Char.MinValue:
                    token = new Token.Token(TokenType.EOF, "");
                    break;
                default:
                    token = new Token.Token(TokenType.ILLEGAL, ch.ToString());
                    break;
            }

            this.readChar();
            return token;
        }
    }
}
