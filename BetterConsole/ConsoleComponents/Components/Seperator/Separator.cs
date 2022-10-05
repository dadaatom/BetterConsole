namespace BetterConsole.ConsoleComponents
{
    public class Separator : ConsoleComponent
    {
        public int Length;
        
        public Separator(int length)
        {
            Length = length;
            //Renderer = new SeperatorRenderer(this);
        }

        protected override ComponentBuilder Build()
        {
            throw new System.NotImplementedException();
        }
    }
}