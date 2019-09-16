using Microsoft.VisualStudio.TestTools.UnitTesting;
using WritingAnInterpreterInCSharp.Lexer;
using WritingAnInterpreterInCSharp.Tokens;


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
            const string input = @"let five = 5;
                let ten = 10;

                let add = fn(x, y) {
                    x + y;
                };

                let result = add(five, ten);
                !-/*5;
                5 < 10 > 5;

                if (5 < 10) {
                    return true;
                } else {
                    return false;
                }

                10 == 10;
                10 != 9;

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
                new TokenTest(TokenType.BANG, "!"),
                new TokenTest(TokenType.MINUS, "-"),
                new TokenTest(TokenType.SLASH, "/"),
                new TokenTest(TokenType.ASTERISK, "*"),
                new TokenTest(TokenType.INT, "5"),
                new TokenTest(TokenType.SEMICOLON, ";"),
                new TokenTest(TokenType.INT, "5"),
                new TokenTest(TokenType.LT, "<"),
                new TokenTest(TokenType.INT, "10"),
                new TokenTest(TokenType.GT, ">"),
                new TokenTest(TokenType.INT, "5"),
                new TokenTest(TokenType.SEMICOLON, ";"),
                new TokenTest(TokenType.IF, "if"),
                new TokenTest(TokenType.LPAREN, "("),
                new TokenTest(TokenType.INT, "5"),
                new TokenTest(TokenType.LT, "<"),
                new TokenTest(TokenType.INT, "10"),
                new TokenTest(TokenType.RPAREN, ")"),
                new TokenTest(TokenType.LBRACE, "{"),
                new TokenTest(TokenType.RETURN, "return"),
                new TokenTest(TokenType.TRUE, "true"),
                new TokenTest(TokenType.SEMICOLON, ";"),
                new TokenTest(TokenType.RBRACE, "}"),
                new TokenTest(TokenType.ELSE, "else"),
                new TokenTest(TokenType.LBRACE, "{"),
                new TokenTest(TokenType.RETURN, "return"),
                new TokenTest(TokenType.FALSE, "false"),
                new TokenTest(TokenType.SEMICOLON, ";"),
                new TokenTest(TokenType.RBRACE, "}"),
                new TokenTest(TokenType.INT, "10"),
                new TokenTest(TokenType.EQ, "=="),
                new TokenTest(TokenType.INT, "10"),
                new TokenTest(TokenType.SEMICOLON, ";"),
                new TokenTest(TokenType.INT, "10"),
                new TokenTest(TokenType.NOT_EQ, "!="),
                new TokenTest(TokenType.INT, "9"),
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
