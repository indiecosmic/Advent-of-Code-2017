using AdventOfCode.Day8;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day8.Given_JumpInstruction
{
    public abstract class Arrange
    {
        protected virtual string Instruction => "b inc 5 if a > 1";
        protected JumpInstruction Result;

        [SetUp]
        public void SetupBase()
        {
            Result = JumpInstruction.Parse(Instruction);
        }
    }
}
