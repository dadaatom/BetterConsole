using System.Collections.Generic;

namespace BetterConsole.Commands
{
    /*
     * TODO:
     * Command issue event/class/struct? I'd like to incorporate time signatures
     * Subcommands
     * help command
     * command parameters
     */
    public abstract class ConsoleCommand
    {
        public string Command { get; }
        public string[] Aliases { get; }

        public CommandParameter[] Parameters { get; }

        public ConsoleCommand[] SubCommands { get; }

        private string _description;
        
        public ConsoleCommand(string command, string[] aliases, string description)
        {
            Command = command;
            Aliases = aliases;
            _description = description;
        }
        
        ConsoleCommand(string command, string description) : this(command, new string[0], description) { }
        ConsoleCommand(string command) : this(command, new string[0], "") { }
        
        /// <summary>
        /// Called when command signature is detected in input.
        /// </summary>
        /// <param name="signature">Signature read from the command line.</param>
        public abstract void Execute(string[] signature);
    }
}