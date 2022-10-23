using System;

namespace BetterConsole.ConsoleComponents
{
    public class UnorderedList : ListComponent
    {
        private readonly string _itemHeader = " - "; // Maybe make an option of dashes vs bullets, e.t.c.
        
        public UnorderedList(string label = "") : this(label, new ConsoleComponent[]{}) { }
        
        public UnorderedList(string[] list) : this("", list) { }
        
        public UnorderedList(ConsoleComponent[] list) : this("", list) { }
        
        public UnorderedList(string label, string[] list) : base(label, list) { }

        public UnorderedList(string label, ConsoleComponent[] list) : base(label, list) { }

        /// <summary>
        /// Gets header of unordered list.
        /// </summary>
        /// <param name="index">This parameter is not used for unordered lists.</param>
        /// <returns>Item header of unordered list.</returns>
        public override string GetHeader(int index)
        {
            return _itemHeader;
        }
    }
}