using DG.MarsRover.Models;
using NUnit.Framework;

namespace DG.MarsRover.Tests
{
    public class MarsRoverTests
    {
        private MarsRoverController _roverController;

        [SetUp]
        public void SetUp()
        {
            _roverController = new MarsRoverController(new Grid(0, 9, 0, 9));
        }

        [Test]
        public void NoCommands_ReturnsStartPosition()
        {
            //Act
            var result = _roverController.Execute("");

            //Assert
            Assert.That(result, Is.EqualTo("0:0:N"));
        }

        [Test]
        [TestCase("L", "0:0:W")]
        [TestCase("LL", "0:0:S")]
        [TestCase("LLL", "0:0:E")]
        [TestCase("LLLL", "0:0:N")]
        [TestCase("R", "0:0:E")]
        [TestCase("RR", "0:0:S")]
        [TestCase("RRR", "0:0:W")]
        [TestCase("RRRR", "0:0:N")]
        public void DirectionalCommand_ReturnsCompassDirection(string input, string expectedOutput)
        {
            //Act
            var result = _roverController.Execute(input);

            //Assert
            Assert.That(result, Is.EqualTo(expectedOutput));
        }

        [Test]
        [TestCase("LR", "0:0:N")]
        [TestCase("RL", "0:0:N")]
        [TestCase("LLR", "0:0:W")]
        [TestCase("LLLR", "0:0:S")]
        [TestCase("RRL", "0:0:E")]
        [TestCase("RRRL", "0:0:S")]
        [TestCase("RLRLRR", "0:0:S")]
        [TestCase("LLRLR", "0:0:W")]
        public void MixedDirectionalCommand_ReturnsCompassDirection(string input, string expectedOutput)
        {
            //Act
            var result = _roverController.Execute(input);

            //Assert
            Assert.That(result, Is.EqualTo(expectedOutput));
        }

        [Test]
        [TestCase("M", "0:1:N")]
        [TestCase("MMMM", "0:4:N")]
        [TestCase("MMMMMMMMM", "0:9:N")]
        public void MoveCommand_ReturnsGridPosition(string input, string expectedOutput)
        {
            //Act
            var result = _roverController.Execute(input);

            //Assert
            Assert.That(result, Is.EqualTo(expectedOutput));
        }

        [Test]
        [TestCase("MRM", "1:1:E")]
        [TestCase("MMRMMM", "3:2:E")]
        [TestCase("MMLLLMMMMR", "4:2:S")]
        public void MoveWithDirections_ReturnsGridPosition(string input, string expectedOutput)
        {
            //Act
            var result = _roverController.Execute(input);

            //Assert
            Assert.That(result, Is.EqualTo(expectedOutput));
        }

        [Test]
        [TestCase("RRM", "0:9:S")]
        [TestCase("RMMMMMMMMMM", "0:0:E")]
        [TestCase("LM", "9:0:W")]
        public void MoveOffEdgeOfMap_ReturnsGridPositionAfterWrapAround(string input, string expectedOutput)
        {
            //Act
            var result = _roverController.Execute(input);

            //Assert
            Assert.That(result, Is.EqualTo(expectedOutput));
        }

        [Test]
        [TestCase("MMMM", "0,3", "O:0:2:N")]
        [TestCase("RMMMMLMMMLM", "3,3", "O:4:3:W")]
        [TestCase("MRMMMMMM", "6,1", "O:5:1:E")]
        [TestCase("MMMMMMMRMRMMMMMMM", "1,4", "O:1:5:S")]
        public void GivenAnObstacle_RoverStopsAndReportsLastLocation(string input, string obstacleLocation,
            string expectedOutput)
        {
            //Arrange
            var obstacle = RoverTestHelper.ConvertCoordinateStringToCoordinate(obstacleLocation);
            var grid = new Grid(0,10,0,10, obstacle);
            _roverController = new MarsRoverController(grid);

            //Act
            var result = _roverController.Execute(input);

            //Assert
            Assert.That(result, Is.EqualTo(expectedOutput));
        }

        [Test]
        [TestCase("MMRMMLM", "2:3:N")]
        [TestCase("MMMMMMMMMM", "0:0:N")]
        public void ScenarioGivenTestCases_ReturnsExpectedResults(string input, string expectedOutput)
        {
            //Act
            var result = _roverController.Execute(input);

            //Assert
            Assert.That(result, Is.EqualTo(expectedOutput));
        }
    }
}