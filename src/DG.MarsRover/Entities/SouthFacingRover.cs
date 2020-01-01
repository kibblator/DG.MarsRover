using DG.MarsRover.Models;
using DG.MarsRover.Types;

namespace DG.MarsRover.Entities
{
    public class SouthFacingRover : RoverPosition
    {
        public SouthFacingRover(RoverPosition state) : this (state.Grid, state.CurrentX, state.CurrentY, state.Rover)
        {
        }

        public SouthFacingRover(Grid grid, int currentX, int currentY, Rover rover)
        {
            this.grid = grid;
            this.currentX = currentX;
            this.currentY = currentY;
            this.rover = rover;
            Initialise();
        }

        private void Initialise()
        {
            currentDirection = CompassDirection.S;
        }

        public override void MoveForwards()
        {
            var proposedNewY = currentY - 1;

            CheckForObstacle(currentX, proposedNewY);

            currentY = proposedNewY;

            if (currentY < grid.MinY)
                currentY = grid.MaxY;
        }

        public override void TurnLeft()
        {
            rover.State = new EastFacingRover(this);
        }

        public override void TurnRight()
        {
            rover.State = new WestFacingRover(this);
        }
    }
}