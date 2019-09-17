using System.Collections.Generic;

namespace WritingAnInterpreterInCSharp.AST
{
    public class Program
    {
        public IList<IStatement> Statements;

        public string TokenLiteral()
        {
            if (this.Statements.Count > 0)
                return this.Statements[0].TokenLiteral();
            else
                return string.Empty;
        }
    }
}
