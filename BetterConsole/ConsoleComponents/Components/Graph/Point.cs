using System;

namespace BetterConsole.ConsoleComponents.Graph
{
    public struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Distance from this point to another.
        /// </summary>
        /// <param name="p">Point to compare.</param>
        /// <returns>Double distance.</returns>
        public double Distance(Point p)
        {
            return Math.Sqrt(Math.Pow(X - p.X, 2) + Math.Pow(Y - p.Y, 2));
        }
    }
}