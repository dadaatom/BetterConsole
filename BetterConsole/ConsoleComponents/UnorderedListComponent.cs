using System;

namespace BetterConsole.ConsoleComponents
{
    public class UnorderedListComponent : ListComponent
    {
        private string _itemHeader = " - ";
        
        public UnorderedListComponent() { }

        public UnorderedListComponent(string[] list) : base(list) { }

        public UnorderedListComponent(ConsoleComponent[] list) : base(list) { }

        public override string ToString()
        {
            string toReturn = Label;

            if (toReturn.Length > 0)
            {
                toReturn += "\n";
            }

            string paddedHeader = "";
            for (int i = 0; i < _itemHeader.Length; i++)
            {
                paddedHeader += " ";
            }

            int counter = 0;
            foreach (ConsoleComponent component in List)
            {
                toReturn += TabComponent(component, _itemHeader, paddedHeader);
                
                if (counter < List.Count - 1)
                {
                    toReturn += "\n";
                }

                counter++;
            }

            return toReturn;
        }
    }
}