using AdventOfCode.Day11;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day11.Given_AxialCoordinates
{
    [TestFixture]
    public class When_Calculate
    {
        private static AxialCoordinates Subject => new AxialCoordinates();

        [TestCase("ne, ne, ne", 3)]
        [TestCase("ne, ne, sw, sw", 0)]
        [TestCase("ne, ne, s, s", 2)]
        [TestCase("se, sw, se, sw, sw", 3)]
        public void Result_should_be_least_steps_needed(string input, int expectedResult)
        {
            var result = Subject.CalculateFewestNumberOfSteps(input);
            Assert.AreEqual(expectedResult, result);
        }
    }
}
