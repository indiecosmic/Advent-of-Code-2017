using AdventOfCode.Day17;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day17.Given_CircularBuffer
{
    [TestFixture]
    public class When_StepForward
    {
        private CircularBuffer _subject;

        [TestCase(new[]{0}, 0, 3, 0)]
        [TestCase(new[]{0, 1}, 1, 3, 0)]
        [TestCase(new[]{0, 2, 1}, 1, 3, 1)]
        public void CurrentPosition_should_move_forward_and_wrap_around(int[] state, int currentPosition, int steps, int expectedResult)
        {
            _subject = new CircularBuffer(state, currentPosition);
            var result = _subject.StepForward(steps);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
