using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using BetterConsole.ConsoleComponents;

namespace BetterConsole
{
    public class BetterConsole
    {
        public static BetterConsole Instance;
        private List<ConsoleComponent> _displayed;
        private readonly int _displayLimit;

        public BetterConsole(int displayLimit = int.MaxValue)
        {
            Instance = this;
            _displayed = new List<ConsoleComponent>();
            _displayLimit = displayLimit;
        }
        
        public void Reload()
        {
            Console.Clear();
            for (int i = 0; i < _displayed.Count; i++)
            {
                string toWrite = "";
                ConsoleComponent current = _displayed[i];
                while (current != null)
                {
                    toWrite += current;
                    current = current.Next;
                }
                Console.WriteLine(toWrite);
            }
        }

        private void AddToDisplay(ConsoleComponent component)
        {
            if (_displayed.Count > _displayLimit)
            {
                _displayed.RemoveAt(0);
                _displayed.Add(component);
                Reload();
            }
            else
            {
                _displayed.Add(component);
            }
        }

        public void Write(ConsoleComponent component)
        {
            if (_displayed.Count == 0)
            {
                AddToDisplay(component);
            }
            else
            {
                _displayed[_displayed.Count-1].Next = component;
            }
            Console.Write(component);
        }
        
        public void WriteLine(ConsoleComponent component) //Enable line break and redirect to write.
        {
            AddToDisplay(component);
            Console.WriteLine(component);
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
            _displayed = new List<ConsoleComponent>();
            Console.Clear();
        }
    }
}