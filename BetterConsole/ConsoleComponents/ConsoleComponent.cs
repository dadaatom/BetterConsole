namespace BetterConsole.ConsoleComponents
{
    public abstract class ConsoleComponent
    {
        //line break param?
        private bool linebreak;
        
        protected ConsoleComponent(bool linebreak)
        {
            this.linebreak = linebreak;
        }

        public abstract override string ToString();
    }
    
    /*
     * Components to create:
     * Figlet component using figlet .net
     * loading bar
     */
}