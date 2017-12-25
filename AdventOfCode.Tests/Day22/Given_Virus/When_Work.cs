using System.Collections.Generic;
using AdventOfCode.Day22;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day22.Given_Virus
{
    [TestFixture]
    public class When_Work
    {
        private readonly Map _map = Map.Parse("..#\n#..\n...");
        private readonly Virus _subject = new Virus((0, 0), (0, 1));
        private Map _result;

        [OneTimeSetUp]
        public void Because_of() => _result = _subject.Work(_map);

        [Test]
        public void Current_node_should_be_infected() => Assert.That(_result.IsInfected(0, 0), Is.True);

        [Test]
        public void Virus_should_move_left() => Assert.That(_subject.Position, Is.EqualTo((-1, 0)));

        [Test]
        public void Infection_count_should_increase() => Assert.That(_subject.InfectionCount, Is.EqualTo(1));
    }
}
