using BetterConsole.ConsoleCommands.Exceptions;

namespace BetterConsole.ConsoleCommands
{
    public abstract class ParameterizedCommand : ConsoleCommand
    {
        public CommandParameter[] Parameters { get; private set; }
        
        public ParameterizedCommand(string header, string description = "") : this(header, new ConsoleCommand[0], new CommandParameter[0], description) { }

        public ParameterizedCommand(string header, ConsoleCommand[] subCommands, CommandParameter[] parameters, string description = "") : base(
            header, subCommands, description)
        {
            SetParameters(parameters);
        }
        
        /// <summary>
        /// Validates the sub-signature in reference to the command parameters.
        /// </summary>
        /// <param name="signature">Command parameters to be validated.</param>
        /// <returns>Boolean of parameters validity.</returns>
        public override bool ValidateSignature(string[] signature)
        {
            if (signature.Length > Parameters.Length)
            {
                return false;
            }

            for (int i = 0; i < Parameters.Length; i++) {
                if (Parameters[i].Required && i >= signature.Length)
                {
                    return false;
                }
                
                if (i < signature.Length && Parameters[i].ValidationStrategy != null && !Parameters[i].ValidationStrategy.Validate(signature[i]))
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
    }
}