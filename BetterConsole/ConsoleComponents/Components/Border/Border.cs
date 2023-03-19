using System;

namespace BetterConsole.ConsoleComponents
{
    /*
     * TODO:
     * Use style options here please.
     */
    public class Border : ConsoleComponent
    {
        public ConsoleComponent Contents { get; private set; }

        public readonly PaddedComponent PaddedContents;

        public Border(string contents) : this(new TextComponent(contents)) { }

        public Border(ConsoleComponent contents)
        {
            Contents = contents;
            PaddedContents = new PaddedComponent(new TextComponent(contents.ToString()));

            //Renderer = new BorderRenderer(this);
        }

        protected override ComponentBuilder Build()
        {
            PaddedContents.Compute();

            ComponentBuilder builder = new ComponentBuilder();
            
            string value = " ";
            for (int j = 0; j < PaddedContents.TotalWidth; j++)
            {
                value += "_";
            }
            value += " \n";
            
            builder.Merge(Color.ApplyTo(value));
            
            for (int i = 0; i < PaddedContents.PaddedValue.Length; i++)
            {
                builder.Merge(Color.ApplyTo("|"));
                builder.Merge(PaddedContents.Component.Color.ApplyTo(PaddedContents.PaddedValue[i])); 
                builder.Merge(Color.ApplyTo("|\n"));
            }
            
            value = "|";
            for (int j = 0; j < PaddedContents.TotalWidth; j++)
            {
                value += "_";
            }
            value += "|";
            
            builder.Merge(Color.ApplyTo(value));

            return builder;
        }
        
        /// <summary>
        /// Sets the inner contents of the border.
        /// </summary>
        /// <param name="contents">New inner contents.</param>
        public void SetContents(ConsoleComponent contents)
        {
            Contents = contents;
            PaddedContents.SetValue(Contents);
        }
    }
}