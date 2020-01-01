using DG.MarsRover.Models;
using DG.MarsRover.Types;

namespace DG.MarsRover.Entities
{
    public abstract class RoverPosition
    {
        protected Rover rover;
        protected Grid grid;
        protected int currentX;
        protected int currentY;
        protected CompassDirection currentDirection;

        public Rover Rover
        {
            get => rover;
            set => rover = value;
        }

        public Grid Grid
        {
            get => grid;
            set => grid = value;
        }

        public int CurrentX
        {
            get => currentX;
            set => currentX = value;
        }

        public int CurrentY
        {
            get => currentY;
            set => currentY = value;
        }

        public string GetCurrentPosition()
        {
            return $"{currentX}:{currentY}:{currentDirection.ToString()}";
        }

        public abstract void MoveForwards();
        public abstract void TurnLeft();
        public abstract void TurnRight();
    }
}
