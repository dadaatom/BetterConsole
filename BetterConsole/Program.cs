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
            console.WriteLine("This will be cleared.");
            console.Clear();
            console.Write("Te");
            console.Write("st");
            console.Reload();
            console.WriteLine(new TextComponent("Let's issue some commands:"));
            console.AddCommand(new PingCommand());
            console.BeginCommandHandling();
            //console.WriteLine(new StringComponent("Loading: "));
            
            LoadingBar loadingBar = new LoadingBar(10);
            console.Write(loadingBar);
            for (int i = 0; i <= 20; i++) {
                Thread.Sleep(100);
                loadingBar.SetPercentage(i*(1/20));
            }
        }
    }
}