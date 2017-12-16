using System.Collections.Generic;
using AdventOfCode.Day03;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day03
{
    [TestFixture]
    public class When_GenerateSpiral_using_sum_of_adjacent_squares : Arrange
    {
        private Dictionary<(int, int), int> _result;
        protected override IMemoryWriter MemoryWriter => new SumAdjacent();

        [SetUp]
        public void Because_of()
        {
            _result = Subject.GenerateSpiral(5);
        }

        [Test]
        public void Spiral_should_not_be_null() => Assert.That(_result, Is.Not.Null);

        [Test]
        public void Spiral_length_should_be_size_to_the_power_of_2() => Assert.That(_result.Count, Is.EqualTo(25));

        [Test]
        public void Spiral_should_start_in_center() => Assert.That(_result[(0, 0)], Is.EqualTo(1));

        public static List<TestCaseData> SumAdjacentTestCases => new List<TestCaseData>
        {
            new TestCaseData((-2, 0), 330),
            new TestCaseData((-1, 0), 10),
            new TestCaseData((1,0), 1),
            new TestCaseData((2, 0), 54),
            new TestCaseData((-2, 1), 351),
            new TestCaseData((-1, 1), 11),
            new TestCaseData((0, 1), 23),
            new TestCaseData((1, 1), 25),
            new TestCaseData((2, 1), 26)
        };

        [TestCaseSource(nameof(SumAdjacentTestCases))]
        public void Spiral_should_sum_adjacent_squares((int, int) location, int expectedValue) => Assert.That(_result[location], Is.EqualTo(expectedValue));
    }
}
