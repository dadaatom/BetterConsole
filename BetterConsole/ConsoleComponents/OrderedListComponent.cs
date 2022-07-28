using System;

namespace BetterConsole.ConsoleComponents
{
    public class OrderedListComponent : ListComponent
    {
        public OrderedListStyle OrderedListStyle;

        private char[] _alphabet = {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
        
        public OrderedListComponent(string label = "", OrderedListStyle style = OrderedListStyle.Numerical) : this(label,new ConsoleComponent[]{}, style){ }
        
        public OrderedListComponent(string[] list, OrderedListStyle style = OrderedListStyle.Numerical) : this("", list, style) { }
        
        public OrderedListComponent(ConsoleComponent[] list, OrderedListStyle style = OrderedListStyle.Numerical) : this("", list, style) { }
        
        public OrderedListComponent(string label, string[] list, OrderedListStyle style = OrderedListStyle.Numerical) : base(label, list)
        {
            OrderedListStyle = style;
        }

        public OrderedListComponent(string label, ConsoleComponent[] list, OrderedListStyle style = OrderedListStyle.Numerical) : base(label, list)
        {
            OrderedListStyle = style;
        }

        /// <summary>
        /// Gets header of ordered list whether its numerical or alphabetic.
        /// </summary>
        /// <param name="index">Current item element within the list.</param>
        /// <returns>Item header of ordered list.</returns>
        public override string GetHeader(int index)
        {
            string toReturn = "";
            
            if (OrderedListStyle == OrderedListStyle.Numerical)
            {
                toReturn = " " + (index + 1) + ". ";
            }
            else if (OrderedListStyle == OrderedListStyle.Alphabetic)
            {
                do
                {
                    toReturn = _alphabet[index % 26] + toReturn;
                    index /= 26;
                } while (index > 0);

                toReturn = " " + toReturn + ". ";
            }

            return toReturn;
        }
    }
}