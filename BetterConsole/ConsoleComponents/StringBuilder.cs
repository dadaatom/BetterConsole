using System;
using System.Collections.Generic;

namespace BetterConsole.ConsoleComponents
{
    public class StringBuilder //todo give this more suitable name.
    {
        public LinkedList<ComponentColor.ColorSegment> Segments;

        public StringBuilder(string str, ComponentColor color)
        {
            Segments = new LinkedList<ComponentColor.ColorSegment>(color.GetColors(str));
        }

        public class StringSegment
        {
            public string Text { get; }
            public ConsoleColor TextColor { get; }

            public ConsoleColor BackgroundColor { get; }

            public StringSegment(string text, ConsoleColor textColor) : this(text, textColor, Console.BackgroundColor) { }

            public StringSegment(string text, ConsoleColor textColor, ConsoleColor backgroundColor)
            {
                Text = text;
                TextColor = textColor;
                BackgroundColor = backgroundColor;
            }
        }
    }
}