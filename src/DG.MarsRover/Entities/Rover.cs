using DG.MarsRover.Types;

namespace DG.MarsRover.Entities
{
    public class Rover
    {
        private RoverState _roverState;

        public Rover(CompassDirection compassDirection, int xPos, int yPos)
        {
            _roverState = new RoverState
            {
                CompassDirection = compassDirection,
                XPos = xPos,
                YPos = yPos
            };
        }

        public void MoveRover()
        {
            _roverState.YPos += 1;
        }

        public void AlterCompassDirection(string command)
        {
            if (command == "R")
            {
                _roverState.CompassDirection += 1;
                if ((int)_roverState.CompassDirection == 5)
                    _roverState.CompassDirection = CompassDirection.N;
            }
            else if (command == "L")
            {
                _roverState.CompassDirection -= 1;
                if ((int)_roverState.CompassDirection == 0)
                    _roverState.CompassDirection = CompassDirection.W;
            }
        }

        public string GetPosition()
        {
            return _roverState.ToString();
        }
    }
}
