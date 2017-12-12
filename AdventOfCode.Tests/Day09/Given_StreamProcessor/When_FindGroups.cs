using AdventOfCode.Day09;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day09.Given_StreamProcessor
{
    [TestFixture]
    public class When_FindGroups
    {
        protected StreamProcessor Subject => new StreamProcessor();

        [TestCase("{}", 1)]
        [TestCase("{{{}}}", 3)]
        [TestCase("{{},{}}", 3)]
        [TestCase("{{{},{},{{}}}}", 6)]
        [TestCase("{<{},{},{{}}>}", 1)]
        [TestCase("{<a>,<a>,<a>,<a>}", 1)]
        [TestCase("{{<a>},{<a>},{<a>},{<a>}}", 5)]
        [TestCase("{{<!>},{<!>},{<!>},{<a>}}", 2)]
        public void Result_should_be_correct_number_of_groups(string input, int expectedCount)
        {
            var result = Subject.FindGroups(input);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.GetCount(), Is.EqualTo(expectedCount));
        }

        [TestCase("{}", 1)]
        [TestCase("{{{}}}", 6)]
        [TestCase("{{},{}}", 5)]
        [TestCase("{{{},{},{{}}}}", 16)]
        [TestCase("{<a>,<a>,<a>,<a>}", 1)]
        [TestCase("{{<ab>},{<ab>},{<ab>},{<ab>}}", 9)]
        [TestCase("{{<!!>},{<!!>},{<!!>},{<!!>}}", 9)]
        [TestCase("{{<a!>},{<a!>},{<a!>},{<ab>}}", 3)]
        public void Score_should_increase_by_group_nesting(string input, int expectedScore)
        {
            var result = Subject.FindGroups(input);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.GetScore(), Is.EqualTo(expectedScore));
        }
    }
}
