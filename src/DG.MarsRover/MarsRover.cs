using System.Linq;

namespace DG.MarsRover
{
    public enum CompassDirection
    {
        N = 1,
        E = 2,
        S = 3,
        W = 4
    }

    public class MarsRover
    {
        private CompassDirection _compassDirection;
        private int _xPos;
        private int _yPos;

        public MarsRover()
        {
            _compassDirection = CompassDirection.N;
            _xPos = 0;
            _yPos = 0;
        }

        public string Execute(string commandString)
        {
            var commands = commandString.Select(c => c.ToString());
            foreach (var command in commands)
            {
                if (command == "M")
                {
                    MoveRover();
                }
                else
                {
                    AlterCompassDirection(command);
                }
            }
            return $"{_xPos}:{_yPos}:{_compassDirection}";
        }

        private void MoveRover()
        {
            _yPos += 1;
        }

        private void AlterCompassDirection(string command)
        {
            if (command == "R")
            {
                _compassDirection += 1;
                if ((int)_compassDirection == 5)
                    _compassDirection = CompassDirection.N;
            }
            else if (command == "L")
            {
                _compassDirection -= 1;
                if ((int)_compassDirection == 0)
                    _compassDirection = CompassDirection.W;
            }
        }
    }
}
