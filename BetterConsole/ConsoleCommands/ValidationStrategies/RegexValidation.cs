using System.Text.RegularExpressions;

namespace BetterConsole.ConsoleCommands
{
    public class RegexValidation : ValidationStrategy
    {
        public string Regex { get; }

        public RegexValidation(string regex)
        {
            Regex = regex;
        }
        
        public override bool Validate(string input)
        {
            Regex regex = new Regex(Regex);
            Match match = regex.Match(input);
            return match.Success;
        }
    }
}