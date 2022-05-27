namespace BetterConsole.ConsoleComponents
{
    public class Cell
    {
        public string Value { get; private set; }

        public string[] CenteredValue { get; private set; }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public int TargetWidth { get; private set; }

        public int TargetHeight { get; private set; }


        public Cell(string value)
        {
            SetValue(value);
        }
        
        public Cell(string value, int targetWidth, int targetHeight)
        {
            TargetWidth = targetWidth;
            TargetHeight = targetHeight;
            
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

            int maxWidth = 1;
            for (int i = 0; i < list.Length; i++) {
                if (list[i].Length > maxWidth)
                {
                    maxWidth = list[i].Length;
                }
            }

            Width = maxWidth;
            Height = list.Length;

            if (TargetWidth == 0)
            {
                TargetWidth = Width;
            }

            if (TargetHeight == 0)
            {
                TargetHeight = Height;
            }

            CenteredValue = center(Value, TargetWidth, TargetHeight);
        }
        
        /// <summary>
        /// Sets target size of the cell, will recompute the centered string array.
        /// Target sizes cannot be less than the cell width or height.
        /// </summary>
        /// <param name="width">New target width of the cell.</param>
        /// <param name="height">New target height of the cell.</param>
        public void SetTargetSizes(int width, int height)
        {
            TargetWidth = width;
            TargetHeight = height;

            if (TargetWidth < Width)
            {
                TargetWidth = Width;
            }
            if (TargetHeight < Height)
            {
                TargetHeight = Height;
            }

            CenteredValue = center(Value, TargetWidth, TargetHeight);
        }
        
        /// <summary>
        /// Will compute the centered string array with padded spaces and line breaks.
        /// </summary>
        /// <param name="str">String value to be centered.</param>
        /// <param name="targetWidth">Target width of the padded string.</param>
        /// <param name="targetHeight">Target height of the padded string.</param>
        /// <returns></returns>
        private string[] center(string str, int targetWidth, int targetHeight)
        {
            string toCenter = str;
            
            int heightToAdd = targetHeight - toCenter.Split('\n').Length;
            bool upper = false;
            
            for (int i = 0; i < heightToAdd; i++) {
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
                int widthToAdd = targetWidth - strList[i].Length;
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

            return strList;
        }
    }
}