namespace BetterConsole.ConsoleCommands
{
    public class CommandMatch
    {
        public bool Success { get; private set; }
        public ConsoleCommand Matched { get; private set; }
        public string[] Parameters { get; private set; }

        public int MatchHeuristic { get; private set; }

        public CommandMatch() : this(false, null, new string[0]) { }
        
        public CommandMatch(bool success) : this(success, null, new string[0]) { }
        
        public CommandMatch(bool success, ConsoleCommand matched) : this(success, matched, new string[0]) { }

        public CommandMatch(bool success, ConsoleCommand matched, string[] parameters, int matchHeuristic = 0)
        {
            Success = success;
            Matched = matched;
            Parameters = parameters;
        }
    }
}