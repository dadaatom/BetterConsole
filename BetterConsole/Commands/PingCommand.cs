using System;

namespace BetterConsole.Commands
{
    public class PingCommand : ConsoleCommand
    {
        public PingCommand() : base("ping", new string[]{"p"}, "Pings the console for a response.") { }

        public override void Execute(string[] signature)
        {
            Console.WriteLine("pong");
        }
    }
}