using System;
using DG.MarsRover.Models;

namespace DG.MarsRover.Tests
{
    public static class RoverTestHelper
    {
        public static Obstacle ConvertCoordinateStringToCoordinate(string obstacleLocation)
        {
            var obsCoords = obstacleLocation.Split(",");
            var obsX = Convert.ToInt32(obsCoords[0]);
            var obsY = Convert.ToInt32(obsCoords[1]);

            return new Obstacle(obsX, obsY);
        }
    }
}
