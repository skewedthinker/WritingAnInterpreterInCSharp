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
        private char ch;            // current char under examination

        private void readChar()
        {
            if (this.readPosition >= this.input.Length)
                this.ch = Char.MinValue;
            else
                this.ch = this.input[this.readPosition];

            this.position = this.readPosition;
            this.readPosition += 1;
        }

        private char peekChar()
        {
            if (this.readPosition >= this.input.Length)
                return Char.MinValue;
            else
                return this.input[this.readPosition];
        }

        private string readIdentifier()
        {
            int curPosition = this.position;

            while (isLetter(this.ch))
            {
                this.readChar();
            }

            return this.input.Substring(curPosition, this.position - curPosition);
        }

        private bool isLetter(char check)
        {
            return ('a' <= check && check <= 'z') ||
                ('A' <= check && check <= 'Z') ||
                (check == '_');
        }

        private string readNumber()
        {
            int curPosition = this.position;

            while (Char.IsDigit(this.ch))
            {
                this.readChar();
            }

            return this.input.Substring(curPosition, this.position - curPosition);
        }

        private void skipWhitespace()
        {
            while (this.ch == ' ' || this.ch == '\t' || this.ch == '\n' || this.ch == '\r')
            {
                this.readChar();
            }
        }

        public Token.Token NextToken()
        {
            Token.Token token;

            this.skipWhitespace();

            switch (this.ch)
            {
                case '=':
                    if (this.peekChar() == '=')
                    {
                        string literal = this.ch.ToString();
                        this.readChar();
                        literal += this.ch.ToString();
                        token = new Token.Token(TokenType.EQ, literal);
                    }
                    else
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
                case '-':
                    token = new Token.Token(TokenType.MINUS, this.ch.ToString());
                    break;
                case '!':
                    if (this.peekChar() == '=')
                    {
                        string literal = this.ch.ToString();
                        this.readChar();
                        literal += this.ch.ToString();
                        token = new Token.Token(TokenType.NOT_EQ, literal);
                    }
                    else
                        token = new Token.Token(TokenType.BANG, this.ch.ToString());
                    break;
                case '/':
                    token = new Token.Token(TokenType.SLASH, this.ch.ToString());
                    break;
                case '*':
                    token = new Token.Token(TokenType.ASTERISK, this.ch.ToString());
                    break;
                case '<':
                    token = new Token.Token(TokenType.LT, this.ch.ToString());
                    break;
                case '>':
                    token = new Token.Token(TokenType.GT, this.ch.ToString());
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
                    if (isLetter(this.ch))
                    {
                        string literal = this.readIdentifier();
                        TokenType type = Token.Token.LookupIdent(literal);
                        return new Token.Token(type, literal);
                    }
                    else if (Char.IsDigit(this.ch))
                        return new Token.Token(TokenType.INT, this.readNumber());
                    else
                        token = new Token.Token(TokenType.ILLEGAL, ch.ToString());
                    break;
            }

            this.readChar();
            return token;
        }
    }
}
