using System;
using System.Net.Mime;

namespace BetterConsole.ConsoleComponents
{
    public class TextComponent : ConsoleComponent
    {
        public string Content { get; set; }

        public TextComponent(string content) : this(content, null) { }

        public TextComponent(string content, ComponentColor color) : base(color)
        {
            Content = content;
            //Renderer = new TextComponentRenderer(this);
        }

        protected override ComponentBuilder Build()
        {
            return Color.ApplyTo(Content);
        }
    }
}
