using System;
using System.Collections.Generic;
using System.Threading;
using BetterConsole.ConsoleComponents;

namespace BetterConsole
{
    public class TimeHandler
    {
        public LinkedList<TimeComponent> SubscribedComponents { get; set; }
        
        private Thread _thread;

        public TimeHandler()
        {
            SubscribedComponents = new LinkedList<TimeComponent>();
        }

        public void Start()
        {
            _thread = new Thread(HandleTime);
            _thread.Start();
        }

        public void Stop()
        {
            _thread?.Interrupt();
        }

        private void HandleTime() //Rename this function appropriately? Rework this using Current time to handle different update rates.
        {
            while (true)
            {
                DateTime current = DateTime.Now;
                foreach (TimeComponent component in SubscribedComponents)
                {
                    
                }
            }
        }
    }
}