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
            string input = @"let five = 5;
                let ten = 10;

                let add = fn(x, y) {
                    x + y;
                };

                let result = add(five, ten);
                ";

            var testArray = new TokenTest[]
            {
                new TokenTest(TokenType.LET, "let"),
                new TokenTest(TokenType.IDENT, "five"),
                new TokenTest(TokenType.ASSIGN, "="),
                new TokenTest(TokenType.INT, "5"),
                new TokenTest(TokenType.SEMICOLON, ";"),
                new TokenTest(TokenType.LET, "let"),
                new TokenTest(TokenType.IDENT, "ten"),
                new TokenTest(TokenType.ASSIGN, "="),
                new TokenTest(TokenType.INT, "10"),
                new TokenTest(TokenType.SEMICOLON, ";"),
                new TokenTest(TokenType.LET, "let"),
                new TokenTest(TokenType.IDENT, "add"),
                new TokenTest(TokenType.ASSIGN, "="),
                new TokenTest(TokenType.FUNCTION, "fn"),
                new TokenTest(TokenType.LPAREN, "("),
                new TokenTest(TokenType.IDENT, "x"),
                new TokenTest(TokenType.COMMA, ","),
                new TokenTest(TokenType.IDENT, "y"),
                new TokenTest(TokenType.RPAREN, ")"),
                new TokenTest(TokenType.LBRACE, "{"),
                new TokenTest(TokenType.IDENT, "x"),
                new TokenTest(TokenType.PLUS, "+"),
                new TokenTest(TokenType.IDENT, "y"),
                new TokenTest(TokenType.SEMICOLON, ";"),
                new TokenTest(TokenType.RBRACE, "}"),
                new TokenTest(TokenType.SEMICOLON, ";"),
                new TokenTest(TokenType.LET, "let"),
                new TokenTest(TokenType.IDENT, "result"),
                new TokenTest(TokenType.ASSIGN, "="),
                new TokenTest(TokenType.IDENT, "add"),
                new TokenTest(TokenType.LPAREN, "("),
                new TokenTest(TokenType.IDENT, "five"),
                new TokenTest(TokenType.COMMA, ","),
                new TokenTest(TokenType.IDENT, "ten"),
                new TokenTest(TokenType.RPAREN, ")"),
                new TokenTest(TokenType.SEMICOLON, ";"),
                new TokenTest(TokenType.EOF, ""),
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
