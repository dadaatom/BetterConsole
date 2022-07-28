using System;

namespace BetterConsole.ConsoleComponents
{
    public class UnorderedListComponent : ListComponent
    {
        private string _itemHeader = " - "; // Maybe make an option of dashes vs bullets, e.t.c.
        
        public UnorderedListComponent(string label = "") : this(label, new ConsoleComponent[]{}) { }
        
        public UnorderedListComponent(string[] list) : this("", list) { }
        
        public UnorderedListComponent(ConsoleComponent[] list) : this("", list) { }
        
        public UnorderedListComponent(string label, string[] list) : base(label, list) { }

        public UnorderedListComponent(string label, ConsoleComponent[] list) : base(label, list) { }

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