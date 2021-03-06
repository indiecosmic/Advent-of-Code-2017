﻿using System.Collections.Generic;
using AdventOfCode.Day02;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day02
{
    public class When_Calculate_with_EvenDivisible : Arrange
    {
        protected override IRowValueCalculator RowValueCalculator => new EvenDivisible();

        private static IEnumerable<TestCaseData> TestCase => new[]{ new TestCaseData("5 9 2 8\n9 4 7 3\n3 8 6 5").Returns(9) };

        [TestCaseSource(nameof(TestCase))]
        public int Result_should_be_even_divisible_each_row(string input)
        {
            var result = Subject.Calculate(input);
            return result;
        }
    }
}
