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
        }

        protected override void DisplayText()
        {
            for (int i = 0; i < ImageMap.Height; i++) {
                for (int j = 0; j < ImageMap.Width; j++)
                {
                    Color pixel = ImageMap.GetPixel(j, i);
                    //ColorInfo colorInfo = ColorPalette.BestMatch(pixel.R, pixel.G, pixel.B);
                    Console.BackgroundColor = ColorUtil.ClosestConsoleColor(pixel.R, pixel.G, pixel.B);
                    Console.Write("   ");
                }

                if (i < ImageMap.Height - 1)
                {
                    Console.Write("\n");
                }
            }
        }

        public override string ToString()
        {
            string toReturn = "";
            
            for (int i = 0; i < ImageMap.Width; i++) {
                for (int j = 0; j < ImageMap.Height; j++)
                {
                    toReturn += "   ";
                }

                if (i < ImageMap.Width - 1)
                {
                    Console.Write("\n");
                }
            }

            return toReturn;
        }
    }
}