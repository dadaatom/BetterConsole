using System;
using System.Collections.Generic;
using System.Linq;

namespace BetterConsole.ConsoleCommands
{
    /*
     * TODO:
     * help command
     * aliases
     * errors
     */
    public abstract class ConsoleCommand
    {
        public string Command { get; }
        
        public ConsoleCommand[] SubCommands { get; }
        
        public CommandParameter[] Parameters
        {
            get
            {
                return Parameters;
            }
            set
            {
                bool flag = false;
                for (int i = 0; i < value.Length; i++) {
                    if (!value[i].Required)
                    {
                        flag = true;
                    }
                    else if(flag)
                    {
                        throw new Exception("CommandParameterOrderException: Required parameters must be sorted before non-required fields.");
                    }
                }

                Parameters = value;
            }
        }

        public string Description { get; set; }

        public ConsoleCommand(string command) : this(command, new ConsoleCommand[0], new CommandParameter[0]) { }
        
        public ConsoleCommand(string command, ConsoleCommand[] subCommands, CommandParameter[] parameters)
        {
            Command = command;
            SubCommands = subCommands;
            Parameters = parameters;
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
            if (signature.Length > 0 && Command == signature[0])
            {
                string[] subSignature = new string[signature.Length - 1];

                for (int i = 0; i < subSignature.Length; i++)
                {
                    subSignature[i] = signature[i+1];
                }

                foreach (ConsoleCommand command in SubCommands)
                {
                    if (Command == signature[0])
                    {
                        command.AttemptExecute(subSignature);
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
                
                if (Parameters[i].ValidationStrategy != null && !Parameters[i].ValidationStrategy.Validate(parameters[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}