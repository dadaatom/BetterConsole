namespace BetterConsole.Commands
{
    public abstract class ConsoleCommand
    {
        public string Command { get; }
        public string[] Aliases { get; }
        
        private string _description;
        
        ConsoleCommand(string command, string[] aliases, string description)
        {
            Command = command;
            Aliases = aliases;
            _description = description;
        }
        ConsoleCommand(string command, string description) : this(command, new string[0], description) { }
        ConsoleCommand(string command) : this(command, new string[0], "") { }

        public abstract void Execute(string[] arguments);
    }
}