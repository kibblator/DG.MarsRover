namespace DG.MarsRover.Models
{
    public class Grid
    {
        public Grid(int minY, int maxY)
        {
            MinY = minY;
            MaxY = maxY;
        }

        public int MinY { get; private set; }
        public int MaxY { get; private set; }
    }
}