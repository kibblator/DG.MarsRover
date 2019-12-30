using System.Linq;
using DG.MarsRover.Entities;
using DG.MarsRover.Types;

namespace DG.MarsRover
{
    public class MarsRover
    {
        private readonly Rover _rover;

        public MarsRover()
        {
            _rover = new Rover(CompassDirection.N, 0,0);
        }

        public string Execute(string commandString)
        {
            var commands = commandString.Select(c => c.ToString());
            foreach (var command in commands)
            {
                if (command == "M")
                {
                    _rover.MoveRover();
                }
                else
                {
                    _rover.AlterCompassDirection(command);
                }
            }
            return _rover.GetPosition();
        }
    }
}
