using System;

namespace BetterConsole.ConsoleComponents
{
    public class Cell
    {
        public PaddedComponent Value;
        
        // TODO: MULTICELL OPTIONS HERE
        // TODO: CELL WIDTHS / HEIGHTS

        public int Height;
        /*{
            get => Height;
            set => Math.Max(1, value);
        }*/

        public int Width;
        /*{
            get => Width;
            set => Math.Max(1, value);
        }*/

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