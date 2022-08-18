namespace BetterConsole.ConsoleComponents
{
    public class Dropdown : ConsoleComponent
    {
        public string Header { get; set; }
        public ConsoleComponent Component { get; set; }
        public bool Dropped { get; private set; }

        public Dropdown(string header, ConsoleComponent component)
        {
            Header = header;
            Component = component;
            Dropped = false;
        }

        public override string ToString()
        {
            string toReturn = "[" + (Dropped ? 'v' : '^') + "] " + Header;
            
            if (Dropped)
            {
                toReturn += '\n';
                toReturn += Component.ToString();
            }

            return toReturn;
        }

        public void ToggleDropped()
        {
            Dropped = !Dropped;
        }
    }
}