using System;

namespace BetterConsole.ConsoleComponents
{
    public class ConsoleTheme
    {
        public ComponentColor PrimaryColor;
        public ComponentColor SecondaryColor;

        public ComponentColor AlertColor;

        public ConsoleTheme(ComponentColor primaryColor, ComponentColor secondaryColor, ComponentColor alertColor)
        {
            PrimaryColor = primaryColor;
            SecondaryColor = secondaryColor;
            AlertColor = alertColor;
        }
    }
}