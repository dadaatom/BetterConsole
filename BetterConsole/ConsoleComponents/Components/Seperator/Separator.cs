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
            string value = "";
            for (int i = 0; i < Length; i++)
            {
                value += '-';
            }

            return Color.ApplyTo(value);
        }
    }
}
