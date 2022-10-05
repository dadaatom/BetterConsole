namespace BetterConsole.ConsoleComponents
{
    public class TimeComponentRenderer : ComponentRenderer<TimeComponent>
    {
        public TimeComponentRenderer(TimeComponent obj) : base(obj) { }

        public override ComponentBuilder Render()
        {
            return Object.Color.ApplyTo(Object.GetCurrentTimeSpan().ToString());
        }
    }
}