using System;
using System.Threading;
using System.Collections.Generic;
using BetterConsole.ConsoleCommands;
using BetterConsole.ConsoleCommands.Exception;

namespace BetterConsole
{
    /*
     * TODO:
     * Reasons why commands failed.
     */
    public class CommandHandler
    {
        public List<ConsoleCommand> RegisteredCommands { get; private set; }

        public HelpCommand HelpCommand;
        
        private Thread _thread;

        public CommandHandler()
        {
            RegisteredCommands = new List<ConsoleCommand>();
            HelpCommand = new HelpCommand();
            _thread = null;
        }

        /// <summary>
        /// Registers command to be handled.
        /// </summary>
        /// <param name="command">New command to be registered.</param>
        /// <param name="startThread">When true, starts the handling thread if not already started.</param>
        public void Register(ConsoleCommand command, bool startThread = false)
        {
            foreach (ConsoleCommand c in RegisteredCommands)
            {
                if (c.Header.Equals(command.Header))
                {
                    throw new DuplicateCommandException();
                }
            }

            RegisteredCommands.Add(command);

            if (startThread && (_thread == null || !_thread.IsAlive))
            {
                Start();
            }
        }

        /// <summary>
        /// Registers a list of commands to be handled.
        /// </summary>
        /// <param name="commands">New commands to be registered.</param>
        /// <param name="startThread">When true, starts the handling thread if not already started.</param>
        public void Register(ConsoleCommand[] commands, bool startThread = false)
        {
            foreach (ConsoleCommand command in commands)
            {
                Register(command, startThread);
            }
        }

        /// <summary>
        /// Removes command from registered commands.
        /// </summary>
        /// <param name="command">Existing command to unregister.</param>
        public void Remove(ConsoleCommand command)
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
        public void Start()
        {
            _thread = new Thread(HandleCommands);
            _thread.Start();
        }

        /// <summary>
        /// Stops command handling thread.
        /// </summary>
        public void Stop()
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
                
                string line = BetterConsole.ReadLine();

                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }
                
                string[] signature = line.Split(' ');

                CommandMatch match = null;

                if (HelpCommand != null)
                {
                    match = HelpCommand.MatchSignature(signature);
                    if (match.Success)
                    {
                        match.Matched.Execute(new CommandSignature(match.Parameters));
                    }
                }

                if (match == null || !match.Success)
                {
                    foreach (ConsoleCommand command in RegisteredCommands)
                    {
                        match = command.MatchSignature(signature);
                        if (match.Success)
                        {
                            match.Matched.Execute(new CommandSignature(match.Parameters));
                        }
                    }

                    if ((match == null || !match.Success) && HelpCommand != null)
                    {
                        BetterConsole.WriteLine("Type 'help' for command descriptions and help.\n");
                    }
                }
            }
        }
    }
}