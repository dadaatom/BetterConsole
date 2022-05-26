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

            Table table = new Table(2,2);
            table.SetCell(new Cell("36", 3,2),0,0);
            table.SetCell(new Cell("big\n603\n?", 3,2),0,1);
            table.SetCell(new Cell("5", 3,2),1,0);
            table.SetCell(new Cell("40", 3,2),1,1);
            
            console.WriteLine(table);
        }
    }
}