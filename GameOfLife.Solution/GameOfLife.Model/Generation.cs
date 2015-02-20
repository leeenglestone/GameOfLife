using System.Text;

namespace GameOfLife.Models
{
    public class Generation
    {
        public Cell[,] Cells { get; private set; }
       
        public Generation(Cell[,] cells)
        {
            Cells = cells;
            
            for (int row = 0; row < Cells.GetLength(1); row++)
            {                
                for (int column = 0; column < Cells.GetLength(0); column++)
                {
                    if (Cells[column, row] == null)
                    {
                        Cells[column, row] = new Cell(column, row);
                    }
                }
            }
        }

        public Cell[,] GetCells()
        {
            return Cells;
        }

        public Cell GetCell(int x, int y)
        {
            return Cells[x, y];
        }

        public int GetCellCount()
        {
            return Cells.Length;
        }

        public Generation Clone()
        {
            var newCells = (Cell[,])Cells.Clone();

            var generation = new Generation(newCells);

            return generation;
        }

        public void Genocide()
        {
            for (int row = 0; row < Cells.GetLength(1); row++)
            {
                for (int column = 0; column < Cells.GetLength(0); column++)
                {                    
                    Cells[column, row] = new Cell(column, row);                    
                }
            }
        }

        public override string ToString()
        {
            var generation = new StringBuilder();

            for (int row = 0; row < Cells.GetLength(1); row++)
            {
                for (int column = 0; column < Cells.GetLength(0); column++)
                {
                    generation.Append(GetCell(column, row).IsAlive ? " X " : " - ");
                }

                generation.AppendLine();
            }

            return generation.ToString();
        }
    }
}
