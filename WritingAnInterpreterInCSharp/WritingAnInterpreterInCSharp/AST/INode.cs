﻿namespace WritingAnInterpreterInCSharp.AST
{
    public interface INode
    {
        string TokenLiteral();
        string OutputString();
    }
}
