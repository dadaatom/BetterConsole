using System;

namespace BetterConsole.ConsoleComponents
{
    public class TableRenderer : ComponentRenderer<Table>
    {
        public TableRenderer(Table obj) : base(obj) { }

        public override ComponentBuilder Render()
        {
            if (Object.Cells.GetLength(0) == 0 || Object.Cells.GetLength(1) == 0)
            {
                throw new EmptyTableException();
            }

            throw new System.Exception("Not implemented");
            
            string upper = "_";
            string lower = "_";
            string seperator = "-";
            string border = "|";

            ComponentBuilder toReturn = new ComponentBuilder();
            
            string segment = " ";
            
            for (int i = 0; i < Object.Cells.GetLength(1); i += Object.Cells[0,i] == null ? 1 : Object.Cells[0,i].Width)
            {
                for (int w = 0; w < (Object.Cells[0,i] == null ? Object.ColumnSizes[i] : Object.Cells[0,i].Value.TotalWidth); w++)
                {
                    segment += upper;
                }

                segment += " ";
            }

            segment += "\n";
            
            toReturn.Merge(Object.Color.ApplyTo(segment));

            ColumnElement[] toDisplay = new ColumnElement[Object.Cells.GetLength(1)];

            for (int i = 0; i < Object.Cells.GetLength(0); i++)
            {
                for (int h = 0; h < Object.RowSizes[i]; h++)
                {
                    toReturn.Merge(Object.Color.ApplyTo(border));

                    int num;
                    for (int j = 0; j < Object.Cells.GetLength(1); j += num) // Make this use the toDisplay item from that iteration.
                    {
                        num = 1;
                        if (toDisplay[j] == null)
                        {
                            if (Object.Cells[i, j] != null)
                            {
                                toDisplay[j] = new ColumnElement(Object.Cells[i, j]);
                            }
                        }

                        if (toDisplay[j] == null)
                        {
                            for (int w = 0; w < Object.ColumnSizes[j]; w++)
                            {
                                toReturn.Merge(Object.Color.ApplyTo(" "));
                            }
                        }
                        else
                        {
                            toReturn.Merge(toDisplay[j].Cell.Component.Color.ApplyTo(toDisplay[j].NextLine()));
                            num = toDisplay[j] != null ? toDisplay[j].Cell.Width : 1;
                            
                            if (toDisplay[j].RemainingLines <= 0)
                            {
                                toDisplay[j] = null;
                            }
                        }
                        
                        toReturn.Merge(Object.Color.ApplyTo(border));
                    }
                    toReturn.Merge(Object.Color.ApplyTo("\n"));
                }
                
                if (i < Object.Cells.GetLength(0) - 1)
                {
                    toReturn.Merge(Object.Color.ApplyTo(border));
                    
                    for (int j = 0; j < Object.Cells.GetLength(1); j += Object.Cells[i, j] != null ? Object.Cells[i,j].Width : 1)
                    {
                        if (toDisplay[j] != null)
                        {
                            toReturn.Merge(toDisplay[j].Cell.Component.Color.ApplyTo(toDisplay[j].NextLine()));
                            if (toDisplay[j].RemainingLines <= 0)
                            {
                                toDisplay[j] = null;
                            }
                        }
                        else{
                            for (int w = 0; w < (Object.Cells[i,j] == null ? Object.ColumnSizes[j] : Object.Cells[i,j].Value.TotalWidth); w++)
                            {
                                toReturn.Merge(Object.Color.ApplyTo(seperator));
                            }
                        }
                        
                        toReturn.Merge(Object.Color.ApplyTo(border));
                    }

                    toReturn.Merge(Object.Color.ApplyTo("\n"));
                }
            }

            toReturn.Merge(Object.Color.ApplyTo(border));
            
            for (int i = 0; i < Object.Cells.GetLength(1); i++) 
            {
                for (int w = 0; w < Object.ColumnSizes[i]; w++)
                {
                    toReturn.Merge(Object.Color.ApplyTo(lower));
                }
                toReturn.Merge(Object.Color.ApplyTo(border));
            }

            return toReturn;
        }
        
        private class ColumnElement
        {
            public Cell Cell { get; private set; }
            public int RemainingLines { get; private set; }
        
            public ColumnElement(Cell cell)
            {
                Cell = cell;
                RemainingLines = Cell.Value.PaddedValue.Length;
            }

            /// <summary>
            /// Gets next line of the cell to display.
            /// </summary>
            /// <returns>Current line in the element display.</returns>
            public string NextLine()
            {
                int index = Cell.Value.PaddedValue.Length - RemainingLines;

                RemainingLines--;
            
                return Cell.Value.PaddedValue[index];
            }
        }
    }
}
