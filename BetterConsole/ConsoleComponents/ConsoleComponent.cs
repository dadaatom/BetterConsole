using System;

namespace BetterConsole.ConsoleComponents
{
    /*
     * TODO:
     * Figlet component using figlet .net
     * Style options (i.e. loading bar) (exist as a class applied to the console that most things communicate with)
     * Pages?
     * Buttons?
     */
    
    public abstract class ConsoleComponent
    {
        public ComponentColor Color { get; set; }

        public ComponentRenderer Renderer { get; set; }

        public int Height { get; private set; }

        public int Length { get; private set; }
        
        public ConsoleComponent() : this(null) { }

        public ConsoleComponent(ComponentColor color)
        {
            Color = color;
        }

        public abstract override string ToString();
        
        /// <summary>
        /// Writes the component to the console, and handles pre/post conditions.
        /// </summary>
        public void Write()
        {
            ConsoleColor baseTextColor = Console.ForegroundColor;
            ConsoleColor baseBackgroundColor = Console.BackgroundColor;
            
            DisplayText();

            Console.ForegroundColor = baseTextColor;
            Console.BackgroundColor = baseBackgroundColor;
        }

        /// <summary>
        /// Displays the component text.
        /// </summary>
        protected virtual void DisplayText()
        {
            string toDisplay = Generate();

            ComponentColor color = Color ?? BetterConsole.ConsoleStyle.DefaulColor;

            foreach (ComponentColor.ColorSegment output in color.GetColors(toDisplay))
            {
                Console.ForegroundColor = output.TextColor;
                Console.BackgroundColor = output.BackgroundColor;
                Console.Write(output.Text);
            }
        }

        /// <summary>
        /// Updates inner string with newest toString.
        /// </summary>
        /// <returns>Returns newest generation of the toString method.</returns>
        public string Generate()
        {
            string toReturn = ToString();
            UpdateSizes(toReturn);
            return toReturn;
        }

        /// <summary>
        /// Updates height and length variables of the component.
        /// </summary>
        /// <param name="str">New display string to parse for information.</param>
        private void UpdateSizes(string str)
        {
            string[] lines = str.Split('\n');

            int max = 0;
            foreach (string line in lines)
            {
                if (line.Length > max)
                {
                    max = line.Length;
                }
            }

            Length = max;
            Height = lines.Length;
        }
    }
}