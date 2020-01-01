using DG.MarsRover.Models;
using DG.MarsRover.Types;

namespace DG.MarsRover.Entities
{
    public class WestFacingRover : RoverPosition
    {
        public WestFacingRover(RoverPosition state) : this (state.Grid, state.CurrentX, state.CurrentY, state.Rover)
        {
        }

        public WestFacingRover(Grid grid, int currentX, int currentY, Rover rover)
        {
            this.grid = grid;
            this.currentX = currentX;
            this.currentY = currentY;
            this.rover = rover;
            Initialise();
        }

        private void Initialise()
        {
            currentDirection = CompassDirection.W;
        }

        public override void MoveForwards()
        {
            var proposedNewX = currentX - 1;

            CheckForObstacle(proposedNewX, currentY);

            currentX = proposedNewX;

            if (currentX < grid.MinX)
                currentX = grid.MaxX;
        }

        public override void TurnLeft()
        {
            rover.State = new SouthFacingRover(this);
        }

        public override void TurnRight()
        {
            rover.State = new NorthFacingRover(this);
        }
    }
}