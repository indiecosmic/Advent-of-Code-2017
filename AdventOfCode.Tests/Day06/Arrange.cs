using AdventOfCode.Day06;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day06
{
    public abstract class Arrange
    {
        protected MemoryBank Subject { get; private set; }
        protected abstract int[] State { get; }

        [SetUp]
        public void SetupBase()
        {
            Subject = new MemoryBank(State);
        }
    }
}
