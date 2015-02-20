using System;
using System.Collections.Generic;
using GameOfLife.Model;

namespace GameOfLife.Models
{
    public class World
    {
        public Generation Generation { get; private set; }
    
        public World(Generation generation)
        {            
            Generation = generation;         
        }        

        public int GetCellCount()
        {
            return Generation.GetCellCount();
        }

        public Cell GetCell(int x, int y)
        {
            return Generation.GetCell(x, y);
        }

        public void Evolve()
        {
            var newGeneration = Generation.Clone();
            newGeneration.Genocide();

            foreach (var cell in Generation.Cells)
            {
                Console.WriteLine("");
                Console.WriteLine("== Checking cell ({0},{1})== ", cell.X, cell.Y);
                Console.WriteLine(Generation.ToString());

                // Get number of neighbours
                int livingNeighbours = GetNumberOfLivingNeighbours(cell.X, cell.Y);

                Console.WriteLine("Number of living neighbours : {0}",livingNeighbours);
                Console.WriteLine("Cell IsAlive : {0}", cell.IsAlive);


                if (livingNeighbours < 2)
                {                    
                    newGeneration.Cells[cell.X, cell.Y].IsAlive = false;                    
                }
                else if ((livingNeighbours == 2 && cell.IsAlive))
                {
                    //cell.IsAlive = true;
                    newGeneration.Cells[cell.X, cell.Y].IsAlive = true;
                    
                }
                else if (livingNeighbours == 3)
                {
                    //cell.IsAlive = true;
                    newGeneration.Cells[cell.X, cell.Y].IsAlive = true;
                    
                }
                else if (livingNeighbours > 3)
                {
                //    cell.IsAlive = false;
                    newGeneration.Cells[cell.X, cell.Y].IsAlive = false;
                }

                //newGeneration.Cells[cell.X, cell.Y].IsAlive = cell.IsAlive;
            }

            Generation = newGeneration;
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

        public int GetNumberOfLivingNeighbours(int x, int y)
        {
            //Console.WriteLine("");
            //Console.WriteLine("Checking[{0},{1}] neighbours", x, y);

            int neighbours = 0;

            // All neighbouring positions
            var neighbourPositions = GetNeighbourPositions(x,y);

            foreach (var worldPoint in neighbourPositions)
            {
                var cell = Generation.GetCells()[worldPoint.X, worldPoint.Y];

                //Console.WriteLine("Checking position [{0},{1}] = {2}", worldPoint.X, worldPoint.Y, cell.IsAlive);

                if (cell.IsAlive)
                {
                    neighbours++;
                }

            }

            return neighbours;
        }

        public int GetNumberOfLivingCells()
        {
            var numberOflivingCells = 0;

            for (int row = 0; row < Generation.Cells.GetLength(0); row++)
            {
                for (int column = 0; column < Generation.Cells.GetLength(1); column++)
                {
                    if (Generation.GetCell(column, row).IsAlive)
                        numberOflivingCells++;
                }
            }

            return numberOflivingCells;
        }

    }
}
