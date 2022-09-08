using System;
using System.Collections.Generic;
using System.Drawing;

namespace BetterConsole.ConsoleComponents
{
    public class StringBuilder //todo give this more suitable name.
    {
        public List<StringSegment> Segments;

        public StringBuilder(string str, ComponentColor color)
        {
            //Segments = new List<StringSegment>(color.GetColors(str));
            Segments = new List<StringSegment>(new StringSegment[] { new StringSegment(str, ConsoleColor.Gray) });
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
        }

        public void Append(StringSegment segment) => Segments.Add(segment);

        public void Insert(int index, StringSegment segment) => Segments.Insert(index, segment);

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