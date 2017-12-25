using AdventOfCode.Day20;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day20.Given_Particle
{
    [TestFixture]
    public class When_Parse
    {
        private const string Input = "p=<1500,413,-535>, v=<-119,22,36>, a=<-5,-12,3>";
        private Particle _result;

        [SetUp]
        public void Because_of() => _result = Particle.Parse(Input);

        [Test]
        public void Position_should_be_first_vector() =>
            Assert.That(_result.Position, Is.EqualTo(new Vector(1500, 413, -535)));

        [Test]
        public void Velocity_should_be_second_vector() =>
            Assert.That(_result.Velocity, Is.EqualTo(new Vector(-119, 22, 36)));

        [Test]
        public void Acceleration_should_be_third_vector() =>
            Assert.That(_result.Acceleration, Is.EqualTo(new Vector(-5, -12, 3)));
    }
}
