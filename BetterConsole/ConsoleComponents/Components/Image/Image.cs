using System;
using System.Drawing;

namespace BetterConsole.ConsoleComponents
{
    public class Image : ConsoleComponent
    {
        public Bitmap ImageMap { get; private set; }

        public int Width { get; }

        public int Height { get; }

        public Image(string imageFilePath) : this(new Bitmap(imageFilePath)) { }
        
        public Image(Bitmap imageMap)
        {
            ImageMap = imageMap;
        }
        
        public override string ToString()
        {
            throw new NotImplementedException();
            
            string toReturn = "";
            for (int i = 0; i < ImageMap.Width; i++) {
                for (int j = 0; j < ImageMap.Height; j++)
                {
                    Color pixel = ImageMap.GetPixel(i, j);
                    BetterColor color = ColorPalette.BestMatch(pixel.R, pixel.G, pixel.B);
                    toReturn += "  ";
                }

                if (i < ImageMap.Width-1)
                {
                    toReturn += '\n';
                }
            }

            return "";
        }
    }
}