using System;

namespace BetterConsole.ConsoleComponents
{
    public class BetterColor
    {
        public ConsoleColor ConsoleColor { get; }

        public byte R { get; }
        public byte G { get; }
        public byte B { get; }
        public byte A { get; }
        
        public BetterColor(ConsoleColor consoleColor, byte r, byte g, byte b, byte a = 255)
        {
            ConsoleColor = consoleColor;
            
            R = r;
            G = g;
            B = b;
            A = a;
        }
    }
}