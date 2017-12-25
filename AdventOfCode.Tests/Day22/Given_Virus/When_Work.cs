using AdventOfCode.Day22;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day22.Given_Virus
{
    [TestFixture]
    public class When_Work
    {
        private readonly Map _map = Map.Parse("..#\n#..\n...");
        private readonly (int, int) _position = (0, 0);
        private Virus _subject;
        private Map _result;

        [OneTimeSetUp]
        public void Because_of()
        {
            _subject = new Virus(_position, Direction.Up);
            _result = _subject.Work(_map);
        }

        [Test]
        public void Current_node_should_be_infected() => Assert.That(_result.GetState(_position), Is.EqualTo(Map.NodeState.Infected));

        [Test]
        public void Virus_should_move_left() => Assert.That(_subject.Position, Is.EqualTo((-1, 0)));

        [Test]
        public void Infection_count_should_increase() => Assert.That(_subject.InfectionCount, Is.EqualTo(1));
    }
}
