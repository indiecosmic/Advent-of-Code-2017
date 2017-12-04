using AdventOfCode.Day1;
using AdventOfCodeTests;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day1
{
    [TestFixture]
    public abstract class Arrange
    {
        protected InverseCaptcha Subject { get; private set; }
        protected virtual IDigitFinder DigitFinder { get; }

        [SetUp]
        public void SetupBase()
        {
            Subject = new InverseCaptcha(DigitFinder);
        }
    }
}
