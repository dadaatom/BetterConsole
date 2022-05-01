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
        protected DateTime _starting;
        protected DateTime _current;
        
        public TimeComponent() : base()
        {
            _starting = DateTime.Now;
            _current = DateTime.Now;
        }

        public void Reset()
        {
            _starting = DateTime.Now;
            //reset time
        }

        public void Stop()
        {
            // remove this component from timed reload.
        }
    }
}