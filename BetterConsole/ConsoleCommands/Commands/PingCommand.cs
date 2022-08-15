namespace BetterConsole.ConsoleCommands
{
    public class PingCommand : ParameterizedCommand
    {
        public PingCommand() : base("ping")
        {
            Description = "Pings the console for a response.";
        }

        public override void Execute(CommandSignature signature)
        {
            BetterConsole.WriteLine("pong");
        }
    }
}