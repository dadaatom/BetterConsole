using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using BetterConsole.Commands;
using BetterConsole.ConsoleComponents;

namespace BetterConsole
{
    /*
     * TODO:
     * - Create listener paradigm for loading bars so they dont have to be reloaded?
     * - user input threads
     * - remove component func
     * - See console component todo.
     * - See Table todo.
     * - See console command todo.
     */

    public class BetterConsole
    {
        public static BetterConsole Instance = new BetterConsole();

        public List<ConsoleComponent> DisplayedComponents { get; private set; }
        
        private List<ConsoleCommand> _commands;
        
        private Thread _commandThread;
        private Thread _timeThread;

        public bool EnforceLimit = false;
        private int _displayLimit;

        private long _tickFrequency;
        
        //====================// Constructors //====================//
        
        public BetterConsole(int displayLimit = 1000)
        {
            Instance = this;
            
            _commands = new List<ConsoleCommand>();
            DisplayedComponents = new List<ConsoleComponent>();
            
            _displayLimit = displayLimit;
        }

        ~BetterConsole()
        {
            _commandThread?.Interrupt();
            _timeThread?.Interrupt();
        }
        
        //====================// Ported Methods //====================//
        
        /// <summary>
        /// Writes the component within the console.
        /// </summary>
        /// <param name="component">Console component to be written.</param>
        public void Write(ConsoleComponent component)
        {
            AppendLine(component);
            component.Write();
        }
        
        /// <summary>
        /// Writes the component to the new line within the console.
        /// </summary>
        /// <param name="component">Console component to be written.</param>
        public void WriteLine(ConsoleComponent component) //Enable line break and redirect to write.
        {
            AppendLine(component);
            AddLine(null);
            component.Write();
            Console.WriteLine("");
        }
        
        /// <summary>
        /// Forwards a colored text component to the Write function.
        /// </summary>
        /// <param name="text">Text to be written.</param>
        /// <param name="color">Color to display the text.</param>
        public void Write(string text, ConsoleColor color)
        {
            TextComponent textComp = new TextComponent(text);
            textComp.SetColor(color);
            Write(textComp);
        }
        
        /// <summary>
        /// Forwards a text component to the Write function.
        /// </summary>
        /// <param name="text">Text to be written.</param>
        public void Write(string text)
        {
            Write(new TextComponent(text));
        }
        
        /// <summary>
        /// Forwards a colored text component to the WriteLine function.
        /// </summary>
        /// <param name="text">Text to be written.</param>
        /// <param name="color">Color to display the text.</param>
        public void WriteLine(string text, ConsoleColor color)
        {
            TextComponent textComp = new TextComponent(text);
            textComp.SetColor(color);
            WriteLine(textComp);
        }
        
        /// <summary>
        /// Forwards a text component to the WriteLine function.
        /// </summary>
        /// <param name="text">Text to be written.</param>
        public void WriteLine(string text)
        {
            WriteLine(new TextComponent(text));
        }

        //implement some sort of parallel read line?
        
        
        /// <summary>
        /// Reads line and adds user input to the consoles displayed list.
        /// </summary>
        /// <returns>User input read from the console.</returns>
        public string ReadLine()
        {
            string val = Console.ReadLine();
            AddLine(new TextComponent(val)); //todo: revisit when read / read line are updated inline of Console functionality
            return val;
        }
        
        /// <summary>
        /// Reads and adds user input to the consoles displayed list.
        /// </summary>
        /// <returns>User input read from the console.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public string Read()
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Clears the console and list of displayed items.
        /// </summary>
        public void Clear()
        {
            DisplayedComponents = new List<ConsoleComponent>();
            Console.Clear();
        }
        
        //====================// Display //====================//
        
        /// <summary>
        /// Clears the console and reloads either the last line or the entire console.
        /// </summary>
        /// <param name="component">Reloads based on the position of this component within the console.</param>
        public void Reload(ConsoleComponent component)
        {
            if (false) // IF IS LAST AND IS NOT MULTILINE.
            {
                Console.Write("\r");
                DisplayedComponents[DisplayedComponents.Count-1]?.Write();
            }
            else
            {
                Reload();
            }
        }
        
        /// <summary>
        /// Clears the console and rewrites all items stored within the displayed list.
        /// </summary>
        public void Reload()
        {
            Console.Clear();
            for (int i = 0; i < DisplayedComponents.Count; i++) // Fix the order in which
            {
                DisplayedComponents[i]?.Write();
                if (i < DisplayedComponents.Count-1)
                {
                    Console.Write("\n");
                }
            }
        }
        
        /// <summary>
        /// Adds a new line to the displayed list and will enforce the display limit if enabled.
        /// </summary>
        /// <param name="component">Console component to be saved within the displayed list.</param>
        private void AddLine(ConsoleComponent component)
        {
            if (DisplayedComponents.Count + 1 > _displayLimit)
            {
                DisplayedComponents.RemoveAt(0);
                DisplayedComponents.Add(component);
                if (EnforceLimit)
                {
                    Reload();
                }
            }
            else
            {
                DisplayedComponents.Add(component);
            }
        }

        /// <summary>
        /// Appends component to the end of the last line.
        /// </summary>
        /// <param name="component">New component to be appended.</param>
        private void AppendLine(ConsoleComponent component)
        {
            if (DisplayedComponents.Count == 0)
            {
                AddLine(component);
            }
            else if(DisplayedComponents[DisplayedComponents.Count-1] != null)
            {
                ConsoleComponent current = DisplayedComponents[DisplayedComponents.Count - 1];

                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = component;
            }
            else
            {
                DisplayedComponents[DisplayedComponents.Count - 1] = component;
            }
        }


        //====================// Time Handling //====================//
        
        /*
         * TODO:
         * threaded time reloads.
         */
    
        public void BeginTimeHandling(long tickFrequency)
        {
            _tickFrequency = tickFrequency;
            
            _timeThread = new Thread(HandleTimedReloads);
            _timeThread.Start();
        }

        public void StopTimeHandling()
        {
            _timeThread?.Interrupt();
        }

        private void HandleTimedReloads() //Rename this function appropriately?
        {
            long sum = 0;
            
            DateTime prev = DateTime.Now;
            while (true)
            {
                DateTime current = DateTime.Now;
                sum += (current - prev).Milliseconds;

                if (sum >= _tickFrequency)
                {
                    sum -= _tickFrequency;
                    Reload();
                    // ONLY RELOAD LAST IF POSSIBLE.
                }
            }
        }
            
        //====================// Command Handling //====================//
        
        public void BeginCommandHandling()
        {
            _commandThread = new Thread(HandleCommands);
            _commandThread.Start();
        }

        public void StopCommandHandling()
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