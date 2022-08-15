using System;
using System.Linq;

namespace BetterConsole.ConsoleCommands
{
    public class WhitelistValidation : ValidationStrategy
    {
        public string[] Whitelist { get; }
        public bool CaseSensitive { get; }

        public WhitelistValidation(string whitelistedValue, bool caseSensitive = true)
        {
            Whitelist = new []{whitelistedValue};
            CaseSensitive = caseSensitive;
        }

        public WhitelistValidation(string[] whitelist, bool caseSensitive = true)
        {
            Whitelist = whitelist;
            CaseSensitive = caseSensitive;
        }

        public override bool Validate(string input)
        {
            foreach (string str in Whitelist) {
                if ((!CaseSensitive && string.Equals(input, str, StringComparison.CurrentCultureIgnoreCase)) || input == str)
                {
                    return true;
                }
            }

            return false;
        }
    }
}