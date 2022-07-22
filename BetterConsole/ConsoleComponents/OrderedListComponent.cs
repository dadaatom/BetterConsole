using System;

namespace BetterConsole.ConsoleComponents
{
    public class OrderedListComponent : ListComponent
    {
        public OrderedListStyle OrderedListStyle;

        private char[] _alphabet = {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
        
        public OrderedListComponent() : this(new ConsoleComponent[]{}, OrderedListStyle.Numerical){ }

        public OrderedListComponent(OrderedListStyle style) : this(new ConsoleComponent[]{}){ }

        public OrderedListComponent(string[] list, OrderedListStyle style = OrderedListStyle.Numerical) : base(list)
        {
            OrderedListStyle = style;
        }

        public OrderedListComponent(ConsoleComponent[] list, OrderedListStyle style = OrderedListStyle.Numerical) : base(list)
        {
            OrderedListStyle = style;
        }

        public override string ToString()
        {
            string toReturn = "";

            string paddedHeader = "";

            int maxLength = 0;
            if (OrderedListStyle == OrderedListStyle.Numerical)
            {
                maxLength = (int) (Math.Log10(List.Count) + 1) + 3;
            }
            else if (OrderedListStyle == OrderedListStyle.Alphabetic)
            {
                maxLength = (int)(Math.Log(List.Count) / Math.Log(_alphabet.Length) + 1) + 3;
            }

            for (int i = 0; i < maxLength; i++)
            {
                paddedHeader += " ";
            }

            int counter = 0;
            
            foreach (ConsoleComponent component in List)
            {
                string header = "";
                
                if (OrderedListStyle == OrderedListStyle.Numerical)
                {
                    header = " " + (counter + 1) + ". ";
                }
                else if (OrderedListStyle == OrderedListStyle.Alphabetic)
                {
                    int count = counter;
                    do
                    {
                        header = _alphabet[count % 26] + header;
                        count /= 26;
                    } while (count > 0);

                    header = " " + header + ". ";
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