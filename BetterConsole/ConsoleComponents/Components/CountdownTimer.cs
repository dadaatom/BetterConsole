using System;

namespace BetterConsole.ConsoleComponents
{
    public class CountdownTimer : TimeComponent
    {
        public DateTime Target;
        
        public CountdownTimer(DateTime target, int updateFrequency = 1000) : base(updateFrequency)
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