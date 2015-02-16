using GameOfLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Models
{
    public class Generation
    {
        public Cell[,] Cells { get; private set; }

        //Cell[,] _cells;
        int rows;
        int columns;

        public Generation(Cell[,] cells)
        {
            Cells = cells;

            for(int row=0; row < Cells.GetLength(0); row++)
            {
                for(int column=0; column < Cells.GetLength(1); column++)
                {
                    Cells[row,column] = new Cell(row, column);
                }
            }
        }

        public Cell[,] GetCells()
        {
            return Cells;
        }
    }
}
