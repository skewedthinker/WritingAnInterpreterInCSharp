using System;
using System.Collections.Generic;
using WritingAnInterpreterInCSharp.Tokens;

namespace WritingAnInterpreterInCSharp.AST
{
    public class Parser
    {
        public Parser(Lexer.Lexer lexer)
        {
            this.lexer = lexer;
            this.errors = new List<string>();

            this.nextToken();
            this.nextToken();
        }

        Lexer.Lexer lexer;

        Token curToken;
        Token peekToken;

        List<string> errors;
        public List<string> Errors() => this.errors;

        private void nextToken()
        {
            this.curToken = this.peekToken;
            this.peekToken = this.lexer.NextToken();
        }

        public Program ParseProgram()
        {
            Program program = new Program();
            program.Statements = new List<IStatement>();

            do
            {
                IStatement stmt = this.parseStatement();

                if (stmt != null)
                {
                    program.Statements.Add(stmt);
                }

                this.nextToken();
            } while (this.curTokenIs(TokenType.EOF) == false);

            return program;
        }

        private IStatement parseStatement()
        {
            if (this.curToken.Type.Equals(TokenType.LET))
                return this.parseLetStatement();
            else if (this.curToken.Type.Equals(TokenType.RETURN))
                return this.parseReturnStatement();
            else
                return null;
        }
        private LetStatement parseLetStatement()
        {
            LetStatement stmt = new LetStatement(this.curToken);

            if (this.expectPeek(TokenType.IDENT) == false)
                return null;

            stmt.Name = new Identifier(this.curToken, this.curToken.Literal);

            if (this.expectPeek(TokenType.ASSIGN) == false)
                return null;

            // TODO: We're skipping the expressions until we encounter a semicolon
            do
            {
                this.nextToken();
            } while (this.curTokenIs(TokenType.SEMICOLON) == false);

            return stmt;
        }

        private ReturnStatement parseReturnStatement()
        {
            ReturnStatement stmt = new ReturnStatement(this.curToken);

            this.nextToken();

            // TODO: Skipping the expressions until we encounter a semicolon
            do
            {
                this.nextToken();
            } while (this.curTokenIs(TokenType.SEMICOLON) == false);

            return stmt;
        }

        private bool curTokenIs(TokenType t)
        {
            return this.curToken.Type.Equals(t);
        }

        private bool peekTokenIs(TokenType t)
        {
            return this.peekToken.Type.Equals(t);
        }

        private bool expectPeek(TokenType t)
        {
            if (this.peekTokenIs(t))
            {
                this.nextToken();
                return true;
            }
            else
            {
                this.peekError(t);
                return false;
            }
        }

        private void peekError(TokenType t)
        {
            string message = $"expected next token to be {t}, got {this.peekToken.Type} instead";
            errors.Add(message);
        }
    }
}
