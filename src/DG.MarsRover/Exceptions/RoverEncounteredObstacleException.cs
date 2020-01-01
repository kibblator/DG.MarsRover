using System;

namespace DG.MarsRover.Exceptions
{
    public class RoverEncounteredObstacleException : Exception
    {
        public string CurrentPosition { get; private set; }
        public RoverEncounteredObstacleException(string currentPosition) : base($"The rover encountered an obstacle when trying to reach the destination from position {currentPosition}")
        {
            CurrentPosition = $"O:{currentPosition}";
        }
    }
}
