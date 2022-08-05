using System.Linq;

namespace BetterConsole.ConsoleCommands
{
    public class BlacklistValidation : ValidationStrategy
    {
        public string[] Blacklist { get; }

        public BlacklistValidation(string blacklistedValue)
        {
            Blacklist = new []{blacklistedValue};
        }

        public BlacklistValidation(string[] blacklist)
        {
            Blacklist = blacklist;
        }

        public override bool Validate(string input)
        {
            return !Blacklist.Contains(input);
        }
    }
}