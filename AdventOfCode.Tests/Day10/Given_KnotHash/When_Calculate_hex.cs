using NUnit.Framework;

namespace AdventOfCode.Tests.Day10.Given_KnotHash
{
    [TestFixture]
    public class When_Calculate_hex : Arrange
    {
        [TestCase("")]
        [TestCase("AoC 2017")]
        [TestCase("1,2,3")]
        [TestCase("1,2,4")]
        public void Result_should_always_be_32_digits(string input) => Assert.That(Subject.Calculate(input), Has.Length.EqualTo(32));

        [TestCase("", "a2582a3a0e66e6e86e3812dcb672a272")]
        [TestCase("AoC 2017", "33efeb34ea91902bb2f59c9920caa6cd")]
        [TestCase("1,2,3", "3efbe78a8d82f29979031a4aa0b16a9d")]
        [TestCase("1,2,4", "63960835bcdc130f0b66d7ff4f6a5a8e")]
        public void Result_should_be_correct_hash(string input, string expected) => Assert.That(Subject.Calculate(input), Is.EqualTo(expected));
    }
}
