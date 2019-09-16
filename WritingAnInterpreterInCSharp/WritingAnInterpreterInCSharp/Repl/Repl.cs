using System;
using System.Collections.Generic;
using System.Text;
using WritingAnInterpreterInCSharp.Tokens;

namespace WritingAnInterpreterInCSharp.Repl
{
    class Repl
    {
        private const string prompt = ">> ";

        public static void Start()
        {
            while(true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (input == string.Empty)
                    return;

                var l = new Lexer.Lexer(input);

                Token token;

                do
                {
                    token = l.NextToken();
                    Console.WriteLine(token);
                } while (token.Type.Equals(TokenType.EOF) == false);
            }
        }

    }
}
