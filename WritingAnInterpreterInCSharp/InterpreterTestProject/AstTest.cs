using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WritingAnInterpreterInCSharp.AST;
using WritingAnInterpreterInCSharp.Tokens;

namespace InterpreterTestProject
{
    [TestClass]
    public class AstTest
    {
        [TestMethod]
        public void TestString()
        {
            var program = new Program()
            {
                Statements = new IStatement[]
                {
                    new LetStatement(new Token(TokenType.LET, "let"))
                    {
                        Name = new Identifier(new Token(TokenType.IDENT, "myVar"), "myVar"),
                        Value = new Identifier(new Token(TokenType.IDENT, "anotherVar"), "anotherVar") 
                    }
                }
            };

            Assert.AreEqual("let myVar = anotherVar;", program.OutputString());
        }
    }
}
