namespace BetterConsole.ConsoleComponents
{
    public class Dropdown : ConsoleComponent
    {
        public string Header { get; set; }
        public ConsoleComponent Component { get; set; }
        public bool Dropped { get; private set; }

        public Dropdown(string header, string text) : this(header, new TextComponent(text)) { }
        
        public Dropdown(string header, ConsoleComponent component)
        {
            Header = header;
            Component = component;
            Dropped = false;

            //Renderer = new DropdownRenderer(this);
        }

        protected override ComponentBuilder Build()
        {
            ComponentBuilder builder = new ComponentBuilder();
            
            builder.Append(new ComponentBuilder.ComponentSegment("[" + (Dropped ? 'v' : '>') + "] " + Header, System.Drawing.Color.White)); //todo: use theme color here.
            
            if (Dropped)
            {
                builder.Merge(BetterConsole.ConsoleStyle.DefaultColor.ApplyTo("\n"));
                builder.Merge(Component.Render());
            }

            return builder;
        }
        
        /// <summary>
        /// Toggle the dropdown component.
        /// </summary>
        public void ToggleDropped()
        {
            Dropped = !Dropped;
        }
    }
}
