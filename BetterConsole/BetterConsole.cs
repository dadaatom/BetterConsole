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
        public static ConsoleStyle ConsoleStyle { get; private set; }

        public static ConsoleHandler ConsoleHandler { get; private set; }

        public static TimeHandler TimeHandler { get; private set; }
        
        static BetterConsole()
        {
            ConsoleTheme theme = new ConsoleTheme(new StaticColor(ConsoleColor.Blue), new StaticColor(ConsoleColor.Cyan), new StaticColor(ConsoleColor.Yellow));
            ConsoleStyle = new ConsoleStyle(new StaticColor(ConsoleColor.Gray), theme);
            
            ConsoleHandler = new ConsoleHandler(100);
            TimeHandler = new TimeHandler();
        }

        /// <summary>
        /// Writes the component within the console.
        /// </summary>
        /// <param name="component">Console component to be written.</param>
        public static void Write(ConsoleComponent component) => ConsoleHandler.Write(component);
        
        /// <summary>
        /// Writes the component to the new line within the console.
        /// </summary>
        /// <param name="component">Console component to be written.</param>
        public static void WriteLine(ConsoleComponent component) => ConsoleHandler.WriteLine(component);
        
        /// <summary>
        /// Forwards a colored text component to the Write function.
        /// </summary>
        /// <param name="text">Text to be written.</param>
        /// <param name="color">Color to display the text.</param>
        public static void Write(string text, ComponentColor color) => ConsoleHandler.Write(new TextComponent(text, color));
        
        /// <summary>
        /// Forwards a text component to the Write function.
        /// </summary>
        /// <param name="text">Text to be written.</param>
        public static void Write(string text) => ConsoleHandler.Write(new TextComponent(text));
        
        
        /// <summary>
        /// Forwards a colored text component to the WriteLine function.
        /// </summary>
        /// <param name="text">Text to be written.</param>
        /// <param name="color">Color to display the text.</param>
        public static void WriteLine(string text, ComponentColor color) => ConsoleHandler.WriteLine(new TextComponent(text, color));
        
        
        /// <summary>
        /// Forwards a text component to the WriteLine function.
        /// </summary>
        /// <param name="text">Text to be written.</param>
        public static void WriteLine(string text) => ConsoleHandler.WriteLine(new TextComponent(text));

        /// <summary>
        /// Reads line and adds user input to the consoles displayed list.
        /// </summary>
        /// <returns>User input read from the console.</returns>
        public static string ReadLine() => ConsoleHandler.ReadLine();
        
        /// <summary>
        /// Reads and adds user input to the consoles displayed list.
        /// </summary>
        /// <returns>User input read from the console.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public static string Read() => ConsoleHandler.Read();
        
        /// <summary>
        /// Clears the console and list of displayed items.
        /// </summary>
        public static void Clear() => ConsoleHandler.Clear();
        
        /// <summary>
        /// Clears the console and reloads either the last line or the entire console.
        /// </summary>
        /// <param name="component">Reloads based on the position of this component within the console.</param>
        public static void Reload(ConsoleComponent component) => ConsoleHandler.Reload(component);
        
        /// <summary>
        /// Clears the console and rewrites all items stored within the displayed list.
        /// </summary>
        public static void Reload() => ConsoleHandler.Reload();
        
        /// <summary>
        /// Creates a line break.
        /// </summary>
        public static void BreakLine() => ConsoleHandler.BreakLine();
    }
}