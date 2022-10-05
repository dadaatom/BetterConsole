using System;

namespace BetterConsole.ConsoleComponents
{
    // todo: create date time formats for outputs
    
    public class Timer : TimeComponent
    {
        public Timer(int updateFrequency = 1000) : base(updateFrequency) { }
        
        public override TimeSpan GetCurrentTimeSpan()
        {
            Update();
            return Current - Starting;
        }
    }
}