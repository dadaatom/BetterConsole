using System;
using System.Collections.Generic;
using System.Threading;
using BetterConsole.ConsoleComponents;

namespace BetterConsole
{
    public class BetterConsole
    {
        public static BetterConsole Instance;
        private List<ConsoleComponent> displayed;

        public BetterConsole()
        {
            Instance = this;
            displayed = new List<ConsoleComponent>();
        }
        
        public void Write(ConsoleComponent component)
        {
            displayed.Add(component);
        }
        
        public void WriteLine(ConsoleComponent component) //Enable line break and redirect to write.
        {
            displayed.Add(component);
        }
        
        public void Write(string item)
        {
            Write(new StringComponent(item));
        }
        
        public void WriteLine(string item)
        {
            Write(new StringComponent(true, item));
        }

        public void Clear()
        {
            displayed = new List<ConsoleComponent>();
            Console.Clear();
        }
    }
}