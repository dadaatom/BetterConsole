using System;
using System.Drawing;
using System.IO;
using System.Threading;
using BetterConsole.ConsoleCommands;
using BetterConsole.ConsoleComponents;
using Image = BetterConsole.ConsoleComponents.Image;
using Timer = BetterConsole.ConsoleComponents.Timer;

namespace BetterConsole.Examples
{
    internal class ExampleProgram
    {
        // Use example of the better console and built in components.
        public static void Main(string[] args)
        {
            
            // CREATE IMAGE //

            Image image = new Image(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()))+"\\Images\\Welcome.png");
            BetterConsole.WriteLine(image);

            
            // CREATE A COOL RAINBOW TEXT //
            
            TextComponent rainbowText = new TextComponent("RAINBOW");
            rainbowText.Color = new RainbowColor();
            BetterConsole.BreakLine();
            BetterConsole.WriteLine(rainbowText);
            
            
            // CREATE AND WRITE LOADING BAR //
            
            LoadingBar loadingBar = new LoadingBar(10);
            BetterConsole.Write("\nLoading Content: ");
            BetterConsole.Write(loadingBar);
            
            
            // UPDATE LOADING BAR INCREMENTALLY //
            
            for (int i = 0; i < 5; i++) {
                //DO STUFF
                loadingBar.SetPercentage(i/5.0);
            }
            
            loadingBar.SetPercentage(1.0);


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

            BetterConsole.BreakLine();

            
            // CREATE AND WRITE UNORDERED LIST //
            
            UnorderedList unorderedList = new UnorderedList("List of things I like:", new string[]{"Rainy days", "Multi\nLine\nStrings", "Strawberries"});
            BetterConsole.WriteLine(unorderedList);
            
            BetterConsole.BreakLine();

            
            // CREATE AND WRITE NUMERICALLY ORDERED LIST //
            
            OrderedList orderedList = new OrderedList("List of my top 4 favorite numbers:",new string[]{"1", "2", "64", "4"});
            BetterConsole.WriteLine(orderedList);
            
            BetterConsole.BreakLine();
            
            
            // CREATE AND WRITE ALPHABETICALLY ORDERED LIST //
            
            OrderedList alphabeticallyOrderedList = new OrderedList("Look at this alphabetic list:", new string[]{"Woah","Cool!","Nice"}, OrderedListType.Alphabetic);
            BetterConsole.WriteLine(alphabeticallyOrderedList);
            
            BetterConsole.BreakLine();
            
            
            // CREATE AND WRITE DROPDOWN //
            
            Dropdown dropdown = new Dropdown("Show code example:", new TextComponent("    "+"COOL CODE HERE"));
            dropdown.ToggleDropped();
            BetterConsole.WriteLine(dropdown);
            //BetterConsole.Reload(dropdown);
            
            BetterConsole.BreakLine();
            
            
            // CREATE AND WRITE TIMER //
            
            Timer timer = new Timer();
            
            BetterConsole.BreakLine();
            BetterConsole.Write("Content loaded ");
            BetterConsole.Write(timer);
            BetterConsole.Write(" ago!");
            
            //timer.Start();
            
            BetterConsole.BreakLine();
            
            
            // REGISTER COMMANDS AND BEGIN HANDLING //
            
            CommandHandler handler = new CommandHandler();
            handler.Register(new ConsoleCommand[]{new PingCommand(), new ExampleCommand()});
            
            BetterConsole.BreakLine();
        }
    }
}