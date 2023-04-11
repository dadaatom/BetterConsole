namespace BetterConsole.ConsoleComponents
{
    public class TextComponentRenderer : ComponentRenderer<TextComponent>
    {
        public TextComponentRenderer(TextComponent obj) : base(obj) { }

        public override ComponentBuilder Render()
        {
            return Object.Color.ApplyTo(Object.Content);
        }
    }
}
