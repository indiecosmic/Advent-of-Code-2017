using AdventOfCode.Day11;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day11.Given_CubeCoordinates
{
    [TestFixture]
    public class When_CalculateFurthestDistance
    {
        private static CubeCoordinates Subject => new CubeCoordinates();

        [TestCase("ne, ne, ne", 3)]
        [TestCase("ne, ne, sw, sw", 2)]
        [TestCase("ne, ne, s, s", 2)]
        [TestCase("se, sw, se, sw, sw", 3)]
        public void Result_should_be_least_steps_needed(string input, int expectedResult)
        {
            var result = Subject.CalculateFurthestDistance(input);
            Assert.AreEqual(expectedResult, result);
        }
    }
}
