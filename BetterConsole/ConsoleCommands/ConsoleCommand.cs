using System.Collections.Generic;
using BetterConsole.ConsoleCommands.Exceptions;

namespace BetterConsole.ConsoleCommands
{
    /*
     * TODO:
     * help command
     * aliases
     * array validation strategy
     * return const list of parameters in signature.
     */
    public abstract class ConsoleCommand
    {
        public string Header { get; }
        
        public ConsoleCommand[] SubCommands { get; private set; }

        public string Description { get; set; } = "";

        public ConsoleCommand(string header) : this(header, new ConsoleCommand[]{}) { }
        
        public ConsoleCommand(string header, ConsoleCommand[] subCommands)
        {
            Header = header;
            SetSubCommands(subCommands);
        }

        /// <summary>
        /// Called when command signature is detected in input.
        /// </summary>
        /// <param name="signature">Signature read from the command line.</param>
        public abstract void Execute(CommandSignature signature);

        /// <summary>
        /// Matches signature to the console command and returns the .
        /// </summary>
        /// <param name="signature">Signature to match command with</param>
        /// <returns>A command match containing all the information concerning the match.</returns>
        public CommandMatch MatchSignature(string[] signature)
        {
            string[] subSignature = new string[signature.Length - 1];

            for (int i = 0; i < subSignature.Length; i++)
            {
                subSignature[i] = signature[i+1];
            }
            
            if (signature.Length > 0 && Header == signature[0])
            {
                foreach (ConsoleCommand command in SubCommands)
                {
                    CommandMatch match = MatchSignature(subSignature);
                    if (match.Success)
                    {
                        return match;
                    }
                }

                if (ValidateSignature(subSignature))
                {
                    return new CommandMatch(true, this, subSignature);
                }
            }

            return new CommandMatch(false, this, subSignature);
        }
        
        public virtual bool ValidateSignature(string[] signature)
        {
            return true;
        }

        /// <summary>
        /// Sets the subcommands.
        /// </summary>
        /// <param name="commands">Array of new commands to set.</param>
        /// <exception cref="DuplicateCommandException">Thrown when another command already exists with the same header.</exception>
        public void SetSubCommands(ConsoleCommand[] commands)
        {
            List<string> list = new List<string>();
            foreach (ConsoleCommand command in commands) {
                if (list.Contains(command.Header))
                {
                    throw new DuplicateCommandException();
                }
                list.Add(command.Header);
            }

            SubCommands = commands;
        }
    }
}