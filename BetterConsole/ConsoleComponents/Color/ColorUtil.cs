using System;
using System.Collections.Generic;
using System.Drawing;

namespace BetterConsole.ConsoleComponents
{
    public static class ColorUtil
    {
        /// <summary>
        /// Converts color to console color.
        /// </summary>
        /// <param name="color">Color to be converted.</param>
        /// <returns>Closest fitting console color.</returns>
        public static ConsoleColor ConvertToConsoleColor(Color color)
        {
            return ClosestConsoleColor(color.R, color.G, color.B);
        }

        /// <summary>
        /// Converts console color to color.
        /// </summary>
        /// <param name="color">Console color to be converted.</param>
        /// <returns>Color representing console color.</returns>
        public static Color ConvertToColor(ConsoleColor color)
        {
            string name = Enum.GetName(typeof(ConsoleColor), color);
            return Color.FromName(name == "DarkYellow" ? "Orange" : name);
        }
        
        /// <summary>
        /// Converts console color to color.
        /// </summary>
        /// <param name="color">Console color to be converted.</param>
        /// <returns>Color representing console color.</returns>
        public static Color[] ConvertColors(ConsoleColor[] colors)
        {
            Color[] toReturn = new Color[colors.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                toReturn[i] = ConvertToColor(colors[i]);
            }

            return toReturn;
        }
        
        /// <summary>
        /// Finds closest console color to RGB values.
        /// </summary>
        /// <param name="r">Red byte.</param>
        /// <param name="g">Green byte.</param>
        /// <param name="b">Blue byte.</param>
        /// <returns>Best matching console color.</returns>
        public static ConsoleColor ClosestConsoleColor(byte r, byte g, byte b)
        {
            // Source: http://www.java2s.com/example/csharp/system.drawing/get-the-closest-consolecolor-to-the-rgb-values.html
            
            ConsoleColor ret = 0;
            double rr = r, gg = g, bb = b, delta = double.MaxValue;

            foreach (ConsoleColor cc in Enum.GetValues(typeof(ConsoleColor)))
            {
                string n = Enum.GetName(typeof(ConsoleColor), cc);
                Color c = Color.FromName(n == "DarkYellow" ? "Orange" : n);
                double t = Math.Pow(c.R - rr, 2.0) + Math.Pow(c.G - gg, 2.0) + Math.Pow(c.B - bb, 2.0);
                
                if (t == 0.0)
                {
                    return cc;
                }
                
                if (t < delta)
                {
                    delta = t;
                    ret = cc;
                }
            }
            return ret;
        }
    }
}
