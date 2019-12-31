using System.Linq;
using DG.MarsRover.Entities;
using DG.MarsRover.Models;
using DG.MarsRover.Types;

namespace DG.MarsRover
{
    public class MarsRoverController
    {
        private readonly Rover _rover;

        public MarsRoverController(Grid grid)
        {
            _rover = new Rover(new RoverState
            {
                CompassDirection = CompassDirection.N,
                XPos = 0,
                YPos = 0
            }, grid);
        }

        public string Execute(string commandString)
        {
            var commands = commandString.Select(c => c.ToString());
            foreach (var command in commands)
            {
                _rover.IssueCommand(command);
            }
            return _rover.GetPosition();
        }
    }
}
