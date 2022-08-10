using System.Linq;

namespace BetterConsole.ConsoleCommands
{
    public class WhitelistValidation : ValidationStrategy
    {
        public string[] Whitelist { get; }

        public WhitelistValidation(string whitelistedValue)
        {
            Whitelist = new []{whitelistedValue};
        }

        public WhitelistValidation(string[] whitelist)
        {
            Whitelist = whitelist;
        }

        public override bool Validate(string input)
        {
            return Whitelist.Contains(input);
        }
    }
}