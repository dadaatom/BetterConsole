namespace BetterConsole.ConsoleComponents
{
    public class PaddedComponent
    {
        public string Value { get; private set; }

        public ConsoleComponent Component { get; private set; }

        public string[] PaddedValue { get; private set; }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public int TotalWidth => Width + HorizontalPadding;

        public int TotalHeight => Height + VerticalPadding;

        public int HorizontalPadding { get; private set; }

        public int VerticalPadding { get; private set; }

        public HorizontalAlignment HorizontalAlignment { get; private set; } = HorizontalAlignment.Center;

        public VerticalAlignment VerticalAlignment { get; private set; } = VerticalAlignment.Center;

        public PaddedComponent(string value)
        {
            SetValue(value);
        }
        
        public PaddedComponent(ConsoleComponent component)
        {
            SetValue(component);
        }
        
        /// <summary>
        /// Sets value of the table cell.
        /// </summary>
        /// <param name="value">New string value for the cell.</param>
        public void SetValue(string value)
        {
            SetValue(new TextComponent(value));
        }

        /// <summary>
        /// Sets value of the table cell.
        /// </summary>
        /// <param name="component">New component value for the cell.</param>
        public void SetValue(ConsoleComponent component)
        {
            Component = component;
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
        /// Sets the horizontal and vertical alignments of the string contents.
        /// </summary>
        /// <param name="horizontalAlignment">Horizontal alignment of the text.</param>
        /// <param name="verticalAlignment">Vertical alignment of the text.</param>
        public void SetAlignments(HorizontalAlignment horizontalAlignment, VerticalAlignment verticalAlignment)
        {
            HorizontalAlignment = horizontalAlignment;
            VerticalAlignment = verticalAlignment;
            
            Compute();
        }

        /// <summary>
        /// Computed the padded value array.
        /// </summary>
        /// <param name="newValue"></param>
        public void Compute()
        {
            string newValue = GetComponentString();
            if (newValue == Value)
            {
                return;
            }
            
            bool upper = VerticalAlignment == VerticalAlignment.Lower;

            for (int i = 0; i < VerticalPadding; i++) {
                if (upper)
                {
                    newValue = "\n" + newValue;
                }
                else
                {
                    newValue += "\n";
                }

                if (VerticalAlignment == VerticalAlignment.Center)
                {
                    upper = !upper;
                }
            }
            
            string[] strList = newValue.Split('\n');
            
            for (int i = 0; i < strList.Length; i++) {
                int widthToAdd = HorizontalPadding + (Width == 0 ? 1 : Width) - strList[i].Length;
                
                bool forward = HorizontalAlignment != HorizontalAlignment.Left;

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

                    if (HorizontalAlignment == HorizontalAlignment.Center)
                    {
                        forward = !forward;
                    }
                }
            }

            PaddedValue = strList;
            Value = newValue;
        }

        /// <summary>
        /// Computes the component string of the Component.
        /// </summary>
        /// <returns>Aggregated toString values of all Components.</returns>
        private string GetComponentString()
        {
            if (Component == null)
            {
                return "";
            }

            ConsoleComponent current = Component;
            string value = "";
            
            while (current != null)
            {
                value += current.ToString();
                current = current.Next;
            }

            return value;
        }
    }
}