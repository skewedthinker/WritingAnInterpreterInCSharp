using Microsoft.VisualStudio.TestTools.UnitTesting;
using WritingAnInterpreterInCSharp.Lexer;
using WritingAnInterpreterInCSharp.Token;


namespace InterpreterTestProject
{
    [TestClass]
    public class LexerTest
    {
        struct TokenTest
        {
            public TokenTest(TokenType type, string literal)
            {
                expectedType = type;
                expectedLiteral = literal;
            }

            public TokenType expectedType;
            public string expectedLiteral;
        }

        [TestMethod]
        public void TestNextToken()
        {
            string input = "=+(){},;";

            var testArray = new TokenTest[]
            {
                new TokenTest(TokenType.ASSIGN, "="),
                new TokenTest(TokenType.PLUS, "+"),
                new TokenTest(TokenType.LPAREN, "("),
                new TokenTest(TokenType.RPAREN, ")"),
                new TokenTest(TokenType.LBRACE, "{"),
                new TokenTest(TokenType.RBRACE, "}"),
                new TokenTest(TokenType.COMMA, ","),
                new TokenTest(TokenType.SEMICOLON, ";"),
                new TokenTest(TokenType.EOF, "")
            };

            Lexer l = new Lexer(input);

            for (int i = 0; i < testArray.Length; i++)
            {
                Token tok = l.NextToken();

                Assert.AreEqual(testArray[i].expectedType, tok.Type);

                Assert.AreEqual(testArray[i].expectedLiteral, tok.Literal);
            }
        }
    }
}
