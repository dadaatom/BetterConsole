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

        protected ConsoleComponent()
        {
            Next = null;
        }

        public abstract override string ToString();
        
    }
}