using AdventOfCode.Day10;

namespace AdventOfCode.Tests.Day10.Given_KnotHash
{
    public abstract class Arrange
    {
        protected KnotHash Subject => new KnotHash(new ListReverser());
    }
}
