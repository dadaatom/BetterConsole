namespace BetterConsole.ConsoleComponents
{
    public class BorderRenderer : ComponentRenderer<Border>
    {
        public BorderRenderer(Border obj) : base(obj) { }

        public override ComponentBuilder Render()
        {
            Object.PaddedContents.Compute();

            ComponentBuilder builder = new ComponentBuilder();
            
            string value = " ";
            for (int j = 0; j < Object.PaddedContents.TotalWidth; j++)
            {
                value += "_";
            }
            value += " \n";
            
            builder.Merge(Object.Color.ApplyTo(value));
            
            for (int i = 0; i < Object.PaddedContents.PaddedValue.Length; i++)
            {
                builder.Merge(Object.Color.ApplyTo("|"));
                builder.Merge(Object.PaddedContents.Component.Color.ApplyTo(Object.PaddedContents.PaddedValue[i])); 
                builder.Merge(Object.Color.ApplyTo("|\n"));
            }
            
            value = "|";
            for (int j = 0; j < Object.PaddedContents.TotalWidth; j++)
            {
                value += "_";
            }
            value += "|";
            
            builder.Merge(Object.Color.ApplyTo(value));

            return builder;
        }
    }
}
