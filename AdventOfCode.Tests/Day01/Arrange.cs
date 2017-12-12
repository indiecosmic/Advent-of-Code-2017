using AdventOfCode.Day1;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day01
{
    [TestFixture]
    public abstract class Arrange
    {
        protected InverseCaptcha Subject { get; private set; }
        protected abstract IDigitFinder DigitFinder { get; }

        [SetUp]
        public void SetupBase()
        {
            Subject = new InverseCaptcha(DigitFinder);
        }
    }
}
