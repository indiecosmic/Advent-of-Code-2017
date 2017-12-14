using NUnit.Framework;

namespace AdventOfCode.Tests.Day13.Given_Layer
{
    [TestFixture]
    public class When_Update_and_scanner_is_at_bottom : Arrange
    {
        protected override int ScannerPosition => 2;

        [SetUp]
        public void Because_of() => Subject.Update();

        [Test]
        public void Scanner_should_move_up() => Assert.That(Subject.ScannerPosition, Is.EqualTo(1));
    }
}
