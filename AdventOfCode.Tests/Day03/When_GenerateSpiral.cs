using System.Collections.Generic;
using AdventOfCode.Day03;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day03
{
    [TestFixture]
    public class When_GenerateSpiral : Arrange
    {
        protected override IMemoryWriter MemoryWriter => new SequenceWriter();
        private Dictionary<(int,int), int> _result;

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

        [Test]
        public void Spiral_should_end_in_bottom_right_corner() => Assert.That(_result[(2, 2)], Is.EqualTo(25));
    }
}
