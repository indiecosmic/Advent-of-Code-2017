using AdventOfCode.Day2;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day2
{
    public abstract class Arrange
    {
        protected abstract IRowValueCalculator RowValueCalculator { get; }
        protected ChecksumCalculator Subject;

        [SetUp]
        public void SetupBase()
        {
            Subject = new ChecksumCalculator(RowValueCalculator);
        }
    }
}
