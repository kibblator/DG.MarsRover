using DG.MarsRover.Models;
using DG.MarsRover.Types;

namespace DG.MarsRover.Entities
{
    public class EastFacingRover : RoverPosition
    {
        public EastFacingRover(RoverPosition state) : this(state.Grid, state.CurrentX, state.CurrentY, state.Rover)
        {
        }

        public EastFacingRover(Grid grid, int currentX, int currentY, Rover rover)
        {
            this.grid = grid;
            this.currentX = currentX;
            this.currentY = currentY;
            this.rover = rover;
            Initialise();
        }

        private void Initialise()
        {
            currentDirection = CompassDirection.E;
        }

        public override void MoveForwards()
        {
            currentX += 1;
            if (currentX > grid.MaxX)
                currentX = grid.MinX;
        }

        public override void TurnLeft()
        {
            rover.State = new NorthFacingRover(this);
        }

        public override void TurnRight()
        {
            rover.State = new SouthFacingRover(this);
        }
    }
}