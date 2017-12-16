using AdventOfCode.Day01;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day01
{
    [TestFixture]
    public class When_calculate_using_halfway_around : Arrange
    {
        protected override IDigitFinder DigitFinder => new HalfwayAroundDigit();

        [TestCase("1212", 6)]
        [TestCase("1221", 0)]
        [TestCase("1234", 0)]
        [TestCase("123425", 4)]
        [TestCase("123123", 12)]
        [TestCase("12131415", 4)]
        public void Result_should_be_sum_of_matching_digits_halfway_around(string input, int expectedResult)
        {
            var result = Subject.Calculate(input);
            Assert.AreEqual(expectedResult, result);
        }
    }
}
