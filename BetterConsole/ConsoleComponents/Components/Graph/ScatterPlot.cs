using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BetterConsole.ConsoleComponents.Graph
{
    public class ScatterPlot : Graph
    {
        public List<Point> Points;

        public ScatterPlot() : this(new List<Point>()) { }
        public ScatterPlot(Point[] points) : this(new List<Point>(points)) { }
        
        public ScatterPlot(List<Point> points)
        {
            Points = points;
        }

        protected override ComponentBuilder Build()
        {
            double xMax = Points.Count > 0 ? Points[0].X : 0;
            double yMax = Points.Count > 0 ? Points[0].Y : 0;

            for (int i = 0; i < Points.Count; i++)
            {
                xMax = Math.Max(Points[i].X, xMax);
                yMax = Math.Max(Points[i].Y, yMax);
            }

            double perXTick = xMax / (Width - 1);
            double perYTick = yMax / (Height - 1);

            ComponentBuilder yAxisBuilder = BuildYAxis(Height);
            ComponentBuilder toReturn = new ComponentBuilder();
            
            for (int i = Height - 1; i >= 0; i--)
            {
                toReturn.Append(yAxisBuilder.Segments[Height - i - 1]);

                string line = "";
                for (int j = 0; j < Width; j++)
                {
                    bool found = false;
                    foreach (Point p in Points)
                    {
                        if (i * perYTick <= p.Y && j * perXTick <= p.X)
                        {
                            double upperY = (i + 1) * perYTick;
                            double upperX = (j + 1) * perXTick;
                            if (p.Y < upperY && p.X < upperX || 
                                (p.Y <= upperY && p.X <= upperX && j == Width - 1 && i == Height - 1))
                            {
                                found = true;
                                break;
                            }
                        }
                    }
                    
                    if (found)
                    {
                        line += 'X'; //'•';
                    }
                    else
                    {
                        line += ' ';
                    }
                }
                
                line += '\n';
                
                toReturn.Merge(Color.ApplyTo(line));
            }
            
            toReturn.Merge(BuildXAxis(Width));

            return toReturn;
        }
    }
}
