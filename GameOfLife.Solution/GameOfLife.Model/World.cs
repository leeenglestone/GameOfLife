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
                int livingNeighbours = GetNumberOfLivingNeighbours(cell.Y, cell.X);


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

        public List<WorldPoint> GetNeighbourPositions()
        {
            var positions = new List<WorldPoint>();

            for(int x = -1; x <= 1; x++)
            {
                for(int y = -1; y <= 1; y++)
                {
                    if (!(x == 0 && y == 0))
                    {
                        
                    }

                }
            }

            return positions;

        }

        public int GetNumberOfLivingNeighbours(int row, int column)
        {
            Console.WriteLine("");
            Console.WriteLine("Checking[{0},{1}] neighbours", row, column);

            int neighbours = 0;

            var neighbourPositions = GetNeighbourPositions();

            foreach (var worldPoint in neighbourPositions)
            {
                
            }


            //for (int x = -1; x <= 1; x++)
            //{
            //    for (int y = -1; y <= 1; y++)
            //    {
            //        if (!(x == 0 && y == 0))
            //        {
            //            try
            //            {
            //                Console.WriteLine("Checking if neighbour [{0},{1}] is alive = {2}", row + y, column + x, _cells[row + y, column + x].IsAlive);

            //                if (_cells[row + y, column + x].IsAlive)
            //                {
            //                    neighbours++;
            //                    Console.WriteLine("Neighbour found");
            //                }
            //            }
            //            catch
            //            {

            //            }
            //        }
            //    }
            //}

            return neighbours;
        }
    }
}
