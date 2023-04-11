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
        /// <param name="merge">Merges segment with previous if coloring matches</param>
        public void Append(ComponentSegment segment, bool merge = false)
        {
            bool completed = false;
            
            if (merge)
            {
                int index = Segments.Count - 1;
                ComponentSegment seg = Segments[index];
                if (seg.TextColor == segment.TextColor && seg.BackgroundColor == segment.BackgroundColor)
                {
                    Segments[index] = new ComponentSegment(seg.Text + segment.Text, segment.TextColor, segment.BackgroundColor);
                    completed = true;
                }
            }
            
            if (!completed)
            {
                Segments.Add(segment);
            }
        }

        /// <summary>
        /// Inserts component segment at index.
        /// </summary>
        /// <param name="index">Insert position.</param>
        /// <param name="segment">New segment to insert.</param>
        public void Insert(int index, ComponentSegment segment, bool merge = false)
        {
            bool completed = false;
            
            if (merge)
            {
                ComponentSegment seg = Segments[index];
                if (seg.TextColor == segment.TextColor && seg.BackgroundColor == segment.BackgroundColor)
                {
                    Segments[index] = new ComponentSegment(segment.Text + seg.Text, segment.TextColor, segment.BackgroundColor);
                    completed = true;
                }
            }
            
            
            if (!completed)
            {
                Segments.Insert(index, segment);
            }
        }

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
