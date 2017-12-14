using System;
using AdventOfCode.Day12;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day12
{
    [TestFixture]
    public class When_Find_programs_in_group
    {
        private PipeSystem subject;
        private int[] result;

        [SetUp]
        public void Because_of()
        {
            var input = @"
            0 <-> 2
            1 <-> 1
            2 <-> 0, 3, 4
            3 <-> 2, 4
            4 <-> 2, 3, 6
            5 <-> 6
            6 <-> 4, 5";
            subject = PipeSystem.Parse(input);
            result = subject.FindProgramsInGroup(0);
        }

        [Test]
        public void Result_should_contain_own_program() => Assert.That(result, Has.One.EqualTo(0));

        [Test]
        public void Result_should_contain_directly_connected_programs() => Assert.That(result, Has.One.EqualTo(2));

        [Test]
        public void Result_should_contain_indirectly_connected_programs() => Assert.That(
            result,
            Has.One.EqualTo(3)
                .And.One.EqualTo(4)
                .And.One.EqualTo(5)
                .And.One.EqualTo(6)
        );

        [Test]
        public void Result_should_not_contain_unconnected_programs() => Assert.That(result, Has.None.EqualTo(1));
    }
}
