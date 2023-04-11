using System;

namespace BetterConsole.ConsoleComponents.Graph
{
    public abstract class Graph : ConsoleComponent
    {
        public GraphAxisSettings XAxis = new GraphAxisSettings();
        public GraphAxisSettings YAxis = new GraphAxisSettings();

        private int _width;
        public int Width {
            get => _width;
            set => _width = Math.Max(RequiredWidth(), value);
        }

        private int _height;
        public int Height
        {
            get => _height;
            set => _height = Math.Max(RequiredHeight(), value);
        }

        public Graph(int width = 20, int height = 10)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Required width of the graph.
        /// </summary>
        /// <returns>Graph width.</returns>
        public virtual int RequiredWidth()
        {
            return 2;
        }

        /// <summary>
        /// Required height of the graph.
        /// </summary>
        /// <returns>Graph height.</returns>
        public virtual int RequiredHeight()
        {
            return 2;
        }

        /// <summary>
        /// Builds the XAxis as a component builder.
        /// </summary>
        /// <param name="length">Lenght of the X axis.</param>
        /// <returns>X axis built as a ComponentBuilder.</returns>
        public ComponentBuilder BuildXAxis(int length)
        {
            int borderWidth = 2;
            string xAxis = "";

            for (int i = 0; i < borderWidth; i++)
            {
                xAxis += ' ';
            }

            for (int i = 0; i < length; i++)
            {
                if (i == 0)
                {
                    xAxis += '\'';
                }
                else if (i == length - 1)
                {
                    xAxis += ">\n";
                }
                else
                {
                    xAxis += '-';
                }
            }

            ComponentBuilder toReturn = new ComponentBuilder();
            toReturn.Merge(Color.ApplyTo(xAxis));

            string temp = "";
            for (int j = 0; j < borderWidth; j++)
            {
                temp += ' ';
            }
            
            PaddedComponent xBorder = new PaddedComponent(new TextComponent(XAxis.Label));
            xBorder.SetPaddings(length-XAxis.Label.Length, 1);
            
            for (int i = 0; i < xBorder.PaddedValue.Length; i++)
            {
                toReturn.Merge(Color.ApplyTo(temp));
                toReturn.Merge(Color.ApplyTo(xBorder.PaddedValue[i]));
            }

            return toReturn;
        }

        /// <summary>
        /// Builds the Y axis as a ComponentBuilder.
        /// </summary>
        /// <param name="length">Y axis length.</param>
        /// <returns>Build segments of the Y axis.</returns>
        public ComponentBuilder BuildYAxis(int length)
        {
            string newYLabel = "";
            char[] yChars = YAxis.Label.ToCharArray();

            for (int i = 0; i < yChars.Length; i++)
            {
                newYLabel += yChars[i];
                
                if (i < yChars.Length - 1)
                {
                    newYLabel += '\n';
                }
            }
            
            PaddedComponent yBorder = new PaddedComponent(new TextComponent(newYLabel), HorizontalAlignment.Left, VerticalAlignment.Center);
            yBorder.SetPaddings(1, length - YAxis.Label.Length);

            ComponentBuilder toReturn = new ComponentBuilder();
            for (int i = 0; i < length; i++)
            {
                toReturn.Merge(Color.ApplyTo(yBorder.PaddedValue[i] + (i == 0 ? '^' : '|')));
            }

            return toReturn;
        }
    }
}
