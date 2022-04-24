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
        
        public void Reload()
        {
            Console.Clear();
            for (int i = 0; i < displayed.Count; i++)
            {
                string toWrite = "";
                ConsoleComponent current = displayed[i];
                while (current != null)
                {
                    toWrite += current;
                    current = current.Next;
                }
                Console.WriteLine(toWrite);
            }
        }
        
        public void Write(ConsoleComponent component)
        {
            if (displayed.Count == 0)
            {
                displayed.Add(component);
            }
            else
            {
                displayed[displayed.Count-1].Next = component;
            }
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
            WriteLine(new StringComponent(item));
        }

        public void Clear()
        {
            displayed = new List<ConsoleComponent>();
            Console.Clear();
        }
    }
}