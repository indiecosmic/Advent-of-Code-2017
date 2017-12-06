using AdventOfCode.Day4;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day4
{
    public abstract class Arrange
    {
        protected PassphraseValidator Validator { get; private set; }

        [SetUp]
        public void SetupBase()
        {
            Validator = new PassphraseValidator();
        }
    }
}
