namespace BetterConsole.ConsoleComponents
{
    public struct LoadingBarStyle
    {
        public string Fill;
        public string Empty;

        public string LeftBorder;
        public string RightBorder;

        public LoadingBarStyle(string fill, string empty, string leftBorder = "[", string rightBorder = "]")
        {
            Fill = fill;
            Empty = empty;
            LeftBorder = leftBorder;
            RightBorder = rightBorder;
        }
    }
}