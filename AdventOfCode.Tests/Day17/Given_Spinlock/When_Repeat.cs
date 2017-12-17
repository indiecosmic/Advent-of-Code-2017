using AdventOfCode.Day17;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day17.Given_Spinlock
{
    [TestFixture]
    public class When_Repeat : TestBase<Spinlock>
    {
        [TestCase(9, 5)]
        [TestCase(2017, 638)]
        public void Should_evolve_like_example(int input, int expected) => Assert.That(Subject.Repeat(input, 3), Is.EqualTo(expected));
    }
}
