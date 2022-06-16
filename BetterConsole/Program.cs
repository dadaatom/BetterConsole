using System;
using System.Threading;
using BetterConsole.Commands;
using BetterConsole.ConsoleComponents;

namespace BetterConsole
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            BetterConsole betterConsole = new BetterConsole();

            // CREATE GREEN BORDERED WELCOME MESSAGE.
            TextComponent welcome = new TextComponent("WELCOME");
            Border border = new Border(welcome);
            border.SetColor(ConsoleColor.Green);
            border.PaddedContents.SetAlignments(HorizontalAlignment.Center, VerticalAlignment.Lower);
            border.PaddedContents.SetPaddings(8,1);
            betterConsole.WriteLine(border);
            
            // CREATE LOADING BAR
            LoadingBar loadingBar = new LoadingBar(10);
            betterConsole.Write("\nLoading Content: ");
            betterConsole.WriteLine(loadingBar);
            
            for (int i = 0; i < 500; i++) {
                loadingBar.SetPercentage(i/500.0);
                Thread.Sleep(10);
            }
            
            loadingBar.SetPercentage(1.0);
            
            betterConsole.WriteLine(new Seperator(15));
            
            betterConsole.WriteLine("Animals Spotted:");
            
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
        }
    }
}