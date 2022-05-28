namespace BetterConsole.ConsoleComponents
{
    public class Cell
    {
        public PaddedString Value;
        
        public Cell(string value)
        {
            Value = new PaddedString(value);
        }
    }
}