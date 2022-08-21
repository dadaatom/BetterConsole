namespace BetterConsole.ConsoleComponents
{
    public class AggregateComponent : ConsoleComponent
    {
        public ConsoleComponent[] Components;
        
        public AggregateComponent(ConsoleComponent[] components)
        {
            Components = components;
        }

        public override string ToString()
        {
            string toReturn = "";
            foreach (ConsoleComponent component in Components)
            {
                toReturn += component.ToString();
            }
            return toReturn;
        }
    }
}