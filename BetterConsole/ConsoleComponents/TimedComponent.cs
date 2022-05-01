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
    
    public abstract class TimedComponent : ConsoleComponent
    {
        private DateTime _starting;
        private DateTime _current;
        
        public TimedComponent()
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