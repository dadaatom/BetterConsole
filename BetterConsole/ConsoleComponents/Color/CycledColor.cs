using System;
using System.Drawing;

namespace BetterConsole.ConsoleComponents
{
    public class CycledColor : ComponentColor
    {
        public Color[] Colors { get; }
        public int SegmentLength { get; }

        public CycledColor(Color[] colors, int segmentLength = 1)
        {
            Colors = colors;
            SegmentLength = Math.Max(1, segmentLength);
        }
        
        /// <summary>
        /// Alternates colors in the list onto the string.
        /// </summary>
        /// <param name="toDisplay">String to be color segmented.</param>
        /// <returns>Pairs of text and colors.</returns>
        public override ComponentBuilder ApplyTo(string toDisplay)
        {
            ComponentBuilder toReturn = new ComponentBuilder();
            
            for (int i = 0; i < (int)Math.Ceiling((double)toDisplay.Length / SegmentLength); i++)
            {
                toReturn.Append(new ComponentBuilder.ComponentSegment(toDisplay.Substring(i*SegmentLength, Math.Min(SegmentLength, toDisplay.Length - i*SegmentLength)), Colors[i % Colors.Length]));
            }

            return toReturn;
        }
    }
}
