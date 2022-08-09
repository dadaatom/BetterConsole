namespace BetterConsole.ConsoleCommands
{
    public class PingCommand : ConsoleCommand
    {
        public PingCommand() : base("ping", new string[]{"p"}) { }

        public override void Execute(string[] signature)
        {
            BetterConsole.WriteLine("pong");
        }
    }
}