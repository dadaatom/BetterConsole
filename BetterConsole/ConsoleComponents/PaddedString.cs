namespace BetterConsole.ConsoleComponents
{
    /*
     * TODO:
     * Add text alignment options 
     */
    public class PaddedString
    {
        public string Value { get; private set; }

        public string[] PaddedValue { get; private set; }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public int TotalWidth => Width + HorizontalPadding;

        public int TotalHeight => Height + VerticalPadding;

        public int HorizontalPadding { get; private set; }

        public int VerticalPadding { get; private set; }

        public PaddedString(string value)
        {
            SetValue(value);
        }
        
        /// <summary>
        /// Sets value of the table cell.
        /// </summary>
        /// <param name="value">New value for the cell.</param>
        public void SetValue(string value)
        {
            Value = value;
            string[] list = Value.Split('\n');

            int maxWidth = 0;
            for (int i = 0; i < list.Length; i++) {
                if (list[i].Length > maxWidth)
                {
                    maxWidth = list[i].Length;
                }
            }

            Width = maxWidth;
            Height = list.Length;

            Compute();
        }
        
        /// <summary>
        /// Sets target size of the cell, will recompute the centered string array.
        /// Target sizes cannot be less than the cell width or height.
        /// </summary>
        /// <param name="width">New target width of the cell.</param>
        /// <param name="height">New target height of the cell.</param>
        public void SetPaddings(int horizontal, int vertical)
        {
            HorizontalPadding = horizontal;
            VerticalPadding = vertical;
            
            Compute();
        }
        
        /// <summary>
        /// Computed the padded value array.
        /// </summary>
        public void Compute()
        {
            string toCenter = Value;
            
            bool upper = false;
            
            for (int i = 0; i < VerticalPadding; i++) {
                if (upper)
                {
                    toCenter = "\n" + toCenter;
                }
                else
                {
                    toCenter += "\n";
                }

                upper = !upper;
            }
            
            string[] strList = toCenter.Split('\n');
            
            for (int i = 0; i < strList.Length; i++) {
                int widthToAdd = HorizontalPadding + (Width == 0 ? 1 : Width) - strList[i].Length;
                bool forward = true;

                for (int j = 0; j < widthToAdd; j++)
                {
                    if (forward)
                    {
                        strList[i] = " " + strList[i];
                    }
                    else
                    {
                        strList[i] += " ";
                    }

                    forward = !forward;
                }
            }

            PaddedValue = strList;
        }
    }
}