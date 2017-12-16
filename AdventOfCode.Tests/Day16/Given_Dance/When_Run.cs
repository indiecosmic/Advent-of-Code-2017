using AdventOfCode.Day16;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day16.Given_Dance
{
    [TestFixture]
    public class When_Run
    {
        private readonly char[] _startPositions = { 'a', 'b', 'c', 'd', 'e' };
        private readonly Dance _subject = Dance.Parse("s1,x3/4,pe/b");
        private char[] _result;

        [SetUp]
        public void Because_of() => _result = _subject.Run(_startPositions);

        [Test]
        public void Result_should_be_as_example() => Assert.That(_result, Is.EqualTo(new[] { 'b', 'a', 'e', 'd', 'c' }));

    }
}
