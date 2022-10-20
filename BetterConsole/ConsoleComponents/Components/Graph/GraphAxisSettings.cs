namespace BetterConsole.ConsoleComponents.Components.Graph
{
    public class GraphAxisSettings
    {
        public string Label { get; set; }
        public double TickFrequency { get; set; }

        public GraphAxisSettings()
        {
            Label = "";
            TickFrequency = 1;
        }
    }
}