using System;
using System.Threading;
using BetterConsole.Commands;
using BetterConsole.ConsoleComponents;
using Timer = BetterConsole.ConsoleComponents.Timer;

namespace BetterConsole
{
    internal class Program
    {
        // Use example of the better console and built in components.
        public static void Main(string[] args)
        {
            // CREATE DEFAULT BETTER CONSOLE //
            BetterConsole betterConsole = new BetterConsole();

            // CREATE AND WRITE GREEN BORDERED WELCOME MESSAGE //
            TextComponent welcome = new TextComponent("WELCOME");
            Border border = new Border(welcome);
            border.SetColor(ConsoleColor.Green);
            border.PaddedContents.SetAlignments(HorizontalAlignment.Center, VerticalAlignment.Lower);
            border.PaddedContents.SetPaddings(8,1);
            betterConsole.WriteLine(border);
            
            // CREATE AND WRITE LOADING BAR //
            LoadingBar loadingBar = new LoadingBar(10);
            betterConsole.Write("\nLoading Content: ");
            betterConsole.WriteLine(loadingBar);
            
            // UPDATE LOADING BAR INCREMENTALLY //
            for (int i = 0; i < 500; i++) {
                loadingBar.SetPercentage(i/500.0);
            }
            
            loadingBar.SetPercentage(1.0);
            
            // CREATE AND WRITE SEPARATOR AND LABEL //
            betterConsole.WriteLine(new Separator(15));
            
            betterConsole.WriteLine("Animals Spotted:");

            // CREATE AND WRITE TABLE //
            Table table = new Table(4,3);

            table.SetCell(new Cell("Tom"),0,1);
            table.SetCell(new Cell("John"),0,2);
            
            table.SetCell(new Cell("Dogs"),1,0);
            table.SetCell(new Cell("Cats"),2,0);
            
            table.SetCell(new Cell("10"),1,1);
            table.SetCell(new Cell("2"),1,2);
            table.SetCell(new Cell("6"),2,1);
            table.SetCell(new Cell("9"),2,2);
            
            table.SetCell(new Cell("Cool\nBird"),3,0);
            table.SetCell(new Cell("1"),3,1);
            table.SetCell(new Cell("0"),3,2);

            betterConsole.WriteLine(table);

            // CREATE AND WRITE TIMER //
            Timer timer = new Timer();
            
            betterConsole.Write("Content loaded: ");
            betterConsole.Write(timer);
            
            timer.Start();
        }
    }
}