using System;

namespace BetterConsole.ConsoleComponents
{
    /*
     * TODO:
     * Figlet component using figlet .net
     * Style options (i.e. loading bar)
     */
    
    public abstract class ConsoleComponent
    {
        public ConsoleComponent Next { get; set; }
        
        private ConsoleColor _color;

        public ConsoleComponent() : this(ConsoleColor.Gray) { }

        public ConsoleComponent(ConsoleColor color)
        {
            Next = null;
            _color = color;
        }
        
        /// <summary>
        /// Sets the color for this component and all subsequent components in the line.
        /// </summary>
        /// <param name="color">New text color.</param>
        public void SetAllColors(ConsoleColor color)
        {
            ConsoleComponent current = this;
            while (current != null)
            {
                current.SetColor(color);
                current = current.Next;
            }
        }
        
        /// <summary>
        /// Sets the color for just this component.
        /// </summary>
        /// <param name="color">New text color.</param>
        public void SetColor(ConsoleColor color)
        {
            _color = color;
        }
        
        /// <summary>
        /// Writes the entire line to the console.
        /// </summary>
        public void Write()
        {
            ConsoleColor baseColor = Console.ForegroundColor;
            Console.ForegroundColor = _color;
            
            Console.Write(ToString());
            Next?.Write();
            
            Console.ForegroundColor = baseColor;
        }
        
        public abstract override string ToString();
    }
}