﻿using System;
using System.Collections.Generic;
using BetterConsole.ConsoleCommands.Exception;

namespace BetterConsole.ConsoleCommands
{
    /*
     * TODO:
     * aliases
     * array validation strategy
     * return const list of parameters in signature.
     */
    public abstract class ConsoleCommand
    {
        public string Header { get; }
        
        public ConsoleCommand[] SubCommands { get; private set; }

        public string Description { get; set; } = "";

        public ConsoleCommand(string header, string description = "") : this(header, new ConsoleCommand[]{}, description) { }
        
        public ConsoleCommand(string header, ConsoleCommand[] subCommands, string description = "")
        {
            Header = header;
            SetSubCommands(subCommands);
            Description = description;
        }

        /// <summary>
        /// Called when command signature is detected in input.
        /// </summary>
        /// <param name="signature">Signature read from the command line.</param>
        public abstract void Execute(CommandSignature signature);

        /// <summary>
        /// Matches signature to the console command and returns the best command match.
        /// </summary>
        /// <param name="signature">Signature to match command with</param>
        /// <returns>A command match containing all the information concerning the match.</returns>
        public CommandMatch MatchSignature(string[] signature)
        {
            string[] subSignature = new string[Math.Max(0, signature.Length - 1)];

            for (int i = 0; i < subSignature.Length; i++)
            {
                subSignature[i] = signature[i+1];
            }
            
            if (signature.Length > 0 && Header == signature[0])
            {
                CommandMatch bestMatch = null;
                
                foreach (ConsoleCommand command in SubCommands)
                {
                    CommandMatch match = command.MatchSignature(subSignature);
                    if (match.Success)
                    {
                        match.Heuristic *= match.Heuristic;
                        return match;
                    }

                    if (bestMatch == null || match.Heuristic > bestMatch.Heuristic)
                    {
                        bestMatch = match;
                    }
                }
                
                if (ValidateSignature(subSignature))
                {
                    return new CommandMatch(true, this, subSignature, subSignature.Length);
                }

                if (bestMatch != null)
                {
                    bestMatch.Heuristic++;
                    return bestMatch;
                }
                else
                {
                    return new CommandMatch(false, this, subSignature, 1);
                }
            }

            return new CommandMatch(false, this, subSignature);
        }

        /// <summary>
        /// Overrideable function that validates the parameters passed to the function.
        /// </summary>
        /// <param name="signature">Array of parameters to be passed to the function.</param>
        /// <returns>Validity of the signature, default is true.</returns>
        public virtual bool ValidateSignature(string[] signature)
        {
            return true;
        }

        /// <summary>
        /// Sets the subcommands.
        /// </summary>
        /// <param name="commands">Array of new commands to set.</param>
        /// <exception cref="DuplicateCommandException">Thrown when another command already exists with the same header.</exception>
        public void SetSubCommands(ConsoleCommand[] commands)
        {
            List<string> list = new List<string>();
            foreach (ConsoleCommand command in commands) {
                if (list.Contains(command.Header))
                {
                    throw new DuplicateCommandException();
                }
                list.Add(command.Header);
            }

            SubCommands = commands;
        }
    }
}