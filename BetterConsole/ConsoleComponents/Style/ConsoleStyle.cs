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

        public void SetTheme(ConsoleTheme theme)
        {
            Theme = theme;
            BetterConsole.Reload();
        }
    }
}