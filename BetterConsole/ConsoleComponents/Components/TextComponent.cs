using System;
using System.Net.Mime;

namespace BetterConsole.ConsoleComponents
{
    public class TextComponent : ConsoleComponent
    {
        private string _content;

        public TextComponent(string content)
        {
            _content = content;
        }

        public TextComponent(string content, ComponentColor color) : base(color)
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