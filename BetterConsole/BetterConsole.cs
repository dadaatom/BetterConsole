using System;
using BetterConsole.ConsoleComponents;
using BetterConsole.Exception;

namespace BetterConsole
{
    /*
     * TODO:
     * - See console component todo.
     * - See Table todo.
     * - See console command todo.
     * - Memoization for longer computations?
     * - bug Console.Clear() on reload.
     */

    public static class BetterConsole
    {
        public static ConsoleStyle ConsoleStyle { get; private set; }

        public static ConsoleHandler ConsoleHandler { get; private set; }

        public static TimeHandler TimeHandler { get; private set; }

        /// <summary>
        /// Instantiates the BetterConsole attributes.
        /// </summary>
        public static void Instantiate()
        {
            ConsoleHandler handler = new ConsoleHandler(100);
            TimeHandler timeHandler = new TimeHandler();
            ConsoleStyle consoleStyle = new ConsoleStyle(new StaticColor(ColorUtil.ConvertToColor(ConsoleColor.Gray)), new ConsoleTheme());
            
            Instantiate(handler, timeHandler, consoleStyle);
        }
        
        /// <summary>
        /// Instantiates the BetterConsole attributes.
        /// </summary>
        /// <param name="handler">New console handler.</param>
        /// <param name="timeHandler">New time handler.</param>
        public static void Instantiate(ConsoleHandler handler, TimeHandler timeHandler)
        {
            ConsoleStyle consoleStyle = new ConsoleStyle(new StaticColor(ColorUtil.ConvertToColor(ConsoleColor.Gray)), new ConsoleTheme());
            Instantiate(handler, timeHandler, consoleStyle);
        }

        /// <summary>
        /// Instantiates the BetterConsole attributes.
        /// </summary>
        /// <param name="handler">New console handler.</param>
        /// <param name="timeHandler">New time handler.</param>
        /// <param name="style">New console style.</param>
        public static void Instantiate(ConsoleHandler handler, TimeHandler timeHandler, ConsoleStyle style)
        {
            ConsoleHandler = handler;
            TimeHandler = timeHandler;
            ConsoleStyle = style;
        }

        /// <summary>
        /// Writes the component within the console.
        /// </summary>
        /// <param name="component">Console component to be written.</param>
        public static void Write(ConsoleComponent component)
        {
            CheckInstantiationStatus();
            ConsoleHandler.Write(component);
        }

        /// <summary>
        /// Writes the component to the new line within the console.
        /// </summary>
        /// <param name="component">Console component to be written.</param>
        public static void WriteLine(ConsoleComponent component)
        {
            CheckInstantiationStatus();
            ConsoleHandler.WriteLine(component);
        }

        /// <summary>
        /// Forwards a colored text component to the Write function.
        /// </summary>
        /// <param name="text">Text to be written.</param>
        /// <param name="color">Color to display the text.</param>
        public static void Write(string text, ComponentColor color)
        {
            CheckInstantiationStatus();
            ConsoleHandler.Write(new TextComponent(text, color));
        }

        /// <summary>
        /// Forwards a text component to the Write function.
        /// </summary>
        /// <param name="text">Text to be written.</param>
        public static void Write(string text)
        {
            CheckInstantiationStatus();
            ConsoleHandler.Write(new TextComponent(text));
        }

        /// <summary>
        /// Forwards a colored text component to the WriteLine function.
        /// </summary>
        /// <param name="text">Text to be written.</param>
        /// <param name="color">Color to display the text.</param>
        public static void WriteLine(string text, ComponentColor color)
        {
            CheckInstantiationStatus();
            ConsoleHandler.WriteLine(new TextComponent(text, color));
        }

        /// <summary>
        /// Forwards a text component to the WriteLine function.
        /// </summary>
        /// <param name="text">Text to be written.</param>
        public static void WriteLine(string text)
        {
            CheckInstantiationStatus();
            ConsoleHandler.WriteLine(new TextComponent(text));
        }

        /// <summary>
        /// Reads line and adds user input to the consoles displayed list.
        /// </summary>
        /// <returns>User input read from the console.</returns>
        public static string ReadLine()
        {
            CheckInstantiationStatus();
            return ConsoleHandler.ReadLine();
        }

        /// <summary>
        /// Reads and adds user input to the consoles displayed list.
        /// </summary>
        /// <returns>User input read from the console.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public static string Read()
        {
            CheckInstantiationStatus();
            return ConsoleHandler.Read();
        }

        /// <summary>
        /// Clears the console and list of displayed items.
        /// </summary>
        public static void Clear()
        {
            CheckInstantiationStatus();
            ConsoleHandler.Clear();
        }

        /// <summary>
        /// Clears the console and reloads either the last line or the entire console.
        /// </summary>
        /// <param name="component">Reloads based on the position of this component within the console.</param>
        public static void Reload(ConsoleComponent component)
        {
            CheckInstantiationStatus();
            ConsoleHandler.Reload(component);
        }

        /// <summary>
        /// Clears the console and rewrites all items stored within the displayed list.
        /// </summary>
        public static void Reload()
        {
            CheckInstantiationStatus();
            ConsoleHandler.Reload();
        }

        /// <summary>
        /// Creates a line break.
        /// </summary>
        public static void BreakLine()
        {
            CheckInstantiationStatus();
            ConsoleHandler.BreakLine();
        }

        /// <summary>
        /// Checks if BetterConsole has been started.
        /// </summary>
        /// <exception cref="NotInstantiatedException">Thrown if server not instantiated.</exception>
        public static void CheckInstantiationStatus()
        {
            if (ConsoleHandler == null || ConsoleStyle == null)
            {
                throw new NotInstantiatedException();
            }
        }
    }
}
