using System;

namespace BetterConsole.ConsoleCommands.Exceptions
{
    public class DuplicateCommandException : Exception
    {
        public DuplicateCommandException(string msg) : base(msg) { }

        public DuplicateCommandException() : base("Duplicate command exists.") { }
    }
}