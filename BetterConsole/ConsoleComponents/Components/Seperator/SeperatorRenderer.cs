namespace BetterConsole.ConsoleComponents
{
    public class SeperatorRenderer : ComponentRenderer<Separator>
    {
        public SeperatorRenderer(Separator obj) : base(obj) { }

        public override ComponentBuilder Render()
        {
            string value = "";
            for (int i = 0; i < Object.Length; i++)
            {
                value += '-';
            }

            return Object.Color.ApplyTo(value);
        }
    }
}