using AdventOfCode.Day3;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day03
{
    public abstract class Arrange
    {
        protected ManhattanDistance Subject;

        [SetUp]
        public void SetupBase()
        {
            Subject = new ManhattanDistance();
        }
        
    }
}
