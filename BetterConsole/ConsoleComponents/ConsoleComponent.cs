namespace BetterConsole.ConsoleComponents
{
    public abstract class ConsoleComponent
    {

        public ConsoleComponent Next { get; set; }

        protected ConsoleComponent()
        {
            Next = null;
        }

        public abstract override string ToString();
        
    }
    
    /*
     * Components to create:
     * Figlet component using figlet .net
     * Timer
     * Countdown
     */
}