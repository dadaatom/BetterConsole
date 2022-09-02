using System;

namespace BetterConsole.ConsoleComponents
{
    public abstract class ComponentColor
    {
        /// <summary>
        /// Gets the color segmentation of a string.
        /// </summary>
        /// <param name="toDisplay">String to be color segmented.</param>
        /// <returns>Pairs of text and colors.</returns>
        public abstract ColorSegment[] GetColors(string toDisplay);

        public class ColorSegment
        {
            public string Text { get; }
            public ConsoleColor TextColor { get; }

            public ConsoleColor BackgroundColor { get; }

            public ColorSegment(string text, ConsoleColor textColor) : this(text, textColor, Console.BackgroundColor) { }

            public ColorSegment(string text, ConsoleColor textColor, ConsoleColor backgroundColor)
            {
                Text = text;
                TextColor = textColor;
                BackgroundColor = backgroundColor;
            }
        }
    }
}