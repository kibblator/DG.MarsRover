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
    }
}