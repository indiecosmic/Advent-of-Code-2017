﻿using AdventOfCode.Day22;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day22.Given_EvolvedVirus
{
    [TestFixture]
    public class When_Work
    {
        private readonly Map _map = Map.Parse("..#\n#..\n...");
        private readonly EvolvedVirus _subject = new EvolvedVirus((0, 0), Direction.Up);
        private Map _result;

        [OneTimeSetUp]
        public void Because_of() => _result = _subject.Work(_map);

        [Test]
        public void Current_node_should_be_weakened() => Assert.That(_result.GetState((0,0)), Is.EqualTo(Map.NodeState.Weakened));

        [Test]
        public void Virus_should_move_left() => Assert.That(_subject.Position, Is.EqualTo((-1, 0)));

        [Test]
        public void Infection_count_should_not_increase() => Assert.That(_subject.InfectionCount, Is.EqualTo(0));
    }
}
