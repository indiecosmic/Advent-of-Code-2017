using AdventOfCode.Day14;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day14.Given_RegionIdentifier
{
    [TestFixture]
    public class When_IdentifyRegions : TestBase<RegionIdentifier>
    {
        private readonly byte[][] _testData = {
            new byte[] {1, 1, 0, 1, 0, 1, 0, 0},
            new byte[] {0, 1, 0, 1, 0, 1, 0, 1},
            new byte[] {0, 0, 0, 0, 1, 0, 1, 0},
            new byte[] {1, 0, 1, 0, 1, 1, 0, 1},
            new byte[] {0, 1, 1, 0, 1, 0, 0, 0},
            new byte[] {1, 1, 0, 0, 1, 0, 0, 1},
            new byte[] {0, 1, 0, 0, 0, 1, 0, 0},
            new byte[] {1, 1, 0, 1, 0, 1, 1, 0}
        };

        private readonly int[,] _expectedResult = {
            { 1, 1, 0, 2, 0, 3, 0, 0 },
            { 0, 1, 0, 2, 0, 3, 0, 4 },
            { 0, 0, 0, 0, 5, 0, 6, 0 },
            { 7, 0, 8, 0, 5, 5, 0, 9 },
            { 0, 8, 8, 0, 5, 0, 0, 0 },
            { 8, 8, 0, 0, 5, 0, 0, 10 },
            { 0, 8, 0, 0, 0, 11, 0, 0 },
            { 8, 8, 0, 12, 0, 11, 11, 0 }
        };

        private int[,] _result;

        [SetUp]
        public void Because_of() => _result = RegionIdentifier.IdentifyRegions(_testData);

        [Test]
        public void Result_should_be_same_size_as_grid() => Assert.That(_result.Length, Is.EqualTo(_testData.Length * _testData.Length));

        [Test]
        public void Result_should_be_same_as_expected() => Assert.That(_result, Is.EqualTo(_expectedResult));
    }
}
