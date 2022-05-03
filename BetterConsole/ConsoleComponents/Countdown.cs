using System;

namespace BetterConsole.ConsoleComponents
{
    public class Countdown : TimeComponent
    {
        public DateTime Target;
        
        public Countdown(DateTime target)
        {
            Target = target;
        }

        public override string ToString()
        {
            TimeSpan toDisplay = Target - DateTime.Now;
            return toDisplay.ToString();
        }
    }
}