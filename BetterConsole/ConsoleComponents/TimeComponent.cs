using System;
using System.Threading;

namespace BetterConsole.ConsoleComponents
{
    /*
     * TODO:
     * Create some sort of static multithreaded reload for timedcomponents include update ticks.
     */
    
    public abstract class TimeComponent : ConsoleComponent
    {
        private bool _active;
        public DateTime Starting;
        
        public TimeComponent() : base()
        {
            Starting = DateTime.Now;
        }

        public void Start()
        {
            if (!_active)
            {
                _active = true;
            }
            // throw error if started?
        }

        public void Stop()
        {
            if (_active)
            {
                // remove this component from timed reload.
            }
            // throw error is not active?
        }

        public bool IsActive()
        {
            return _active;
        }

        public void Reset()
        {
            Starting = DateTime.Now;
        }
    }
}