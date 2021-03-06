﻿using NUnit.Framework;

namespace AdventOfCode.Tests.Day06
{
    public class When_FindBankWithMostBlocks_and_two_values_are_same : Arrange
    {
        protected override int[] State => new[] {1, 2, 5, 4, 5};

        [Test]
        public void Should_return_first_index()
        {
            var actual = Subject.FindBankWithMostBlocks();
            Assert.AreEqual(2, actual);
        }
    }
}
