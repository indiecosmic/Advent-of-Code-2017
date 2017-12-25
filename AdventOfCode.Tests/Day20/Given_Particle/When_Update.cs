using AdventOfCode.Day20;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day20.Given_Particle
{
    [TestFixture]
    public class When_Update
    {
        private readonly Particle _subject;

        public When_Update()
        {
            _subject = new Particle(new Vector(3, 0, 0), new Vector(2, 0, 0), new Vector(-1, 0, 0));
        }

        [OneTimeSetUp]
        public void Because_of() => _subject.Update();

        [Test]
        public void Velocity_should_increase_by_acceleration() => Assert.That(_subject.Velocity, Is.EqualTo(new Vector(1, 0, 0)));

        [Test]
        public void Position_should_increase_by_velocity() => Assert.That(_subject.Position, Is.EqualTo(new Vector(4, 0, 0)));

        [Test]
        public void Distance_should_increase() => Assert.That(_subject.Distance(Vector.Zero), Is.EqualTo(4));
    }
}
