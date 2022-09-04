namespace BetterConsole.ConsoleCommands
{
    public class CommandParameter
    {
        public string Label { get; }
        public ValidationStrategy ValidationStrategy { get; }
        public bool Required { get; }
        
        public CommandParameter(string label, ValidationStrategy validationStrategy = null, bool required = false)
        {
            Label = label;
            ValidationStrategy = validationStrategy;
            Required = required;
        }
    }
}