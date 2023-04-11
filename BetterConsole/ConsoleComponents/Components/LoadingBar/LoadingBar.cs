using System;

namespace BetterConsole.ConsoleComponents
{
    public class LoadingBar : ConsoleComponent
    {
        public int Size { get; private set; }
        public int Count { get; private set; }
        
        private double _percentage;
        
        public LoadingBar(int size)
        {
            Size = size;
            Count = 0;
            
            _percentage = 0;

            //Renderer = new LoadingBarRenderer(this);
        }
        
        protected override ComponentBuilder Build()
        {
            string toReturn = "[";
            
            for (int i = 1; i <= Size; i++)
            {
                if (i <= Count)
                {
                    toReturn += "=";
                }
                else
                {
                    toReturn += " ";
                }
            }
            
            toReturn += "]";
            
            return Color.ApplyTo(toReturn);        }
        
        /// <summary>
        /// Gets the current loading bar percentage of completion.
        /// </summary>
        /// <returns>Current percentage of completion.</returns>
        public double GetPercentage()
        {
            return _percentage;
        }

        /// <summary>
        /// Sets the percentage of completion for the loading bar.
        /// Values are bounded between 0 and 1.
        /// </summary>
        /// <param name="percentage">Percentage to be displayed by the loading bar.</param>
        public void SetPercentage(double percentage)
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
            
            int prevCount = Count;
            Count = (int)(_percentage*Size);
            
            if (prevCount != Count)
            {
                BetterConsole.Reload(this);
            }
        }
    }
}
