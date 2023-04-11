namespace BetterConsole.ConsoleComponents
{
    public class ListRenderer : ComponentRenderer<ListComponent>
    {
        public ListRenderer(ListComponent obj) : base(obj) { }

        public override ComponentBuilder Render()
        {
            ComponentBuilder builder = new ComponentBuilder();

            builder.Merge(Object.Color.ApplyTo(Object.Label)); // todo: Use theme settings here.

            if (builder.Segments.Count > 0)
            {
                builder.Merge(Object.Color.ApplyTo("\n"));
            }

            string paddedHeader = "";
            
            int counter = 0;
            foreach (ConsoleComponent component in Object.List)
            {
                string header = Object.GetHeader(counter);

                if (header.Length != paddedHeader.Length)
                {
                    paddedHeader = Object.GetPaddedHeader(header.Length);
                }

                builder.Merge(Object.Color.ApplyTo(Object.TabComponent(component, header, paddedHeader)));

                if (counter < Object.List.Count - 1)
                {
                    builder.Merge(Object.Color.ApplyTo("\n"));
                }

                counter++;
            }

            return builder;
        }
    }
}
