using System;

namespace BetterConsole.ConsoleComponents
{
    public class RainbowColor : CycledColor
    {
        public RainbowColor() : base(ColorUtil.ConvertColors(new [] {ConsoleColor.Red, ConsoleColor.DarkMagenta, ConsoleColor.Blue, ConsoleColor.Green, ConsoleColor.Yellow})) { }
    }
}
