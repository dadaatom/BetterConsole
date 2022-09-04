using System;

namespace BetterConsole.ConsoleCommands
{
    public class BoolValidation : ValidationStrategy
    {
        public override bool Validate(string input)
        {
            bool x;
            return Boolean.TryParse(input, out x);
        }
    }
}