using System;

namespace BetterConsole.ConsoleComponents
{
    /*
     * TODO:
     * Add wraparound logic to Cell if max vals are defined.
     * Fix multi row / col lower sep
     */
    
    public class Table : ConsoleComponent
    {
        public Cell[,] Cells { get; private set; }

        public int[] RowSizes { get; private set; }
        public int[] ColumnSizes { get; private set; }

        //TODO: Loop these variables into a style class.
        
        
        public Table (int rows, int columns)
        {
            Cells = new Cell[rows, columns];

            RowSizes = new int[rows];
            ColumnSizes = new int[columns];

            //Renderer = new TableRenderer(this);
        }
        
        protected override ComponentBuilder Build()
        {
            if (Cells.GetLength(0) == 0 || Cells.GetLength(1) == 0)
                {
                    throw new System.Exception("Table is empty."); //TODO: Make custom exceptions
                }

                UpdateTargetSizes();
                
                string upper = "_";
                string lower = "_";
                string seperator = "-";
                string border = "|";

                ComponentBuilder toReturn = new ComponentBuilder();
                
                string segment = " ";
                
                for (int i = 0; i < Cells.GetLength(1); i += Cells[0,i] == null ? 1 : Cells[0,i].Width)
                {
                    for (int w = 0; w < (Cells[0,i] == null ? ColumnSizes[i] : Cells[0,i].Value.TotalWidth); w++)
                    {
                        segment += upper;
                    }

                    segment += " ";
                }

                segment += "\n";
                
                toReturn.Merge(Color.ApplyTo(segment));

                ColumnElement[] toDisplay = new ColumnElement[Cells.GetLength(1)];

                for (int i = 0; i < Cells.GetLength(0); i++)
                {
                    for (int h = 0; h < RowSizes[i]; h++)
                    {
                        toReturn.Merge(Color.ApplyTo(border));

                        int num;
                        for (int j = 0; j < Cells.GetLength(1); j += num) // Make this use the toDisplay item from that iteration.
                        {
                            num = 1;
                            if (toDisplay[j] == null)
                            {
                                if (Cells[i, j] != null)
                                {
                                    toDisplay[j] = new ColumnElement(Cells[i, j]);
                                }
                            }

                            if (toDisplay[j] == null)
                            {
                                for (int w = 0; w < ColumnSizes[j]; w++)
                                {
                                    toReturn.Merge(Color.ApplyTo(" "));
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
                            
                            toReturn.Merge(Color.ApplyTo(border));
                        }
                        toReturn.Merge(Color.ApplyTo("\n"));
                    }
                    
                    if (i < Cells.GetLength(0) - 1)
                    {
                        toReturn.Merge(Color.ApplyTo(border));
                        
                        for (int j = 0; j < Cells.GetLength(1); j += Cells[i, j] != null ? Cells[i,j].Width : 1)
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
                                for (int w = 0; w < (Cells[i,j] == null ? ColumnSizes[j] : Cells[i,j].Value.TotalWidth); w++)
                                {
                                    toReturn.Merge(Color.ApplyTo(seperator));
                                }
                            }
                            
                            toReturn.Merge(Color.ApplyTo(border));
                        }

                        toReturn.Merge(Color.ApplyTo("\n"));
                    }
                }

                toReturn.Merge(Color.ApplyTo(border));
                
                for (int i = 0; i < Cells.GetLength(1); i++) 
                {
                    for (int w = 0; w < ColumnSizes[i]; w++)
                    {
                        toReturn.Merge(Color.ApplyTo(lower));
                    }
                    toReturn.Merge(Color.ApplyTo(border));
                }

                return toReturn;
        }
        
        /// <summary>
        /// Sets a cell within the table.
        /// </summary>
        /// <param name="cell">Cell to be added to table.</param>
        /// <param name="row">Row position within cells matrix.</param>
        /// <param name="column">Column position within cells matrix.</param>
        public void SetCell(Cell cell, int row, int column)
        {
            if (cell != null)
            {
                if (cell.Value.Width > ColumnSizes[column])
                {
                    ColumnSizes[column] = cell.Value.Width;
                }

                if (cell.Value.Height > RowSizes[row])
                {
                    RowSizes[row] = cell.Value.Height;
                }
            }

            Cells[row, column] = cell;
        }

