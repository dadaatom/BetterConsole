using System;
using BetterConsole.ConsoleComponents;

namespace BetterConsole.ConsoleCommands
{
    public class HelpCommand : ConsoleCommand
    {
        public HelpCommand() : base("help") { }

        public override void Execute(CommandSignature signature)
        {
            ConsoleCommand[] commands = BetterConsole.CommandHandler.RegisteredCommands.ToArray();
            if (signature.Parameters.Length == 0)
            {
                ListCommands(commands);
            }
            else
            {
                for (int i = 0; i < signature.Parameters.Length; i++)
                {
                    string parameter = signature.Parameters[i];

                    if (commands.Length == 0)
                    {
                        break;
                    }

                    bool found = false;
                    foreach (ConsoleCommand consoleCommand in commands)
                    {
                        if (consoleCommand.Header == parameter)
                        {
                            if (i == signature.Parameters.Length - 1)
                            {
                                DisplayHelp(consoleCommand);
                                return;
                            }
                            else
                            {
                                commands = consoleCommand.SubCommands;

                                found = true;
                                break;
                            }
                        }
                    }

                    if (!found)
                    {
                        // PARAMETER NOT FOUND
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Displays commands and descriptions in the form of a table.
        /// </summary>
        /// <param name="commands">Commands to be displayed.</param>
        private void ListCommands(ConsoleCommand[] commands)
        {
            Table table = new Table(commands.Length + 1, 2);
            table.SetCell(new Cell("Command"), 0, 0);
            table.SetCell(new Cell("Description"), 0, 1);
            
            for (int i = 0; i < commands.Length; i++) {
                table.SetCell(new Cell(commands[i].Header), i+1, 0);
                table.SetCell(new Cell(commands[i].Description), i+1, 1);
            }
            
            BetterConsole.WriteLine(table);
        }

        /// <summary>
        /// Displays subcommand and parameter information of a command.
        /// </summary>
        /// <param name="command">Command to display information.</param>
        private void DisplayHelp(ConsoleCommand command)
        {
            if (command.SubCommands.Length > 0)
            {
                UnorderedList list1 = new UnorderedList();
                list1.Label = "Subcommands:";
            
                foreach (ConsoleCommand c in command.SubCommands)
                {
                    list1.List.AddLast(new TextComponent(c.Header + ": " + c.Description));
                }

                BetterConsole.WriteLine(list1);
            }
            
            if (command is ParameterizedCommand)
            {
                ParameterizedCommand parameterizedCommand = (ParameterizedCommand) command;

                if (parameterizedCommand.Parameters.Length > 0)
                {
                    UnorderedList list2 = new UnorderedList();
                    list2.Label = "Parameters:";
                
                    foreach (CommandParameter parameter in parameterizedCommand.Parameters)
                    {
                        list2.List.AddLast(new TextComponent(parameter.Label + " (" + (parameter.Required ? "required" : "optional") + ")"));
                    }
                    
                    BetterConsole.WriteLine(list2);
                }
            }
        }
    }
}