namespace BetterConsole.ConsoleComponents
{
    public class Seperator : ConsoleComponent
    {
        public int Length;
        
        private string seperator = "-";
        
        public Seperator(int length)
        {
            Length = length;
        }

        public override string ToString()
        {
            string toReturn = "";
            for (int i = 0; i < Length; i++)
            {
                toReturn += seperator;
            }

            return toReturn;
        }
    }
}