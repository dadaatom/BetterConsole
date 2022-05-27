using System;

namespace BetterConsole.ConsoleComponents
{
    public class LoadingBar : ConsoleComponent
    {
        private LoadingBarStyle _style;
        private int _size;
        
        private float _percentage;
        private int _count;

        public LoadingBar(LoadingBarStyle loadingBarStyle, int size)
        {
            _style = loadingBarStyle;
            _size = size;
            
            _percentage = 0;
            _count = 0;
        }

        public LoadingBar(int size) : this(new LoadingBarStyle("#","_"), size) { }
        
        public override string ToString()
        {
            string toReturn = _style.LeftBorder;
            
            for (int i = 1; i <= _size; i++)
            {
                if (i <= _count)
                {
                    toReturn += _style.Fill;
                }
                else
                {
                    toReturn += _style.Empty;
                }
                //toReturn += ((i <= completed) ? _fillStyle : _emptyStyle);
            }

            return toReturn + _style.RightBorder;
        }
        
        /// <summary>
        /// Sets the percentage of completion for the loading bar.
        /// Values are bounded between 0 and 1.
        /// </summary>
        /// <param name="percentage">Percentage to be displayed by the loading bar.</param>
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
            
            int prevCount = _count;
            _count = (int)(_percentage*_size);

            if (prevCount != _count)
            {
                BetterConsole.Instance.Reload();
            }
        }
        
        /// <summary>
        /// Sets the display style.
        /// </summary>
        /// <param name="loadingBarStyle">Style element information.</param>
        public void SetStyle(LoadingBarStyle loadingBarStyle)
        {
            _style = loadingBarStyle;
        }
    }
}