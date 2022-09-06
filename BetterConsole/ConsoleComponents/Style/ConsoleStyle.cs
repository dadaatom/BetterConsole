namespace BetterConsole.ConsoleComponents
{
    public class ConsoleStyle
    {
        public ComponentColor DefaulColor { get; set; }
        public ConsoleTheme Theme { get; private set; }

        public ConsoleStyle(ComponentColor color, ConsoleTheme theme)
        {
            DefaulColor = color;
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