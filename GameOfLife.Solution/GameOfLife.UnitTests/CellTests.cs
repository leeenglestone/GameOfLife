using System;
using GameOfLife.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.UnitTests
{
    [TestClass]
    public class CellTests
    {
        [TestMethod]
        public void World_Create_ShouldInitialiseWithCorrectNumberOfCells()
        {
            const int rows = 3;
            const int columns = 3;

            var cells = new Cell[rows, columns];
            var generation = new Generation(cells);
            World world = new World(generation);
            
            Assert.IsTrue(world.GetCellCount() == rows*columns);

            Console.WriteLine(world.GetCellCount());
        }

        [TestMethod]
        public void World_WhenEvolves_LivingCellWith0NeighboursDies()
        {            
            var cells = new Cell[3,3];
            cells[1,1] = new Cell(1,1);
            var generation = new Generation(cells);

            var world = new World(generation);
            world.Evolve();

            Assert.IsFalse(cells[1,1].IsAlive);
        }

        [TestMethod]
        public void World_WhenEvolves_LivingCellWith1NeighbourDies()
        {
            var cells = new Cell[3, 3];
            cells[0, 1] = new Cell(0, 1);
            cells[1, 1] = new Cell(1, 1);
            var generation = new Generation(cells);

            var world = new World(generation);
            world.Evolve();

            Assert.IsFalse(cells[1, 1].IsAlive);
        }

        [TestMethod]
        public void World_WhenEvolves_LivingCellWith2NeighboursLives()
        {
            var cells = new Cell[3, 3];
            cells[0, 1] = new Cell(0, 1, true);
            cells[1, 1] = new Cell(1, 1, true);
            cells[1, 2] = new Cell(1, 2, true);
            var generation = new Generation(cells);

            var world = new World(generation);
            world.Evolve();

            Assert.IsTrue(cells[1, 1].IsAlive);
        }

        [TestMethod]
        public void World_WhenEvolves_DeadCellWithExactly3NeighboursComesToLife()
        {
            var cells = new Cell[3, 3];
            cells[0, 1] = new Cell(0, 1, true);
            cells[1, 1] = new Cell(1, 1, true);
            cells[1, 2] = new Cell(1, 2, true);

            var generation = new Generation(cells);

            var world = new World(generation);
            world.Evolve();

            Assert.IsTrue(cells[1, 1].IsAlive);
        }

        [TestMethod]
        public void Evolve_GetNeighbours()
        {           
            var cells = new Cell[3, 3];
            var generation = new Generation(cells);
            var world = new World(generation);
           
            var neighbours = world.GetNeighbourPositions();

            Assert.IsTrue(neighbours.Count > 0);

        }
    }
}
