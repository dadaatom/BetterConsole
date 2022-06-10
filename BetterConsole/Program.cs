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
            BetterConsole console = new BetterConsole();

            Border border = new Border("Cool animals spotted!");
            border.PaddedContents.SetAlignments(HorizontalAlignment.Center, VerticalAlignment.Lower);
            border.PaddedContents.SetPaddings(4,1);
            //Console.WriteLine(border);

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

            console.WriteLine(table);

            //console.WriteLine(table);
            //console.Write(border);
        }
    }
}