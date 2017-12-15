using AdventOfCode.Day15;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day15.Given_Judge
{
    [TestFixture]
    public class When_JudgePairs
    {
        private Generator _generatorA;
        private Generator _generatorB;

        [SetUp]
        public void Because_of()
        {
            _generatorA = new Generator(16807, 65);
            _generatorB = new Generator(48271, 8921);
        }
        [TestCase(5, 1)]
        [TestCase(40000000, 588)]
        public void Result_should_be_number_of_matching_pairs(int iterations, int expectedResult) =>
            Assert.That(Judge.JudgePairs(_generatorA, _generatorB, iterations), Is.EqualTo(expectedResult));
    }
}
