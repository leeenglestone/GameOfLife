using GameOfLife.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.UnitTests
{
    [TestClass]
    public class CellTests
    {
        [TestMethod]
        public void World_Create_ShouldInitialiseWithCorrectNumberOfCells()
        {
            int rows = 3;
            int columns = 3;

            var cells = new Cell[rows, columns];

            World world = new World(cells);
            
            Assert.IsTrue(world.GetCellCount() == rows*columns);

            Console.WriteLine(world.GetCellCount());
        }

        [TestMethod]
        public void World_WhenEvolves_LivingCellWith0NeighboursDies()
        {            
            var cells = new Cell[3,3];
            cells[1,1] = new Cell(1,1);

            var world = new World(cells);
            world.Evolve();

            Assert.IsFalse(cells[1,1].IsAlive);
        }

        [TestMethod]
        public void World_WhenEvolves_LivingCellWith1NeighbourDies()
        {
            var cells = new Cell[3, 3];
            cells[0, 1] = new Cell(0, 1);
            cells[1, 1] = new Cell(1, 1);

            var world = new World(cells);
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

            var world = new World(cells);
            world.Evolve();

            Assert.IsTrue(cells[1, 1].IsAlive);
        }

        [TestMethod]
        public void Evolve_GetNeighbours()
        {
            var cells = new Cell[3, 3];


        }
    }
}
