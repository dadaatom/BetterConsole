namespace BetterConsole.ConsoleComponents
{
    public class LoadingBarRenderer : ComponentRenderer<LoadingBar>
    {
        public LoadingBarRenderer() : this(null){ }

        public LoadingBarRenderer(LoadingBar bar) : base(bar) { }

        public override ComponentBuilder Render()
        {
            string toReturn = "[";
            
            for (int i = 1; i <= Object.Size; i++)
            {
                if (i <= Object.Count)
                {
                    toReturn += "=";
                }
                else
                {
                    toReturn += " ";
                }
            }
            
            toReturn += "]";
            
            return Object.Color.ApplyTo(toReturn);
        }
    }
}