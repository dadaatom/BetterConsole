using System;

namespace BetterConsole.ConsoleComponents
{
    public abstract class ComponentColor
    {
        public abstract ColoredOutput[] GetColors(string toDisplay);

        public class ColoredOutput
        {
            public string Text { get; }
            public ConsoleColor Color { get; }

            public ColoredOutput(string text, ConsoleColor color)
            {
                Text = text;
                Color = color;
            }
        }
    }
}