using System;
using System.Linq;
using DG.MarsRover.Entities;
using DG.MarsRover.Exceptions;
using DG.MarsRover.Models;

namespace DG.MarsRover
{
    public class MarsRoverController
    {
        private readonly Rover _rover;

        public MarsRoverController(Grid grid)
        {
            _rover = new Rover(grid);
        }

        public string Execute(string commandString)
        {
            var commands = commandString.Select(c => c.ToString());
            foreach (var command in commands)
            {
                try
                {
                    _rover.IssueCommand(command);
                }
                catch (RoverEncounteredObstacleException ex)
                {
                    return ex.CurrentPosition;
                }
            }
            return _rover.GetCurrentPosition();
        }
    }
}
