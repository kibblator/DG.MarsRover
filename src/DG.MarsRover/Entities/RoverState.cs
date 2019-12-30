using DG.MarsRover.Types;

namespace DG.MarsRover.Entities
{
    public class RoverState
    {
        public CompassDirection CompassDirection { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }

        public override string ToString()
        {
            return $"{XPos}:{YPos}:{CompassDirection.ToString()}";
        }
    }
}