using System.Drawing;
using BetterConsole.ConsoleComponents;

namespace BetterConsole.Examples
{
    public class ExampleColor : ComponentColor
    {
        public Color[] Colors { get; }

        public ExampleColor(Color[] colors)
        {
            Colors = colors;
        }

        public override ComponentBuilder ApplyTo(string toDisplay)
        {
            ComponentBuilder toReturn = new ComponentBuilder();
            string[] list = toDisplay.Split(new[] {' ', '\n'});

            for(int i = 0; i < list.Length; i++)
            {
                toReturn.Append(new ComponentBuilder.ComponentSegment(list[i], Colors[i % Colors.Length]));
            }

            return toReturn;
        }
    }
}