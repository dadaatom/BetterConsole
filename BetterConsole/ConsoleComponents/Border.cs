using System;

namespace BetterConsole.ConsoleComponents
{
    /*
     * TODO:
     * Use style options here please.
     */
    public class Border : ConsoleComponent
    {
        public ConsoleComponent Contents { get; private set; }

        public PaddedString PaddedContents;
        
        public Border(ConsoleComponent contents)
        {
            Contents = contents;
            PaddedContents = new PaddedString(contents.ToString());
            PaddedContents.SetPaddings(6,1);
        }

        public void SetContents(ConsoleComponent contents)
        {
            Contents = contents;
            ComputeContents();
        }

        private void ComputeContents()
        {
            string value = "";
            ConsoleComponent current = Contents;
            
            while (current != null)
            {
                value += current.ToString();
                current = current.Next;
            }
            
            PaddedContents.SetValue(value);
        }

        public override string ToString()
        {
            string toReturn = " ";
            
            for (int j = 0; j < PaddedContents.TotalWidth; j++)
            {
                toReturn += "_";
            }
            
            toReturn += " \n";
            
            for (int i = 0; i < PaddedContents.PaddedValue.Length; i++)
            {
                toReturn += "|" + PaddedContents.PaddedValue[i] + "|\n";
            }
            
            toReturn += "|";
            
            for (int j = 0; j < PaddedContents.TotalWidth; j++)
            {
                toReturn += "_";
            }
            
            toReturn += "|";

            return toReturn;
        }
    }
}