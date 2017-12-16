using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Day14;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace AdventOfCode.Tests.Day14.Given_DiskDefragmenter
{
    [TestFixture]
    public class When_CreateGrid
    {
        private readonly DiskDefragmenter _subject = new DiskDefragmenter();
        private IEnumerable<byte[]> _result;

        [SetUp]
        public void Because_of() => _result = _subject.CreateGrid("flqrgnkx");

        [Test]
        public void Result_should_not_be_null() => Assert.That(_result, Is.Not.Null);

        [Test]
        public void Grid_should_be_128x128() => Assert.Multiple(() =>
        {
            Assert.That(_result.Count(), Is.EqualTo(128));
            Assert.That(_result.All(b => b.Length == 128), Is.True);
        });

        [Test]
        public void Start_of_grid_should_match_example() => Assert.Multiple(() =>
        {
            Assert.That(_result.First(), new ByteStartsWithConstraint(new byte[] { 1, 1, 0, 1, 0, 1, 0, 0 }));
        });

        [Test]
        public void Should_use_8108_squares() => Assert.That(_result.Sum(row => row.Sum(square => square)), Is.EqualTo(8108));

        private class ByteStartsWithConstraint : Constraint
        {
            private readonly byte[] _expected;

            public ByteStartsWithConstraint(byte[] expected) : base(expected)
            {
                _expected = expected;
            }

            public override ConstraintResult ApplyTo<TActual>(TActual actual)
            {
                if (actual == null)
                    throw new ArgumentNullException(nameof(actual));

                var actualAsBytes = actual as byte[];
                if (actual != null && actualAsBytes == null)
                    throw new ArgumentException($"Actual value must be a byte array but was {actual.GetType()}", nameof(actual));

                for (var i = 0; i < _expected.Length; i++)
                {
                    if (_expected[i] != actualAsBytes[i])
                    {
                        return new ConstraintResult(this, actual, false);
                    }
                }

                return new ConstraintResult(this, actual, true);
            }

        }
    }
}
