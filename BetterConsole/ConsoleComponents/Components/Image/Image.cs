using System;
using System.Drawing;

namespace BetterConsole.ConsoleComponents
{
    public class Image : ConsoleComponent
    {
        public Bitmap ImageMap { get; private set; }

        public Image(string imageFilePath) : this(new Bitmap(imageFilePath)) { }
        
        public Image(Bitmap imageMap)
        {
            ImageMap = imageMap;

            //Renderer = new ImageRenderer(this);
        }

        protected override ComponentBuilder Build()
        {
            ComponentBuilder builder = new ComponentBuilder();
            
            for (int i = 0; i < ImageMap.Height; i++) {
                for (int j = 0; j < ImageMap.Width; j++)
                {
                    Color pixel = ImageMap.GetPixel(j, i);
                    builder.Append(new ComponentBuilder.ComponentSegment("   ", pixel, pixel));
                }

                if (i < ImageMap.Height - 1)
                {
                    builder.Append(new ComponentBuilder.ComponentSegment("\n", System.Drawing.Color.Black, System.Drawing.Color.Black));
                }
            }
            
            return builder;
        }
        
        /// <summary>
        /// Resizes image to new size.
        /// </summary>
        /// <param name="width">New width of the image.</param>
        /// <param name="height">New height of the image.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Resize(int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);

            throw new NotImplementedException();
        }
    }
}
