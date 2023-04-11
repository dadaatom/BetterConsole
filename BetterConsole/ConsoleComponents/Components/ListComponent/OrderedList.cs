using System;

namespace BetterConsole.ConsoleComponents
{
    public class OrderedList : ListComponent
    {
        public OrderedListType OrderedListType;

        private char[] _alphabet = {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
        
        public OrderedList(string label = "", OrderedListType type = OrderedListType.Numerical) : this(label,new ConsoleComponent[]{}, type){ }
        
        public OrderedList(string[] list, OrderedListType type = OrderedListType.Numerical) : this("", list, type) { }
        
        public OrderedList(ConsoleComponent[] list, OrderedListType type = OrderedListType.Numerical) : this("", list, type) { }
        
        public OrderedList(string label, string[] list, OrderedListType type = OrderedListType.Numerical) : base(label, list)
        {
            OrderedListType = type;
        }

        public OrderedList(string label, ConsoleComponent[] list, OrderedListType type = OrderedListType.Numerical) : base(label, list)
        {
            OrderedListType = type;
        }

        /// <summary>
        /// Gets header of ordered list whether its numerical or alphabetic.
        /// </summary>
        /// <param name="index">Current item element within the list.</param>
        /// <returns>Item header of ordered list.</returns>
        public override string GetHeader(int index)
        {
            string toReturn = "";
            
            if (OrderedListType == OrderedListType.Numerical)
            {
                toReturn = " " + (index + 1) + ". ";
            }
            else if (OrderedListType == OrderedListType.Alphabetic)
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
