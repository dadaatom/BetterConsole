using System;

namespace BetterConsole.ConsoleCommands.Exceptions
{
    public class ParameterOrderMismatchException : System.Exception
    {
        public ParameterOrderMismatchException() : base("Console parameter not organised properly.") { }
        public ParameterOrderMismatchException(string msg) : base(msg) { }
    }
}