using System;
using System.Drawing;

namespace BetterConsole.ConsoleComponents
{
    public class DropdownRenderer : ComponentRenderer<Dropdown>
    {
        public DropdownRenderer(Dropdown obj) : base(obj) { }

        public override ComponentBuilder Render()
        {
            ComponentBuilder builder = new ComponentBuilder();
            
            builder.Append(new ComponentBuilder.ComponentSegment("[" + (Object.Dropped ? 'v' : '>') + "] " + Object.Header, Color.White)); //todo: use theme color here.
            
            if (Object.Dropped)
            {
                builder.Merge(BetterConsole.ConsoleStyle.DefaultColor.ApplyTo("\n"));
                throw new Exception("UNCOMMENT THIS");
                //builder.Merge(Object.Component.Renderer.Render());
            }

            return builder;
        }
    }
}