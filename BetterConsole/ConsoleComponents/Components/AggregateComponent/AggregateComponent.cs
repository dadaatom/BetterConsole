namespace BetterConsole.ConsoleComponents
{
    public class AggregateComponent : ConsoleComponent
    {
        public ConsoleComponent[] Components;
        
        public AggregateComponent(ConsoleComponent[] components)
        {
            Components = components;
            //Renderer = new AggregateComponentRenderer(this);
        }

        protected override ComponentBuilder Build()
        {
            ComponentBuilder builder = new ComponentBuilder();

            foreach (ConsoleComponent component in Components)
            {
                builder.Merge(component.Render());
            }

            return builder;
        }
    }
}