using System.Collections.Generic;
using System.Text;

namespace WritingAnInterpreterInCSharp.AST
{
    public class Program : INode
    {
        public IList<IStatement> Statements;

        public string TokenLiteral()
        {
            if (this.Statements.Count > 0)
                return this.Statements[0].TokenLiteral();
            else
                return string.Empty;
        }

        public string OutputString()
        {
            var output = new StringBuilder();

            foreach (IStatement statement in this.Statements)
                output.Append(statement.OutputString());

            return output.ToString();
        }
    }
}
