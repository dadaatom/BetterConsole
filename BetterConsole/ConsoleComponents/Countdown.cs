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
            Update();
            
            TimeSpan toDisplay = Target - Current;
            return toDisplay.ToString();
        }
    }
}