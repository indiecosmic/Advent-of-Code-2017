using AdventOfCode.Day22;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day22.Given_Map
{
    [TestFixture]
    public class When_Parse
    {
        private Map _result;

        [SetUp]
        public void Because_of() => _result = Map.Parse("..#\n#..\n...");

        [Test]
        public void Count_should_be_9() => Assert.That(_result.Count, Is.EqualTo(9));

        [Test]
        public void Upper_right_corner_should_be_infected() => Assert.That(_result.IsInfected(1, 1), Is.True);

        [TestCase(-1, 1)]
        [TestCase(0, 1)]
        public void Upper_left_and_middle_should_be_clean(int x, int y) => Assert.That(_result.IsInfected(x, y), Is.False);

        [Test]
        public void Middle_left_should_be_infected() => Assert.That(_result.IsInfected(-1, 0), Is.True);

        [Test]
        public void Middle_should_be_clean() => Assert.That(_result.IsInfected(0, 0), Is.False);

        [TestCase(-1, -1)]
        [TestCase(0, -1)]
        [TestCase(1, -1)]
        public void Bottom_row_should_be_clean(int x, int y) => Assert.That(_result.IsInfected(x, y), Is.False);
    }
}
