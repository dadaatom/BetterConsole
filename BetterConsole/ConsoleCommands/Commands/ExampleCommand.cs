using System;

namespace BetterConsole.ConsoleCommands
{
    public class ExampleCommand : ConsoleCommand
    {
        public ExampleCommand() : base("test")
        {
            CommandParameter param1 = new CommandParameter(new WhitelistValidation(new []{"A","B","C"}), true);
            CommandParameter param2 = new CommandParameter(new IntegerValidation(), true);
            SetParameters(new CommandParameter[] {param1, param2});

            //ConsoleCommand command = new PingCommand();
            //SetSubCommands(new []{command});
        }

        public override void Execute(CommandSignature signature)
        {
            string toDisplay = "";
            for (int i = 0; i < Int32.Parse(signature.Parameters[0]); i++)
            {
                toDisplay += signature.Parameters[1];
            }

            BetterConsole.WriteLine("Success: " + toDisplay);
        }
    }
}