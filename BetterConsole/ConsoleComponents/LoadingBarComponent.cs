﻿using System;

namespace BetterConsole.ConsoleComponents
{
    public class LoadingBarComponent : ConsoleComponent
    {
        private int _size;
        private float _percentage;

        private string _fillStyle = "#"; // Temp incorporate style enum or param.
        private string _emptyStyle = "_";

        public LoadingBarComponent(int size) : base()
        {
            _size = size;
            _percentage = 0;
            
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
        }

        public override string ToString()
        {
            string toReturn = "[";
            int completed = (int)(_percentage*_size);
            
            for (int i = 1; i <= _size; i++)
            {
                if (i <= completed)
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