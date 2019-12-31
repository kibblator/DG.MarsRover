namespace DG.MarsRover.Models
{
    public class Grid
    {
        public Grid(int minY, int maxY, int minX, int maxX)
        {
            MinY = minY;
            MaxY = maxY;
            MinX = minX;
            MaxX = maxX;
        }

        public int MinY { get; private set; }
        public int MaxY { get; private set; }
        public int MaxX { get; private set; }
        public int MinX { get; private set; }
    }
}