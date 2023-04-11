using System.Drawing;

namespace BetterConsole.ConsoleComponents
{
    public class ImageRenderer : ComponentRenderer<Image>
    {
        public ImageRenderer(Image obj) : base(obj) { }

        public override ComponentBuilder Render()
        {
            ComponentBuilder builder = new ComponentBuilder();
            
            for (int i = 0; i < Object.ImageMap.Height; i++) {
                for (int j = 0; j < Object.ImageMap.Width; j++)
                {
                    Color pixel = Object.ImageMap.GetPixel(j, i);
                    builder.Append(new ComponentBuilder.ComponentSegment("   ", pixel));
                }

                if (i < Object.ImageMap.Height - 1)
                {
                    builder.Append(new ComponentBuilder.ComponentSegment("\n", Color.Black));
                }
            }
            
            return builder;
        }
    }
}
