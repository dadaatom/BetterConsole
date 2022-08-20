using System;
using System.Threading;
using BetterConsole.ConsoleCommands;
using BetterConsole.ConsoleComponents;
using Timer = BetterConsole.ConsoleComponents.Timer;

namespace BetterConsole
{
    internal class ExampleProgram
    {
        // Use example of the better console and built in components.
        public static void Main(string[] args)
        {
            Console.SetWindowSize(40,40);
            
            // CREATE AND WRITE GREEN BORDERED WELCOME MESSAGE //
            TextComponent welcome = new TextComponent("WELCOME");
            Border border = new Border(welcome);
            border.Color = new StaticColor(ConsoleColor.Green);
            border.PaddedContents.SetAlignments(HorizontalAlignment.Center, VerticalAlignment.Lower);
            border.PaddedContents.SetPaddings(8,1);
            BetterConsole.WriteLine(border);
            
            
            // CREATE A COOL RAINBOW TEXT //
            TextComponent rainbowText = new TextComponent("RAINBOW");
            rainbowText.Color = new RainbowColor();
            BetterConsole.WriteLine("");
            BetterConsole.WriteLine(rainbowText);
            
            
            // CREATE AND WRITE LOADING BAR //
            LoadingBar loadingBar = new LoadingBar(10);
            BetterConsole.Write("\nLoading Content: ");
            BetterConsole.WriteLine(loadingBar);
            
            
            // UPDATE LOADING BAR INCREMENTALLY //
            for (int i = 0; i < 500; i++) {
                loadingBar.SetPercentage(i/500.0);
            }
            
            loadingBar.SetPercentage(1.0);
            
            
            // CREATE AND WRITE SEPARATOR AND LABEL //
            BetterConsole.WriteLine(new Separator(30));

            
            // CREATE AND WRITE TABLE //
            Table table = new Table(3,3);

            table.SetCell(new Cell("Tom"),0,1);
            table.SetCell(new Cell("John"),0,2);
            
            table.SetCell(new Cell("Dogs"),1,0);
            table.SetCell(new Cell("Cats"),2,0);
            
            table.SetCell(new Cell("10"),1,1);
            table.SetCell(new Cell("2"),1,2);
            table.SetCell(new Cell("6"),2,1);
            table.SetCell(new Cell("9"),2,2);

            table.Resize(4,3, verticalAlignment: VerticalAlignment.Lower);
            
            Cell titleCell = new Cell("Animals Spotted", 3, 1);
            table.SetCell(titleCell, 0, 0);
            BetterConsole.WriteLine(table);

            
            // CREATE AND WRITE UNORDERED LIST //
            UnorderedList unorderedList = new UnorderedList("List of things I like:", new string[]{"Rainy days", "Multi\nLine\nStrings", "Strawberries"});
            BetterConsole.WriteLine("");
            BetterConsole.WriteLine(unorderedList);
            
            
            // CREATE AND WRITE NUMERICALLY ORDERED LIST //
            OrderedList orderedList = new OrderedList("List of my top 4 favorite numbers:",new string[]{"1", "2", "64", "4"});
            BetterConsole.WriteLine("");
            BetterConsole.WriteLine(orderedList);
            
            
            // CREATE AND WRITE ALPHABETICALLY ORDERED LIST //
            OrderedList alphabeticallyOrderedList = new OrderedList("Look at this alphabetic list:", new string[]{"Woah","Cool!","Nice"}, OrderedListStyle.Alphabetic);
            BetterConsole.WriteLine("");
            BetterConsole.WriteLine(alphabeticallyOrderedList);
            

            // CREATE AND WRITE TIMER //
            Timer timer = new Timer();
            
            BetterConsole.WriteLine("");
            BetterConsole.Write("Content loaded ");
            BetterConsole.Write(timer);
            BetterConsole.WriteLine(" ago.\n");
            
            //timer.Start();
            
            
            // CREATE AND WRITE DROPDOWN //
            Dropdown dropdown = new Dropdown("Show code example:", new TextComponent("CODE"));
            BetterConsole.WriteLine(dropdown);
            dropdown.ToggleDropped();
            
            Thread.Sleep(1000);
            BetterConsole.Reload(dropdown);
            
            
            // REGISTER COMMANDS AND BEGIN HANDLING //
            ConsoleCommand[] commands = new ConsoleCommand[]{new PingCommand(), new ExampleCommand()};
            BetterConsole.CommandHandler.Register(commands);
            //BetterConsole.CommandHandler.Start();
        }
    }
}