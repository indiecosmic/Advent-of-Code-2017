using AdventOfCode.Day22;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day22.Given_EvolvedVirus
{
    [TestFixture()]
    public class When_Work_and_current_node_is_infected
    {
        private readonly Map _map = Map.Parse("..#\n#W.\n...");
        private readonly EvolvedVirus _subject = new EvolvedVirus((-1, 0), Direction.Left);
        private Map _result;

        [OneTimeSetUp]
        public void Because_of() => _result = _subject.Work(_map);

        [Test]
        public void Current_node_should_be_flagged() => Assert.That(_result.GetState((-1, 0)), Is.EqualTo(Map.NodeState.Flagged));

        [Test]
        public void Virus_should_move_up() => Assert.That(_subject.Position, Is.EqualTo((-1, 1)));

        [Test]
        public void Infection_count_should_not_increase() => Assert.That(_subject.InfectionCount, Is.EqualTo(0));
    }
}
