﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;

namespace BetterConsole.ConsoleComponents
{
    /*
     * TODO:
     * Color strategy pattern
     * Figlet component using figlet .net
     * Style options (i.e. loading bar) (exist as a class applied to the console that most things communicate with)
     * Pages?
     * Images?
     * Buttons?
     */
    
    public abstract class ConsoleComponent
    {
        public ComponentColor Color { get; set; }
        
        private string[] _lines;

        public ConsoleComponent() : this(BetterConsole.ConsoleStyle.DefaultColor) { }

        public ConsoleComponent(ComponentColor color)
        {
            //Next = null;
            Color = color;

            _lines = new string[0];
        }

        public abstract override string ToString();
        
        /// <summary>
        /// Writes the entire line to the console.
        /// </summary>
        /// <param name="generate">Updates inner string with newest toString iteration.</param>
        public void Write(bool generate = true)
        {
            ConsoleColor baseColor = Console.ForegroundColor;
            //Console.ForegroundColor = Color;
            
            if (generate)
            {
                _lines = Generate().Split('\n');
            }

            string toDisplay = ""; // Loop this data into an input var.
            for (int i = 0; i < _lines.Length; i++) {
                toDisplay += _lines[i];
                if (i < _lines.Length - 1)
                {
                    toDisplay += '\n';
                }
            }

            foreach (ComponentColor.ColorSegment output in Color.GetColors(toDisplay))
            {
                Console.ForegroundColor = output.Color;
                Console.Write(output.Text);
            }

            Console.ForegroundColor = baseColor;
        }
        
        /// <summary>
        /// Updates inner string with newest toString.
        /// </summary>
        /// <returns>Returns newest generation of the toString method.</returns>
        public string Generate()
        {
            string toReturn = ToString();
            _lines = toReturn.Split('\n');
            return toReturn;
        }

        /// <summary>
        /// Gets the number of lines in the Console Component.
        /// </summary>
        /// <returns>Line count of the component.</returns>
        public int GetLineCount()
        {
            return _lines.Length;
        }

        /// <summary>
        /// Gets the length of all characters in the Console Component.
        /// </summary>
        /// <returns>Length of the string.</returns>
        public int Length()
        {
            int count = 0;
            foreach (string str in _lines)
            {
                count += str.Length;
            }

            return count;
        }
    }
}