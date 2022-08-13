namespace BetterConsole.ConsoleCommands
{
    public class HelpCommand : ConsoleCommand
    {
        public HelpCommand(string header) : base(header) { }

        public override void Execute(CommandSignature signature)
        {
            throw new System.NotImplementedException();
        }
    }
}