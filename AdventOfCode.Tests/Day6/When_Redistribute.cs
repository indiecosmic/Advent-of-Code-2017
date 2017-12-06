using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day6
{
    public class When_Redistribute : Arrange
    {
        protected override int[] State => new[] {0, 2, 7, 0};

        [Test]
        public void Result_should_be_2_4_1_2()
        {
            var expected = new[] {2, 4, 1, 2};
            var actual = Subject.Redistribute();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Result_should_be_copy_of_state()
        {
            var actual = Subject.Redistribute();
            Assert.AreNotSame(State, actual);
        }
    }
}
