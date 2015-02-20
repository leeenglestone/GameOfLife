using System;

namespace GameOfLife.Models
{
    public class Cell
    {        
        public int Y { get; private set; }
        public int X { get; private set; }
        public bool IsAlive { get; set; }
        public bool IsDead { get { return !IsAlive; } }

        public Cell(int x, int y)
        {
            Y = y;
            X = x;    
        }

        public Cell(int x, int y, bool isAlive)
        {
            Y = y;
            X = x;
            IsAlive = isAlive;
        }

        public override string ToString()
        {
            return String.Format("({0},{1}) = {2}", X, Y, IsAlive ? "Alive" : "Dead");
        }
    }
}
