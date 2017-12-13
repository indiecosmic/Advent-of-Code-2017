using AdventOfCode.Day03;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day03
{
    public abstract class Arrange
    {
        protected ManhattanDistance Subject;
        protected abstract IMemoryWriter MemoryWriter { get; }

        [SetUp]
        public void SetupBase()
        {
            Subject = new ManhattanDistance(MemoryWriter);
        }
        
    }
}
