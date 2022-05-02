using System;

namespace BetterConsole.ConsoleComponents
{
    public class NumberComponent : ConsoleComponent
    {
        private int _value;

        public NumberComponent(int value, ConsoleColor color = ConsoleColor.Gray) : base()
        {
            _value = value;
        }
        
        public override string ToString()
        {
            return _value.ToString();
        }

        public int GetValue()
        {
            return _value;
        }

        public void SetValue(int value)
        {
            _value = value;
        }
    }
}