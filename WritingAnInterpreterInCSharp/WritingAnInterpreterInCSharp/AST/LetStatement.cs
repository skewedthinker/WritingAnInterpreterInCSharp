using System.Text;
using WritingAnInterpreterInCSharp.Tokens;

namespace WritingAnInterpreterInCSharp.AST
{
    public class LetStatement : IStatement
    {
        Token Token;
        public Identifier Name;
        public IExpression Value;

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

        public string OutputString()
        {
            var output = new StringBuilder();

            output.Append(this.TokenLiteral() + " ");

            output.Append(this.Name.OutputString());

            output.Append(" = ");

            if (this.Value != null)
                output.Append(this.Value.OutputString());

            output.Append(";");

            return output.ToString();
        }
    }
}
