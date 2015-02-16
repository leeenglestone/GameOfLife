namespace GameOfLife.Models
{
    public class Cell
    {
        public int Y { get; private set; }
        public int X { get; private set; }
        public bool IsAlive { get; set; }

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
    }
}
