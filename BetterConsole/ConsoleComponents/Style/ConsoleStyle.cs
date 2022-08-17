using System;

namespace BetterConsole.ConsoleComponents
{
    public class ConsoleStyle
    {
        public ComponentColor DefaultColor { get; set; }

        public ConsoleStyle(ComponentColor color)
        {
            DefaultColor = color;
        }
    }
}