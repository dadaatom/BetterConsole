using System;

namespace BetterConsole.ConsoleComponents
{
    public class StaticColor : ComponentColor
    {
        public ConsoleColor Color { get; }

        public StaticColor(ConsoleColor color)
        {
            Color = color;
        }

        public override ColoredOutput[] GetColors(string toDisplay)
        {
            return new[] {new ColoredOutput(toDisplay, Color)};
        }
    }
}