﻿using System;
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
            console.WriteLine(new StringComponent("Let's issue some commands:", ConsoleColor.DarkCyan));
            console.AddCommand(new PingCommand());
            console.BeginCommandHandling();
            //console.WriteLine(new StringComponent("Loading: "));
            
            /*
            LoadingBarComponent loadingBarBar = new LoadingBarComponent(10, ConsoleColor.Green);
            console.Write(loadingBarBar);

            for (int i = 0; i <= 20; i++) {
                Thread.Sleep(100);

                loadingBarBar.SetPercentage(i*.05f);
                console.Reload();
            }
            */
            
            
        }
    }
}