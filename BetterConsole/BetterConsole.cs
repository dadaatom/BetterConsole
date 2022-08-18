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
     * - Make displayed componenets a linked list of linked lists?
     */

    public static class BetterConsole
    {
        public static LinkedList<ConsoleComponent> DisplayedComponents;

        public static ConsoleStyle ConsoleStyle;
        
        public static TimeHandler TimeHandler { get; }

        public static CommandHandler CommandHandler { get; }

        public static bool EnforceLimit { get; set; }
        public static int DisplayLimit { get; set; }

        //====================// Constructors //====================//
        
        static BetterConsole()
        {
            DisplayedComponents = new LinkedList<ConsoleComponent>();

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
            DisplayedComponents = new LinkedList<ConsoleComponent>();
            Console.Clear();
        }
        
        //====================// Display //====================//
        
        /// <summary>
        /// Clears the console and reloads either the last line or the entire console.
        /// </summary>
        /// <param name="component">Reloads based on the position of this component within the console.</param>
        public static void Reload(ConsoleComponent component)
        {
            if (DisplayedComponents.Last.Value.Contains(component) && false) // Need to create spaces to cover rest of string, maybe multiline okay if there's a clear sep between components?
            {
                ConsoleComponent current = DisplayedComponents.Last.Value;

                while(current != null)
                {
                    if (current.GetLineCount() <= 1)
                    {
                        Reload();
                        return;
                    }

                    current = current.Next;
                }
                
                Console.Write("\r");
                DisplayedComponents.Last.Value?.Write();
            }
            else
            {
                Reload();
            }
        }
        
        /// <summary>
        /// Clears the console and rewrites all items stored within the displayed list.
        /// </summary>
        public static void Reload()
        {
            Console.Clear();

            LinkedListNode<ConsoleComponent> current = DisplayedComponents.First;
            while (current != null)
            {
                current.Value?.Write();
                
                if (current.Next != null)
                {
                    Console.Write("\n");
                }

                current = current.Next;
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
                DisplayedComponents.AddLast(component);
                if (EnforceLimit)
                {
                    Reload();
                }
            }
            else
            {
                DisplayedComponents.AddLast(component);
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
            else if(DisplayedComponents.Last.Value != null)
            {
                ConsoleComponent current = DisplayedComponents.Last.Value;

                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = component;
            }
            else
            {
                DisplayedComponents.Last.Value = component;
            }
        }
    }
}