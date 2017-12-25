using AdventOfCode.Day22;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day22.Given_Virus
{
    [TestFixture]
    public class When_Turn
    {
        [TestCase(0, 1, 1, 0, Description = "Turn right from up should be right")]
        [TestCase(1, 0, 0, -1, Description = "Turn right from right should be down")]
        [TestCase(0, -1, -1, 0, Description = "Turn right from down should be left")]
        [TestCase(-1, 0, 0, 1, Description = "Turn right from left should be up")]
        public void Direction_right_should_be_updated(int directionX, int directionY, int expectedX, int expectedY) =>
            Assert.That(Virus.TurnRight((directionX, directionY)), Is.EqualTo((expectedX, expectedY)));

        [TestCase(0, 1, -1, 0, Description = "Turn left from up should be left")]
        [TestCase(-1, 0, 0, -1, Description = "Turn left from left should be down")]
        [TestCase(0, -1, 1, 0, Description = "Turn left from down should be right")]
        [TestCase(1, 0, 0, 1, Description = "Turn left from right should be up")]
        public void Direction_left_should_be_updated(int directionX, int directionY, int expectedX, int expectedY) =>
            Assert.That(Virus.TurnLeft((directionX, directionY)), Is.EqualTo((expectedX, expectedY)));
    }
}
