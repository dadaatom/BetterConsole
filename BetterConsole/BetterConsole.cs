using System;
using System.Collections.Generic;
using BetterConsole.ConsoleComponents;

namespace BetterConsole
{
    /*
     * TODO:
     * - user input threads?
     * - See console component todo.
     * - See Table todo.
     * - See console command todo.
     * - Memoization for longer computations.
     * - bug Console.Clear() on reload.
     */

    public static class BetterConsole
    {
        public static ConsoleStyle ConsoleStyle = new ConsoleStyle(new StaticColor(ConsoleColor.Gray));

        public static ConsoleHandler ConsoleHandler { get; private set; }

        public static TimeHandler TimeHandler { get; private set; }
        
        static BetterConsole()
        {
            ConsoleHandler = new ConsoleHandler();
            TimeHandler = new TimeHandler();
        }

        public static void WriteLine(ConsoleComponent component) => ConsoleHandler.WriteLine(component);
        
        public static void WriteLine(string str) => ConsoleHandler.WriteLine(str);
        
        public static void WriteLine(string str, ComponentColor color) => ConsoleHandler.WriteLine(str, color);
        
        public static void Write(ConsoleComponent component) => ConsoleHandler.Write(component);
        
        public static void Write(string str) => ConsoleHandler.Write(str);
        
        public static void Write(string str, ComponentColor color) => ConsoleHandler.Write(str, color);

        public static string ReadLine() => ConsoleHandler.ReadLine();
        
        public static string Read() => ConsoleHandler.Read();
        
        public static void Clear() => ConsoleHandler.Clear();
        
        public static void Reload() => ConsoleHandler.Reload();
        
        public static void Reload(ConsoleComponent component) => ConsoleHandler.Reload(component);
    }
}