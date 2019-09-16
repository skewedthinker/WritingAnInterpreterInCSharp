using System;

namespace WritingAnInterpreterInCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string user = "user";
            Console.WriteLine($"Hello {user}! This is the Monkey programming language!");
            Console.WriteLine("Feel free to type in commands");
            Repl.Repl.Start();
        }
    }
}
