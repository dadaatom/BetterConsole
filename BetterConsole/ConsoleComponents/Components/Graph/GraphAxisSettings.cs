namespace BetterConsole.ConsoleComponents.Graph
{
    public struct GraphAxisSettings
    {
        public string Label { get; set; }
        public double TickFrequency { get; set; }

        public GraphAxisSettings(string label = "", double tickFrequency = 1)
        {
            Label = label;
            TickFrequency = tickFrequency;
        }
    }
}
