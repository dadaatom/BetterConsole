using System;
using System.Threading;

namespace BetterConsole.ConsoleComponents
{
    /*
     * TODO:
     * Create some sort of static multithreaded reload for timedcomponents include update ticks.
     * Include styles, only potentially include days, hours, minutes, seconds, and milliseconds.
     */
    
    public abstract class TimeComponent : ConsoleComponent
    {
        private bool _active;
        public DateTime Starting;
        public DateTime Current;
        
        public TimeComponent() : base()
        {
            Starting = DateTime.Now;
            Current = DateTime.Now;
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
                _active = false;
                // remove this component from timed reload.
            }
            // throw error is not active?
        }

        public void Update()
        {
            if (_active)
            {
                Current = DateTime.Now;
            }
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