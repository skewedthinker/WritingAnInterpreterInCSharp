using WritingAnInterpreterInCSharp.Tokens;

namespace WritingAnInterpreterInCSharp.AST
{
    public class LetStatement : IStatement
    {
        Token Token;
        public Identifier Name;
        IExpression Value;

        public LetStatement(Token curToken)
        {
            this.Token = curToken;
        }

        public void statementNode()
        {

        }

        public string TokenLiteral()
        {
            return this.Token.Literal;
        }
    }
}
