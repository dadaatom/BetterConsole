using System.Linq;

namespace BetterConsole.Commands
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