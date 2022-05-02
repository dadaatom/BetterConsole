using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using BetterConsole.Commands;
using BetterConsole.ConsoleComponents;

namespace BetterConsole
{
    /*
     * TODO:
     * - Create listener paradigm for loading bars so they dont have to be reloaded
     * - user input threads
     * - See console component todo.
     */

    public class BetterConsole
    {
        public static BetterConsole Instance;
        
        private List<ConsoleCommand> _commands;
        private List<ConsoleComponent> _displayed;
        
        private Thread _commandThread;
        private Thread _timeThread;

        private int _displayLimit;
        private int _timeComponentCount;
        
        //====================// Constructors //====================//
        
        public BetterConsole(int displayLimit = 1000)
        {
            Instance = this;
            
            _commands = new List<ConsoleCommand>();
            _displayed = new List<ConsoleComponent>();
            
            _displayLimit = displayLimit;
            _timeComponentCount = 0;
        }

        ~BetterConsole()
        {
            _commandThread?.Interrupt();
        }
        
        //====================// Simple Methods //====================//
        
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
        
        public void Write(string text, ConsoleColor color)
        {
            TextComponent textComp = new TextComponent(text);
            textComp.SetColor(color);
            Write(textComp);
        }
        
        public void Write(string text)
        {
            Write(new TextComponent(text));
        }
        
        public void WriteLine(string text, ConsoleColor color)
        {
            TextComponent textComp = new TextComponent(text);
            textComp.SetColor(color);
            WriteLine(textComp);
        }
        
        public void WriteLine(string text)
        {
            WriteLine(new TextComponent(text));
        }
        
        //implement some sort of parallel read line?
        
        public string ReadLine()
        {
            return Console.ReadLine();
        }
        
        public void Clear()
        {
            _displayed = new List<ConsoleComponent>();
            Console.Clear();
        }
        
        //====================// Display //====================//
        
        public void Reload()
        {
            Console.Clear();
            for (int i = 0; i < _displayed.Count; i++)
            {
                /*
                string toWrite = "";
                ConsoleComponent current = _displayed[i];
                while (current != null)
                {
                    toWrite += current;
                    current = current.Next;
                }
                Console.WriteLine(toWrite);
                */
                
                _displayed[i].Write();
                Console.Write("\n");
            }
        }

        private void AddToDisplay(ConsoleComponent component)
        {
            if (_displayed.Count + 1 > _displayLimit)
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
        
        //====================// Time Components //====================//
        
            /*
             * TODO:
             * threaded time reloads.
             */
        
        //====================// Command Handling //====================//
        
        public void BeginCommandHandling()
        {
            _commandThread = new Thread(HandleCommands);
            _commandThread.Start();
        }

        public void StopHandlingCommands()
        {
            _commandThread?.Interrupt();
        }

        private void HandleCommands() //Rename this function appropriately?
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (!string.IsNullOrEmpty(line))
                {
                    string[] signature = line.Split(' ');

                    foreach (ConsoleCommand command in _commands) {
                        if (command.Command.Equals(signature[0]) || command.Aliases.Contains(signature[0]))
                        {
                            command.Execute(signature);
                            break;
                        }
                    }
                }
            }
        }

        //====================// Commands //====================//
        
        public List<ConsoleCommand> GetCommands()
        {
            return _commands;
        }
        
        public void AddCommand(ConsoleCommand command)
        {
            bool exists = false;

            foreach (ConsoleCommand c in _commands)
            {
                if (c.Command.Equals(command.Command))
                {
                    //throw new Exception(); // Throw some sort of duplicate command exception?
                    exists = true;
                }
            }

            if (!exists)
            {
                _commands.Add(command);
            }
        }
    }
}