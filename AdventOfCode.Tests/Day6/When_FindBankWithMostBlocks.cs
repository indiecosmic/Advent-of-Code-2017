using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day6
{
    public class When_FindBankWithMostBlocks : Arrange
    {
        protected override int[] State => new[] {1, 2, 3, 4, 5};

        [Test]
        public void Should_return_index_with_largest_value()
        {
            var index = Subject.FindBankWithMostBlocks();
            Assert.AreEqual(4, index);
        }
    }
}
