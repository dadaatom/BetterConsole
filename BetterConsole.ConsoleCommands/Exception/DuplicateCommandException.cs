using System;

namespace BetterConsole.ConsoleCommands.Exception
{
    public class DuplicateCommandException : System.Exception
    {
        public DuplicateCommandException(string msg) : base(msg) { }

        public DuplicateCommandException() : base("Duplicate command exists.") { }
    }
}