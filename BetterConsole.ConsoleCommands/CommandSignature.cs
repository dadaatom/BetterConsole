using System;

namespace BetterConsole.ConsoleCommands
{
    public class CommandSignature
    {
        public string[] Parameters { get; }
        public DateTime TimeStamp { get; }

        public CommandSignature(string[] parameters)
        {
            Parameters = parameters;
            TimeStamp = DateTime.Now;
        }
    }
}