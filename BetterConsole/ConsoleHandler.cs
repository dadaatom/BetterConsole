using System;
using System.Collections.Generic;
using BetterConsole.ConsoleComponents;

namespace BetterConsole
{
    public class ConsoleHandler
    {
        public LinkedList<LinkedList<ConsoleComponent>> DisplayedComponents { get; private set; }
    
        public bool EnforceLimit { get; set; }
        public int DisplayLimit { get; set; }

        public ConsoleHandler(int displayLimit, bool enforceLimit = false)
        {
            DisplayLimit = displayLimit;
            EnforceLimit = enforceLimit;

            DisplayedComponents = new LinkedList<LinkedList<ConsoleComponent>>();
        }

        //====================// Reimplemented Methods //====================//
        
        /// <summary>
        /// Writes the component within the console.
        /// </summary>
        /// <param name="component">Console component to be written.</param>
        public void Write(ConsoleComponent component)
        {
            AppendLine(component);
            component.Write();
        }
        
        /// <summary>
        /// Writes the component to the new line within the console.
        /// </summary>
        /// <param name="component">Console component to be written.</param>
        public void WriteLine(ConsoleComponent component) //Enable line break and redirect to write.
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
        public void Write(string text, ComponentColor color)
        {
            TextComponent textComp = new TextComponent(text);
            textComp.Color = color;
            Write(textComp);
        }

        /// <summary>
        /// Forwards a text component to the Write function.
        /// </summary>
        /// <param name="text">Text to be written.</param>
        public void Write(string text)
        {
            Write(new TextComponent(text));
        }
        
        /// <summary>
        /// Forwards a colored text component to the WriteLine function.
        /// </summary>
        /// <param name="text">Text to be written.</param>
        /// <param name="color">Color to display the text.</param>
        public void WriteLine(string text, ComponentColor color)
        {
            TextComponent textComp = new TextComponent(text);
            textComp.Color = color;
            WriteLine(textComp);
        }
        
        /// <summary>
        /// Forwards a text component to the WriteLine function.
        /// </summary>
        /// <param name="text">Text to be written.</param>
        public void WriteLine(string text)
        {
            WriteLine(new TextComponent(text));
        }

        /// <summary>
        /// Reads line and adds user input to the consoles displayed list.
        /// </summary>
        /// <returns>User input read from the console.</returns>
        public string ReadLine()
        {
            string val = Console.ReadLine();
            AddLine(new TextComponent(val));
            return val;
        }
        
        /// <summary>
        /// Reads and adds user input to the consoles displayed list.
        /// </summary>
        /// <returns>User input read from the console.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public string Read()
        {
            Console.WriteLine();
            int val = Console.Read();
            AppendLine(new TextComponent(val.ToString()));
            return val.ToString();
        }

        /// <summary>
        /// Clears the console and list of displayed items.
        /// </summary>
        public void Clear()
        {
            DisplayedComponents = new LinkedList<LinkedList<ConsoleComponent>>();
            Console.Clear();
        }
        
        //====================// Display //====================//
        
        /// <summary>
        /// Clears the console and reloads either the last line or the entire console.
        /// </summary>
        /// <param name="component">Reloads based on the position of this component within the console.</param>
        public void Reload(ConsoleComponent component)
        {
            LinkedListNode<ConsoleComponent> node = DisplayedComponents.Last.Value.Find(component);

            if (component != null && node != null)
            {
                int totalLength = 0;
                
                foreach (ConsoleComponent consoleComponent in DisplayedComponents.Last.Value)
                {
                    if (consoleComponent == null)
                    {
                        continue;
                    }

                    if (consoleComponent.Height > 1)
                    {
                        Reload();
                        return;
                    }
                    
                    totalLength += consoleComponent.Length;
                }

                Console.Write("\r");

                string toPrint = "";
                for (int i = 0; i < totalLength; i++)
                {
                    toPrint += ' ';
                }
                
                Console.Write(toPrint);

                Console.Write("\r");
                
                foreach (ConsoleComponent consoleComponent in DisplayedComponents.Last.Value)
                {
                    consoleComponent?.Write();
                }

                return;
            }

            Reload();
        }
        
        /// <summary>
        /// Clears the console and rewrites all items stored within the displayed list.
        /// </summary>
        public void Reload()
        {
            Console.Clear();

            foreach (LinkedList<ConsoleComponent> line in DisplayedComponents)
            {
                foreach (ConsoleComponent component in line)
                {
                    component?.Write();
                }
                
                Console.Write("\n");
            }
        }

        
        /// <summary>
        /// Creates a line break.
        /// </summary>
        public void BreakLine()
        {
            AddLine(null);
        }

        /// <summary>
        /// Adds a new line to the displayed list and will enforce the display limit if enabled.
        /// </summary>
        /// <param name="component">Console component to be saved within the displayed list.</param>
        private void AddLine(ConsoleComponent component)
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
        private void AppendLine(ConsoleComponent component)
        {
            if (DisplayedComponents.Count == 0)
            {
                AddLine(component);
            }
            else if(DisplayedComponents.Last.Value != null)
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