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
        
        public ComponentBuilder(ComponentSegment segment)
        {
            Segments = new List<ComponentSegment>(new ComponentSegment[] { segment });
        }

        /// <summary>
        /// Appends component builder with a new segment.
        /// </summary>
        /// <param name="segment">New component segment.</param>
        public void Append(ComponentSegment segment) => Segments.Add(segment);

        /// <summary>
        /// Inserts component segment at index.
        /// </summary>
        /// <param name="index">Insert position.</param>
        /// <param name="segment">New segment to insert.</param>
        public void Insert(int index, ComponentSegment segment) => Segments.Insert(index, segment);

        /// <summary>
        /// Merges this component builder with another.
        /// </summary>
        /// <param name="builder">Second component builder.</param>
        public void Merge(ComponentBuilder builder)
        {
            foreach (ComponentSegment componentSegment in builder.Segments)
            {
                Append(componentSegment);
            }
        }

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