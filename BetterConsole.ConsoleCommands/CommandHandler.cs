using System;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;
using BetterConsole.ConsoleCommands.Exception;

namespace BetterConsole.ConsoleCommands
{
    /*
     * TODO Reasons why commands failed.
     * TODO Create shortcut for help with last failed command.
     */
    public class CommandHandler
    {
        public static CommandHandler Instance;
        
        public List<ConsoleCommand> RegisteredCommands { get; private set; }

        public string Delimiter;
        
        public HelpCommand HelpCommand;
        
        private Thread _thread;

        public CommandHandler(string delimiter = "")
        {
            Instance = this;

            Delimiter = delimiter;
            
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

                if (string.IsNullOrEmpty(line) || line.IndexOf(Delimiter, StringComparison.Ordinal) != 0)
                {
                    continue;
                }
                
                string[] signature = line.Split(' ');

                CommandMatch match = HandleSignature(signature);

                if (!match.Success)
                {
                    if (match.Heuristic > 0)
                    {
                        BetterConsole.Write("Signature validation failed on command '" + match.Matched.Header + "'");
                    }
                    else
                    {
                        BetterConsole.Write("Command not recognised");
                    }
                    
                    if (HelpCommand != null)
                    {
                        BetterConsole.Write(", ");
                        BetterConsole.WriteLine("type 'help' for command descriptions and help.\n");
                    }
                    else
                    {
                        BetterConsole.WriteLine(".");
                    }
                }
                BetterConsole.BreakLine();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="signature"></param>
        /// <returns></returns>
        private CommandMatch HandleSignature(string[] signature)
        {
            CommandMatch bestMatch = null;

            for (int i = 0; i <= RegisteredCommands.Count; i++)
            {
                ConsoleCommand command;

                if (i == 0)
                {
                    command = HelpCommand;
                }
                else
                {
                    command = RegisteredCommands[i-1];
                }

                if (command == null)
                {
                    continue;
                }

                CommandMatch match = command.MatchSignature(signature);
                    
                if (bestMatch == null || match.Heuristic > bestMatch.Heuristic)
                {
                    bestMatch = match;
                }
                    
                if (match.Success)
                {
                    match.Matched.Execute(new CommandSignature(match.Parameters));
                    return match;
                }
            }

            return bestMatch;
        }
    }
}