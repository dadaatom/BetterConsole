using System.Collections.Generic;

namespace BetterConsole.ConsoleComponents
{
    /*
     * TODO:
     * Sublists shouldn't print with the header.
     * OrderedLists should changes between styles for sublists.
     * Add list header item
     * Keep spacing consistent with multi sized headers.
     */
    
    public abstract class ListComponent : ConsoleComponent
    {
        public LinkedList<ConsoleComponent> List { get; set; }

        public ListComponent() : this(new ConsoleComponent[]{}){ }

        public ListComponent(string[] list)
        {
            List = new LinkedList<ConsoleComponent>();
            foreach (string str in list)
            {
                List.AddLast(new TextComponent(str));
            }
        }

        public ListComponent(ConsoleComponent[] list)
        {
            List = new LinkedList<ConsoleComponent>();
            foreach (ConsoleComponent component in list)
            {
                List.AddLast(component);
            }
        }
        
        /// <summary>
        /// Adds text component to the console component list.
        /// </summary>
        /// <param name="str">String to be added to the component list.</param>
        public void AddText(string str)
        {
            List.AddLast(new TextComponent(str));
        }
        
        public abstract override string ToString();

        /// <summary>
        /// Tabs a string for a list element.
        /// </summary>
        /// <param name="component">Component to add tabbing.</param>
        /// <param name="header">Header added in front of component.</param>
        /// <param name="paddedHeader">Padded header added in front of multiline component strings.</param>
        /// <returns>Tabbed component with a header in front of the first line.</returns>
        protected string TabComponent(ConsoleComponent component, string header, string paddedHeader = null)
        {
            string toReturn = "";

            if (paddedHeader == null)
            {
                paddedHeader = "";
                for (int i = 0; i < header.Length; i++)
                {
                    paddedHeader += " ";
                }
            }

            string[] lines = component.ToString().Split('\n');
            for (int i = 0; i < lines.Length; i++) {
                if (i == 0)
                {
                    toReturn += header + lines[i];
                }
                else
                {
                    toReturn += paddedHeader + lines[i];
                }

                if (i < lines.Length - 1)
                {
                    toReturn += "\n";
                }
            }

            return toReturn;
        }
    }
}