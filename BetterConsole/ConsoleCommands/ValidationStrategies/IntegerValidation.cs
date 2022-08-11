using System;

namespace BetterConsole.ConsoleCommands
{
    public class IntegerValidation : ValidationStrategy
    {
        public override bool Validate(string input)
        {
            int x;
            return Int32.TryParse(input, out x);
        }
    }
}