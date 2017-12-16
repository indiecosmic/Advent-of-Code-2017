using AdventOfCode.Day08;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day08.Given_JumpInstruction
{
    public abstract class Arrange
    {
        private static string Instruction => "b inc 5 if a > 1";
        protected JumpInstruction Result;

        [SetUp]
        public void SetupBase()
        {
            Result = JumpInstruction.Parse(Instruction);
        }
    }
}
