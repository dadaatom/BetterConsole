using System;
using System.Threading;
using System.Linq;
using BetterConsole.Commands;
using System.Collections.Generic;

namespace BetterConsole
{
    public class CommandHandler
    {
        public List<ConsoleCommand> RegisteredCommands { get; private set; }

        private Thread _thread;

        public CommandHandler()
        {
            RegisteredCommands = new List<ConsoleCommand>();
            _thread = null;
        }
        
        /// <summary>
        /// Registers command to be handled.
        /// </summary>
        /// <param name="command">New command to be registered.</param>
        public void Register(ConsoleCommand command)
        {
            bool exists = false;

            foreach (ConsoleCommand c in RegisteredCommands)
            {
                if (c.Command.Equals(command.Command))
                {
                    //throw new Exception(); // Throw some sort of duplicate command exception?
                    exists = true;
                }
            }

            if (exists)
            {
                return;
            }
            
            RegisteredCommands.Add(command);

            if (_thread == null || !_thread.IsAlive)
            {
                Start();
            }
        }
        
        /// <summary>
        /// Removes command from registered commands.
        /// </summary>
        /// <param name="command">Existing command to unregister.</param>
        public void UnRegister(ConsoleCommand command)
        {
            RegisteredCommands.Remove(command);
            if (RegisteredCommands.Count <= 0)
            {
                Stop();
            }
        }

        /// <summary>
        /// Starts command handling thread.
        /// </summary>
        private void Start()
        {
            _thread = new Thread(HandleCommands);
            _thread.Start();
        }

        /// <summary>
        /// Stops command handling thread.
        /// </summary>
        private void Stop()
        {
            _thread?.Interrupt();
        }

        /// <summary>
        /// Handles inputted console commands.
        /// </summary>
        private void HandleCommands()
        {
            while (true)
            {
                if (RegisteredCommands.Count <= 0)
                {
                    continue;
                }
                
                string line = Console.ReadLine();
                if (!string.IsNullOrEmpty(line))
                {
                    string[] signature = line.Split(' ');

                    foreach (ConsoleCommand command in RegisteredCommands) {
                        if (command.Command.Equals(signature[0]) || command.Aliases.Contains(signature[0]))
                        {
                            command.Execute(signature);
                            break;
                        }
                    }
                }
            }
        }
    }
}