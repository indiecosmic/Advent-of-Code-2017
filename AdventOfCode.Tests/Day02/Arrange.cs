using AdventOfCode.Day02;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day02
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
