using System;
using System.Collections.Generic;
using System.Linq;
using BetterConsole.ConsoleComponents;

namespace BetterConsole
{
    /*
     * TODO:
     * - user input threads?
     * - See console component todo.
     * - See Table todo.
     * - See console command todo.
     * - Memoisation for longer computations.
     * - Make displayed componenets a linked list of linked lists?
     */

    public static class BetterConsole
    {
        //public static LinkedList<ConsoleComponent> DisplayedComponents;
        public static LinkedList<LinkedList<ConsoleComponent>> DisplayedComponents { get; private set; }

        public static ConsoleStyle ConsoleStyle;
        
        public static TimeHandler TimeHandler { get; }

        public static CommandHandler CommandHandler { get; }

        public static bool EnforceLimit { get; set; }
        public static int DisplayLimit { get; set; }

        //====================// Constructors //====================//
        
        static BetterConsole()
        {
            DisplayedComponents = new LinkedList<LinkedList<ConsoleComponent>>();

            ConsoleStyle = new ConsoleStyle(new StaticColor(ConsoleColor.Gray));
            
            TimeHandler = new TimeHandler();
            CommandHandler = new CommandHandler();

            EnforceLimit = false;
            DisplayLimit = 1000;
        }

        //====================// Reimplemented Methods //====================//
        
        /// <summary>
        /// Writes the component within the console.
        /// </summary>
        /// <param name="component">Console component to be written.</param>
        public static void Write(ConsoleComponent component)
        {
            AppendLine(component);
            component.Write();
        }
        
        /// <summary>
        /// Writes the component to the new line within the console.
        /// </summary>
        /// <param name="component">Console component to be written.</param>
        public static void WriteLine(ConsoleComponent component) //Enable line break and redirect to write.
        {
            AppendLine(component);
            AddLine(null);
            component.Write();
            Console.WriteLine("");
        }
        
        /// <summary>
        /// Forwards a colored text component to the Write function.
        /// </summary>
        /// <param name="text">Text to be written.</param>
        /// <param name="color">Color to display the text.</param>
        public static void Write(string text, ComponentColor color)
        {
            TextComponent textComp = new TextComponent(text);
            textComp.Color = color;
            Write(textComp);
        }

        /// <summary>
        /// Forwards a text component to the Write function.
        /// </summary>
        /// <param name="text">Text to be written.</param>
        public static void Write(string text)
        {
            Write(new TextComponent(text));
        }
        
        /// <summary>
        /// Forwards a colored text component to the WriteLine function.
        /// </summary>
        /// <param name="text">Text to be written.</param>
        /// <param name="color">Color to display the text.</param>
        public static void WriteLine(string text, ComponentColor color)
        {
            TextComponent textComp = new TextComponent(text);
            textComp.Color = color;
            WriteLine(textComp);
        }
        
        /// <summary>
        /// Forwards a text component to the WriteLine function.
        /// </summary>
        /// <param name="text">Text to be written.</param>
        public static void WriteLine(string text)
        {
            WriteLine(new TextComponent(text));
        }

        /// <summary>
        /// Reads line and adds user input to the consoles displayed list.
        /// </summary>
        /// <returns>User input read from the console.</returns>
        public static string ReadLine()
        {
            string val = Console.ReadLine();
            AddLine(new TextComponent(val)); //todo: revisit when read / read line are updated inline of Console functionality
            return val;
        }
        
        /// <summary>
        /// Reads and adds user input to the consoles displayed list.
        /// </summary>
        /// <returns>User input read from the console.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public static string Read()
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Clears the console and list of displayed items.
        /// </summary>
        public static void Clear()
        {
            DisplayedComponents = new LinkedList<LinkedList<ConsoleComponent>>();
            Console.Clear();
        }
        
        //====================// Display //====================//
        
        /// <summary>
        /// Clears the console and reloads either the last line or the entire console.
        /// </summary>
        /// <param name="component">Reloads based on the position of this component within the console.</param>
        public static void Reload(ConsoleComponent component)
        {
            if (DisplayedComponents.Last.Value.Contains(component))// && false) // Need to create spaces to cover rest of string, maybe multiline okay if there's a clear sep between components?
            {
                //DO THIS
                
                return;
            }
            
            Reload();
        }
        
        /// <summary>
        /// Clears the console and rewrites all items stored within the displayed list.
        /// </summary>
        public static void Reload()
        {
            Console.Clear();

            LinkedListNode<LinkedList<ConsoleComponent>> current = DisplayedComponents.First;
            foreach (LinkedList<ConsoleComponent> lines in DisplayedComponents)
            {
                foreach (ConsoleComponent component in lines)
                {
                    component?.Write();
                }
                
                Console.Write("\n");
            }
        }
        
        /// <summary>
        /// Adds a new line to the displayed list and will enforce the display limit if enabled.
        /// </summary>
        /// <param name="component">Console component to be saved within the displayed list.</param>
        private static void AddLine(ConsoleComponent component)
        {
            if (DisplayedComponents.Count + 1 > DisplayLimit)
            {
                DisplayedComponents.RemoveFirst();
                DisplayedComponents.AddLast(new LinkedList<ConsoleComponent>(new []{component}));
                if (EnforceLimit)
                {
                    Reload();
                }
            }
            else
            {
                DisplayedComponents.AddLast(new LinkedList<ConsoleComponent>(new []{component}));
            }
        }

        /// <summary>
        /// Appends component to the end of the last line.
        /// </summary>
        /// <param name="component">New component to be appended.</param>
        private static void AppendLine(ConsoleComponent component)
        {
            if (DisplayedComponents.Count == 0)
            {
                AddLine(component);
            }
            else if(DisplayedComponents.Last.Value.Last.Value != null)
            {
                DisplayedComponents.Last.Value.AddLast(component);
            }
            else
            {
                DisplayedComponents.Last.Value = new LinkedList<ConsoleComponent>(new []{component});
            }
        }
    }
}