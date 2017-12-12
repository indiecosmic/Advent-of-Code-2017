using AdventOfCode.Day04;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day04
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
