using System;

namespace BetterConsole.ConsoleCommands.Exceptions
{
    public class DuplicateCommandException : Exception
    {
        public DuplicateCommandException() : base("Duplicate command exists.") { }
    }
}