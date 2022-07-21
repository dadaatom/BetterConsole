
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

        public PaddedComponent(string value) : this(new TextComponent(value)) { }
        
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
            Compute();
        }

        /// <summary>
        /// Sets the padding sizes for PaddedValue.
        /// </summary>
        /// <param name="horizontal">Padding to be added horizontally.</param>
        /// <param name="vertical">Padding to be added vertically.</param>
        public void SetPaddings(int horizontal, int vertical)
        {
            HorizontalPadding = horizontal;
            VerticalPadding = vertical;
            
            Compute(false);
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
            
            Compute(false);
        }

        /// <summary>
        /// Sets the horizontal alignment of the string content.
        /// </summary>
        /// <param name="horizontalAlignment">Horizontal alignment of the text.</param>
        public void SetHorizontalAlignment(HorizontalAlignment horizontalAlignment)
        {
            SetAlignments(horizontalAlignment, VerticalAlignment);
        }

        /// <summary>
        /// Sets the vertical alignment of the string content.
        /// </summary>
        /// <param name="verticalAlignment">Vertical alignment of the text.</param>
        public void SetVerticalAlignment(VerticalAlignment verticalAlignment)
        {
            SetAlignments(HorizontalAlignment, verticalAlignment);
        }

        /// <summary>
        /// Computed the padded value array.
        /// </summary>
        public void Compute(bool checkValue = true)
        {
            string newValue = GetComponentString();
            
            if (checkValue && newValue == Value)
            {
                return;
            }
            
            string[] newValueLines = newValue.Split('\n');

            int maxWidth = 0;
            for (int i = 0; i < newValueLines.Length; i++) {
                if (newValueLines[i].Length > maxWidth)
                {
                    maxWidth = newValueLines[i].Length;
                }
            }

            Width = maxWidth;
            Height = newValueLines.Length;
            
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
            
            newValueLines = newValue.Split('\n');
            
            for (int i = 0; i < newValueLines.Length; i++) {
                int widthToAdd = HorizontalPadding + (Width == 0 ? 1 : Width) - newValueLines[i].Length;
                
                bool forward = HorizontalAlignment != HorizontalAlignment.Left;

                for (int j = 0; j < widthToAdd; j++)
                {
                    if (forward)
                    {
                        newValueLines[i] = " " + newValueLines[i];
                    }
                    else
                    {
                        newValueLines[i] += " ";
                    }

                    if (HorizontalAlignment == HorizontalAlignment.Center)
                    {
                        forward = !forward;
                    }
                }
            }

            PaddedValue = newValueLines;
            Value = newValue;
        }

        /// <summary>
        /// Computes the component string of the Component.
        /// </summary>
        /// <returns>Aggregate toString values of all Components.</returns>
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