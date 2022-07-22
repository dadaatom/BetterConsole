using System;

namespace BetterConsole.ConsoleComponents
{
    public class OrderedListComponent : ListComponent
    {
        private char[] _alphabet = {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
        
        public OrderedListComponent() : this(new ConsoleComponent[]{}){ }
        
        public OrderedListComponent(string[] list) : base(list) { }
        public OrderedListComponent(ConsoleComponent[] list) : base(list) { }

        public override string ToString()
        {
            string toReturn = "";

            string paddedHeader = "";
            for (int i = 0; i < (int) (Math.Log10(List.Count) + 1) + 3; i++)
            {
                paddedHeader += " ";
            }

            int counter = 0;
            
            foreach (ConsoleComponent component in List)
            {
                string header = "";
                
                if (true) // IF STYLE IS NUMBERS
                {
                    header = " " + (counter + 1) + ". ";
                }
                else
                {
                    // DO ALPHABET.
                }

                toReturn += TabComponent(component, header, paddedHeader);
                
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