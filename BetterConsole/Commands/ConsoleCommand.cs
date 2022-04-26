namespace BetterConsole.Commands
{
    public abstract class ConsoleCommand
    {
        private string _command;
        private string[] _aliases;
        
        private string _description;
        
        ConsoleCommand(string command, string[] aliases, string description)
        {
            _command = command;
            _aliases = aliases;
        }
        ConsoleCommand(string command, string description) : this(command, new string[0], description) { }
        ConsoleCommand(string command) : this(command, new string[0], "") { }

        public abstract void Execute(string[] arguments);
    }
}