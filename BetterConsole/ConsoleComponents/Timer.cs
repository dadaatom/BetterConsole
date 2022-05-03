using System;

namespace BetterConsole.ConsoleComponents
{
    public class Timer : TimeComponent
    {
        public Timer() : base() { }

        public override string ToString()
        {
            TimeSpan toDisplay = DateTime.Now - Starting;
            return toDisplay.ToString(); // Include styles, only potentially include days, hours, minutes, seconds, and milliseconds.
        }
    }
}