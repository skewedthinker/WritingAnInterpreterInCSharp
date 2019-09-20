using WritingAnInterpreterInCSharp.Tokens;

namespace WritingAnInterpreterInCSharp.AST
{
    public struct Identifier : IExpression
    {
        Token Token;
        public string Value;

        public Identifier(Token curToken, string literal)
        {
            this.Token = curToken;
            this.Value = literal;
        }

        public void expressionNode()
        {
        }

        public string TokenLiteral()
        {
            return this.Token.Literal;
        }

        public string OutputString()
        {
            return Value;
        }
    }
}
