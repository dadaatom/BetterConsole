using System;

namespace BetterConsole.ConsoleComponents
{
    public class TextComponent : ConsoleComponent
    {
        private string _content;

        public TextComponent(string content)
        {
            _content = content;
        }
        
        public override string ToString()
        {
            return _content;
        }

        public void SetText(string text)
        {
            _content = text;
        }
    }
}