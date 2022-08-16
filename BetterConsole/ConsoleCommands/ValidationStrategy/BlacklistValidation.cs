using System;

namespace BetterConsole.ConsoleCommands
{
    public class BlacklistValidation : ValidationStrategy
    {
        public string[] Blacklist { get; }
        public bool CaseSensitive { get; }

        public BlacklistValidation(string blacklistedValue, bool caseSensitive = true)
        {
            Blacklist = new []{blacklistedValue};
            CaseSensitive = caseSensitive;
        }

        public BlacklistValidation(string[] blacklist, bool caseSensitive = true)
        {
            Blacklist = blacklist;
            CaseSensitive = caseSensitive;
        }

        public override bool Validate(string input)
        {
            foreach (string str in Blacklist) {
                if ((!CaseSensitive && string.Equals(input, str, StringComparison.CurrentCultureIgnoreCase)) || input == str)
                {
                    return false;
                }
            }

            return true;
        }
    }
}