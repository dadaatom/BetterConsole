﻿using System;

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

        public void SetStyle(LoadingBarStyle loadingBarStyle)
        {
            _style = loadingBarStyle;
        }
    }
}