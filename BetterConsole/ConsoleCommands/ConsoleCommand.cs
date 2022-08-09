using System.Linq;

namespace BetterConsole.ConsoleCommands
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
        
        public ConsoleCommand[] SubCommands { get; }
        
        public CommandParameter[] Parameters { get; }

        public string Description { get; set; }

        public ConsoleCommand(string command, string[] aliases)
        {
            Command = command;
            Aliases = aliases;
        }
        
        ConsoleCommand(string command) : this(command, new string[0]) { }

        /// <summary>
        /// Called when command signature is detected in input.
        /// </summary>
        /// <param name="signature">Signature read from the command line.</param>
        public abstract void Execute(string[] signature);

        public bool Matches(string[] signature)
        {
            if (signature.Length > 0 && (Command == signature[0] || Aliases.Contains(signature[0])))
            {
                foreach (ConsoleCommand command in SubCommands)
                {
                    if (Command == signature[0] || Aliases.Contains(signature[0]))
                    {
                        return true;
                    }
                }

                for (int i = 0; i < Parameters.Length; i++) {
                    if (!Parameters[i].ValidationStrategy.Validate(signature[i+1]))
                    {
                        return false;
                    }
                }
                
                return true;
            }

            return false;
        }
    }
}