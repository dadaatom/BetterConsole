using System;
using System.Collections.Generic;

namespace BetterConsole.ConsoleComponents.Graph
{
    public class Histogram : Graph
    {
        public List<HistoBar> Bars { get; set; }
        
        public Histogram(int width = 20, int height = 10) : this(new List<HistoBar>(), width, height) { }
        public Histogram(HistoBar[] bars, int width = 20, int height = 10) : this(new List<HistoBar>(bars), width, height) { }

        public Histogram(List<HistoBar> bars, int width = 20, int height = 10) : base(width, height)
        {
            Bars = bars;
        }

        public override int RequiredWidth()
        {
            return Math.Max(Bars != null ? Bars.Count * 5 + 1 : 2, 2);
        }

        protected override ComponentBuilder Build()
        {
            double max = Bars.Count > 0 ? Bars[0].Value : 5;
            double min = Bars.Count > 0 ? Bars[0].Value : 5;

            for (int i = 1; i < Bars.Count; i++)
            {
                max = Math.Max(Bars[i].Value, max);
                min = Math.Min(Bars[i].Value, min);
            }

            double perTick = max / (Height - 1);
            int barWidth = (Width - Bars.Count * 4 - 1) / Bars.Count;
            int remainder = (Width - Bars.Count * 4 - 1) % Bars.Count;


            // REMAINDER STRING //

            string remainderStr = "";

            for (int i = 0; i < remainder; i++)
            {
                remainderStr += ' ';
            }
            
            
            // Y AXIS //

            ComponentBuilder yAxisBuilder = BuildYAxis(Height);
            
            
            // BUILD GRAPH //
            
            ComponentBuilder toReturn = new ComponentBuilder();

            for (int i = 0; i < Height; i++) {
                
                toReturn.Append(yAxisBuilder.Segments[i]);

                //DRAW BARS todo: fix this with theme
                
                for (int j = 0; j < Bars.Count; j++) {
                    string inner = "";
                    for (int k = 0; k < barWidth; k++)
                    {
                        inner += ' ';
                    }
                    
                    if(Bars[j].Value >= (Height - i) * perTick)
                    {
                        toReturn.Merge(Color.ApplyTo(" |" + inner + "| "));
                    }
                    else if (Bars[j].Value >= (Height - (i+1))*perTick)
                    {
                        string upper = "";
                        for (int k = 0; k < barWidth; k++)
                        {
                            upper += '_';
                        }
                        
                        toReturn.Merge(Color.ApplyTo("  " + upper + "  "));
                    }
                    else
                    {
                        toReturn.Append(new ComponentBuilder.ComponentSegment(inner + "    ", System.Drawing.Color.Black));
                    }
                }

                toReturn.Append(new ComponentBuilder.ComponentSegment(remainderStr+"\n", System.Drawing.Color.Black));
            }

            toReturn.Merge(BuildXAxis(Width));
            
            return toReturn;
        }
    }
}
