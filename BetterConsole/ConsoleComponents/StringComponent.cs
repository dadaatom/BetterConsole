namespace BetterConsole.ConsoleComponents
{
    public class StringComponent : ConsoleComponent
    {
        private readonly string _content;
        
        public StringComponent(string content) : base()
        {
            _content = content;
        }

        public override string ToString()
        {
            return _content;
        }
    }
}