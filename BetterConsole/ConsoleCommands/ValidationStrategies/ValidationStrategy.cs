namespace BetterConsole.Commands
{
    public abstract class ValidationStrategy
    {
        public abstract bool Validate(string input);
    }
}