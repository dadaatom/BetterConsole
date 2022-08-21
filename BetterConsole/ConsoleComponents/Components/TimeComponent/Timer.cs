using System;

namespace BetterConsole.ConsoleComponents
{
    // todo: create date time formats for outputs
    
    public class Timer : TimeComponent
    {
        public Timer(int updateFrequency = 1000) : base(updateFrequency) { }

        public override string ToString()
        {
            Update();

            TimeSpan toDisplay = Current - Starting;
            return toDisplay.ToString();
        }
    }
}