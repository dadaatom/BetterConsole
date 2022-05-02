using System;

namespace BetterConsole.ConsoleComponents
{
    public class Timer : TimeComponent
    {
        public Timer() : base() { }

        public override string ToString()
        {
            Current = DateTime.Now;
            TimeSpan toDisplay = Current - Starting;
            return toDisplay.ToString(); // Include styles, only potentially include days, hours, minutes, seconds, and milliseconds.
        }
    }
}