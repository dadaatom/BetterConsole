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
            table.SetCell(new Cell("603", 3,2),0,1);
            table.SetCell(new Cell("2345", 3,2),1,0);
            
            console.WriteLine(table);
        }
    }
}