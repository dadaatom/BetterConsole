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
        
        public CommandParameter[] Parameters { get; private set; }

        public string Description { get; set; }

        public ConsoleCommand(string header) : this(header, new ConsoleCommand[]{}, new CommandParameter[]{}) { }
        
        public ConsoleCommand(string header, ConsoleCommand[] subCommands, CommandParameter[] parameters)
        {
            Header = header;
            SetSubCommands(subCommands);
            SetParameters(parameters);
        }

        /// <summary>
        /// Called when command signature is detected in input.
        /// </summary>
        /// <param name="signature">Signature read from the command line.</param>
        public abstract void Execute(CommandSignature signature);
        
        /// <summary>
        /// Attempts to execute the function given the complete command signature.
        /// </summary>
        /// <param name="signature">Command signature in the form of a string array.</param>
        /// <returns>Boolean of parameters validity.</returns>
        public bool AttemptExecute(string[] signature)
        {
            if (signature.Length > 0 && Header == signature[0])
            {
                string[] subSignature = new string[signature.Length - 1];

                for (int i = 0; i < subSignature.Length; i++)
                {
                    subSignature[i] = signature[i+1];
                }

                foreach (ConsoleCommand command in SubCommands)
                {
                    if (command.AttemptExecute(subSignature))
                    {
                        return true;
                    }
                }

                if (!ValidateParameters(subSignature))
                {
                    return false;
                }

                Execute(new CommandSignature(subSignature));
                return true;
            }

            return false;
        }

        /// <summary>
        /// Validates the sub-signature in reference to the command parameters.
        /// </summary>
        /// <param name="parameters">Command parameters to be validated.</param>
        /// <returns>Boolean of parameters validity.</returns>
        public bool ValidateParameters(string[] parameters)
        {
            if (parameters.Length > Parameters.Length)
            {
                return false;
            }

            for (int i = 0; i < Parameters.Length; i++) {
                if (Parameters[i].Required && i >= parameters.Length)
                {
                    return false;
                }
                
                if (i < parameters.Length && Parameters[i].ValidationStrategy != null && !Parameters[i].ValidationStrategy.Validate(parameters[i]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Sets the command parameters.
        /// </summary>
        /// <param name="parameters">Array of new parameters to set.</param>
        /// <exception cref="ParameterOrderMismatchException">Thrown when an optional parameter is found before a required parameter.</exception>
        public void SetParameters(CommandParameter[] parameters)
        {
            bool flag = false;
            foreach (CommandParameter param in parameters) {
                if (param.Required)
                {
                    if (flag)
                    {
                        throw new ParameterOrderMismatchException("Required parameter cannot follow an optional parameter.");
                    }
                }
                else
                {
                    flag = true;
                }
            }

            Parameters = parameters;
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