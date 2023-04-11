using System;

namespace BetterConsole.ConsoleComponents
{
    public class Cell
    {
        public PaddedComponent Value;

        public ConsoleComponent Component => Value?.Component;

        private int _height;
        public int Height
        {
            get => _height;
            set
            {
                _height = Math.Max(1, value);
            }
        }
        
        private int _width;
        public int Width
        {
            get => _width;
            set
            {
                _width = Math.Max(1, value);
            }
        }

        public Cell(string value) : this(new TextComponent(value)) { }

        public Cell(string value, int width, int height) : this(new TextComponent(value), width, height) { }
        
        public Cell(ConsoleComponent component, int width = 1, int height = 1, HorizontalAlignment horizontalAlignment = HorizontalAlignment.Center, VerticalAlignment verticalAlignment = VerticalAlignment.Center)
        {
            Value = new PaddedComponent(component, horizontalAlignment, verticalAlignment);
            Height = height;
            Width = width;
        }
    }
}
