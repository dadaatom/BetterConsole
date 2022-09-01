using System;

namespace BetterConsole.ConsoleComponents
{
    public class StaticColor : ComponentColor
    {
        public ConsoleColor TextColor { get; }
        
        public StaticColor(ConsoleColor textColor)
        {
            TextColor = textColor;
        }

        /// <summary>
        /// Colors a string with a single color.
        /// </summary>
        /// <param name="toDisplay">String to be color segmented.</param>
        /// <returns>Pairs of text and colors.</returns>
        public override ColorSegment[] GetColors(string toDisplay)
        {
            return new[] {new ColorSegment(toDisplay, TextColor)};
        }
    }
}