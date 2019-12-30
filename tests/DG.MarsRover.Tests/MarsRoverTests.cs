using NUnit.Framework;

namespace DG.MarsRover.Tests
{
    public class MarsRoverTests
    {
        [Test]
        public void NoCommands_ReturnsStartPosition()
        {
            //Arrange
            var rover = new MarsRover();

            //Act
            var result = rover.Execute("");

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
            //Arrange
            var rover = new MarsRover();

            //Act
            var result = rover.Execute(input);

            //Assert
            Assert.That(result, Is.EqualTo(expectedOutput));
        }
    }
}