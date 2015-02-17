namespace GameOfLife.Models
{
    public class Generation
    {
        public Cell[,] Cells { get; private set; }
        
        int rows;
        int columns;

        public Generation(Cell[,] cells)
        {
            Cells = cells;
                       
                for(int column=0; column < Cells.GetLength(0); column++)
                {
                    for (int row = 0; row < Cells.GetLength(1); row++)
                    {
                        if (Cells[column, row] == null)
                        {
                            Cells[column, row] = new Cell(row, column);    
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
            return Cells[x,y];
        }
    }
}
