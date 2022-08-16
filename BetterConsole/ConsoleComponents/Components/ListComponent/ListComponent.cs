using System;
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
        public string Label { get; set; }
        
        public LinkedList<ConsoleComponent> List { get; set; }
        
        public ListComponent(string label = "") : this(label, new ConsoleComponent[]{}) { }

        public ListComponent(string[] list) : this("", list) { }
        
        public ListComponent(ConsoleComponent[] list) : this("", list) { }

        public ListComponent(string label, string[] list)
        {
            Label = label;
            
            List = new LinkedList<ConsoleComponent>();
            foreach (string str in list)
            {
                List.AddLast(new TextComponent(str));
            }
        }

        public ListComponent(string label, ConsoleComponent[] list)
        {
            Label = label;
            
            List = new LinkedList<ConsoleComponent>();
            foreach (ConsoleComponent component in list)
            {
                List.AddLast(component);
            }
        }
        
        /// <summary>
        /// Gets list headers to generate list
        /// </summary>
        /// <param name="index">List index of header.</param>
        /// <returns>Item header within list</returns>
        public abstract string GetHeader(int index);
        
        public override string ToString()
        {
            string toReturn = Label;

            if (toReturn.Length > 0)
            {
                toReturn += "\n";
            }

            string paddedHeader = "";
            
            int counter = 0;
            foreach (ConsoleComponent component in List)
            {
                string header = GetHeader(counter);

                if (header.Length != paddedHeader.Length)
                {
                    paddedHeader = GetPaddedHeader(header.Length);
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
        
        /// <summary>
        /// Adds text component to the console component list.
        /// </summary>
        /// <param name="str">String to be added to the component list.</param>
        public void AddElement(string str) // Feels awkward?
        {
            List.AddLast(new TextComponent(str));
        }

        /// <summary>
        /// Tabs a string for a list element.
        /// </summary>
        /// <param name="component">Component to add tabbing.</param>
        /// <param name="header">Header added in front of component.</param>
        /// <param name="paddedHeader">Padded header added in front of multiline component strings.</param>
        /// <returns>Tabbed component with a header in front of the first line.</returns>
        private string TabComponent(ConsoleComponent component, string header, string paddedHeader = null)
        {
            string toReturn = "";

            if (paddedHeader == null)
            {
                paddedHeader = GetPaddedHeader(header.Length);
            }

            string componentString = component.ToString();
            if (component is ListComponent && ((ListComponent)component).Label.Length == 0)
            {
                componentString = "\n" + componentString;
            }

            string[] lines = componentString.Split('\n');
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
        
        
        private string GetPaddedHeader(int length)
        {
            string toReturn = "";
            for (int i = 0; i < length; i++)
            {
                toReturn += " ";
            }

            return toReturn;
        }
    }
}