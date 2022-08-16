using System;

namespace BetterConsole.ConsoleComponents
{
    public class CycledColor : ComponentColor
    {
        public ConsoleColor[] Colors { get; }
        public int SegmentLength { get; }

        public CycledColor(ConsoleColor[] colors, int segmentLength = 1)
        {
            Colors = colors;
            SegmentLength = Math.Max(1, segmentLength);
        }
        
        /// <summary>
        /// Alternates colors in the list onto the string.
        /// </summary>
        /// <param name="toDisplay">String to be color segmented.</param>
        /// <returns>Pairs of text and colors.</returns>
        public override ColorSegment[] GetColors(string toDisplay)
        {
            int length = (int)Math.Ceiling((double)toDisplay.Length / SegmentLength);
            ColorSegment[] toReturn = new ColorSegment[length];

            for (int i = 0; i < toReturn.Length; i++)
            {
                toReturn[i] = new ColorSegment(toDisplay.Substring(i*SegmentLength, Math.Min(SegmentLength, toDisplay.Length - i*SegmentLength)), Colors[i % Colors.Length]);
            }

            return toReturn;
        }
    }
}