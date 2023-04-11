using System;

namespace BetterConsole.ConsoleComponents
{
    public class AggregateComponentRenderer : ComponentRenderer<AggregateComponent>
    {
        public AggregateComponentRenderer(AggregateComponent obj) : base(obj) { }

        public override ComponentBuilder Render()
        {
            ComponentBuilder builder = new ComponentBuilder();

            foreach (ConsoleComponent component in Object.Components)
            {
                throw new System.Exception("UNCOMMENT THIS");
                //builder.Merge(component.Renderer.Render());
            }

            return builder;
        }
    }
}
