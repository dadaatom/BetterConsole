namespace BetterConsole.Exception
{
    public class NotInstantiatedException : System.Exception
    {
        public NotInstantiatedException() : base("BetterConsole not yet instantiated, call BetterConsole.Instantiate() to start the console.") { }
    }
}
