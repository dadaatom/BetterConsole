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
        
        public override ColoredOutput[] GetColors(string toDisplay)
        {
            int length = (int)Math.Ceiling((double)toDisplay.Length / SegmentLength);
            ColoredOutput[] toReturn = new ColoredOutput[length];

            for (int i = 0; i < toReturn.Length; i++)
            {
                toReturn[i] = new ColoredOutput(toDisplay.Substring(i*SegmentLength, Math.Min(SegmentLength, toDisplay.Length - i*SegmentLength)), Colors[i % Colors.Length]);
            }

            return toReturn;
        }
    }
}