using System;
using BetterConsole.ConsoleComponents;

namespace BetterConsole.ConsoleCommands
{
    public class HelpCommand : ConsoleCommand
    {
        public HelpCommand(string header) : base(header) { }

        public override void Execute(CommandSignature signature)
        {
            
        }

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

        private void DisplayHelp(ConsoleCommand command)
        {
            UnorderedList list1 = new UnorderedList();
            list1.Label = "Subcommands:";
            foreach (ConsoleCommand c in command.SubCommands)
            {
                list1.List.AddLast(new TextComponent(c.Header + ": " + c.Description));
            }
            
            UnorderedList list2 = new UnorderedList();
            list2.Label = "Parameters:";
            foreach (CommandParameter parameter in command.Parameters)
            {
                list2.List.AddLast(new TextComponent(parameter.Label + " (" + (parameter.Required ? "required" : "optional") + ")"));
            }
            
            BetterConsole.WriteLine(list1);
            BetterConsole.WriteLine(list2);
        }
    }
}