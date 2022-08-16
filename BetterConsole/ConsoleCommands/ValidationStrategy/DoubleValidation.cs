using System;

namespace BetterConsole.ConsoleCommands
{
    public class DoubleValidation : ValidationStrategy
    {
        public override bool Validate(string input)
        {
            double x;
            return Double.TryParse(input, out x);
        }
    }
}