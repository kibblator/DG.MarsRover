using DG.MarsRover.Models;
using DG.MarsRover.Types;

namespace DG.MarsRover.Entities
{
    public class Rover
    {
        private readonly RoverState _roverState;
        private readonly Grid _grid;

        public Rover(RoverState intialRoverState, Grid grid)
        {
            _roverState = intialRoverState;
            _grid = grid;
        }

        public void Move(string command)
        {
            if (command == "R")
            {
                _roverState.CompassDirection += 1;
                if ((int) _roverState.CompassDirection == 5)
                    _roverState.CompassDirection = CompassDirection.N;
            }
            else if (command == "L")
            {
                _roverState.CompassDirection -= 1;
                if ((int) _roverState.CompassDirection == 0)
                    _roverState.CompassDirection = CompassDirection.W;
            }
            else if (command == "M")
            {
                if (_roverState.CompassDirection == CompassDirection.N)
                    _roverState.YPos += 1;
                if (_roverState.CompassDirection == CompassDirection.E)
                    _roverState.XPos += 1;
                if (_roverState.CompassDirection == CompassDirection.S)
                    _roverState.YPos -= 1;
                if (_roverState.CompassDirection == CompassDirection.W)
                    _roverState.XPos -= 1;
            }
        }

        public string GetPosition()
        {
            return _roverState.ToString();
        }
    }
}