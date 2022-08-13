namespace BetterConsole.ConsoleCommands
{
    public class CommandParameter
    {
        public ValidationStrategy ValidationStrategy { get; }
        public bool Required { get; }
        
        public CommandParameter(ValidationStrategy validationStrategy = null, bool required = false)
        {
            ValidationStrategy = validationStrategy;
            Required = required;
        }
    }
}