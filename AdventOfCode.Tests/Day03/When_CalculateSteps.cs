﻿using AdventOfCode.Day03;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day03
{
    public class When_CalculateSteps : Arrange
    {
        [TestCase(1, ExpectedResult = 0)]
        [TestCase(10, ExpectedResult = 3)]
        [TestCase(12, ExpectedResult = 3)]
        [TestCase(23, ExpectedResult = 2)]
        [TestCase(1024, ExpectedResult = 31)]
        public int Distance_should_be_shortest_path(int fromSquare)
        {
            return Subject.CalculateSteps(fromSquare);
        }

        protected override IMemoryWriter MemoryWriter => new SequenceWriter();
    }
}
