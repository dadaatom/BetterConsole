namespace BetterConsole.ConsoleComponents
{
    public class Cell
    {
        public PaddedComponent Value;
        
        // TODO: MULTICELL OPTIONS HERE
        // TODO: CELL WIDTHS / HEIGHTS
        
        public Cell(string value)
        {
            Value = new PaddedComponent(value);
        }

        public Cell(ConsoleComponent component)
        {
            Value = new PaddedComponent(component);
        }
    }
}