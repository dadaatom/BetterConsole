﻿using System;

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

        private int[] _rowSizes;
        private int[] _columnSizes;
        
        //TODO: Loop these variables into a style class.
        private string upper = "_";
        private string lower = "_"; //"\u0305"; //"‾";
        private string seperator = "-";
        private string border = "|";
        
        public Table (int rows, int columns)
        {
            Cells = new Cell[rows, columns];

            _rowSizes = new int[rows];
            _columnSizes = new int[columns];
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
                if (cell.Value.Width > _columnSizes[column])
                {
                    _columnSizes[column] = cell.Value.Width;
                }

                if (cell.Value.Height > _rowSizes[row])
                {
                    _rowSizes[row] = cell.Value.Height;
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
                newRowSizes[i+rowShift] = _rowSizes[i];
            }
            
            int[] newColumnSizes = new int[columns];
            for (int i = Math.Max(0, -columnShift); i < Math.Min(Cells.GetLength(1), columns-columnShift); i++)
            {
                newColumnSizes[i+columnShift] = _columnSizes[i];
            }

            Cells = newCells;
            _rowSizes = newRowSizes;
            _columnSizes = newColumnSizes;
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
        /// Creates the entire matrix of cells into a table.
        /// </summary>
        /// <returns>The table formatted as a string.</returns>
        public override string ToString()
        {
            if (Cells.GetLength(0) == 0 || Cells.GetLength(1) == 0)
            {
                throw new Exception("Table is empty."); //TODO: Make custom exceptions
            }

            UpdateTargetSizes();
            
            string toReturn = " ";
            
            for (int i = 0; i < Cells.GetLength(1); i += Cells[0,i] == null ? 1 : Cells[0,i].Width)
            {
                for (int w = 0; w < (Cells[0,i] == null ? _columnSizes[i] : Cells[0,i].Value.TotalWidth); w++)
                {
                    toReturn += upper;
                }

                toReturn += " ";
            }

            toReturn += "\n";

            ColumnElement[] toDisplay = new ColumnElement[Cells.GetLength(1)];

            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int h = 0; h < _rowSizes[i]; h++)
                {
                    toReturn += border;

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
                            for (int w = 0; w < _columnSizes[j]; w++)
                            {
                                toReturn += " ";
                            }
                        }
                        else
                        {
                            toReturn += toDisplay[j].NextLine();
                            num = toDisplay[j] != null ? toDisplay[j].Cell.Width : 1;
                            
                            if (toDisplay[j].RemainingLines <= 0)
                            {
                                toDisplay[j] = null;
                            }
                        }
                        
                        toReturn += border;
                    }
                    toReturn += "\n";
                }
                
                if (i < Cells.GetLength(0) - 1)
                {
                    toReturn += border;
                    
                    for (int j = 0; j < Cells.GetLength(1); j += Cells[i, j] != null ? Cells[i,j].Width : 1)
                    {
                        if (toDisplay[j] != null)
                        {
                            toReturn += toDisplay[j].NextLine();
                            if (toDisplay[j].RemainingLines <= 0)
                            {
                                toDisplay[j] = null;
                            }
                        }
                        else{
                            for (int w = 0; w < (Cells[i,j] == null ? _columnSizes[j] : Cells[i,j].Value.TotalWidth); w++)
                            {
                                toReturn += seperator;
                            }
                        }
                        
                        toReturn += border;
                    }

                    toReturn += "\n";
                }
            }

            toReturn += border;
            
            for (int i = 0; i < Cells.GetLength(1); i++) 
            {
                for (int w = 0; w < _columnSizes[i]; w++)
                {
                    toReturn += lower;
                }
                toReturn += border;
            }

            return toReturn;
        }
        
        /// <summary>
        /// Update target size of all cells within the cells matrix.
        /// </summary>
        private void UpdateTargetSizes()
        {
            _rowSizes = new int[Cells.GetLength(0)];
            _columnSizes = new int[Cells.GetLength(1)];

            for (int i = 0; i < _columnSizes.Length; i++) 
            {
                _columnSizes[i] = 1;
            }

            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    if (Cells[i,j] != null)
                    {
                        if (Cells[i, j].Value.Height > _rowSizes[i])
                        {
                            _rowSizes[i] = Cells[i, j].Value.Height;
                        }

                        int rowSize = (int)Math.Ceiling((double)Cells[i, j].Value.Height / Math.Min(Cells[i, j].Height, Cells.GetLength(0)-i));
                        for (int y = j; y < Math.Min(j+Cells[i,j].Height, Cells.GetLength(0)); y++) {
                            if (rowSize > _rowSizes[y])
                            {
                                _rowSizes[y] = rowSize;
                            }
                        }

                        int columnSize = (int)Math.Ceiling((double)Cells[i, j].Value.Width / Math.Min(Cells[i, j].Width, Cells.GetLength(1)-j));
                        for (int x = j; x < Math.Min(j+Cells[i,j].Width, Cells.GetLength(1)); x++) {
                            if (columnSize > _columnSizes[x])
                            {
                                _columnSizes[x] = columnSize;
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
                    for (int x = j; x < Math.Min(_columnSizes.Length, j+Cells[i,j].Width); x++)
                    {
                        targetWidth += _columnSizes[x];
                    }

                    int targetHeight = Cells[i,j].Height - 1;
                    for (int x = i; x < Math.Min(_rowSizes.Length, i+Cells[i,j].Height); x++)
                    {
                        targetHeight += _rowSizes[x];
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