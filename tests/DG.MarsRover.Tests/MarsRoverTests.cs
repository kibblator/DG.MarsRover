using DG.MarsRover.Entities;
using DG.MarsRover.Models;
using DG.MarsRover.Types;
using NUnit.Framework;

namespace DG.MarsRover.Tests
{
    public class MarsRoverTests
    {
        private MarsRover _rover;

        [SetUp]
        public void SetUp()
        {
            _rover = new MarsRover(new Grid(0, 10));
        }

        [Test]
        public void NoCommands_ReturnsStartPosition()
        {
            //Act
            var result = _rover.Execute("");

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
            var result = _rover.Execute(input);

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
            var result = _rover.Execute(input);

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
            var result = _rover.Execute(input);

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
            var result = _rover.Execute(input);

            //Assert
            Assert.That(result, Is.EqualTo(expectedOutput));
        }
    }
}