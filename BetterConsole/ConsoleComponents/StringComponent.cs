using System;

namespace BetterConsole.ConsoleComponents
{
    public class StringComponent : ConsoleComponent
    {
        private readonly string _content;

        public StringComponent(string content, ConsoleColor color = ConsoleColor.Gray) : base(color)
        {
            _content = content;
        }
        
        public override string ToString()
        {
            return _content;
        }
    }
}