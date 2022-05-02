using System;

namespace BetterConsole.ConsoleComponents
{
    /*
     * TODO:
     * Figlet component using figlet .net
     * Timer
     * Countdown
     * Style options (i.e. loading bar)
     * Can colors be done?
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

        public void SetColors(ConsoleColor color)
        {
            ConsoleComponent current = this;
            while (current != null)
            {
                current.SetColor(color);
                current = current.Next;
            }
        }

        public void SetColor(ConsoleColor color)
        {
            _color = color;
        }

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