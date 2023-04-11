using System.Drawing;
using System.Drawing.Imaging;

namespace BetterConsole.ConsoleComponents.Graph
{
    public class HistoBar
    {
        public string Label { get; set; }
        public double Value { get; set; }
        public Color Color { get; set; }

        public HistoBar(string label, double value, Color color = new Color())
        {
            Label = label;
            Value = value;
            Color = color;
        }
    }
}
