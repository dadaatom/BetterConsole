namespace BetterConsole.ConsoleCommands
{
    public abstract class ValidationStrategy
    {
        public abstract bool Validate(string input);
    }
}