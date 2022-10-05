using System;
using System.Runtime.CompilerServices;

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
        public ComponentColor Color //todo: FIX THIS ASAP MAX
        {
            get
            {
                if (_color == null)
                {
                    return BetterConsole.ConsoleStyle.DefaultColor;
                }
                return _color;
            }
            set => _color = value;
        }

        private ComponentColor _color;

        //public ComponentRenderer Renderer { get; set; }

        public int Height { get; private set; }

        public int Length { get; private set; }
        
        public ConsoleComponent() : this(null) { }

        public ConsoleComponent(ComponentColor color)
        {
            Color = color;
        }

        protected abstract ComponentBuilder Build();
        
        /// <summary>
        /// Renders the component and updates the sizes.
        /// </summary>
        /// <returns>ComponentBuilder of the rendered component.</returns>
        public ComponentBuilder Render()
        {
            //ComponentBuilder toReturn = Renderer.Render();
            ComponentBuilder toReturn = Build();
            UpdateSizes(toReturn);
            return toReturn;
        }

        /// <summary>
        /// Updates height and length variables of the component.
        /// </summary>
        /// <param name="str">New display string to parse for information.</param>
        private void UpdateSizes(ComponentBuilder builder)
        {
            int maxLength = 0;
            int length = 0;
            int height = 1;

            foreach (ComponentBuilder.ComponentSegment segment in builder.Segments)
            {
                string[] list = segment.Text.Split('\n');

                if (list.Length >= 1)
                {
                    length += list[0].Length;
                    if (maxLength < length)
                    {
                        maxLength = length;
                    }
                }
                if (list.Length > 1)
                {
                    for (int i = 1; i < list.Length; i++)
                    {
                        length = list[i].Length;
                        
                        if (maxLength < length)
                        {
                            maxLength = length;
                        }
                    }

                    height += list.Length - 1;
                }

            }

            Length = maxLength;
            Height = height;
        }
    }
}