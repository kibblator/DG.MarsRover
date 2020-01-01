using DG.MarsRover.Models;

namespace DG.MarsRover.Entities
{
    public class Rover
    {
        public RoverPosition State { get; set; }

        public Rover(Grid grid)
        {
            State = new NorthFacingRover(grid, 0, 0, this);
        }

        public void IssueCommand(string command)
        {
            if (IsTurnLeftCommand(command))
                State.TurnLeft();
            else if (IsTurnRightCommand(command))
                State.TurnRight();
            else if (IsMoveCommand(command)) 
                State.MoveForwards();
        }

        public string GetCurrentPosition()
        {
            return State.GetCurrentPosition();
        }

        private static bool IsTurnRightCommand(string command)
        {
            return command == "R";
        }

        private static bool IsTurnLeftCommand(string command)
        {
            return command == "L";
        }

        private static bool IsMoveCommand(string command)
        {
            return command == "M";
        }
    }
}
