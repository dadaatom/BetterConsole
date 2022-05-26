
using System;

namespace BetterConsole.ConsoleComponents
{
    /*
     * TODO:
     * Create max width/heights where the cell will omit some data where it can
     * Add wraparound logic to Cell if max vals are defined.
     *
     * Accept null fields in the toString method.
     */
    
    public class Table : ConsoleComponent
    {
        public Cell[,] cells;

        public int CellWidth { get; private set; }
        public int CellHeight { get; private set; }
        
        //TODO: Loop these variables into a style class.
        private string upper = "_";
        private string lower = "‾";
        private string seperator = "-";
        private string border = "|";
        
        public Table (int rows, int columns)
        {
            cells = new Cell[rows, columns];
        }

        public void SetCell(Cell cell, int row, int column)
        {
            bool changed = false;
            if (cell.Width > CellWidth)
            {
                CellWidth = cell.Width;
                changed = true;
            }

            if (cell.Height > CellHeight)
            {
                CellHeight = cell.Height;
                changed = true;
            }

            if (changed)
            {
                UpdateTargetSizes(CellWidth, CellHeight);
            }

            cells[row, column] = cell;
        }

        public void UpdateTargetSizes(int width, int height)
        {
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    cells[i,j]?.SetTargetSizes(width, height);
                }
            }
        }

        public override string ToString()
        {
            if (cells.GetLength(0) == 0 || cells.GetLength(1) == 0)
            {
                throw new Exception("Table empty bro.");
            }

            int width = 1;
            int height = 1;

            for (int i = 0; i < cells.GetLength(0); i++) {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    Cell cell = cells[i, j];

                    if (cell.Width > width)
                    {
                        width = cell.Width;
                    }
                    if (cell.Height > height)
                    {
                        height = cell.Height;
                    }
                }
            }

            string toReturn = " ";

            for (int i = 0; i < cells.GetLength(1); i++) 
            {
                for (int w = 0; w < width; w++)
                {
                    toReturn += upper;
                }
                toReturn += " ";
            }

            toReturn += "\n";

            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int h = 0; h < height; h++)
                {
                    toReturn += border;
                    for (int j = 0; j < cells.GetLength(1); j++)
                    {
                        toReturn += cells[i, j].CenteredValue[h] + border;
                    }
                    toReturn += "\n";
                }
            }

            toReturn += " ";
            for (int i = 0; i < cells.GetLength(1); i++) 
            {
                for (int w = 0; w < width; w++)
                {
                    toReturn += lower;
                }
                toReturn += " ";
            }

            return toReturn;
        }
    }
}