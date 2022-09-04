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

        public void Resize(int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);

            throw new NotImplementedException();
        }

        protected override void DisplayText()
        {
            ConsoleColor background = Console.BackgroundColor;
            
            for (int i = 0; i < ImageMap.Height; i++) {
                for (int j = 0; j < ImageMap.Width; j++)
                {
                    Color pixel = ImageMap.GetPixel(j, i);

                    if (pixel.A < 128)
                    {
                        Console.BackgroundColor = background;
                    }
                    else
                    {
                        Console.BackgroundColor = ColorUtil.ClosestConsoleColor(pixel.R, pixel.G, pixel.B);
                    }
                    
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