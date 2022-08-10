namespace BetterConsole.ConsoleCommands
{
    public class PingCommand : ConsoleCommand
    {
        public PingCommand() : base("ping") { }

        public override void Execute(CommandSignature signature)
        {
            BetterConsole.WriteLine("pong");
        }
    }
}