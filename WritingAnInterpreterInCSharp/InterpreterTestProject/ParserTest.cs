using Microsoft.VisualStudio.TestTools.UnitTesting;
using WritingAnInterpreterInCSharp.Lexer;
using WritingAnInterpreterInCSharp.AST;
using System;
using System.Text;

namespace InterpreterTestProject
{
    [TestClass]
    public class ParserTest
    {
        struct IdentifierTest
        {
            public IdentifierTest(string id)
            {
                this.expectedIdentifier = id;
            }

            public string expectedIdentifier;
        }

        [TestMethod]
        public void TestLetStatements()
        {
            string input = @"
                let x = 5;
                let y = 10;
                let foobar = 838383;
";

            Lexer lexer = new Lexer(input);
            Parser parser = new Parser(lexer);

            Program program = parser.ParseProgram();
            checkParserErrors(parser);

            if (program == null)
                Assert.Fail("ParseProgram() returned nil");
            if (program.Statements.Count != 3)
                Assert.Fail($"program.Statements  does not contain 3 statements. got {program.Statements.Count}");

            IdentifierTest[] identifierTests = new IdentifierTest[]
            {
                new IdentifierTest("x"),
                new IdentifierTest("y"),
                new IdentifierTest("foobar")
            };

            for (int i = 0; i < identifierTests.Length; i++)
            {
                IStatement stmt = program.Statements[i];
                TestLetStatements(stmt, identifierTests[i].expectedIdentifier);
            }
        }

        private void checkParserErrors(Parser parser)
        {
            var errors = parser.Errors();
            if (errors.Count == 0)
                return;

            StringBuilder errorMessage = new StringBuilder();
            errorMessage.AppendLine($"parser had {errors.Count} errors");

            foreach (string error in errors)
            {
                errorMessage.AppendLine(error);
            }

            Assert.Fail(errorMessage.ToString());
        }

        private void TestLetStatements(IStatement stmt, string name)
        {
            Assert.AreEqual("let", stmt.TokenLiteral());

            Assert.IsInstanceOfType(stmt, typeof(LetStatement));

            LetStatement letStmt = (LetStatement)stmt;

            Assert.AreEqual(name, letStmt.Name.Value);

            Assert.AreEqual(name, letStmt.Name.TokenLiteral());
        }
    }
}
