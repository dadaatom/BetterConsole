namespace BetterConsole.ConsoleComponents
{
    public class Cell
    {
        public PaddedString Value;
        
        // TODO: MULTICELL OPTIONS HERE
        
        public Cell(string value)
        {
            Value = new PaddedString(value);
        }
    }
}