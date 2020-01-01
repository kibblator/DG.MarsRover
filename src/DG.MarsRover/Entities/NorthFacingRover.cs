using DG.MarsRover.Models;
using DG.MarsRover.Types;

namespace DG.MarsRover.Entities
{
    public class NorthFacingRover : RoverPosition
    {
        public NorthFacingRover(RoverPosition state) : this(state.Grid, state.CurrentX, state.CurrentY, state.Rover)
        {
        }

        public NorthFacingRover(Grid grid, int currentX, int currentY, Rover rover)
        {
            this.grid = grid;
            this.currentX = currentX;
            this.currentY = currentY;
            this.rover = rover;
            Initialise();
        }

        private void Initialise()
        {
            currentDirection = CompassDirection.N;
        }

        public override void MoveForwards()
        {
            var proposedNewY = currentY + 1;

            CheckForObstacle(currentX, proposedNewY);

            currentY = proposedNewY;
            if (currentY > grid.MaxY)
                currentY = grid.MinY;
        }

        public override void TurnLeft()
        {
            rover.State = new WestFacingRover(this);
        }

        public override void TurnRight()
        {
            rover.State = new EastFacingRover(this);
        }
    }
}