using System;
using System.Drawing;

namespace BetterConsole.ConsoleComponents
{
    public class StaticColor : ComponentColor
    {
        public Color TextColor { get; }
        
        public StaticColor(Color textColor)
        {
            TextColor = textColor;
        }

        /// <summary>
        /// Colors a string with a single color.
        /// </summary>
        /// <param name="toDisplay">String to be color segmented.</param>
        /// <returns>Pairs of text and colors.</returns>
        public override ComponentBuilder ApplyTo(string toDisplay)
        {
            return new ComponentBuilder(new ComponentBuilder.ComponentSegment(toDisplay, TextColor));
        }
    }
}
