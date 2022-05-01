using System;

namespace BetterConsole.ConsoleComponents
{
    public class TimerComponent : TimeComponent
    {
        public TimerComponent() : base() { }

        public override string ToString()
        {
            _current = DateTime.Now;
            return (_current - _starting).ToString(); // Include styles, only potentially include days, hours, minutes, seconds, and milliseconds.
        }
    }
}