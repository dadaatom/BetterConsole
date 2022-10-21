using System;
using System.Collections.Generic;

namespace BetterConsole.ConsoleComponents.Components.Graph
{
    public class Histogram : Graph
    {
        public List<HistoBar> Bars { get; set; }
        public int TargetWidth { get; set; }
        public int TargetHeight { get; set; }

        public Histogram(int targetWidth = 30, int targetHeight = 10) : this(new HistoBar[0], targetWidth, targetHeight) { }

        public Histogram(HistoBar[] bars, int targetWidth = 30, int targetHeight = 10)
        {
            Bars = new List<HistoBar>(bars);
            TargetWidth = targetWidth;
            TargetHeight = targetHeight;
        }

        protected override ComponentBuilder Build()
        {
            int height = TargetHeight;
            int width = Math.Max(Bars.Count * 5 + 1, TargetWidth);

            double max = Bars.Count > 0 ? Bars[0].Value : 5;
            double min = Bars.Count > 0 ? Bars[0].Value : 5;

            for (int i = 1; i < Bars.Count; i++)
            {
                if (Bars[i].Value < min)
                {
                    min = Bars[i].Value;
                }

                if (Bars[i].Value > max)
                {
                    max = Bars[i].Value;
                }
            }

            double perTick = max / (height - 1);

            int barWidth = (width - Bars.Count * 4 - 1) / Bars.Count;

            int remainder = (width - Bars.Count * 4 - 1) % Bars.Count;


            // REMAINDER STRING //

            string remainderStr = "";

            for (int i = 0; i < remainder; i++)
            {
                remainderStr += ' ';
            }


            // CREATE X LABEL BORDER //
            
            PaddedComponent xBorder = new PaddedComponent(new TextComponent(XAxis.Label));
            xBorder.SetPaddings(width-XAxis.Label.Length, 1);
            
            
            // CREATE Y LABEL BORDER //
            
            string newYLabel = "";
            char[] yChars = YAxis.Label.ToCharArray();

            for (int i = 0; i < yChars.Length; i++)
            {
                newYLabel += yChars[i];
                
                if (i < yChars.Length - 1)
                {
                    newYLabel += '\n';
                }
            }
            
            PaddedComponent yBorder = new PaddedComponent(new TextComponent(newYLabel), HorizontalAlignment.Left, VerticalAlignment.Center);
            yBorder.SetPaddings(2, height - YAxis.Label.Length);
            
            
            // BUILD GRAPH //
            
            ComponentBuilder toReturn = new ComponentBuilder();

            for (int i = 0; i < height; i++) {
                toReturn.Merge(Color.ApplyTo(yBorder.PaddedValue[i]));

                if (i == 0)
                {
                    toReturn.Merge(Color.ApplyTo("^"));
                }
                else
                {
                    toReturn.Merge(Color.ApplyTo("|"));
                }

                //todo: fix this with theme
                
                //DRAW BARS
                for (int j = 0; j < Bars.Count; j++) {
                    string inner = "";
                    for (int k = 0; k < barWidth; k++)
                    {
                        inner += ' ';
                    }
                    
                    if(Bars[j].Value >= (height - i) * perTick)
                    {
                        toReturn.Append(new ComponentBuilder.ComponentSegment(" |", System.Drawing.Color.Black));
                        toReturn.Append(new ComponentBuilder.ComponentSegment(inner, System.Drawing.Color.White, System.Drawing.Color.Red));
                        toReturn.Append(new ComponentBuilder.ComponentSegment("| ", System.Drawing.Color.Black));
                    }
                    else if (Bars[j].Value >= (height - (i+1))*perTick)
                    {
                        string upper = "";
                        for (int k = 0; k < barWidth; k++)
                        {
                            upper += '_';
                        }
                        
                        toReturn.Append(new ComponentBuilder.ComponentSegment("  ", System.Drawing.Color.Black));
                        toReturn.Append(new ComponentBuilder.ComponentSegment(upper, System.Drawing.Color.Black));
                        toReturn.Append(new ComponentBuilder.ComponentSegment("  ", System.Drawing.Color.Black));
                    }
                    else
                    {
                        toReturn.Append(new ComponentBuilder.ComponentSegment(inner + "    ", System.Drawing.Color.Black));
                    }
                }

                toReturn.Append(new ComponentBuilder.ComponentSegment(remainderStr+"\n", System.Drawing.Color.Black));
            }

            string xAxis = "";

            for (int i = 0; i < yBorder.TotalWidth; i++)
            {
                xAxis += ' ';
            }

            for (int i = 0; i < width; i++)
            {
                if (i == 0)
                {
                    xAxis += '\'';
                }
                else if (i == width - 1)
                {
                    xAxis += ">\n";
                }
                else
                {
                    xAxis += '-';
                }
            }

            toReturn.Merge(Color.ApplyTo(xAxis));

            string temp = "";
            for (int j = 0; j < yBorder.TotalWidth; j++)
            {
                temp += ' ';
            }
            
            for (int i = 0; i < xBorder.PaddedValue.Length; i++)
            {
                toReturn.Merge(Color.ApplyTo(temp));
                toReturn.Merge(Color.ApplyTo(xBorder.PaddedValue[i]));
            }
            
            return toReturn;
        }
    }
}

/*


 ^
 |
 +  _   __
 | | |  ||
 + | |  ||
 '------------------------------>



*/