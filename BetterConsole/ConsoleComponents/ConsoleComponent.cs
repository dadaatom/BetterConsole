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
        
        public ConsoleColor Color;
        
        public ConsoleComponent(ConsoleColor color = ConsoleColor.Gray)
        {
            Next = null;
            Color = color;
        }
        
        public void Write()
        {
            ConsoleColor baseColor = Console.ForegroundColor;

            Console.ForegroundColor = Color;
            Console.Write(ToString());
            Next?.Write();
            Console.ForegroundColor = baseColor;
        }
        
        public abstract override string ToString();
        
    }
}