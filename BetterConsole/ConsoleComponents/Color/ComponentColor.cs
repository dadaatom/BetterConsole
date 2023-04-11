using System;

namespace BetterConsole.ConsoleComponents
{
    public abstract class ComponentColor
    {
        /// <summary>
        /// Gets the color segmentation of a string.
        /// </summary>
        /// <param name="toDisplay">String to be color segmented.</param>
        /// <returns>Pairs of text and colors.</returns>
        public abstract ComponentBuilder ApplyTo(string toDisplay);
    }
}
