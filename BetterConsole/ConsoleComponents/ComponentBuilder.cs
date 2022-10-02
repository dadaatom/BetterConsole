using System;
using System.Collections.Generic;
using System.Drawing;

namespace BetterConsole.ConsoleComponents
{
    public class ComponentBuilder
    {
        public List<ComponentSegment> Segments;

        public ComponentBuilder()
        {
            Segments = new List<ComponentSegment>();
        }

        public ComponentBuilder(string str) : this(str, ColorUtil.ConvertToColor(ConsoleColor.Gray)) { }
        
        public ComponentBuilder(string str, Color color)
        {
            Segments = new List<ComponentSegment>(new ComponentSegment[] { new ComponentSegment(str, color) });
        }

        public void Append(ComponentSegment segment) => Segments.Add(segment);

        public void Insert(int index, ComponentSegment segment) => Segments.Insert(index, segment);

        public class ComponentSegment
        {
            public string Text { get; }
            public Color TextColor { get; }

            public Color BackgroundColor { get; }

            public ComponentSegment(string text, Color textColor) : this(text, textColor, ColorUtil.ConvertToColor(Console.BackgroundColor)) { }

            public ComponentSegment(string text, Color textColor, Color backgroundColor)
            {
                Text = text;
                TextColor = textColor;
                BackgroundColor = backgroundColor;
            }
        }
    }
}