using System;
using System.Collections.Generic;
using System.Threading;
using BetterConsole.ConsoleComponents;

namespace BetterConsole
{
    public class TimeHandler
    {
        public LinkedList<TimeComponent> SubscribedComponents { get; private set; }
        
        private Thread _thread;

        public TimeHandler()
        {
            SubscribedComponents = new LinkedList<TimeComponent>();
        }

        /// <summary>
        /// Subscribes component to the time handler.
        /// </summary>
        /// <param name="component">New time component to handle.</param>
        public void Subscribe(TimeComponent component)
        {
            SubscribedComponents.AddLast(component);
            if (_thread == null || !_thread.IsAlive)
            {
                Start();
            }
        }

        /// <summary>
        /// Unsubscribes component from the time handler.
        /// </summary>
        /// <param name="component">Existing time component to stop handling.</param>
        public void UnSubscribe(TimeComponent component)
        {
            SubscribedComponents.Remove(component);
            if (SubscribedComponents.Count <= 0)
            {
                Stop();
            }
        }

        /// <summary>
        /// Starts time handling thread.
        /// </summary>
        private void Start()
        {
            _thread = new Thread(HandleTime);
            _thread.Start();
        }

        /// <summary>
        /// Stops time handling thread.
        /// </summary>
        private void Stop()
        {
            _thread?.Interrupt();
        }

        /// <summary>
        /// Handles timed reload of timer components.
        /// </summary>
        private void HandleTime()
        {
            while (true)
            {
                if (SubscribedComponents.Count <= 0)
                {
                    continue;
                }
                
                TimeComponent timeComponent = null;
                double millis = double.MaxValue;
                
                DateTime current = DateTime.Now;
                foreach (TimeComponent component in SubscribedComponents)
                {
                    double timeToReload = component.UpdateFrequency - (current - component.Current).TotalMilliseconds;

                    if (timeToReload < millis)
                    {
                        millis = timeToReload;
                        timeComponent = component;
                    }
                }

                if (millis > 0)
                {
                    Thread.Sleep((int)millis);
                }
                
                BetterConsole.Reload(timeComponent);
            }
        }
    }
}
