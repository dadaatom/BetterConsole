using System;

namespace BetterConsole
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            BetterConsole console = new BetterConsole();
            console.WriteLine("This will disapear.");
            console.Clear();
            console.Write("Te");
            console.Write("st");
            console.Reload();
            console.WriteLine("Hey");
        }
    }
}