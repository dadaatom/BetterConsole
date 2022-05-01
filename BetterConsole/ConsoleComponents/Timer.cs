using System;

namespace BetterConsole.ConsoleComponents
{
    public class Timer : TimeComponent
    {
        public Timer() : base() { }

        public override string ToString()
        {
            _current = DateTime.Now;
            TimeSpan toDisplay = _current - _starting;
            return toDisplay.ToString(); // Include styles, only potentially include days, hours, minutes, seconds, and milliseconds.
        }
    }
}