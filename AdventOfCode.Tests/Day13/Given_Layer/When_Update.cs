using NUnit.Framework;

namespace AdventOfCode.Tests.Day13.Given_Layer
{
    [TestFixture]
    public class When_Update : Arrange
    {
        [SetUp]
        public void Because_of() => Subject.Update();

        [Test]
        public void Scanner_should_move_down() => Assert.That(Subject.ScannerPosition, Is.EqualTo(1));
    }
}
