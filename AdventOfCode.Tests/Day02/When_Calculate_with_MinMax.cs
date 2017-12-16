using System.Collections.Generic;
using AdventOfCode.Day02;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day02
{
    [TestFixture]
    public class When_Calculate_with_MinMax : Arrange
    {
        protected override IRowValueCalculator RowValueCalculator => new MinMaxDiff();

        private static List<TestCaseData> TestCases
        {
            get
            {
                var testCases = new List<TestCaseData>();
                var input = @"5 1 9 5
                7 5 3
                2 4 6 8";
                testCases.Add(new TestCaseData(input).Returns(18));

                

                return testCases;
            }
        }

        [TestCaseSource(nameof(TestCases))]
        public int Result_should_be_difference_between_largest_and_smallest_number(string input)
        {
            var result = Subject.Calculate(input);
            return result;
        }
    }
}
