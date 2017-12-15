using AdventOfCode.Day10;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day10.Given_ListReverser
{
    [TestFixture]
    public class When_Reverse
    {
        private ListReverser subject = new ListReverser();

        [TestCase(new[] { 0, 1, 2, 3, 4 }, 0, 3, new[] { 2, 1, 0, 3, 4 })]
        [TestCase(new[] { 2, 1, 0, 3, 4 }, 3, 4, new[] { 4, 3, 0, 1, 2 })]
        [TestCase(new[] { 4, 3, 0, 1, 2 }, 3, 1, new[] { 4, 3, 0, 1, 2 })]
        [TestCase(new[] { 4, 3, 0, 1, 2 }, 1, 5, new[] { 3, 4, 2, 1, 0 })]
        public void Should_reverse_sublist(int[] numbers, int position, int length, int[] expectedResult)
        {
            subject.Reverse(numbers, position, length);
            Assert.That(numbers, Is.EqualTo(expectedResult));
        }
    }
}
