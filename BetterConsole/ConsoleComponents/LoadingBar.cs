using System;

namespace BetterConsole.ConsoleComponents
{
    public class LoadingBar : ConsoleComponent
    {
        private int _size;
        private float _percentage;
        private int _count;

        private string _fillStyle = "#"; // Temp incorporate style enum, param, or class.
        private string _emptyStyle = "_";

        public LoadingBar(int size, ConsoleColor color = ConsoleColor.Gray) : base()
        {
            _size = size;
            _percentage = 0;
            _count = 0;
        }

        public void SetPercentage(float percentage)
        {
            if (percentage > 1)
            {
                percentage = 1;
            }
            else if (percentage < 0)
            {
                percentage = 0;
            }

            _percentage = percentage;
            
            int _prevCount = _count;
            _count = (int)(_percentage*_size);

            if (_prevCount != _count)
            {
                BetterConsole.Instance.Reload();
            }
        }

        public override string ToString()
        {
            string toReturn = "[";
            
            for (int i = 1; i <= _size; i++)
            {
                if (i <= _count)
                {
                    toReturn += _fillStyle;
                }
                else
                {
                    toReturn += _emptyStyle;
                }
                //toReturn += ((i <= completed) ? _fillStyle : _emptyStyle);
            }

            return toReturn + "]";
        }
    }
}