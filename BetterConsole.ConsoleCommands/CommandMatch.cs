namespace BetterConsole.ConsoleCommands
{
    public class CommandMatch
    {
        public bool Success { get; private set; }
        public ConsoleCommand Matched { get; private set; }
        public string[] Parameters { get; private set; }

        public int Heuristic { get; set; } // MAYBE MAKE SET PRIV? // How should this grow

        public CommandMatch() : this(false, null, new string[0]) { }
        
        public CommandMatch(bool success) : this(success, null, new string[0]) { }
        
        public CommandMatch(bool success, ConsoleCommand matched, int heuristic = 0) : this(success, matched, new string[0], heuristic) { }

        public CommandMatch(bool success, ConsoleCommand matched, string[] parameters, int heuristic = 0)
        {
            Success = success;
            Matched = matched;
            Parameters = parameters;
            Heuristic = heuristic;
        }
    }
}