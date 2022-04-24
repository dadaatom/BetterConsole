namespace BetterConsole.ConsoleComponents
{
    public class StringComponent : ConsoleComponent
    {
        private string content;
        
        public StringComponent(string content) : base()
        {
            this.content = content;
        }

        public override string ToString()
        {
            return content;
        }
    }
}