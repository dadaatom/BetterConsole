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
        public ConsoleColor Color;
        
        public ConsoleComponent Next { get; set; }
        
        public ConsoleComponent(ConsoleColor color = ConsoleColor.Gray)
        {
            Next = null;
            Color = color;
        }

        public abstract override string ToString();
        
    }
}