        /// <summary>
        /// Resizes table and copies old cells to fit new matrix.
        /// </summary>
        /// <param name="rows">New matrix width.</param>
        /// <param name="columns">New matrix height.</param>
        /// <param name="horizontalAlignment">Horizontal alignment of the resized table, default is left alignment.</param>
        /// <param name="verticalAlignment">Vertical alignment of the resized table, default is upper alignment.</param>
        public void Resize(int rows, int columns, HorizontalAlignment horizontalAlignment = HorizontalAlignment.Left, VerticalAlignment verticalAlignment = VerticalAlignment.Upper)
        {
            int rowShift = 0;
            int columnShift = 0;

            switch (verticalAlignment)
            {
                case VerticalAlignment.Upper:
                    rowShift = 0;
                    break;
                case VerticalAlignment.Center:
                {
                    int center = rows / 2;
                    rowShift = center - Cells.GetLength(0) / 2;
                    break;
                }
                case VerticalAlignment.Lower:
                    rowShift = rows - Cells.GetLength(0);
                    break;
            }
            
            switch (horizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    columnShift = 0;
                    break;
                case HorizontalAlignment.Center:
                {
                    int center = columns / 2;
                    columnShift = center - Cells.GetLength(1) / 2;
                    break;
                }
                case HorizontalAlignment.Right:
                    columnShift = columns - Cells.GetLength(1);
                    break;
            }
            
            Cell[,] newCells = new Cell[rows, columns];

            for (int i = Math.Max(0, -rowShift); i < Math.Min(Cells.GetLength(0), rows-rowShift); i++) {
                for (int j = Math.Max(0, -columnShift); j < Math.Min(Cells.GetLength(1), columns-columnShift); j++)
                {
                    newCells[i + rowShift, j + columnShift] = Cells[i, j];
                }
            }

            int[] newRowSizes = new int[rows];
            for (int i = Math.Max(0, -rowShift); i < Math.Min(Cells.GetLength(0), rows-rowShift); i++)
            {
                newRowSizes[i+rowShift] = RowSizes[i];
            }
            
            int[] newColumnSizes = new int[columns];
            for (int i = Math.Max(0, -columnShift); i < Math.Min(Cells.GetLength(1), columns-columnShift); i++)
            {
                newColumnSizes[i+columnShift] = ColumnSizes[i];
            }

            Cells = newCells;
            RowSizes = newRowSizes;
            ColumnSizes = newColumnSizes;
        }


        /// <summary>
        /// Shifts cells within the table.
        /// </summary>
        /// <param name="rows">Row amount to shift.</param>
        /// <param name="columns">Column amount to shift.</param>
        public void ShiftCells(int rows, int columns)
        {
            if(rows == 0 && columns == 0)
            {
                return;
            }

            Cell[,] newCells = new Cell[Cells.GetLength(0), Cells.GetLength(1)];

            for (int i = 0; i < Cells.GetLength(0); i++) {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    newCells[(i + rows) % Cells.GetLength(0), (j + columns) % Cells.GetLength(1)] = Cells[i, j];
                }
            }

            Cells = newCells;
        }

        /// <summary>
        /// Update target size of all cells within the cells matrix.
        /// </summary>
        public void UpdateTargetSizes()
        {
            RowSizes = new int[Cells.GetLength(0)];
            ColumnSizes = new int[Cells.GetLength(1)];

            for (int i = 0; i < ColumnSizes.Length; i++) 
            {
                ColumnSizes[i] = 1;
            }

            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    if (Cells[i,j] != null)
                    {
                        if (Cells[i, j].Value.Height > RowSizes[i])
                        {
                            RowSizes[i] = Cells[i, j].Value.Height;
                        }

                        int rowSize = (int)Math.Ceiling((double)Cells[i, j].Value.Height / Math.Min(Cells[i, j].Height, Cells.GetLength(0)-i));
                        for (int y = j; y < Math.Min(j+Cells[i,j].Height, Cells.GetLength(0)); y++) {
                            if (rowSize > RowSizes[y])
                            {
                                RowSizes[y] = rowSize;
                            }
                        }

                        int columnSize = (int)Math.Ceiling((double)Cells[i, j].Value.Width / Math.Min(Cells[i, j].Width, Cells.GetLength(1)-j));
                        for (int x = j; x < Math.Min(j+Cells[i,j].Width, Cells.GetLength(1)); x++) {
                            if (columnSize > ColumnSizes[x])
                            {
                                ColumnSizes[x] = columnSize;
                            }
                        }
                    }
                }
            }
            
            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    if (Cells[i, j] == null) continue;
                    
                    int targetWidth = Math.Min(Cells[i,j].Width, Cells.GetLength(1)-j) - 1;
                    for (int x = j; x < Math.Min(ColumnSizes.Length, j+Cells[i,j].Width); x++)
                    {
                        targetWidth += ColumnSizes[x];
                    }

                    int targetHeight = Cells[i,j].Height - 1;
                    for (int x = i; x < Math.Min(RowSizes.Length, i+Cells[i,j].Height); x++)
                    {
                        targetHeight += RowSizes[x];
                    }
                        
                    Cells[i,j]?.Value.SetPaddings(targetWidth - (Cells[i,j].Value.Width == 0 ? 1 : Cells[i,j].Value.Width), targetHeight - Cells[i,j].Value.Height);
                }
            }
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