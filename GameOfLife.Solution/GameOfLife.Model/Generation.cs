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
        Cell[,] _cells;
        int rows;
        int columns;

        public Generation(Cell[,] cells)
        {
            _cells = cells;

            for(int row=0; row < _cells.GetLength(0); row++)
            {
                for(int column=0; column < _cells.GetLength(1); column++)
                {
                    _cells[row,column] = new Cell(row, column);
                }
            }
        }
    }
}
