using System;
using System.Threading;
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
            console.WriteLine(new StringComponent("Loading: "));

            LoadingComponent loadingBar = new LoadingComponent(10);
            
            console.Write(loadingBar);

            for (int i = 0; i <= 20; i++) {
                Thread.Sleep(100);

                loadingBar.SetPercentage(i*.05f);
                console.Reload();
            }
        }
    }
}