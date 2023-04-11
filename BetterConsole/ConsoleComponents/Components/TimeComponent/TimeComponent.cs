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
        public DateTime Starting;
        public DateTime Current;

        public int UpdateFrequency { get; private set; }
        
        private bool _active;
        
        public TimeComponent() : this(1000) { }

        public TimeComponent(int updateFrequency)
        {
            Starting = DateTime.Now;
            Current = DateTime.Now;

            UpdateFrequency = updateFrequency;
            
            //Renderer = new TimeComponentRenderer(this);
        }

        public abstract TimeSpan GetCurrentTimeSpan();

        protected override ComponentBuilder Build()
        {
            return Color.ApplyTo(GetCurrentTimeSpan().ToString());
        }

        /// <summary>
        /// Starts the time component.
        /// </summary>
        public void Start()
        {
            if (!_active)
            {
                _active = true;
                BetterConsole.TimeHandler?.Subscribe(this);
            }
            // throw error if started?
        }

        /// <summary>
        /// Stops the time component.
        /// </summary>
        public void Stop()
        {
            if (_active)
            {
                _active = false;
                BetterConsole.TimeHandler?.UnSubscribe(this);
            }
            // throw error is not active?
        }

        /// <summary>
        /// Updates the current time given the timer is active.
        /// </summary>
        public void Update()
        {
            if (_active)
            {
                Current = DateTime.Now;
            }
        }
         
        /// <summary>
        /// Gets whether the time component is active.
        /// </summary>
        /// <returns>Is time component active.</returns>
        public bool IsActive()
        {
            return _active;
        }

        /// <summary>
        /// Resets the component.
        /// </summary>
        public void Reset()
        {
            Starting = DateTime.Now;
        }
    }
}
