
namespace BetterConsole.ConsoleComponents
{
    public class Table : ConsoleComponent
    {
        public Cell[,] cells;

        private string upper = "_";
        private string lower = "‾";
        private string seperator = "-";
        private string border = "|";

        public Table (int rows, int columns)
        {
            cells = new Cell[rows, columns];
        }

        public override string ToString()
        {
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

            throw new System.NotImplementedException();
        }
    }
}