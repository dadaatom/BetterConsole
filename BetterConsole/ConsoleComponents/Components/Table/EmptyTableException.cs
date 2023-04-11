namespace BetterConsole.ConsoleComponents
{
    public class EmptyTableException : System.Exception
    {
        public EmptyTableException() : base("Table is empty, at least one table dimension is 0.") { }
    }
}
