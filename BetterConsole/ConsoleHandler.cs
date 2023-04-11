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
        public virtual void Write(ConsoleComponent component)
        {
            AppendLine(component);
            Display(component.Render());
        }
        
        /// <summary>
        /// Writes the component to the new line within the console.
        /// </summary>
        /// <param name="component">Console component to be written.</param>
        public virtual void WriteLine(ConsoleComponent component) //Enable line break and redirect to write.
        {
            AppendLine(component);
            AddLine(null);
            Display(component.Render());
            Console.WriteLine("");
        }

        /// <summary>
        /// Reads line and adds user input to the consoles displayed list.
        /// </summary>
        /// <returns>User input read from the console.</returns>
        public virtual string ReadLine()
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
        public virtual string Read()
        {
            //Console.WriteLine();
            int val = Console.Read();
            AppendLine(new TextComponent(val.ToString()));
            return val.ToString();
        }

        /// <summary>
        /// Clears the console and list of displayed items.
        /// </summary>
        public virtual void Clear()
        {
            DisplayedComponents = new LinkedList<LinkedList<ConsoleComponent>>();
            Console.Clear();
        }
        
        //====================// Display //====================//
        
        /// <summary>
        /// Clears the console and reloads either the last line or the entire console.
        /// </summary>
        /// <param name="component">Reloads based on the position of this component within the console.</param>
        public virtual void Reload(ConsoleComponent component) //todo: take color into account when preforming clear line portion of successful component reload
        {
            Reload();
            return;
            
            int preLines = 0;
            int postLines = 0;

            bool found = false;

            LinkedListNode<LinkedList<ConsoleComponent>> nextList = null;
            LinkedListNode<ConsoleComponent> foundNode = null;

            LinkedListNode<LinkedList<ConsoleComponent>> listNode = DisplayedComponents.First;
            while (listNode != null)
            {
                LinkedListNode<ConsoleComponent> node = listNode.Value.First;
                while (node != null)
                {
                    if (node.Value == component)
                    {
                        nextList = listNode;
                        
                        foundNode = node;

                        found = true;
                    }
                    
                    int lines = (postLines == 0 && node.Value.ComponentHeight >= 1) ?
                        node.Value.ComponentHeight : node.Value.ComponentHeight - 1;
                    
                    if (found)
                    {
                        postLines += lines;
                    }
                    else
                    {
                        preLines += lines;
                    }
                    
                    node = node.Next;
                }
                listNode = listNode.Next;
            }


            if (found)
            {
                if (preLines > 0 && postLines < Console.BufferHeight)
                {
                    Console.SetCursorPosition(0,preLines);

                    // Write some spaces
                    
                    Console.SetCursorPosition(0,preLines);
                    
                    LinkedListNode<ConsoleComponent> node = foundNode;
                    while (node != null)
                    {
                        //Write nodes
                        Display(node.Value.Render());
                        
                        node = node.Next;
                        if (node == null && nextList != null)
                        {
                            node = nextList.Value.First;
                            nextList = nextList.Next;
                        }
                    }

                    return;
                }
            }
            
            Reload();

            /*
            
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

                    if (consoleComponent.ComponentHeight > 1)
                    {
                        Reload();
                        return;
                    }
                    
                    totalLength += consoleComponent.ComponentWidth;
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
                    if (consoleComponent == null)
                    {
                        continue;
                    }

                    Display(consoleComponent.Render());
                }

                return;
            }

            Reload();
            */
        }
        
        /// <summary>
        /// Clears the console and rewrites all items stored within the displayed list.
        /// </summary>
        public virtual void Reload()
        {
            Console.Clear();

            foreach (LinkedList<ConsoleComponent> line in DisplayedComponents)
            {
                foreach (ConsoleComponent component in line)
                {
                    if (component == null)
                    {
                        continue;
                    }

                    Display(component.Render());
                }
                
                Console.Write("\n");
            }
        }

        /// <summary>
        /// Creates a line break.
        /// </summary>
        public virtual void BreakLine()
        {
            AddLine(null);
            Console.WriteLine();
        }
        
        /// <summary>
        /// Displays the component builder.
        /// </summary>
        /// <param name="builder">Builder to be displayed.</param>
        public virtual void Display(ComponentBuilder builder)
        {
            ConsoleColor foreground = Console.ForegroundColor;
            ConsoleColor background = Console.BackgroundColor;
            
            foreach (ComponentBuilder.ComponentSegment segment in builder.Segments)
            {
                if (segment.TextColor.A <= 128 || segment.BackgroundColor.A <= 128)
                {
                    Console.ForegroundColor = foreground;
                    Console.BackgroundColor = background;
                    
                    string spaces = "";
                    for (int i = 0; i < segment.Text.Length; i++)
                    {
                        spaces += ' ';
                    }
                    
                    Console.Write(spaces);
                    continue;
                }

                Console.ForegroundColor = ColorUtil.ConvertToConsoleColor(segment.TextColor);
                Console.BackgroundColor = ColorUtil.ConvertToConsoleColor(segment.BackgroundColor);
                
                Console.Write(segment.Text);
            }

            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
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
