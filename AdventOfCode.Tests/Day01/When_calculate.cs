using AdventOfCode.Day01;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day01
{
    [TestFixture]
    public class When_calculate : Arrange
    {
        protected override IDigitFinder DigitFinder => new NextDigit();

        [TestCase("1122", 3)]
        [TestCase("1111", 4)]
        [TestCase("1234", 0)]
        [TestCase("91212129", 9)]
        public void Result_should_be_sum_of_matching_digits_in_sequence(string input, int expectedResult)
        {
            var result = Subject.Calculate(input);
            Assert.AreEqual(expectedResult, result);
        }
    }
}
