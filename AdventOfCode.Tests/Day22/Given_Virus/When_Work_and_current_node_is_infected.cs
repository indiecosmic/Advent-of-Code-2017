using AdventOfCode.Day22;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day22.Given_Virus
{
    [TestFixture]
    public class When_Work_and_current_node_is_infected
    {
        private readonly Map _map = Map.Parse("..#\n##.\n...");
        private readonly Virus _subject = new Virus((-1, 0), (-1, 0));
        private Map _result;

        [OneTimeSetUp]
        public void Because_of() => _result = _subject.Work(_map);

        [Test]
        public void Current_node_should_be_cleaned() => Assert.That(_result.IsInfected(-1, 0), Is.False);

        [Test]
        public void Virus_should_move_up() => Assert.That(_subject.Position, Is.EqualTo((-1, 1)));

        [Test]
        public void Infection_count_should_not_increase() => Assert.That(_subject.InfectionCount, Is.EqualTo(0));
    }
}
