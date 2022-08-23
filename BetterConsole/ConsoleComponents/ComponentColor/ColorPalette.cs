using System;
using System.Collections.Generic;

namespace BetterConsole.ConsoleComponents
{
    public class ColorPalette
    {
        public static LinkedList<BetterColor> Colors;

        public ColorPalette()
        {
            Colors = new LinkedList<BetterColor>();

            //Colors.AddLast(new BetterColor())
        }

        public static BetterColor BestMatch(byte r, byte g, byte b)
        {
            double bestDistance = 0;
            BetterColor bestColor = null;
            
            foreach (BetterColor color in Colors)
            {
                double distance = Distance(color, new[] {r, g, b});
                
                if (bestColor == null || distance < bestDistance)
                {
                    bestColor = color;
                    bestDistance = distance;
                }
            }

            return bestColor;
        }

        public static double Distance(BetterColor color1, BetterColor color2)
        {
            return Math.Sqrt(Math.Pow(ByteToInt(color1.R) - ByteToInt(color2.R), 2) + Math.Pow(ByteToInt(color1.G) - ByteToInt(color2.G), 2) + Math.Pow(ByteToInt(color1.B) - ByteToInt(color2.B), 2));
        }
        
        public static double Distance(BetterColor color1, byte[] rgb)
        {
            return Math.Sqrt(Math.Pow(ByteToInt(color1.R) - ByteToInt(rgb[0]), 2) + Math.Pow(ByteToInt(color1.G) - ByteToInt(rgb[1]), 2) + Math.Pow(ByteToInt(color1.B) - ByteToInt(rgb[2]), 2));
        }

        private static int ByteToInt(byte b)
        {
            return BitConverter.ToInt32(new []{b}, 0);
        }
    }
}