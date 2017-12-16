using AdventOfCode.Day09;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day09.Given_StreamProcessor
{
    [TestFixture]
    public class When_CountCharactersInsideGarbage
    {
        private StreamProcessor Subject => new StreamProcessor();

        [TestCase("<>", 0)]
        [TestCase("<random characters>", 17)]
        [TestCase("<<<<>", 3)]
        [TestCase("<{!>}>", 2)]
        [TestCase("<!!>", 0)]
        [TestCase("<!!!>>", 0)]
        [TestCase("<{o\"i!a,<{i<a>", 10)]
        public void Result_should_be_correct_number_of_characters(string input, int expectedCount)
        {
            var result = Subject.CountCharactersInsideGarbage(input);
            Assert.That(result, Is.EqualTo(expectedCount));
        }
    }
}
