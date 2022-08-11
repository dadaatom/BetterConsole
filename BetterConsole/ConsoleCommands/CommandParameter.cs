namespace BetterConsole.ConsoleCommands
{
    public class CommandParameter
    {
        public ValidationStrategy ValidationStrategy;
        public bool Required;

        public CommandParameter() : this(null, false) { }

        public CommandParameter(ValidationStrategy validationStrategy, bool required)
        {
            ValidationStrategy = validationStrategy;
            Required = required;
        }
    }
}