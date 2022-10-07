using System;
using System.Drawing;

namespace BetterConsole.ConsoleComponents
{
    public class ConsoleTheme
    {
        public ComponentColor PrimaryColor;
        public ComponentColor SecondaryColor;

        public ComponentColor AlertColor;

        public ConsoleTheme() : this(new StaticColor(Color.White), new StaticColor(Color.Gray), new StaticColor(Color.Red)) { }

        public ConsoleTheme(ComponentColor primaryColor, ComponentColor secondaryColor, ComponentColor alertColor)
        {
            PrimaryColor = primaryColor;
            SecondaryColor = secondaryColor;
            AlertColor = alertColor;
        }
    }
}