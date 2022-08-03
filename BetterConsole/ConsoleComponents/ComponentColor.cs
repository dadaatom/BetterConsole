using System;
using System.Collections.Generic;

namespace BetterConsole.ConsoleComponents
{
    public abstract class ComponentColor
    {
        public abstract Dictionary<int, ConsoleColor> GetColors(string[] toDisplay);
    }
}