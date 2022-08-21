using System;

namespace BetterConsole.ConsoleCommands
{
    public class ExampleCommand : ParameterizedCommand
    {
        public ExampleCommand() : base("Multiply", "Creates copies of the letter A, B, or C.")
        {
            CommandParameter param1 = new CommandParameter("Letter", new WhitelistValidation(new []{"A","B","C"}), true);
            CommandParameter param2 = new CommandParameter("Count", new IntegerValidation(), true);
            SetParameters(new CommandParameter[] {param1, param2});
        }

        public override void Execute(CommandSignature signature)
        {
            string toDisplay = "";
            for (int i = 0; i < Int32.Parse(signature.Parameters[1]); i++)
            {
                toDisplay += signature.Parameters[0];
            }

            BetterConsole.WriteLine(toDisplay);
        }
    }
}