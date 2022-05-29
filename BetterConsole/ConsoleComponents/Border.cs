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

        private PaddedString _paddedContents;
        
        public Border(ConsoleComponent contents)
        {
            Contents = contents;
            _paddedContents = new PaddedString(contents.ToString());
            _paddedContents.SetPaddings(6,2);
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
            
            _paddedContents.SetValue(value);
        }

        public override string ToString()
        {
            string toReturn = " ";
            
            for (int j = 0; j < _paddedContents.TotalWidth; j++)
            {
                toReturn += "_";
            }
            
            toReturn += " \n";
            
            for (int i = 0; i < _paddedContents.PaddedValue.Length; i++)
            {
                toReturn += "|" + _paddedContents.PaddedValue[i] + "|\n";
            }
            
            toReturn += "|";
            
            for (int j = 0; j < _paddedContents.TotalWidth; j++)
            {
                toReturn += "_";
            }
            
            toReturn += "|";

            return toReturn;
        }
    }
}