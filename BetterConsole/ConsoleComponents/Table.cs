
using System;

namespace BetterConsole.ConsoleComponents
{
    /*
     * TODO:
     * Create max width/heights where the cell will omit some data where it can
     * Add wraparound logic to Cell if max vals are defined.
     * Create resize method
     */
    
    public class Table : ConsoleComponent
    {
        public Cell[,] Cells { get; private set; }

        public int CellWidth;
        public int CellHeight;
        
        //TODO: Loop these variables into a style class.
        private string upper = "_";
        private string lower = "_";//"\u0305";//"‾";
        private string seperator = "-";
        private string border = "|";
        
        public Table (int rows, int columns)
        {
            Cells = new Cell[rows, columns];
        }
        
        /// <summary>
        /// Used to set cells within the table.
        /// </summary>
        /// <param name="cell">Cell to be added to table</param>
        /// <param name="row">Row position within cells matrix</param>
        /// <param name="column">Column position within cells matrix</param>
        public void SetCell(Cell cell, int row, int column)
        {
            if (cell != null)
            {
                if (cell.TargetWidth > CellWidth)
                {
                    CellWidth = cell.Width;
                }

                if (cell.TargetHeight > CellHeight)
                {
                    CellHeight = cell.Height;
                }
            }

            Cells[row, column] = cell;
        }
        
        /// <summary>
        /// Update target size of all cells within the cells matrix.
        /// </summary>
        /// <param name="width">Target width of all cells</param>
        /// <param name="height">Target height of all cells</param>
        private void UpdateTargetSizes(int width, int height)
        {
            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    Cells[i,j]?.SetTargetSizes(width, height);
                }
            }
        }

        public override string ToString()
        {
            if (Cells.GetLength(0) == 0 || Cells.GetLength(1) == 0)
            {
                throw new Exception("Table is empty."); //TODO: Make custom exceptions
            }

            int width = CellWidth;
            int height = CellHeight;

            for (int i = 0; i < Cells.GetLength(0); i++) {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    if (Cells[i, j] != null)
                    {
                        if (Cells[i, j].Width > width)
                        {
                            width = Cells[i, j].Width;
                        }

                        if (Cells[i, j].Height > height)
                        {
                            height = Cells[i, j].Height;
                        }
                    }
                }
            }

            UpdateTargetSizes(width, height);
            
            string toReturn = " ";

            for (int i = 0; i < Cells.GetLength(1); i++) 
            {
                for (int w = 0; w < width; w++)
                {
                    toReturn += upper;
                }
                toReturn += " ";
            }

            toReturn += "\n";

            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int h = 0; h < height; h++)
                {
                    toReturn += border;
                    for (int j = 0; j < Cells.GetLength(1); j++)
                    {
                        if (Cells[i, j] != null)
                        {
                            toReturn += Cells[i, j].CenteredValue[h] + border;
                        }
                        else
                        {
                            for (int w = 0; w < width; w++)
                            {
                                toReturn += " ";
                            }

                            toReturn += border;
                        }
                    }
                    toReturn += "\n";
                }

                if (i < Cells.GetLength(0)-1)
                {
                    toReturn += border;
                    for (int j = 0; j < Cells.GetLength(1); j++)
                    {
                        for (int w = 0; w < width; w++)
                        {
                            toReturn += seperator;
                        }

                        toReturn += border;
                    }

                    toReturn += "\n";
                }
            }

            toReturn += border;
            for (int i = 0; i < Cells.GetLength(1); i++) 
            {
                for (int w = 0; w < width; w++)
                {
                    toReturn += lower;
                }
                toReturn += border;
            }

            return toReturn;
        }
    }
}