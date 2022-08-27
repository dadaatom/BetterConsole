using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;

namespace BetterConsole.ConsoleComponents
{
    /*
     * TODO:
     * Figlet component using figlet .net
     * Style options (i.e. loading bar) (exist as a class applied to the console that most things communicate with)
     * Pages?
     * Images?
     * Buttons?
     */
    
    public abstract class ConsoleComponent
    {
        public ComponentColor Color { get; set; }

        public int Height {
            get
            {
                if (_lines == null ||_lines.Length == 0)
                {
                    Generate();
                }

                return _lines.Length;
            }
        }

        public int Length
        {
            get
            {
                int count = 0;
                foreach (string str in _lines)
                {
                    count += str.Length;
                }

                return count;
            }
        }

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

            string toDisplay = "";
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
    }
}