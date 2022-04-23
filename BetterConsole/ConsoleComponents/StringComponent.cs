namespace BetterConsole.ConsoleComponents
{
    public class StringComponent : ConsoleComponent
    {
        private string content;
        
        public StringComponent(string content) : this(false, content) { }
        
        public StringComponent(bool linebreak, string content) : base(linebreak)
        {
            this.content = content;
        }

        public override string ToString()
        {
            return content;
        }
    }
}