using System;

namespace BetterConsole.ConsoleComponents
{
    public class ConsoleStyle
    {
        public ComponentColor DefaulColor { get; set; }

        public ConsoleStyle(ComponentColor color)
        {
            DefaulColor = color;
        }
    }
}