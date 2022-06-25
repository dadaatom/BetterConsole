namespace BetterConsole.ConsoleComponents
{
    public class Separator : ConsoleComponent
    {
        public int Length;
        
        private string seperator = "-";
        
        public Separator(int length)
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