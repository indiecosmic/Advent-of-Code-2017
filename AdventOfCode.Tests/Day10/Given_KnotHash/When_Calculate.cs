using NUnit.Framework;

namespace AdventOfCode.Tests.Day10.Given_KnotHash
{
    [TestFixture]
    public class When_Calculate : Arrange
    {
        private int _result;

        [SetUp]
        public void Because_of() => _result = Subject.Calculate(new[] { 0, 1, 2, 3, 4 }, new[] { 3, 4, 1, 5 });

        [Test]
        public void Result_should_be_product_of_first_two_numbers_after_reversing() => Assert.That(_result, Is.EqualTo(12));
    }
}
