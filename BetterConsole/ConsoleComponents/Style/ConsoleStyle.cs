namespace BetterConsole.ConsoleComponents
{
    public class ConsoleStyle
    {
        public ComponentColor DefaultColor { get; set; }
        public ConsoleTheme Theme { get; private set; }

        public ConsoleStyle(ComponentColor color, ConsoleTheme theme)
        {
            DefaultColor = color;
            Theme = theme;
        }

        /// <summary>
        /// Sets the theme and reloads the console.
        /// </summary>
        /// <param name="theme">New console theme to implement.</param>
        public void SetTheme(ConsoleTheme theme)
        {
            Theme = theme;
            BetterConsole.Reload();
        }
    }
}