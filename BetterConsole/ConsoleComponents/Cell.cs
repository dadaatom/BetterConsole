using System;

namespace BetterConsole.ConsoleComponents
{
    public class Cell
    {
        public PaddedComponent Value;

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
        
        public Cell(ConsoleComponent component, int width = 1, int height = 1)
        {
            Value = new PaddedComponent(component);
            Height = height;
            Width = width;
        }
    }
}