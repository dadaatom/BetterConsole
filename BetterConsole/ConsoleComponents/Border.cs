﻿using System;

namespace BetterConsole.ConsoleComponents
{
    /*
     * TODO:
     * Use style options here please.
     */
    public class Border : ConsoleComponent
    {
        public ConsoleComponent Contents { get; private set; }

        public readonly PaddedString PaddedContents;

        public Border(string contents) : this(new TextComponent(contents)) { }

        public Border(ConsoleComponent contents)
        {
            Contents = contents;
            PaddedContents = new PaddedString(contents.ToString());
            PaddedContents.SetPaddings(6,1);
        }

        /// <summary>
        /// Sets the inner contents of the border.
        /// </summary>
        /// <param name="contents">New inner contents.</param>
        public void SetContents(ConsoleComponent contents)
        {
            Contents = contents;
            ComputeContents();
        }

        /// <summary>
        /// Computes the inner contents before padding them.
        /// </summary>
        private void ComputeContents()
        {
            string value = "";
            ConsoleComponent current = Contents;
            
            while (current != null)
            {
                value += current.ToString();
                current = current.Next;
            }
            
            PaddedContents.SetValue(value);
        }

        /// <summary>
        /// Adds a border to the padded contents.
        /// </summary>
        /// <returns>A padded string with a surrounding border.</returns>
        public override string ToString()
        {
            string toReturn = " ";
            
            for (int j = 0; j < PaddedContents.TotalWidth; j++)
            {
                toReturn += "_";
            }
            
            toReturn += " \n";
            
            for (int i = 0; i < PaddedContents.PaddedValue.Length; i++)
            {
                toReturn += "|" + PaddedContents.PaddedValue[i] + "|\n";
            }
            
            toReturn += "|";
            
            for (int j = 0; j < PaddedContents.TotalWidth; j++)
            {
                toReturn += "_";
            }
            
            toReturn += "|";

            return toReturn;
        }
    }
}