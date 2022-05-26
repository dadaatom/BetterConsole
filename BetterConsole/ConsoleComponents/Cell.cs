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

        public void SetTargetSizes(int width, int height)
        {
            TargetWidth = width;
            TargetHeight = height;
            
            CenteredValue = center(Value, TargetWidth, TargetHeight);
        }

        private string[] center(string str, int totalWidth, int totalHeight)
        {
            string toCenter = str;
            
            int heightToAdd = totalHeight - toCenter.Split('\n').Length;
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
                int widthToAdd = totalWidth - strList[i].Length;
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