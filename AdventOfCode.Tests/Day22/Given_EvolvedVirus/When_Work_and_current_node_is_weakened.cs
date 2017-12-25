using AdventOfCode.Day22;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day22.Given_EvolvedVirus
{
    [TestFixture]
    public class When_Work_and_current_node_is_weakened
    {
        private readonly Map _map = Map.Parse("WW.#\nW.W.\n....");
        private readonly EvolvedVirus _subject = new EvolvedVirus((-1, 0), Direction.Left);
        private Map _result;

        [OneTimeSetUp]
        public void Because_of() => _result = _subject.Work(_map);

        [Test]
        public void Current_node_should_be_infected() => Assert.That(_result.GetState((-1, 0)), Is.EqualTo(Map.NodeState.Infected));

        [Test]
        public void Virus_should_move_left() => Assert.That(_subject.Position, Is.EqualTo((-2, 0)));

        [Test]
        public void Infection_count_should_increase() => Assert.That(_subject.InfectionCount, Is.EqualTo(1));
    }
}
