using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife.Models
{
    public class Cell
    {
        public int Row { get; private set; }
        public int Column { get; private set; }
        public bool IsAlive { get; set; }

        public Cell(int row, int column)
        {
            Row = row;
            Column = column;    
        }

        public Cell(int row, int column, bool isAlive)
        {
            Row = row;
            Column = column;
            IsAlive = isAlive;
        }
    }
}
