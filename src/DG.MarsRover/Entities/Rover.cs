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
                RotateRight();
            }
            else if (command == "L")
            {
                RotateLeft();
            }
            else if (command == "M")
            {
                CheckCompassDirectionAndUpdateMapPosition();
            }
        }

        private void CheckCompassDirectionAndUpdateMapPosition()
        {
            if (_roverState.CompassDirection == CompassDirection.N)
            {
                MoveNorthWithWrap();
            }

            if (_roverState.CompassDirection == CompassDirection.E)
            {
                MoveEastWithWrap();
            }

            if (_roverState.CompassDirection == CompassDirection.S)
            {
                MoveSouthWithWrap();
            }

            if (_roverState.CompassDirection == CompassDirection.W)
            {
                MoveWestWithWrap();
            }
        }

        private void MoveWestWithWrap()
        {
            if (_roverState.XPos == _grid.MinX)
            {
                _roverState.XPos = _grid.MaxX;
            }
            else
            {
                _roverState.XPos -= 1;
            }
        }

        private void MoveSouthWithWrap()
        {
            if (_roverState.YPos == _grid.MinY)
            {
                _roverState.YPos = _grid.MaxY;
            }
            else
            {
                _roverState.YPos -= 1;
            }
        }

        private void MoveEastWithWrap()
        {
            if (_roverState.XPos == _grid.MaxX)
            {
                _roverState.XPos = _grid.MinX;
            }
            else
            {
                _roverState.XPos += 1;
            }
        }

        private void MoveNorthWithWrap()
        {
            if (_roverState.YPos == _grid.MaxY)
            {
                _roverState.YPos = _grid.MinY;
            }
            else
            {
                _roverState.YPos += 1;
            }
        }

        private void RotateLeft()
        {
            _roverState.CompassDirection -= 1;
            if ((int) _roverState.CompassDirection == 0)
                _roverState.CompassDirection = CompassDirection.W;
        }

        private void RotateRight()
        {
            _roverState.CompassDirection += 1;
            if ((int) _roverState.CompassDirection == 5)
                _roverState.CompassDirection = CompassDirection.N;
        }

        public string GetPosition()
        {
            return _roverState.ToString();
        }
    }
}