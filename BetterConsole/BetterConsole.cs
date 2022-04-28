﻿using System;
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

        private Thread commandThread;
        
        //====================// Constructors //====================//
        
        public BetterConsole(int displayLimit = 1000)
        {
            Instance = this;
            
            _commands = new List<ConsoleCommand>();
            
            _displayed = new List<ConsoleComponent>();
            _displayed.Capacity = displayLimit;
        }
        
        
        ~BetterConsole()
        {
            commandThread?.Interrupt();
        }
        
        
        //====================// Displays //====================//
        
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
            if (_displayed.Count + 1 > _displayed.Capacity)
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
        
        //====================// Commands //====================//

        public string ReadLine()
        {
            return Console.ReadLine();
        }
        
        //implement some sort of parallel read line.
        
        
        public void BeginCommandHandling()
        {
            commandThread = new Thread(HandleCommands);
            commandThread.Start();
        }

        public void StopHandlingCommands()
        {
            commandThread?.Interrupt();
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
            _commands.Add(command);
        }
    }
}