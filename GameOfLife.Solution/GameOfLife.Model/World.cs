using System;
using System.Collections.Generic;
using GameOfLife.Model;

namespace GameOfLife.Models
{
    public class World
    {
        public Generation Generation { get; private set; }

        //Cell[,] _cells;
       
        //public World(Cell[,] cells)
        //{
        //    _cells = cells;

        //    for (int row = 0; row < _cells.GetLength(0); row++)
        //    {
        //        for (int column = 0; column < _cells.GetLength(1); column++)
        //        {
        //            if (_cells[row, column] == null)
        //            {
        //                _cells[row, column] = new Cell(row, column, false);
        //            }
        //        }
        //    }
        //}        

        public World(Generation generation)
        {
            //_cells = generation.Cells;
            Generation = generation;

            for (int row = 0; row < Generation.Cells.GetLength(0); row++)
            {
                for (int column = 0; column < Generation.Cells.GetLength(1); column++)
                {
                    if (Generation.Cells[row, column] == null)
                    {
                        Generation.Cells[row, column] = new Cell(row, column, false);
                    }
                }
            }
        }        

        public int GetCellCount()
        {
            return Generation.Cells.Length;
        }

        public void Evolve()
        {
            foreach (var cell in Generation.Cells)
            {
                // Get number of neighbours
                int livingNeighbours = GetNumberOfLivingNeighbours(cell.X, cell.Y);

                if (livingNeighbours < 2)
                    cell.IsAlive = false;

                if (livingNeighbours == 2 || livingNeighbours == 3)
                    cell.IsAlive = true;

                if (livingNeighbours > 3)
                    cell.IsAlive = false;

                if (livingNeighbours == 3)
                    cell.IsAlive = true;


                Console.WriteLine("Living Neighbours : {0}", livingNeighbours);
                Console.WriteLine("IsAlive : {0}", cell.IsAlive);
            }
        }

        public List<WorldPoint> GetNeighbourPositions(int xPosition, int yPosition)
        {
            var positions = new List<WorldPoint>();

            // for each horizontal
            for (int x = xPosition - 1; x <= xPosition+1; x++)
            {
                for (int y = yPosition - 1; y <= yPosition+1; y++)                
                {
                    if (!(x == xPosition && y == yPosition))
                    {
                        try
                        {                            
                            if (Generation.GetCells()[x, y] != null)
                            {
                                positions.Add(new WorldPoint(x, y));
                            }
                        }
                        catch { }


                    }

                }
            }

            return positions;

        }

        private int GetNumberOfLivingNeighbours(int x, int y)
        {
            Console.WriteLine("");
            Console.WriteLine("Checking[{0},{1}] neighbours", x, y);

            int neighbours = 0;

            // All neighbouring positions
            var neighbourPositions = GetNeighbourPositions(x,y);

            foreach (var worldPoint in neighbourPositions)
            {
                var cell = Generation.GetCells()[worldPoint.X, worldPoint.Y];

                Console.WriteLine("Checking position [{0},{1}] = {2}", worldPoint.X, worldPoint.Y, cell.IsAlive);

                if (cell.IsAlive)
                {
                    neighbours++;
                }

            }

            return neighbours;
        }
    }
}
