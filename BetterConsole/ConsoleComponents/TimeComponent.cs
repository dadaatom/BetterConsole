using System;
using System.Threading;

namespace BetterConsole.ConsoleComponents
{
    /*
     * TODO:
     * Create some sort of static multithreaded reload for timedcomponents include update ticks.
     * timer component
     * countdown component
     */
    
    public abstract class TimeComponent : ConsoleComponent
    {
        public DateTime Starting;
        
        public TimeComponent() : base()
        {
            Starting = DateTime.Now;
        }

        public void Start()
        {
            
        }

        public void Stop()
        {
            // remove this component from timed reload.
        }
        
        public void Reset()
        {
            Starting = DateTime.Now;
        }
    }
}