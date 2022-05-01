using System;

namespace BetterConsole.ConsoleComponents
{
    /*
     * TODO:
     * Headers
     * Seperators
     * Figlet.NET
     */
    
    public class TextComponent : ConsoleComponent
    {
        private string _content;

        public TextComponent(string content, ConsoleColor color = ConsoleColor.Gray) : base(color)
        {
            _content = content;
        }
        
        public override string ToString()
        {
            return _content;
        }

        public void ModifyText(string text)
        {
            _content = text;
        }
    }
}