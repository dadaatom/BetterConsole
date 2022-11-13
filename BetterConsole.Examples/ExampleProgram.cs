using System.IO;
using BetterConsole.ConsoleCommands;
using BetterConsole.ConsoleComponents;
using BetterConsole.ConsoleComponents.Graph;

namespace BetterConsole.Examples
{
    internal class ExampleProgram
    {
        // Use example of the better console and built in components.
        public static void Run(string[] args)
        {
            
            // INSTANTIATE THE BETTERCONSOLE //
            
            BetterConsole.Instantiate();
            
            
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
            
            UnorderedList unorderedList = new UnorderedList("List of things I like:", new[]{"Rainy days", "Multi\nLine\nStrings", "Strawberries"});
            BetterConsole.WriteLine(unorderedList);
            
            BetterConsole.BreakLine();

            
            // CREATE AND WRITE NUMERICALLY ORDERED LIST //
            
            OrderedList orderedList = new OrderedList("List of my top 4 favorite numbers:",new[]{"1", "2", "64", "4"});
            BetterConsole.WriteLine(orderedList);
            
            BetterConsole.BreakLine();
            
            
            // CREATE AND WRITE ALPHABETICALLY ORDERED LIST //
            
            OrderedList alphabeticallyOrderedList = new OrderedList("Look at this alphabetic list:", new[]{"Woah","Cool!","Nice"}, OrderedListType.Alphabetic);
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
            
            
            // CREATE HISTOGRAM //

            Histogram histo = new Histogram(new[]{new HistoBar("A", 3.2), new HistoBar("B", 4.05), new HistoBar("C", 1.7)});
            histo.XAxis.Label = "Bars";
            histo.YAxis.Label = "Cost";
            BetterConsole.WriteLine(histo);
            BetterConsole.BreakLine();
            
            
            // CREATE SCATTERPLOT //
            
            Point[] points = { new Point(0, 3), new Point(3.2, 6), new Point(17,8)};
            ScatterPlot scatterPlot = new ScatterPlot(points);
            scatterPlot.XAxis.Label = "Volume";
            scatterPlot.YAxis.Label = "Price";
            BetterConsole.WriteLine(scatterPlot);
            BetterConsole.BreakLine();
            
            
            // REGISTER COMMANDS AND BEGIN HANDLING //
            
            CommandHandler handler = new CommandHandler();
            handler.Register(new ConsoleCommand[]{new PingCommand(), new ExampleCommand()});
            
            BetterConsole.BreakLine();
            
        }
    }
}