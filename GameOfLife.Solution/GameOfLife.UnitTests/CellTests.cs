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

            Assert.IsTrue(world.GetCellCount() == rows * columns);

            Console.WriteLine(world.GetCellCount());
        }

        [TestMethod]
        public void Generation_Constructor_ShouldInitialiseCells()
        {
            /*
              
             - X - 
             - X X
             - - -               
             
            */

            var cells = new Cell[3, 3];
            cells[1, 0] = new Cell(1, 0, true);
            cells[1, 1] = new Cell(1, 1, true);            
            cells[2, 1] = new Cell(2, 1, true);

            Generation generation = new Generation(cells);

            // First column
            Assert.IsFalse(generation.GetCells()[0, 0].IsAlive);
            Assert.IsFalse(generation.GetCells()[0, 1].IsAlive);
            Assert.IsFalse(generation.GetCells()[0, 2].IsAlive);

            // Second column
            Assert.IsTrue(generation.GetCells()[1, 0].IsAlive);
            Assert.IsTrue(generation.GetCells()[1, 1].IsAlive);
            Assert.IsFalse(generation.GetCells()[1, 2].IsAlive);

            // Third column
            Assert.IsFalse(generation.GetCells()[2, 0].IsAlive);
            Assert.IsTrue(generation.GetCells()[2, 1].IsAlive);
            Assert.IsFalse(generation.GetCells()[2, 2].IsAlive);

            Console.WriteLine(generation.ToString());

        }

        [TestMethod]
        public void World_WhenEvolves_LivingCellWith0NeighboursDies()
        {
            var cells = new Cell[3, 3];
            cells[1, 1] = new Cell(1, 1);
            var generation = new Generation(cells);

            var world = new World(generation);
            world.Evolve();

            Assert.IsFalse(world.GetCell(1,1).IsAlive);
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

            Assert.IsFalse(world.GetCell(1,1).IsAlive);
        }

        [TestMethod]
        public void World_WhenEvolves_LivingCellWith2NeighboursLives()
        {
            // - X -
            // - X X 
            // - - - 

            var cells = new Cell[3, 3];
            cells[1, 0] = new Cell(1, 0, true);
            cells[1, 1] = new Cell(1, 1, true);
            cells[2, 1] = new Cell(2, 1, true);
            var generation = new Generation(cells);

            Console.WriteLine(generation.ToString());

            var world = new World(generation);
            world.Evolve();

            Console.WriteLine(generation.ToString());

            Assert.IsTrue(world.GetCell(1,1).IsAlive);
        }

        [TestMethod]
        public void World_WhenEvolves_LivingCellWith4NeighboursDies()
        {
            // X X X
            // - X X 
            // - - - 

            var cells = new Cell[3, 3];
            cells[0, 0] = new Cell(0, 0, true);
            cells[1, 0] = new Cell(1, 0, true);
            cells[2, 0] = new Cell(2, 0, true);

            cells[1, 1] = new Cell(1, 1, true);
            cells[2, 1] = new Cell(2, 1, true);
            var generation = new Generation(cells);

            Console.WriteLine(generation.ToString());

            var world = new World(generation);
            world.Evolve();

            Console.WriteLine(generation.ToString());

            Assert.IsTrue(world.GetCell(1, 1).IsDead);
        }

        [TestMethod]
        public void World_WhenEvolves_LivingCellWith5NeighboursDies()
        {
            // X X X
            // X X X 
            // - - - 

            var cells = new Cell[3, 3];
            cells[0, 0] = new Cell(0, 0, true);
            cells[1, 0] = new Cell(1, 0, true);
            cells[2, 0] = new Cell(2, 0, true);

            cells[0, 1] = new Cell(0, 1, true);
            cells[1, 1] = new Cell(1, 1, true);
            cells[2, 1] = new Cell(2, 1, true);

            var generation = new Generation(cells);

            Console.WriteLine(generation.ToString());

            var world = new World(generation);
            world.Evolve();

            Console.WriteLine(generation.ToString());

            Assert.IsTrue(world.GetCell(1, 1).IsDead);
        }

        [TestMethod]
        public void World_WhenEvolves_LivingCellWith6NeighboursDies()
        {
            // X X X
            // X X X 
            // X - - 

            var cells = new Cell[3, 3];
            cells[0, 0] = new Cell(0, 0, true);
            cells[1, 0] = new Cell(1, 0, true);
            cells[2, 0] = new Cell(2, 0, true);

            cells[0, 1] = new Cell(0, 1, true);
            cells[1, 1] = new Cell(1, 1, true);
            cells[2, 1] = new Cell(2, 1, true);

            cells[0, 2] = new Cell(0, 2, true);

            var generation = new Generation(cells);

            Console.WriteLine(generation.ToString());

            var world = new World(generation);
            world.Evolve();

            Console.WriteLine(generation.ToString());

            Assert.IsTrue(world.GetCell(1, 1).IsDead);
        }

        [TestMethod]
        public void World_WhenEvolves_LivingCellWith7NeighboursDies()
        {
            // X X X
            // X X X 
            // X X - 

            var cells = new Cell[3, 3];
            cells[0, 0] = new Cell(0, 0, true);
            cells[1, 0] = new Cell(1, 0, true);
            cells[2, 0] = new Cell(2, 0, true);

            cells[0, 1] = new Cell(0, 1, true);
            cells[1, 1] = new Cell(1, 1, true);
            cells[2, 1] = new Cell(2, 1, true);

            cells[0, 2] = new Cell(0, 2, true);
            cells[1, 2] = new Cell(1, 2, true);
            cells[2, 2] = new Cell(2, 2, false);

            var generation = new Generation(cells);

            Console.WriteLine(generation.ToString());

            var world = new World(generation);
            world.Evolve();

            Console.WriteLine(generation.ToString());

            Assert.IsTrue(world.GetCell(1, 1).IsDead);
        }

        [TestMethod]
        public void World_WhenEvolves_LivingCellWith8NeighboursDies()
        {
            // X X X
            // X X X 
            // X X X 

            var cells = new Cell[3, 3];
            cells[0, 0] = new Cell(0, 0, true);
            cells[1, 0] = new Cell(1, 0, true);
            cells[2, 0] = new Cell(2, 0, true);

            cells[0, 1] = new Cell(0, 1, true);
            cells[1, 1] = new Cell(1, 1, true);
            cells[2, 1] = new Cell(2, 1, true);

            cells[0, 2] = new Cell(0, 2, true);
            cells[1, 2] = new Cell(1, 2, true);
            cells[2, 2] = new Cell(2, 2, true);

            var generation = new Generation(cells);

            Console.WriteLine(generation.ToString());

            var world = new World(generation);
            world.Evolve();

            Console.WriteLine(generation.ToString());

            Assert.IsTrue(world.GetCell(1, 1).IsDead);
        }

        [TestMethod]
        public void World_WhenEvolves_DeadCellWith0NeighboursStaysDead()
        {
            var cells = new Cell[3, 3];            

            var generation = new Generation(cells);

            var world = new World(generation);
            world.Evolve();

            Assert.IsTrue(cells[1, 1].IsDead);
            Assert.IsTrue(world.GetNumberOfLivingCells() == 0);
        }

        [TestMethod]
        public void World_WhenEvolves_DeadCellWith1NeighbourStaysDead()
        {
            var cells = new Cell[3, 3];
            cells[1, 0] = new Cell(1, 0, true);

            var generation = new Generation(cells);
            var world = new World(generation);
            world.Evolve();
            
            Assert.IsTrue(cells[1, 1].IsDead);
            Assert.IsTrue(world.GetNumberOfLivingCells() == 0);
        }

        [TestMethod]
        public void World_WhenEvolves_DeadCellWith2NeighboursStaysDead()
        {
            // - X -  
            // - - X
            // - - - 

            var cells = new Cell[3, 3];
            cells[1, 0] = new Cell(1, 0, true);
            cells[2, 1] = new Cell(2, 1, true);

            var generation = new Generation(cells);
            var world = new World(generation);
            world.Evolve();

            Assert.IsTrue(world.GetCell(1,1).IsDead);
            Assert.IsTrue(world.GetNumberOfLivingCells() == 0);
        }

        [TestMethod]
        public void World_WhenEvolves_DeadCellWithExactly3NeighboursComesToLife()
        {
            // X X X  
            // - - -
            // - - - 

            var cells = new Cell[3, 3];
            cells[0, 0] = new Cell(0, 0, true);
            cells[1, 0] = new Cell(1, 0, true);
            cells[2, 0] = new Cell(2, 0, true);

            var generation = new Generation(cells);
            Console.WriteLine(generation.ToString());

            var world = new World(generation);            

            world.Evolve();           

            Assert.IsTrue(world.GetCell(1,1).IsAlive);
        }

        [TestMethod]
        public void World_WhenEvolves_DeadCellWith4NeighboursStaysDead()
        {
            // X X X  
            // - - X
            // - - - 

            var cells = new Cell[3, 3];
            cells[0, 0] = new Cell(0, 0, true);
            cells[1, 0] = new Cell(1, 0, true);
            cells[2, 0] = new Cell(2, 0, true);
            cells[2, 1] = new Cell(2, 1, true);

            var generation = new Generation(cells);
            Console.WriteLine(generation.ToString());

            var world = new World(generation);

            world.Evolve();

            Assert.IsTrue(world.GetCell(1, 1).IsDead);
        }

        [TestMethod]
        public void World_WhenEvolves_DeadCellWith5NeighboursStaysDead()
        {
            // X X X  
            // X - X
            // - - - 

            var cells = new Cell[3, 3];
            cells[0, 0] = new Cell(0, 0, true);
            cells[1, 0] = new Cell(1, 0, true);
            cells[2, 0] = new Cell(2, 0, true);
            cells[2, 1] = new Cell(2, 1, true);
            cells[0, 1] = new Cell(0, 1, true);

            var generation = new Generation(cells);
            Console.WriteLine(generation.ToString());

            var world = new World(generation);

            world.Evolve();

            Assert.IsTrue(world.GetCell(1, 1).IsDead);
        }

        [TestMethod]
        public void World_WhenEvolves_DeadCellWith6NeighboursStaysDead()
        {
            // X X X  
            // X - X
            // X - - 

            var cells = new Cell[3, 3];
            cells[0, 0] = new Cell(0, 0, true);
            cells[1, 0] = new Cell(1, 0, true);
            cells[2, 0] = new Cell(2, 0, true);

            cells[2, 1] = new Cell(2, 1, true);
            cells[0, 1] = new Cell(0, 1, true);
            cells[0, 2] = new Cell(0, 2, true);

            var generation = new Generation(cells);
            Console.WriteLine(generation.ToString());

            var world = new World(generation);

            world.Evolve();

            Assert.IsTrue(world.GetCell(1, 1).IsDead);
        }

        [TestMethod]
        public void World_WhenEvolves_DeadCellWith7NeighboursStaysDead()
        {
            // X X X  
            // X - X
            // X X - 

            var cells = new Cell[3, 3];
            cells[0, 0] = new Cell(0, 0, true);
            cells[1, 0] = new Cell(1, 0, true);
            cells[2, 0] = new Cell(2, 0, true);
            cells[2, 1] = new Cell(2, 1, true);
            cells[0, 1] = new Cell(0, 1, true);
            cells[0, 2] = new Cell(0, 2, true);
            cells[1, 2] = new Cell(1, 2, true);

            var generation = new Generation(cells);
            Console.WriteLine(generation.ToString());

            var world = new World(generation);

            world.Evolve();

            Assert.IsTrue(world.GetCell(1, 1).IsDead);
        }

        [TestMethod]
        public void World_WhenEvolves_DeadCellWith8NeighboursStaysDead()
        {
            // X X X  
            // X - X
            // X X X 

            var cells = new Cell[3, 3];
            cells[0, 0] = new Cell(0, 0, true);
            cells[1, 0] = new Cell(1, 0, true);
            cells[2, 0] = new Cell(2, 0, true);
            cells[2, 1] = new Cell(2, 1, true);
            cells[0, 1] = new Cell(0, 1, true);
            cells[0, 2] = new Cell(0, 2, true);
            cells[1, 2] = new Cell(1, 2, true);
            cells[2, 2] = new Cell(2, 2, true);

            var generation = new Generation(cells);
            Console.WriteLine(generation.ToString());

            var world = new World(generation);

            world.Evolve();

            Assert.IsTrue(world.GetCell(1, 1).IsDead);
        }

        [TestMethod]
        public void Evolve_GetNeighboursOfLeftTopCorner()
        {
            var cells = new Cell[3, 3];
            var generation = new Generation(cells);
            var world = new World(generation);

            var neighbours = world.GetNeighbourPositions(0, 0);

            Assert.AreEqual(3, neighbours.Count);
        }

        [TestMethod]
        public void Evolve_GetNeighboursOfLeftBottomCorner()
        {
            var cells = new Cell[3, 3];
            var generation = new Generation(cells);
            var world = new World(generation);

            var neighbours = world.GetNeighbourPositions(0, 2);

            Assert.AreEqual(3, neighbours.Count);
        }

        [TestMethod]
        public void Evolve_GetNeighboursOfTopNotCorner()
        {
            var cells = new Cell[3, 3];
            var generation = new Generation(cells);
            var world = new World(generation);

            var neighbours = world.GetNeighbourPositions(1, 0);

            Assert.AreEqual(5, neighbours.Count);

        }

        [TestMethod]
        public void Evolve_GetNeighboursOfLeftSideNotCorner()
        {
            var cells = new Cell[3, 3];
            var generation = new Generation(cells);
            var world = new World(generation);

            var neighbours = world.GetNeighbourPositions(0, 1);

            Assert.AreEqual(5, neighbours.Count);
        }

        [TestMethod]
        public void Evolve_GetNeighboursOfRightSideNotCorner()
        {
            var cells = new Cell[3, 3];
            var generation = new Generation(cells);
            var world = new World(generation);

            var neighbours = world.GetNeighbourPositions(2, 1);

            Assert.AreEqual(5, neighbours.Count);
        }

        [TestMethod]
        public void Evolve_GetNeighboursOfRightTopCorner()
        {
            var cells = new Cell[3, 3];
            var generation = new Generation(cells);
            var world = new World(generation);

            var neighbours = world.GetNeighbourPositions(2, 0);

            Assert.AreEqual(3, neighbours.Count);
        }

        [TestMethod]
        public void Evolve_GetNeighboursOfRightBottomCorner()
        {
            var cells = new Cell[3, 3];
            var generation = new Generation(cells);
            var world = new World(generation);

            var neighbours = world.GetNeighbourPositions(2, 2);

            Assert.AreEqual(3, neighbours.Count);

        }

        [TestMethod]
        public void Evolve_GetNeighboursOfNotSideNotCorner()
        {
            var cells = new Cell[3, 3];
            var generation = new Generation(cells);
            var world = new World(generation);

            var neighbours = world.GetNeighbourPositions(1, 1);

            Assert.AreEqual(8, neighbours.Count);
        }

        [TestMethod]        
        public void World_GetNumberOfLivingNeighbours_v1()
        {
            var cells = new Cell[3, 3];
            cells[1,0] = new Cell(1,0,true);
            cells[2, 1] = new Cell(2, 1, true);
            var generation = new Generation(cells);
            var world = new World(generation);

            var livingNeighbours = world.GetNumberOfLivingNeighbours(1, 1);

            Assert.AreEqual(2, livingNeighbours);

        }

        [TestMethod]
        public void Generation_GetCell_ShouldReturnCorrectCell()
        {
            // - X -  
            // - - X
            // - - - 

            var cells = new Cell[3, 3];
            cells[1, 0] = new Cell(1, 0, true);
            cells[2, 1] = new Cell(2, 1, true);

            var generation = new Generation(cells);

            var cell = generation.GetCell(1, 0);

            //var world = new World(generation);

            ///var livingNeighbours = world.GetNumberOfLivingNeighbours(1, 1);

            Assert.IsTrue(generation.GetCell(0, 0).IsDead);
            Assert.IsTrue(generation.GetCell(1, 0).IsAlive);
            Assert.IsTrue(generation.GetCell(2, 0).IsDead);

            Assert.IsTrue(generation.GetCell(0, 1).IsDead);
            Assert.IsTrue(generation.GetCell(1, 1).IsDead);
            Assert.IsTrue(generation.GetCell(2, 1).IsAlive);

            Assert.IsTrue(generation.GetCell(0, 2).IsDead);
            Assert.IsTrue(generation.GetCell(1, 2).IsDead);
            Assert.IsTrue(generation.GetCell(2, 2).IsDead);

        }
    }
}
